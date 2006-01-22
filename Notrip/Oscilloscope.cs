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
			mAxisPen = new Pen( Color.Red, 1f );
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

			//// Spectral analysis:
			//float T = (float) samples.Length / (float) AudioMonitor.SAMPLE_RATE;
			//int n = samples.Length / 2;
			//mSpectrumPoints = new Point[ n/2 ];

			//for( int j = 0; j < n/2; j++ ) {
			//    double firstSummation = 0;
			//    double secondSummation = 0;
			//    double twoPInjk = Math.PI / (float) samples.Length * j * 4d;

			//    for(int k = 0; k < n; k++ ) {
			//        double byK = twoPInjk * k;
			//        firstSummation +=  samples[k] * Math.Cos(byK);
			//        secondSummation += samples[k] * Math.Sin(byK);
			//    }
			//    mSpectrumPoints[j].X = j;
			//    double amp = 4d * Math.Abs( Math.Sqrt(Math.Pow(firstSummation,2) + Math.Pow(secondSummation,2)) ) / (double) samples.Length;
				
			//    mSpectrumPoints[j].Y = Height - 1 - (int) ((Height / 256f) * amp);

			//    if(  j>0 && amp > 5 )
			//        Console.WriteLine("frequency = "+j/T*2d+", amp = "+(int)amp);
			//} 

		    mBufferGraphics.Clear( BackColor );
		    mBufferGraphics.DrawLine( mAxisPen,  0, Height / 2, Width, Height / 2 );
			mBufferGraphics.DrawLines( mWaveformPen, mWaveformPoints );
			//mBufferGraphics.DrawLines( mSpectrumPen, mSpectrumPoints );
			//mBufferGraphics.DrawLine( mAxisPen, n, 0, n, Height );
			//mBufferGraphics.DrawString( "1px = " + 1d/T + "hz", Font, Brushes.Blue, 10, 10 );
			//mBufferGraphics.DrawString( "1px = " + 1/AudioMonitor.SAMPLE_RATE*(samples.Length/Width) + "ms", Font, Brushes.Black, 10, 30 );
			Graphics.FromHwnd( Handle ).DrawImageUnscaled( mBuffer, 0, 0 );
		}

		private void Oscilloscope_Resize( object sender, EventArgs e ) {
			mBuffer = new Bitmap( Width, Height, PixelFormat.Format32bppPArgb );
			mBufferGraphics = Graphics.FromImage( mBuffer );
			mWaveformPoints = new Point[ Width ];
		}	
	}
}
