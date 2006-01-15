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

using WaveLib.NativeApi;

namespace WaveLib.AudioMixer {
	public class MixerException : System.Exception {
		private readonly MMErrors	mErrorCode;
	
		public MixerException(MMErrors errorCode, string errorMessage) : base(errorMessage) {
			mErrorCode = errorCode;
		}
		
		public MMErrors ErrorCode {
			get{return mErrorCode;}
		}
	}
}
