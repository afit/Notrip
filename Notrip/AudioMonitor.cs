using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Microsoft.DirectX.DirectSound;

namespace LothianProductions.Notrip {
	public delegate void AudioDataHandler( byte[] samples, List<Sound> sounds );

	public class AudioMonitor {

		public const int SAMPLE_RATE = 44000;
		public const int ROOT_A4_FREQ = 440;
		protected const int NO_RECORD_NOTIFICATIONS = 16;
		public const short BITS_PER_BYTE = 8;
		
		protected Dictionary<double, Beep> mBeeps = new Dictionary<double, Beep>();
		protected static readonly AudioMonitor mInstance = new AudioMonitor();

		public static AudioMonitor Instance() {
			return mInstance;
		}

		// Protect default constructor.
		protected AudioMonitor() {}	
		
		public event AudioDataHandler AudioDataUpdate;
		
		public AutoResetEvent notificationEvent	= null;
		public int notifySize = 0;
		
		protected int mCaptureBufferSize;
		protected CaptureBuffer mCaptureBuffer;
		
		protected List<double> mFrequencies = new List<double>();
		public List<double> Frequencies {
			get{ return mFrequencies; }
			set{ mFrequencies = value; }
		}

		protected int mSensitivity = 5;
		public int Sensitivity {
			get{ return mSensitivity; }
			set{ mSensitivity = value; }
		}
		
		protected bool mRunning = false;
		public bool IsRunning {
			get{ return mRunning; }
		}

		public void Start() {
			// Create a capture buffer, and tell the capture 
			// buffer to start recording   
			WaveFormat format = new WaveFormat();
			format.FormatTag = WaveFormatTag.Pcm;
			format.SamplesPerSecond = SAMPLE_RATE;
			format.BitsPerSample = 8;
			format.Channels = 1;
			format.BlockAlign = (short) (format.Channels * (format.BitsPerSample / BITS_PER_BYTE));
			format.AverageBytesPerSecond = format.BlockAlign * format.SamplesPerSecond;

			// Set the notification size
			notifySize = (1024 > format.AverageBytesPerSecond / BITS_PER_BYTE) ? 1024 : (format.AverageBytesPerSecond / BITS_PER_BYTE);
			notifySize -= notifySize % format.BlockAlign;   

			CaptureBufferDescription bufferDescription = new CaptureBufferDescription();
			// Set the buffer sizes
			mCaptureBufferSize = notifySize * NO_RECORD_NOTIFICATIONS;
			bufferDescription.BufferBytes = mCaptureBufferSize;
			bufferDescription.Format = format;
			
			// Try to create a recording buffer using the default device to see if the format is valid.
			Guid defaultDeviceGuid = new CaptureDevicesCollection()[0].DriverGuid;
			Capture capture = new Capture( defaultDeviceGuid );
			
			try {
				mCaptureBuffer = new CaptureBuffer( bufferDescription, capture );
			} catch(ApplicationException e) {
				throw new ApplicationException( "Couldn't get access to recording device", e );
			}
			
			mRunning = true;

			// Setup the notification positions
			BufferPositionNotify[] positionNotify = new BufferPositionNotify[ NO_RECORD_NOTIFICATIONS + 1 ];  

			// Create a notification event, for when the sound stops playing
			notificationEvent = new AutoResetEvent( false );
			
			for( int i = 0; i < NO_RECORD_NOTIFICATIONS; i++ ) {
				positionNotify[i].Offset = (notifySize * i) + notifySize - 1;
				positionNotify[i].EventNotifyHandle = notificationEvent.Handle;
			}
			
			// Tell DirectSound when to notify the app. The notification will come in the from 
			// of signaled events that are handled in the notify thread.
			new Notify( mCaptureBuffer ).SetNotificationPositions( positionNotify, NO_RECORD_NOTIFICATIONS );		

			// Create a thread to monitor the notify events
			new Thread( new ThreadStart( Process ) ).Start();
			
			mCaptureBuffer.Start( true );
		}
		
		public void Stop() {
			mRunning = false;
			
			// Stop the buffer
			mCaptureBuffer.Stop();
			
			// Trigger event again...
			notificationEvent.Set();
		}

		protected void Process() {
			int nextCaptureOffset = 0;
			int readPos = 0;
			int capturePos = 0;
			int lockSize;
			
			do {
				// Wait for a notification:
				notificationEvent.WaitOne( Timeout.Infinite, true );
				
				mCaptureBuffer.GetCurrentPosition( out capturePos, out readPos );
				
				lockSize = readPos - nextCaptureOffset;
				if( lockSize < 0 )
					lockSize += mCaptureBufferSize;

				// Block align lock size so that we are always write on a boundary
				lockSize -= (lockSize % notifySize);

				if( lockSize == 0 )
					continue;

				// Read the capture buffer.
				byte[] captureData = (byte[]) mCaptureBuffer.Read( nextCaptureOffset, typeof(byte), LockFlag.None, lockSize );
				
				// Move the capture offset along
				nextCaptureOffset += captureData.Length; 
				nextCaptureOffset %= mCaptureBufferSize; // Circular buffer

				AudioDataUpdate( captureData, SamplesToSounds( captureData, mFrequencies ) );
			} while( mRunning );
		}
		
		public List<Sound> SamplesToSounds( byte[] samples, List<double> frequencies ) {
		    // Spectral analysis:
		    float twoT = ((float) samples.Length / (float) AudioMonitor.SAMPLE_RATE) * 2f;
			
		    Dictionary<int, Sound> sounds = new Dictionary<int, Sound>();
		    double firstSummation, secondSummation;
		    double twoPInjk = Math.PI / samples.Length * 4d;

		    foreach( double frequency in frequencies ) {
		        firstSummation = 0; secondSummation = 0;
		        // Fix the frequency: int = double oldJ = ((frequency / 4d) * twoT);// / twoPInjk;
		        double next = ((frequency / 4d) * twoT) * twoPInjk;

		        for( int k = 0; k < samples.Length / 2; k++ ) {
		            double byK = next * k;
		            firstSummation +=  samples[k] * Math.Cos(byK);
		            secondSummation += samples[k] * Math.Sin(byK);
		        }
				
		        double amp = Math.Abs( Math.Sqrt(Math.Pow(firstSummation, 2) + Math.Pow(secondSummation, 2)) );
		        int amplitude = (int) ((amp / (double) samples.Length) * 4d);
		        //Console.WriteLine( "Amplitude: " + amplitude + ", Frequency: " + frequency );
				
		        if( amplitude > mSensitivity ) {
		            double compensation;
		            int octave;
		            int step = FrequencyToStep( frequency, out compensation );
		            Note note = StepToNote( step, out octave );
					//Console.WriteLine( "Amplitude: " + amplitude + ", Frequency: " + frequency + ", Step: " + step + ", Compensation: " + compensation + ", Note: " + note + octave );
		            Sound sound = new Sound( note, octave, step, amplitude, compensation );
					
		            if( sounds.ContainsKey( step ) )
		                sounds[ step ].Amplitude += amplitude;
		            else
		                sounds.Add( step, sound );
		        }
		    }
			
		    return new List<Sound>( sounds.Values );
		}
		
		public List<Sound> SamplesToSounds( byte[] samples ) {
		    // Spectral analysis:
		    float twoT = ((float) samples.Length / (float) AudioMonitor.SAMPLE_RATE) * 2f;
			
		    Dictionary<int, Sound> sounds = new Dictionary<int, Sound>();
		    double firstSummation, secondSummation;
		    double twoPInjk = Math.PI / samples.Length * 4d;

		    for( int j = 0; j < samples.Length / 4; j++ ) {
		        firstSummation = 0; secondSummation = 0;
		        double next = twoPInjk * j;

		        for( int k = 0; k < samples.Length / 2; k++ ) {
		            double byK = next * k;
		            firstSummation +=  samples[k] * Math.Cos(byK);
		            secondSummation += samples[k] * Math.Sin(byK);
		        }
				
		        double amp = Math.Abs( Math.Sqrt(Math.Pow(firstSummation, 2) + Math.Pow(secondSummation, 2)) );
		        int amplitude = (int) ((amp / (double) samples.Length) * 4d);

		        if( j > 0 && amplitude > 5 ) {
		            double compensation;
		            double frequency = (j / twoT) * 4d;
		            int octave;
		            int step = FrequencyToStep( frequency, out compensation );
		            Note note = StepToNote( step, out octave );
		            //Console.WriteLine( "Amplitude: " + amplitude + ", Frequency: " + frequency + ", Step: " + step + ", Compensation: " + compensation + ", Note: " + note + octave );
		            Sound sound = new Sound( note, octave, step, amplitude, compensation );
					
		            if( sounds.ContainsKey( step ) )
		                sounds[ step ].Amplitude += amplitude;
		            else
		                sounds.Add( step, sound );
		        }
		    }
			
		    return new List<Sound>( sounds.Values );
		}

		public static int FrequencyToStep( double frequency, out double compensation ) {
			double step = (Math.Log( frequency / AudioMonitor.ROOT_A4_FREQ, 2 ) * 12d);// * 12d;
			//if( frequency == 440 || frequency == 1760 )
				//Console.WriteLine( frequency + ":" + frequency / AudioMonitor.ROOT_A4_FREQ + ":" + Math.Log( frequency / AudioMonitor.ROOT_A4_FREQ, 2 ) + ":" + (Math.Log( frequency / AudioMonitor.ROOT_A4_FREQ, 2 ) * 12d) + ":" + step );
			
			compensation = step - (int) step;
						
			if( compensation < -0.5d ) {
				compensation += 1d;
			    return ((int) step) - 1;
			} else 
			    return (int) step;
		}
		
		public static double StepToFrequency( int step ) {
			return ROOT_A4_FREQ * Math.Pow(2, step / 12d);
		}

		public static Tuning StepToTuning( int step ) {
			int octave = 1;
			// Whilst greater than the end of the first octave, count one:
			while( step > -25 ) {
				step -= 12;
				octave++;
			}
			
			return new Tuning( NoteHelper.Instance().GetOrderedNotes()[step + 36], octave );
		}
	
		[Obsolete("Should be StepToTuning")]
		public static Note StepToNote( int step, out int octave ) {
			octave = 1;
			// Whilst greater than the end of the first octave, count one:
			while( step > -25 ) {
				step -= 12;
				octave++;
			}
			
			return NoteHelper.Instance().GetOrderedNotes()[step + 36];
		}
		
		public static int TuningToStep( Tuning tuning ) {
			return -36 + ((tuning.Octave - 1) * 12) + NoteHelper.Instance().GetOrderedNotes().IndexOf( tuning.Note );
		}
		
		public void PlayNote( double frequency, int duration, Control control ) {
			// Create a new beep object and fire it off on a separate thread.
			lock( mBeeps ) {
				Beep beep;
				if( mBeeps.ContainsKey( frequency ) )
					beep = mBeeps[ frequency ];
				else {
					beep = new Beep( control );
					mBeeps.Add( frequency, beep );
					beep.Frequency = frequency;
				}
				
				// Turn off permanent tones:
				if( beep.Playing && beep.Duration > 0 && beep.Duration == duration )
					return;
				else if( beep.Playing ) {
				    beep.Stop();
					if( beep.Duration == 0 )
					    return;
				}
				
				beep.Duration = duration;
				new Thread( new ThreadStart( beep.Start ) ).Start();
			}
		}
	}
}