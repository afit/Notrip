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
		protected Pen mPen;
		protected Pen mWhitePen;
		protected Point[] mPoints = new Point[] {};
		protected Bitmap mBuffer;
		protected Graphics mBufferGraphics;
		
		public Oscilloscope() {
			InitializeComponent();
			Graphics.FromHwnd( Handle ).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			mPen = new Pen( ForeColor, 1f );
			mWhitePen = new Pen( BackColor, 1f );
		}

		public void AddSamples( byte[] samples ) {
			// No need to scale -- either we distort the graph and ruin the scale
			// or we slow down the rendering. Skipping >Width is healthy.
			//for( int i = 0; i < (samples.Length > mPoints.Length ? mPoints.Length : samples.Length); i++ ) {
			//    mPoints[ i ].X = i;
			//    mPoints[ i ].Y = samples[i];
			//}
			for( int i = 0; i < mPoints.Length; i++ ) {
			    mPoints[ i ].X = i;
			    mPoints[ i ].Y = (int) (samples[i * (samples.Length / Width)] * ((float) Height / 256f));
			}


		    mBufferGraphics.Clear( BackColor );
		    mBufferGraphics.DrawLines( mPen, mPoints );
			Graphics.FromHwnd( Handle ).DrawImageUnscaled( mBuffer, 0, 0 );
		}

		private void Oscilloscope_Resize( object sender, EventArgs e ) {
			mBuffer = new Bitmap( Width, Height, PixelFormat.Format32bppPArgb );
			mBufferGraphics = Graphics.FromImage( mBuffer );
			mPoints = new Point[ Width ];
		}	
	}
}
