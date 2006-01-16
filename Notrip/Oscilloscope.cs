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
			//mLastPlots = new int[Width];
			InitializeComponent();
			Graphics.FromHwnd( Handle ).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
			mPen = new Pen( ForeColor, 1f );
			mWhitePen = new Pen( BackColor, 1f );
		}
		
		protected int mOffset = 0;
		protected float mYRatio = 1;
		protected Point mPoint = new Point( 1, 1 );
		protected Point mNewPoint = new Point( 1, 1 );
		protected Pen mPen;
		protected Pen mWhitePen;
		protected int[] mLastPlots;
		protected Point[] mPoints = new Point[] {};
		
		public void AddSamples( byte[] samples ) {
		//    Invoke(
		//        new UpdateRawDataDelegate( UpdateRawData ),
		//        new Object[] { samples }
		//    );
		//}
		//private delegate void UpdateRawDataDelegate( byte[] samples );
		//private void UpdateRawData( byte[] samples ) {
			Graphics g = Graphics.FromHwnd( Handle );
					    
			Point[] newPoints = new Point[ samples.Length ]; // > Width ? Width : samples.Length ];
			
			float ratio = 1f;
			if( samples.Length > newPoints.Length )
			    ratio = samples.Length / newPoints.Length;
			
			for( int i = 0; i < newPoints.Length; i++ ) {
			    newPoints[ i ].X = i;
			    newPoints[ i ].Y = samples[ (int)((float)i * ratio)];
			}
			
			if( mPoints.Length > 1 )
			    g.DrawLines( mWhitePen, mPoints );

			if( newPoints.Length > 1 )			
			    g.DrawLines( mPen, newPoints );
			    
			mPoints = newPoints;
			
			//foreach( byte sample in samples ) {
			//    mNewPoint.X = mOffset;
			//    mNewPoint.Y = (int) ( mYRatio * ((float) sample) );
				
			//    // If the new point is further along X, plot it
			//    // This prevent recursion and stop the first point
			//    // on X being drawn
			//    if( mNewPoint.X > mPoint.X ) {
			//        // White out last point
			//        g.DrawLine( mWhitePen, mPoint.X, mLastPlots[mOffset-1], mNewPoint.X, mLastPlots[mOffset] ); 
			//        // Draw new point
			//        g.DrawLine( mPen, mPoint, mNewPoint );
			//    }
							
			//    mLastPlots[mOffset] = mNewPoint.Y;
			//    mPoint = mNewPoint;
				
			//    // Increment and safely wrap X-axis:
			//    mOffset++;
			//    if( mOffset == Width )
			//        mOffset = 0;
			//}
		}

		private void Oscilloscope_Resize( object sender, EventArgs e ) {
			mYRatio = ((float) Height) / 255f;
			mOffset = 0;
			mLastPlots = new int[Width];
		}
		
	}
}
