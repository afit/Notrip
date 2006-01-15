//
//  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
//  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
//  REMAINS UNCHANGED.
//
//  Email:  gustavo_franco@hotmail.com
//
//  Copyright (C) 2005 Franco, Gustavo 
//
using System;

namespace WaveLib.AudioMixer {
	public class MixerDetail {
		
		public MixerDetail() {
			mName			= "";
			mDeviceId		= -1;
			mSupportWaveIn	= false;
			mSupportWaveOut = false;
		}

		protected string mName;
		public string MixerName {
			get{return mName;}
			set{mName = value;}
		}

		protected int mDeviceId;
		public int DeviceId {
			get{return mDeviceId;}
			set{mDeviceId = value;}
		}

		protected bool mSupportWaveIn;
		public bool SupportWaveIn {
			get{return mSupportWaveIn;}
			set{mSupportWaveIn = value;}
		}

		protected bool mSupportWaveOut;
		public bool SupportWaveOut {
			get{return mSupportWaveOut;}
			set{mSupportWaveOut = value;}
		}

		public override string ToString() {
			return mName;
		}
	}
}
