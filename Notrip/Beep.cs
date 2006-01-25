using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace LothianProductions.Notrip {
    public class Beep {
        const double TwoMathPI = 2.0 * Math.PI;
        const int NumberRecordNotifications = 4;
		
        private SecondaryBuffer buffa = null;
        private int NextWriteOffset = 0;
        private int OutputBufferSize = 0;
        private int TimePlaying = 0;
        private byte[] PlaybackData;
        protected Object mLockObject = new Object();
		
        protected Control mControl;	
        protected bool mPlaying;
        public bool Playing {
            get{ return mPlaying; }
        }

        private struct Osc {
            public double dphi; // frequency
            public double phase; // phase accumulator
            public int duration; // duration in msec.
        } Osc osc = new Osc();

        public Beep( Control control ) {
            mControl = control;

            if( buffa != null ) {
                buffa.Stop();
                buffa.Dispose();
                buffa = null;
            }
					
            WaveFormat format = new WaveFormat();
            format.FormatTag = WaveFormatTag.Pcm;
            format.Channels = 2;
            format.BitsPerSample = 16;
            format.SamplesPerSecond = AudioMonitor.SAMPLE_RATE;
            format.BlockAlign = 2*2;//(short) (format.Channels * (format.BitsPerSample / AudioMonitor.BITS_PER_BYTE ));
            format.AverageBytesPerSecond = 16000*2;//format.BlockAlign * format.SamplesPerSecond;

            //OutputBufferSize = NumberRecordNotifications * ((AudioMonitor.SAMPLE_RATE/100) *  (format.BitsPerSample / AudioMonitor.BITS_PER_BYTE) * format.Channels); // *(10msec)
            OutputBufferSize = NumberRecordNotifications * (160 * 2 * 2);
            //const int BuffSz = 320 * 2; //*220 msec.
            //const int BuffSz = AudioMonitor.SAMPLE_RATE / 25;
            //PlaybackData = new Byte[AudioMonitor.SAMPLE_RATE / 25];
            PlaybackData = new Byte[320 * 2]; //*220msc

            BufferDescription bufferDescription = new BufferDescription();
            bufferDescription.Format = format;
            bufferDescription.ControlVolume = true;
            bufferDescription.CanGetCurrentPosition = true;
            bufferDescription.BufferBytes = OutputBufferSize; // in bytes

            Device dsDevice = new Device();
            dsDevice.SetCooperativeLevel( mControl, CooperativeLevel.Priority );

            buffa = new SecondaryBuffer( bufferDescription, dsDevice );
            buffa.Volume = -1500;

            NextWriteOffset = 0;
            osc.phase = 0;
            osc.duration = 2000;

            Frequency = AudioMonitor.ROOT_A4_FREQ;
        }

        ////dwFreq 
        //[in] Frequency of the soundf, in hertz. This parameter must be in the
        //     range 37 through 32,767 (0x25 through 0x7FFF). 
        //dwDuration 
        //[in] Duration of the soundf, in milliseconds. 
        public void Start() {
            NextWriteOffset = 0;
            TimePlaying = 0;//duration
            buffa.Play(0, BufferPlayFlags.Looping);

            int LockSize;
            lock( mLockObject ) {
                mPlaying = true;
                while( mPlaying ) {
                    // poll
                    LockSize = buffa.PlayPosition - NextWriteOffset;
                    if (LockSize < 0)
                        LockSize += OutputBufferSize;

                    // Block align lock size--always write on a boundary
                    LockSize -= (LockSize % PlaybackData.Length);
                    if (LockSize != 0) {
						int outword;
						
						 //writes 320 bytes, 160 words of a sine/sq wave
						 //to PlaybackData[]
						for( int k = 0; k < PlaybackData.Length; ) { // in bytes
							outword = (int) ( Math.Sin(osc.phase) * 32767 );

							osc.phase += TwoMathPI * osc.dphi;
							if( osc.phase > TwoMathPI )
								osc.phase -= TwoMathPI;

							//stereo 16-bit pcm format
							PlaybackData[k++] = (byte)(outword & 0xff);//lsb
							PlaybackData[k++] = (byte)((outword >> 8) & 0xff);//msb
							PlaybackData[k++] = (byte)(outword & 0xff);//lsb
							PlaybackData[k++] = (byte)((outword >> 8) & 0xff);//msb
						}
                        // Write the buffer
                        buffa.Write(NextWriteOffset, PlaybackData, LockFlag.None);

                        // Move the capture offset along
                        NextWriteOffset += PlaybackData.Length;
                        NextWriteOffset %= OutputBufferSize; // Circular buffer
                        TimePlaying += 20;//20msec per buffer
						
                        if( osc.duration > 0 && TimePlaying >= osc.duration )
                            mPlaying = false;
                    }
                }
            }
            Stop();
        }

        public void Stop() {
            mPlaying = false;
            
            lock( mLockObject ) {
                buffa.Stop();
            }
        }
		
        public int Volume {
            get{ return buffa.Volume; }
            set{ buffa.Volume = value; }
        }
		
        public int Duration {
            get{ return osc.duration; }
            set{ osc.duration = value; }
        }

        public double Frequency {
            get{ return osc.dphi * (double) AudioMonitor.SAMPLE_RATE; }
            set{ osc.dphi = value / (double) AudioMonitor.SAMPLE_RATE; }
        }
	}
}

