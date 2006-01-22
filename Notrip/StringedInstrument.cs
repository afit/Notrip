using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Data;
using System.Runtime.Serialization;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace LothianProductions.Notrip {
	[Serializable()]
	public partial class StringedInstrument : UserControl {
		
		public StringedInstrument() {
			mStrings = new InstrumentString[] {
				new InstrumentString( Note.E, 2 ),
				new InstrumentString( Note.A, 3 ),
				new InstrumentString( Note.D, 3 ),
				new InstrumentString( Note.G, 3 ),
				new InstrumentString( Note.B, 4 ),
				new InstrumentString( Note.E, 4 )
			};
			mFrets = 24;
			mCapo = 0;
			mHorizontal = true;
			mShowFrequencies = false;
			InitializeComponent();
		}

		const int ROOT_A4_FREQ = 440;
		protected Pen mPen = new Pen( Color.Black, 1f );
		protected Bitmap mBuffer;
		protected Graphics mBufferGraphics;
		protected int mLastFret;
		protected int mLastInstrumentString;
		protected Dictionary<double, Beep> mBeeps = new Dictionary<double, Beep>();
		protected InstrumentString[] mStrings;
		public InstrumentString[] Strings {
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

		protected bool mShowFrequencies;
		public bool ShowFrequencies {
			get{ return mShowFrequencies; }
			set{
				mShowFrequencies = value;
				Invalidate();
			}
		}

		// FIXME deprecate this?
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

		public void Highlight( Dictionary<double, int> frequencies ) {
			//Invalidate();
//			foreach( double frequency in frequencies.Keys ) {
//				int fret, instrumentString;
				
				//FindFingering( (int) frequency, out fret, out instrumentString );
				
				//DrawFingering( Graphics.FromHwnd( Handle ), instrumentString, fret, Brushes.Red );
//			}

			for( int instrumentString = 0; instrumentString < mStrings.Length; instrumentString++ ) {
				for( int fret = 0; fret < mFrets; fret++ ) {		
							
					int step = -36 + ((Strings[instrumentString].Octave - 1) * 12) + NoteHelper.Instance().GetOrderedNotes().IndexOf( Strings[instrumentString].RootNote );
					double fingeredFrequency = ROOT_A4_FREQ * Math.Pow(2, (step + fret) / 12d);
					
					//DrawFingering( Graphics.FromHwnd( Handle ), instrumentString + 1, fret + 1, Brushes.White );
					
					foreach( double frequency in frequencies.Keys ) {
						if( frequency + 2 > fingeredFrequency && frequency - 2 < fingeredFrequency ) {
							DrawFingering( Graphics.FromHwnd( Handle ), instrumentString + 1, fret + 1, Brushes.Red );
							break;
						}
					}
				
					//DrawFingering( g, i + 1, ii + 1, Brushes.White );

					//if( i == stringHanding[0] ) {
					//    int stringY = spacingStrings * (Strings.Length + 1);
					//    int fretX = spacingFrets * (ii + 1);
					//    String fretNo = Math.Abs( ii + 1 - (mLeftHanded ? mFrets + 1 : 0) ) + "";
					//    g.DrawString(
					//        fretNo, Font, Brushes.Black,
					//        fretX - (g.MeasureString( fretNo, Font ).ToSize().Width / 2),
					//        stringY - (g.MeasureString( fretNo, Font ).ToSize().Height / 1.5f)
					//    );
					//}
				}
			}
		}
		
		//protected void FindFingering( int frequency, out int fret, out int instrumentString ) {
		//    fret = 0; instrumentString = 0;
			
		//    int step = -36 + ((Strings[instrumentString - 1].Octave - 1) * 12) + NoteHelper.Instance().GetOrderedNotes().IndexOf( Strings[instrumentString - 1].RootNote );
		//    double frequency = ROOT_A4_FREQ * Math.Pow(2, (step + fret - 1) / 12d);
			
		//    fopr
			
		//}
	
		protected void FindFingering( int x, int y, out int fret, out int instrumentString ) {
			if( Strings.Length == 0 || Frets == 0 ) {
				fret = 0;
				instrumentString = 0;
			} else {
				fret = (int) Math.Round( (float) x / (float) (Width / (Frets + 1)), 0 );
				instrumentString = (int) Math.Round( (float) y / (float) (Height / (Strings.Length + 1)), 0 );
			}
		}

		// FIXME move this to AudioMonitor?
		protected void PlayNote( double frequency, int duration ) {
			// Create a new beep object and fire it off on a separate thread.
			lock( mBeeps ) {
				Beep beep;
				if( mBeeps.ContainsKey( frequency ) )
					beep = mBeeps[ frequency ];
				else {
					beep = new Beep( this );
					mBeeps.Add( frequency, beep );
					beep.Frequency = frequency;
				}
				
				// Turn off permanent tones:
				if( beep.Playing ) {
				    beep.Stop();
					if( beep.Duration == 0 )
					    return;
				}
				
				beep.Duration = duration;
				new Thread( new ThreadStart( beep.Start ) ).Start();
			}
		}

		protected void DrawFingering( Graphics g, int instrumentString, int fret, Brush brush ) {
			int spacingFrets = Width / ( Frets + 1 );
			int spacingStrings = Height / ( Strings.Length + 1 );
			int stringY = spacingStrings * instrumentString;
			int fretX = spacingFrets * fret;
			
			g.FillEllipse( brush, fretX - 10, stringY - 10, 20, 20 );

			if( mLeftHanded )
				fret = mFrets + 1 - fret;
			
			String label;
			if( ! mShowFrequencies ) {

				int noteIndex = NoteHelper.Instance().GetOrderedNotes().IndexOf( Strings[instrumentString - 1].RootNote ) + fret - 1;
				while( noteIndex > 11 )
					noteIndex -= 12;
				label = NoteHelper.Instance().GetOrderedNoteNames()[ noteIndex ];
			} else {
				// Convert to int to display more cleanly:
				int step = -36 + ((Strings[instrumentString - 1].Octave - 1) * 12) + NoteHelper.Instance().GetOrderedNotes().IndexOf( Strings[instrumentString - 1].RootNote );
				label = (int) (ROOT_A4_FREQ * Math.Pow(2, (step + fret - 1) / 12d)) + "";
			}
			
			g.DrawString( label, Font, Brushes.Black, fretX - (g.MeasureString( label, Font ).ToSize().Width / 2), stringY - (g.MeasureString( label, Font ).ToSize().Height / 2) );
		}

		private void StringedInstrument_Paint( object sender, PaintEventArgs e ) {
			mBufferGraphics.Clear( BackColor );
		
			Graphics g = mBufferGraphics;
			
			// Add one to the number to find the spacing, so
			// that there's an equal space at the top and bottom.
			int spacingFrets = Width / ( Frets + 1 );
			int spacingStrings = Height / ( Strings.Length + 1 );
			for( int i = 0; i < Frets; i++ ) {
				Point[] points = new Point[] {
					new Point( spacingFrets * (i + 1), spacingStrings ),
					new Point( spacingFrets * (i + 1), Height - spacingStrings )
				};
				g.DrawLines( mPen, points );
			}

			mPen.Width = 2f;					
			
			int startString = 0, endString = Width;
			if( mLeftHanded )
				endString = Width - spacingFrets;
			else
				startString = spacingFrets;
			
			for( int i = 0; i < Strings.Length; i++ ) {
				Point[] points = new Point[] {
					new Point( startString, spacingStrings * (i + 1) ),
					new Point( endString, spacingStrings * (i + 1) )
				};
				g.DrawLines( mPen, points );
			}

			// Draw fingerings on each string for each fret.
			int[] stringHanding, fretHanding;
			
			if( ! mLeftHanded )
				stringHanding = new int[]{ 0, Strings.Length, 1 };
			else
				stringHanding = new int[]{ Strings.Length - 1, -1, -1 };

			if( ! mLeftHanded )
				fretHanding = new int[]{ 0, Frets, 1 };
			else
				fretHanding = new int[]{ Frets - 1, -1, -1 };

				
			for( int i = stringHanding[0]; i != stringHanding[1]; i = i + stringHanding[2] ) {
				for( int ii = fretHanding[0]; ii != fretHanding[1]; ii = ii + fretHanding[2] ) {		
					DrawFingering( g, i + 1, ii + 1, Brushes.White );

					if( i == stringHanding[0] ) {
						int stringY = spacingStrings * (Strings.Length + 1);
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
			
			Graphics.FromHwnd( Handle ).DrawImageUnscaled( mBuffer, 0, 0 );
		}
		
		private void StringedInstrument_Resize( object sender, EventArgs e ) {
			mBuffer = new Bitmap( Width, Height, PixelFormat.Format32bppPArgb );
			mBufferGraphics = Graphics.FromImage( mBuffer );
		}

		private void StringedInstrument_MouseUp(object sender, MouseEventArgs e) {
			int fret, instrumentString;
			FindFingering( e.X, e.Y, out fret, out instrumentString );
			
			if( mLeftHanded )
				fret = (Frets - fret) + 1;
			
			if( fret - 1 >= 0 && instrumentString - 1 >= 0 && fret - 1 < Frets && instrumentString - 1 < Strings.Length ) {

				int step = -36 + ((Strings[instrumentString - 1].Octave - 1) * 12) + NoteHelper.Instance().GetOrderedNotes().IndexOf( Strings[instrumentString - 1].RootNote );
				double frequency = ROOT_A4_FREQ * Math.Pow(2, (step + fret - 1) / 12d);

			    if( e.Button == MouseButtons.Left )
			        PlayNote( frequency, 500 );
			    else if( e.Button == MouseButtons.Right )
			        PlayNote( frequency, 0 );
			}
		}

		private void StringedInstrument_MouseMove(object sender, MouseEventArgs e) {
			int fret, instrumentString;
			FindFingering( e.X, e.Y, out fret, out instrumentString );
			
			// If the fingered note has changed:
			if( fret != mLastFret || instrumentString != mLastInstrumentString ) {			
				// Highlight selected note.
				if( fret - 1 >= 0 && instrumentString - 1 >= 0 && fret - 1 < Frets && instrumentString - 1 < Strings.Length )
					DrawFingering( Graphics.FromHwnd( Handle ), instrumentString, fret, Brushes.SlateBlue );
				// White out old note.
				if( mLastFret - 1 >= 0 && mLastInstrumentString - 1 >= 0 && mLastFret - 1 < Frets && mLastInstrumentString - 1 < Strings.Length )
				    DrawFingering( Graphics.FromHwnd( Handle ), mLastInstrumentString, mLastFret, Brushes.White );
				
				mLastFret = fret;
				mLastInstrumentString = instrumentString;
			}
		}
	}
}