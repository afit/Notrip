// Copyright (C) 2003 Robert Hinrichs. All rights reserved
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace LothianProductions.Notrip {
	public class Beep {
		const int BuffSz = 320 * 2; //*220 msec.
		const double TwoMathPI = 2.0 * Math.PI;
		const int NumberRecordNotifications = 4;
		
		private SecondaryBuffer buffa = null;
		private int NextWriteOffset = 0;
		private int OutputBufferSize = 0;
		private bool FillZero = false;
		private int TimePlaying = 0;
		private byte[] PlaybackData = new Byte[BuffSz];
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
			//CreatePlayBuffer();

				if( buffa != null ) {
					buffa.Stop();
					buffa.Dispose();
					buffa = null;
				}
				
				OutputBufferSize = NumberRecordNotifications * (160 * 2 * 2); // *(10msec)
				
				WaveFormat BuffFormat = new WaveFormat();
				BuffFormat.BlockAlign = 2 * 2;
				BuffFormat.AverageBytesPerSecond = 16000 * 2;
				BuffFormat.FormatTag = WaveFormatTag.Pcm;
				BuffFormat.Channels = 1 * 2; // stereo
				BuffFormat.BitsPerSample = 16;
				BuffFormat.SamplesPerSecond = 8000;

				BufferDescription buffds = new BufferDescription();
				buffds.Format = BuffFormat;
				buffds.ControlVolume = true;
				buffds.CanGetCurrentPosition = true;
				buffds.BufferBytes = OutputBufferSize; // in bytes

				Device dsDevice = new Device();
				dsDevice.SetCooperativeLevel( mControl, CooperativeLevel.Priority );

				buffa = new SecondaryBuffer( buffds, dsDevice );
				buffa.Volume = -1500;


			NextWriteOffset = 0;

			for( int i = 0; i < PlaybackData.Length; i++ )
				PlaybackData[i] = 0; // hi/low byte = 0

			osc.phase = 0;
			osc.duration = 2000;

			FillZero = true;
			GenerateTone();
			buffa.SetCurrentPosition(BuffSz);
			buffa.Write(0, PlaybackData, LockFlag.None);

			GenerateTone();
			buffa.SetCurrentPosition(BuffSz * 2);
			buffa.Write(BuffSz, PlaybackData, LockFlag.None);

			GenerateTone();
			buffa.SetCurrentPosition(BuffSz * 3);
			buffa.Write(BuffSz * 2, PlaybackData, LockFlag.None);

			GenerateTone();
			buffa.SetCurrentPosition(0);
			buffa.Write(BuffSz * 3, PlaybackData, LockFlag.None);

			FillZero = false;
			NextWriteOffset = 0;
			Frequency = 400;
		}

		////dwFreq 
		//[in] Frequency of the soundf, in hertz. This parameter must be in the
		//     range 37 through 32,767 (0x25 through 0x7FFF). 
		//dwDuration 
		//[in] Duration of the soundf, in milliseconds. 
		public void Start() {
			NextWriteOffset = 0;
			TimePlaying = 0;//duration
			FillZero = false;
			buffa.Play(0, BufferPlayFlags.Looping);
//				TransferData();

				int LockSize;
lock( mLockObject ) {
mPlaying = true;
				while (mPlaying) {
					// poll
					//from the sdk example
					LockSize = buffa.PlayPosition - NextWriteOffset;
					if (LockSize < 0)
						LockSize += OutputBufferSize;

					// Block align lock size--always write on a boundary
					LockSize -= (LockSize % BuffSz);
					if (LockSize != 0) {
						GenerateTone();
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

			FillZero = true;//output zeros
			GenerateTone();
			buffa.SetCurrentPosition(BuffSz);
			buffa.Write(0, PlaybackData, LockFlag.None);

			GenerateTone();
			buffa.SetCurrentPosition(0);
			buffa.Write(BuffSz, PlaybackData, LockFlag.None);

			GenerateTone();
			buffa.Write(BuffSz * 2, PlaybackData, LockFlag.None);

			GenerateTone();
			buffa.Write(BuffSz * 3, PlaybackData, LockFlag.None);

			buffa.Play(0, BufferPlayFlags.Default);

			FillZero = false;//output zeros
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
			get{ return osc.dphi / 1.25e-4; }
			set{ osc.dphi = value * 1.25e-4; }
		}
		
		// writes 320 bytes, 160 words of a sine/sq wave
		// to PlaybackData[]
		private void GenerateTone() {
			int outword;

			for( int k = 0; k < PlaybackData.Length; ) { // in bytes
				outword = (int) ( Math.Sin(osc.phase) * 32767 );

				osc.phase += TwoMathPI * osc.dphi;
				if( osc.phase > TwoMathPI )
					osc.phase -= TwoMathPI;

				if( FillZero == true )
					outword = 0;

				//stereo 16-bit pcm format
				PlaybackData[k++] = (byte)(outword & 0xff);//lsb
				PlaybackData[k++] = (byte)((outword >> 8) & 0xff);//msb
				PlaybackData[k++] = (byte)(outword & 0xff);//lsb
				PlaybackData[k++] = (byte)((outword >> 8) & 0xff);//msb
			}
		}
	}
}
