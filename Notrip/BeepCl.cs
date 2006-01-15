// Copyright (C) 2003 Robert Hinrichs. All rights reserved
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
using System;
using System.Windows.Forms;
using System.Collections;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace LothianProductions.Notrip
{
	/// <summary>
	/// Summary description for Beep.
	/// Parameters

	/// </summary>
	public class BeepCl : System.Windows.Forms.UserControl
	{
		private SecondaryBuffer buffa = null;
		private int NextWriteOffset = 0;
		private int OutputBufferSize = 0;
		private bool Playing = false;
		private bool FillZero = false;
		/////////////////////////////////////////
		private System.Windows.Forms.Control MyParent;
		private const int NumberRecordNotifications = 4;
		private Device dsDevice = null;
		private WaveFormat BuffFormat;
		private int NotifySize = 0;
		/////////////////////////////////////////

		//generate sq. or sine wave
		private bool squarewave;
		public bool SquareWave {
			get { return squarewave; }
			set { squarewave = value; }
		}

		private struct Osc
		{
			public double dphi; // frequency
			public double phase; // phase accumulator
			public System.Int32 duration; // duration in msec.
		} Osc osc;

		private int TimePlaying = 0;
		private const int BuffSz = 320 * 2;//*220 msec.
		private const double TwoMathPI = 2.0 * Math.PI;

		byte[] PlaybackData = new System.Byte[BuffSz];

		// constructor
		public BeepCl() {
			MyParent = this;
			CreatePlayBuffer();

			NextWriteOffset = 0;

			for (int i = 0; i < PlaybackData.Length; i++)
				PlaybackData[i] = 0; // hi/low byte = 0

			osc = new Osc();
			osc.phase = 0;
			osc.duration = 2000;
			SquareWave = false;
			SetVolume(-1500);

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
			SetFrequency(400);
		}

		// play with set values
		public void Beep() {
			Playing = true;
			StartOrStopPlay(Playing);
			while (Playing)
				;
			StartOrStopPlay(Playing);
		}
		//dwFreq 
		//[in] Frequency of the soundf, in hertz. This parameter must be in the
		//     range 37 through 32,767 (0x25 through 0x7FFF). 
		//dwDuration 
		//[in] Duration of the soundf, in milliseconds. 
		public void Beep(double freq, System.Int32 dur) {
			SetFrequency(freq);
			SetDuration(dur);
			Playing = true;
			StartOrStopPlay(Playing);
			while (Playing)
				;
			StartOrStopPlay(Playing);
		}

		void StartOrStopPlay(bool StartPlay) {

			if (StartPlay) {
				NextWriteOffset = 0;
				TimePlaying = 0;//duration
				FillZero = false;
				buffa.Play(0, BufferPlayFlags.Looping);
				TransferData();
			} else {
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
		void SetVolume(System.Int32 vol) {
			try {
				buffa.Volume = vol;
			} catch {
				MessageBox.Show(null, "Error: volume out of range",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		void SetDuration(System.Int32 dur) {
			if (dur >= 20)
				osc.duration = dur;
			else
				MessageBox.Show(null, "Error: duration out of range",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

		}
		void SetFrequency(double freq) {
			if ((freq > 36) && (freq < 4000)) {
				osc.dphi = freq * 1.25e-4;
			} else
				MessageBox.Show(null, "Error: frequency out of range",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		void SetFrequency(System.Int32 freq) {
			if ((freq > 36) && (freq < 4000)) {
				osc.dphi = freq * 1.25e-4;
			} else
				MessageBox.Show(null, "Error: frequency out of range",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		void TransferData() {
			//----------------------------------------------------------
			// Name: TransferData()
			// Desc: 
			//----------------------------------------------------------
			int LockSize;
			int PlayPos;

			while (Playing) {
				// poll
				PlayPos = buffa.PlayPosition;
				//from the sdk example
				LockSize = PlayPos - NextWriteOffset;
				if (LockSize < 0)
					LockSize += OutputBufferSize;

				// Block align lock size--always write on a boundary
				LockSize -= (LockSize % BuffSz);
				if (LockSize == 0) {
				} else {
					GenerateTone();
					// Write the buffer
					buffa.Write(NextWriteOffset,
								PlaybackData, LockFlag.None);

					// Move the capture offset along
					NextWriteOffset += PlaybackData.Length;
					NextWriteOffset %= OutputBufferSize; // Circular buffer
					TimePlaying += 20;//20msec per buffer
					if (TimePlaying >= osc.duration)
						Playing = false;
				}
			}
		}


		// writes 320 bytes, 160 words of a sine/sq wave
		// to PlaybackData[]
		private void GenerateTone() {
			System.Int32 outword;

			for (int k = 0; k < PlaybackData.Length; )// in bytes
			{
				if (!SquareWave)
					outword = (System.Int32)(Math.Sin(osc.phase) * (32767));
				else {
					if (Math.Sin(osc.phase) >= 0.1)
						outword = 0x7fff;
					else
						outword = 0x8000;
				}

				osc.phase += TwoMathPI * osc.dphi;
				if (osc.phase > TwoMathPI)
					osc.phase -= TwoMathPI;

				if (FillZero == true) {
					outword = 0;
				}
				//stereo 16-bit pcm format
				PlaybackData[k++] = (System.Byte)(outword & 0xff);//lsb
				PlaybackData[k++] = (System.Byte)((outword >> 8) & 0xff);//msb
				PlaybackData[k++] = (System.Byte)(outword & 0xff);//lsb
				PlaybackData[k++] = (System.Byte)((outword >> 8) & 0xff);//msb
			}
		}
		/////////////////////////////////////////////////////
		void CreatePlayBuffer() {
			BufferDescription buffds = new BufferDescription();
			if (buffa != null) {
				buffa.Stop();
				buffa.Dispose();
				buffa = null;
			}
			NotifySize = 160 * 2 * 2; // 10 msec.
			OutputBufferSize = NotifySize * NumberRecordNotifications;

			buffds.BufferBytes = OutputBufferSize; // in bytes
			BuffFormat.BlockAlign = 2 * 2;
			BuffFormat.AverageBytesPerSecond = 16000 * 2;
			BuffFormat.FormatTag = WaveFormatTag.Pcm;
			BuffFormat.Channels = 1 * 2; // stereo
			BuffFormat.BitsPerSample = 16;
			BuffFormat.SamplesPerSecond = 8000;

			buffds.Format = BuffFormat;

			buffds.ControlVolume = true;
			buffds.CanGetCurrentPosition = true;

			/********************************************************************/
			try {
				dsDevice = new Device();
			} catch (DirectXException) {
				MessageBox.Show(null, "Error creating sound device",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			dsDevice.SetCooperativeLevel(
				MyParent, CooperativeLevel.Priority);

			/********************************************************************/

			buffa = new SecondaryBuffer(buffds, dsDevice);

			// Test
			//buffa = new SecondaryBuffer(@"D:\WINNT\Media\tada.wav", dsDevice);
			//buffa.Play(0f,BufferPlayFlags.Default);

			buffa.Volume = -1500;

			if (buffa == null)
				throw new NullReferenceException();
		}
		//////////////////////////////////////////////////////////////////////
	}
}
