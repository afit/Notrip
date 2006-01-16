using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LothianProductions.Notrip {
	public partial class Oscilloscope : UserControl {
		public Oscilloscope() {
			mLastPlots = new int[Width];
			InitializeComponent();
			Graphics.FromHwnd( Handle ).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
		}
		
		protected int mOffset = 1;
		protected float mYRatio = 1;
		protected Point mPoint = new Point( 1, 1 );
		protected Point mNewPoint = new Point( 1, 1 );
		protected Pen mPen = new Pen( Color.Black, 1f );
		protected Pen mWhitePen = new Pen( Color.White, 1f );
		protected int[] mLastPlots;
		
		public void AddSamples( byte[] samples ) {
		//    Invoke(
		//        new UpdateRawDataDelegate( UpdateRawData ),
		//        new Object[] { samples }
		//    );
		//}
		//private delegate void UpdateRawDataDelegate( byte[] samples );
		//private void UpdateRawData( byte[] samples ) {
			Graphics g = Graphics.FromHwnd( Handle );
			
			foreach( byte sample in samples ) {
				mNewPoint.X = mOffset;
				mNewPoint.Y = (int) ( mYRatio * ((float) sample) );
				
				// If the new point is further along X, plot it
				// This prevent recursion and stop the first point
				// on X being drawn
				if( mNewPoint.X > mPoint.X ) {
					// White out last point
					g.DrawLine( mWhitePen, mPoint.X, mLastPlots[mOffset-1], mNewPoint.X, mLastPlots[mOffset] ); 
					// Draw new point
					g.DrawLine( mPen, mPoint, mNewPoint );
				}
			
				mLastPlots[mOffset] = mNewPoint.Y;
				
				//mLastPlots[mOffset-1] = (int) ( mYRatio * ((float) sample) );
				mPoint = mNewPoint;
				
				// Increment and safely wrap X-axis:
				mOffset++;
                if( mOffset == Width )
					mOffset = 1;
			}
		}

		private void Oscilloscope_Resize( object sender, EventArgs e ) {
			mYRatio = ((float) Height) / 255f;
			mOffset = 1;
			mLastPlots = new int[Width];
		}
		
	}
}
