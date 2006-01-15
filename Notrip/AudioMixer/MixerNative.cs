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
using System.Runtime.InteropServices;

namespace WaveLib.NativeApi {
	public class MixerNative {
		public const int MMSYSERR_BASE			= 0;
		public const int WAVERR_BASE            = 32;
		public const int MIXER_SHORT_NAME_CHARS = 16;
		public const int MIXER_LONG_NAME_CHARS  = 64;
		public const int MAXPNAMELEN			= 32;     /* max product name length (including NULL) */
		public const int MIXERR_BASE            = 1024;
		public const int CALLBACK_WINDOW		= 0x00010000;    /* dwCallback is a HWND */
		public const int MM_MIXM_LINE_CHANGE    = 0x3D0;       /* mixer line change notify */
		public const int MM_MIXM_CONTROL_CHANGE = 0x3D1;  

		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(IntPtr hWnd, int msg, uint wParam, uint lParam);

		[DllImport("winmm.dll")]
		public static extern int mixerOpen(out IntPtr phmx, int pMxId, IntPtr dwCallback, IntPtr dwInstance, uint fdwOpen);
		[DllImport("winmm.dll")]
		public static extern int mixerOpen(out IntPtr phmx, IntPtr pMxId, IntPtr dwCallback, IntPtr dwInstance, MIXER_OBJECTFLAG fdwOpen);
		[DllImport("winmm.dll")]
		public static extern int mixerOpen(out IntPtr phmx, IntPtr pMxId, IntPtr dwCallback, IntPtr dwInstance, uint fdwOpen);
		[DllImport("winmm.dll")]
		internal static extern int mixerGetLineInfo(IntPtr hmxobj,ref MIXERLINE pmxl, MIXER_GETLINEINFOF fdwInfo);
		[DllImport("winmm.dll")]
		public static extern int mixerClose(IntPtr hmx);
		[DllImport("winmm.dll")]
		public static extern int mixerGetLineControls(IntPtr hmxobj, ref MIXERLINECONTROLS pmxlc, MIXER_GETLINECONTROLSFLAG fdwControls);
		[DllImport("winmm.dll")]
		public static extern int mixerGetControlDetails(IntPtr hmxobj,ref MIXERCONTROLDETAILS pmxcd, MIXER_SETCONTROLDETAILSFLAG fdwDetailsmixer);
		[DllImport("winmm.dll")]
		public static extern int mixerGetControlDetails(IntPtr hmxobj,ref MIXERCONTROLDETAILS pmxcd, uint fdwDetailsmixer);
		[DllImport("winmm.dll")]
		public static extern int mixerGetControlDetails(IntPtr hmxobj,ref MIXERCONTROLDETAILS pmxcd, MIXER_GETCONTROLDETAILSFLAG fdwDetailsmixer);
		[DllImport("winmm.dll")]
		public static extern int mixerSetControlDetails(IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, MIXER_SETCONTROLDETAILSFLAG fdwDetails);
		[DllImport("winmm.dll")]
		public static extern int mixerGetID(IntPtr hmxobj, ref int mxId, MIXER_OBJECTFLAG fdwId);
		[DllImport("winmm.dll", CharSet=CharSet.Ansi)] 
		public static extern int mixerGetDevCaps(int uMxId, ref MIXERCAPS pmxcaps, int cbmxcaps); 
		[DllImport("winmm.dll", SetLastError=true)]
		public static extern int mixerGetNumDevs();
	}
}
