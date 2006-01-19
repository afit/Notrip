using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace LothianProductions.Notrip {
	public partial class StringedInstrument : UserControl {
		public StringedInstrument() {
			mStrings = new List<InstrumentString>();
			mStrings.Add( new InstrumentString( Note.E, -17 ) );
			mStrings.Add(  new InstrumentString( Note.A, -12 ) );
			mStrings.Add(  new InstrumentString( Note.D, -7 ) );
			mStrings.Add( new InstrumentString( Note.G, -2 ) );
			mStrings.Add( new InstrumentString( Note.B, 2 ) );
			mStrings.Add( new InstrumentString( Note.E, 7 ) );
			

//			mStrings = new InstrumentString[] {
//				new InstrumentString( Note.E, -17 ),
//				new InstrumentString( Note.A, -12 ),
//				new InstrumentString( Note.D, -7 ),
//				new InstrumentString( Note.G, -2 ),
//				new InstrumentString( Note.B, 2 ),
//				new InstrumentString( Note.E, 7 )
//			};
			mFrets = 24;
			mCapo = 0;
			mHorizontal = true;
			
			mNoteLabels = new String[mStrings.Count, mFrets];
			
			InitializeComponent();
		}

		const int ROOT_FREQ = 440;
		protected int mLastFret;
		protected int mLastInstrumentString;
		protected String[,] mNoteLabels;
		protected Dictionary<String, BeepCl> mBeeps = new Dictionary<string,BeepCl>();

		//protected InstrumentString[] mStrings;
		protected List<InstrumentString> mStrings;
		public List<InstrumentString> Strings {
			get{ return mStrings; }
			set{
				mStrings = value;
				Invalidate();
			}
		}
		
		protected int mFrets;
		public int Frets {
			get{ return mFrets; }
			set{
				mFrets = value;
				Invalidate();
			}
		}

		protected int mCapo;
		public int Capo {
			get{ return mCapo; }
			set{
				mCapo = value;
				Invalidate();
			}
		}
	
		protected bool mHorizontal;
		public bool Horizontal {
			get{ return mHorizontal; }
			set{
				mHorizontal = value;
				Invalidate();
			}
		}

        protected bool mLeftHanded;
        public bool LeftHanded {
            get{ return mLeftHanded; }
            set {
				mLeftHanded = value;
				Invalidate();
            }
        }

		protected void PlayNote( int fret, int instrumentString, int duration ) {
			// Create a new beep object and fire it off on a separate thread.
			if( mLeftHanded )
				fret = (Frets - fret) + 1;
			
			lock( mBeeps ) {
				BeepCl beep;
				if( mBeeps.ContainsKey( fret + ":" + instrumentString ) )
					beep = mBeeps[ fret + ":" + instrumentString ];
				else {
					double steps = Strings[instrumentString - 1].RootSteps + fret - 1;		
					beep = new BeepCl( this );
					mBeeps.Add( fret + ":" + instrumentString, beep );
					beep.Frequency = ROOT_FREQ * Math.Pow(2, steps / 12);
				}
				
				//if( beep.
				//beep.StartOrStopPlay( false );
				beep.Duration = duration;
				new Thread( new ThreadStart( beep.Beep ) ).Start();
			}
		}
		
		protected void FindFingering( int x, int y, out int fret, out int instrumentString ) {
			if( Strings.Count == 0 || Frets == 0 ) {
				fret = 0;
				instrumentString = 0;
			} else {
				fret = (int) Math.Round( (float) x / (float) (Width / (Frets + 1)), 0 );
				instrumentString = (int) Math.Round( (float) y / (float) (Height / (Strings.Count + 1)), 0 );
			}
		}

		protected void DrawFingering( Graphics g, int instrumentString, int fret, Brush brush ) {
			int spacingFrets = Width / ( Frets + 1 );
			int spacingStrings = Height / ( Strings.Count + 1 );
			int stringY = spacingStrings * instrumentString;
			int fretX = spacingFrets * fret;
			
			g.FillEllipse( brush, fretX - 10, stringY - 10, 20, 20 );
			g.DrawString( mNoteLabels[instrumentString - 1, fret - 1], Font, Brushes.Black, fretX - (g.MeasureString( mNoteLabels[instrumentString - 1, fret - 1], Font ).ToSize().Width / 2), stringY - (g.MeasureString( mNoteLabels[instrumentString - 1, fret - 1], Font ).ToSize().Height / 2) );
		}

		private void StringedInstrument_Paint( object sender, PaintEventArgs e ) {
			Graphics g = e.Graphics;
			Pen pen = new Pen( Color.Black, 1f );
			
			// Add one to the number to find the spacing, so
			// that there's an equal space at the top and bottom.
			int spacingFrets = Width / ( Frets + 1 );
			int spacingStrings = Height / ( Strings.Count + 1 );
			for( int i = 0; i < Frets; i++ ) {
				Point[] points = new Point[] {
					new Point( spacingFrets * (i + 1), spacingStrings ),
					new Point( spacingFrets * (i + 1), Height - spacingStrings )
				};
				g.DrawLines( pen, points );
			}

			pen.Width = 2f;					
			
			int startString = 0, endString = Width;
			if( mLeftHanded )
				endString = Width - spacingFrets;
			else
				startString = spacingFrets;
			
			for( int i = 0; i < Strings.Count; i++ ) {
				Point[] points = new Point[] {
					new Point( startString, spacingStrings * (i + 1) ),
					new Point( endString, spacingStrings * (i + 1) )
				};
				g.DrawLines( pen, points );
			}

			// Draw fingerings on each string for each fret.
			int note;
			int[] stringHanding, fretHanding;
			
			if( ! mLeftHanded )
				stringHanding = new int[]{ 0, Strings.Count, 1 };
			else
				stringHanding = new int[]{ Strings.Count - 1, -1, -1 };

			if( ! mLeftHanded )
				fretHanding = new int[]{ 0, Frets, 1 };
			else
				fretHanding = new int[]{ Frets - 1, -1, -1 };

				
			for( int i = stringHanding[0]; i != stringHanding[1]; i = i + stringHanding[2] ) {
				note = (int) Strings[i].RootNote;
				
				for( int ii = fretHanding[0]; ii != fretHanding[1]; ii = ii + fretHanding[2] ) {	
					mNoteLabels[i, ii] = Enum.GetName( typeof(Note), note++ ).Replace( "sharp", "#" ).Replace( "flat", "b" );

					// Loop notes back to start.
					if( note == Enum.GetValues( typeof(Note) ).Length )
						note = 0;
					
					DrawFingering( Graphics.FromHwnd( Handle ), i + 1, ii + 1, Brushes.White );

					if( i == stringHanding[0] ) {
						int stringY = spacingStrings * (Strings.Count + 1);
						int fretX = spacingFrets * (ii + 1);
						String fretNo = Math.Abs( ii + 1 - (mLeftHanded ? mFrets + 1 : 0) ) + "";
						g.DrawString(
							fretNo, Font, Brushes.Black,
							fretX - (g.MeasureString( fretNo, Font ).ToSize().Width / 2),
							stringY - (g.MeasureString( fretNo, Font ).ToSize().Height / 1.5f)
						);
					}
				}
			}
		}
		
		private void StringedInstrument_Resize( object sender, EventArgs e ) {
			this.Invalidate();
		}

		private void StringedInstrument_MouseUp(object sender, MouseEventArgs e) {
			int fret, instrumentString;
			FindFingering( e.X, e.Y, out fret, out instrumentString );
			
			if( fret - 1 >= 0 && instrumentString - 1 >= 0 && fret - 1 < Frets && instrumentString - 1 < Strings.Count )
				if( e.Button == MouseButtons.Left )
					PlayNote( fret, instrumentString, 500 );
				else if( e.Button == MouseButtons.Right )
					PlayNote( fret, instrumentString, 0 );
		}

		private void StringedInstrument_MouseMove(object sender, MouseEventArgs e) {
			int fret, instrumentString;
			FindFingering( e.X, e.Y, out fret, out instrumentString );
			
			// If the fingered note has changed:
			if( fret != mLastFret || instrumentString != mLastInstrumentString ) {			
				// Highlight selected note.
				if( fret - 1 >= 0 && instrumentString - 1 >= 0 && fret - 1 < Frets && instrumentString - 1 < Strings.Count )
					DrawFingering( Graphics.FromHwnd( Handle ), instrumentString, fret, Brushes.SlateBlue );
				// White out old note.
				if( mLastFret - 1 >= 0 && mLastInstrumentString - 1 >= 0 && mLastFret - 1 < Frets && mLastInstrumentString - 1 < Strings.Count )
				    DrawFingering( Graphics.FromHwnd( Handle ), mLastInstrumentString, mLastFret, Brushes.White );
				
				mLastFret = fret;
				mLastInstrumentString = instrumentString;
			}
		}
	}
}