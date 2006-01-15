using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LothianProductions.Notrip {
	public partial class StringedInstrument : UserControl {
		public StringedInstrument() {
			InitializeComponent();
		}

		protected InstrumentString[] mStrings = new InstrumentString[] {
			new InstrumentString( Note.E ),
			new InstrumentString( Note.A ),
			new InstrumentString( Note.D ),
			new InstrumentString( Note.G ),
			new InstrumentString( Note.B ),
			new InstrumentString( Note.E )
		};
		public InstrumentString[] Strings {
			get{ return mStrings; }
			set{ mStrings = value; }
		}
		
		protected int mFrets = 24;
		public int Frets {
			get{ return mFrets; }
			set{ mFrets = value; }
		}

		protected int mCapo = 0;
		public int Capo {
			get{ return mCapo; }
			set{ mCapo = value; }
		}
	
		protected bool mHorizontal = true;
		public bool Horizontal {
			get{ return mHorizontal; }
			set{ mHorizontal = value; }
		}

		private void StringedInstrument_Paint( object sender, PaintEventArgs e ) {
			Graphics g = e.Graphics;
			Pen pen = new Pen( Color.Black, 1f );
			
			// Add one to the number to find the spacing, so
			// that there's an equal space at the top and bottom.
			int spacing = Width / ( Frets + 1 );
			for( int i = 0; i < Frets; i++ ) {
				Point[] points = new Point[] {
					new Point( spacing * (i + 1), 0 ),
					new Point( spacing * (i + 1), Height )
				};
				g.DrawLines( pen, points );
			}

			pen.Width = 2f;					
			spacing = Height / ( Strings.Length + 1 );
			
			for( int i = 0; i < Strings.Length; i++ ) {
				//InstrumentString instrumentString = Strings[ i ];
				Point[] points = new Point[] {
					new Point( 0, spacing * (i + 1) ),
					new Point( Width, spacing * (i + 1) )
				};
				g.DrawLines( pen, points );
			}
		}

		private void StringedInstrument_Resize( object sender, EventArgs e ) {
			this.Invalidate();
		}
	}
}
