using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LothianProductions.Notrip {
	public partial class Oscilloscope : UserControl {		
		protected Pen mWaveformPen;
		protected Pen mAxisPen;
		protected Pen mSpectrumPen;
		protected Point[] mWaveformPoints = new Point[] {};
		protected Point[] mSpectrumPoints;
		protected Bitmap mBuffer;
		protected Graphics mBufferGraphics;
		
		public Oscilloscope() {
			InitializeComponent();
			Graphics.FromHwnd( Handle ).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			mWaveformPen = new Pen( ForeColor, 1f );
			mAxisPen = new Pen( SystemColors.HotTrack, 1f );
			mSpectrumPen = new Pen( Color.Blue, 1f );
		}

		public void AddSamples( byte[] samples ) {
			// No need to scale -- either we distort the graph and ruin the scale
			// or we slow down the rendering. Skipping >Width is healthy.
			//for( int i = 0; i < (samples.Length > mPoints.Length ? mPoints.Length : samples.Length); i++ ) {
			//    mPoints[ i ].X = i;
			//    mPoints[ i ].Y = samples[i];
			//}
			for( int i = 0; i < mWaveformPoints.Length; i++ ) {
			    mWaveformPoints[ i ].X = i;
			    mWaveformPoints[ i ].Y = (int) (samples[i * (samples.Length / Width)] * ((float) Height / 256f));
			}

		    mBufferGraphics.Clear( BackColor );
		    mBufferGraphics.DrawLine( mAxisPen,  0, Height / 2, Width, Height / 2 );
			mBufferGraphics.DrawLines( mWaveformPen, mWaveformPoints );
			Graphics.FromHwnd( Handle ).DrawImageUnscaled( mBuffer, 0, 0 );
		}

		private void Oscilloscope_Resize( object sender, EventArgs e ) {
			mBuffer = new Bitmap( Width, Height, PixelFormat.Format32bppPArgb );
			mBufferGraphics = Graphics.FromImage( mBuffer );
			mWaveformPoints = new Point[ Width ];
		}	
	}
}
