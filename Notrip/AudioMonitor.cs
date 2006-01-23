using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using Microsoft.DirectX.DirectSound;

namespace LothianProductions.Notrip {
	public delegate void AudioDataHandler( byte[] samples, Dictionary<double, int> frequencies );

	public class AudioMonitor {

		public const int SAMPLE_RATE = 16000;
		protected static readonly AudioMonitor mInstance = new AudioMonitor();
		protected const int NO_RECORD_NOTIFICATIONS = 16;
		protected const int BITS_PER_BYTE = 8;

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
			mCaptureBuffer = new CaptureBuffer( bufferDescription, new Capture( new CaptureDevicesCollection()[0].DriverGuid ) );           
			mRunning = true;

			// Create a thread to monitor the notify events
			new Thread( new ThreadStart( Process ) ).Start();

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
			Dictionary<double, int> frequencies = new Dictionary<double, int>();
			
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

				// Spectral analysis:
				float twoT = ((float) captureData.Length / (float) AudioMonitor.SAMPLE_RATE) * 2f;
				
				frequencies = new Dictionary<double,int>();
				double firstSummation, secondSummation;
				double twoPInjk = Math.PI / captureData.Length * 4d;

				for( int j = 0; j < captureData.Length / 4; j++ ) {
					firstSummation = 0; secondSummation = 0;
					//double twoPInjk = Math.PI / captureData.Length * j * 4d;
					double next = twoPInjk * j;

					for( int k = 0; k < captureData.Length / 2; k++ ) {
						double byK = next * k;
						firstSummation +=  captureData[k] * Math.Cos(byK);
						secondSummation += captureData[k] * Math.Sin(byK);
					}
					
					double amp = Math.Abs( Math.Sqrt(Math.Pow(firstSummation,2) + Math.Pow(secondSummation,2)) );// / (double) captureData.Length;

					if( j > 0 && amp > (5d / 4d) * (double) captureData.Length )
						frequencies.Add( j / twoT, (int) ((amp/(double) captureData.Length) * 4d));
				} 

				AudioDataUpdate( captureData, frequencies );
			} while( mRunning );
		}
	}
	
	//protected Dictionary<int, int> listses;
	
}
