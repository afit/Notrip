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
			mStrings = new Tuning[] {
				new Tuning( Note.E, 2 ),
				new Tuning( Note.A, 3 ),
				new Tuning( Note.D, 3 ),
				new Tuning( Note.G, 3 ),
				new Tuning( Note.B, 4 ),
				new Tuning( Note.E, 4 )
			};
			mFrets = 23;
			mHorizontal = true;
			mShowFrequencies = false;
			InitializeComponent();
		}

		protected Pen mPen = new Pen( Color.Black, 1f );
		protected Bitmap mBuffer;
		protected Graphics mBufferGraphics;
		protected int mLastFret;
		protected int mLastInstrumentString;
		
		protected Tuning[] mStrings;
		public Tuning[] Strings {
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
		
		protected bool mShowOctaves;
		public bool ShowOctaves {
			get{ return mShowOctaves; }
			set{
				mShowOctaves = value;
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

        protected bool mHighlightOnce = true;
        public bool HighlightOnce {
            get { return mHighlightOnce; }
        }

		protected List<Sound> mPreviousSounds = new List<Sound>();
		public void Highlight( List<Sound> sounds, bool playHighlighted ) {
			foreach( Sound sound in mPreviousSounds ) {
			    if( playHighlighted )
			        AudioMonitor.Instance().PlayNote( AudioMonitor.StepToFrequency( sound.Step ), 0, this );
					
			    for( int instrumentString = 0; instrumentString < Strings.Length; instrumentString++ ) {		
			        int step = AudioMonitor.TuningToStep( Strings[instrumentString] );
					
			        if( step <= sound.Step && step + Frets > sound.Step ) {
			            int fret = sound.Step - step;
						
			            if( mLeftHanded )
			                fret = mFrets - fret;
							
			            DrawFingering( Graphics.FromHwnd( Handle ), instrumentString + 1, fret, Brushes.White );

                        if( mHighlightOnce )
                            break;
			        }
			    }
			}
			    
			foreach( Sound sound in sounds ) {
			    if( playHighlighted )
			        AudioMonitor.Instance().PlayNote( AudioMonitor.StepToFrequency( sound.Step ), 0, this );
					
			    for( int instrumentString = 0; instrumentString < Strings.Length; instrumentString++ ) {		
			        int step = AudioMonitor.TuningToStep( Strings[instrumentString] );

			        if( step <= sound.Step && step + Frets > sound.Step ) {
			            int fret = sound.Step - step;
						
			            if( mLeftHanded )
			                fret = mFrets - fret;
							
			            DrawFingering(
			                Graphics.FromHwnd( Handle ), instrumentString + 1, fret,
			                new SolidBrush( Color.FromArgb( 255, 255 - (sound.Amplitude >= 64 ? 255 : sound.Amplitude * 4), 255 - (sound.Amplitude >= 64 ? 255 : sound.Amplitude * 4) ) )
			            );

                        if (mHighlightOnce)
                            break;
			        }
			    }
			}
			mPreviousSounds = sounds;
		}
	
		protected void FindFingering( int x, int y, out int fret, out int instrumentString ) {
			if( Strings.Length == 0 ) {
				fret = 0;
				instrumentString = 0;
			} else {
				fret = (int) Math.Round( (float) x / (float) (Width / (Frets + 2)), 0 ) - 1;
				instrumentString = (int) Math.Round( (float) y / (float) (Height / (Strings.Length + 1)), 0 );
			}
		}

		protected void DrawFingering( Graphics g, int instrumentString, int fret, Brush brush ) {
			int spacingFrets = Width / ( Frets + 2 );
			int spacingStrings = Height / ( Strings.Length + 1 );
			int stringY = spacingStrings * instrumentString;
			int fretX = spacingFrets * (fret + 1);
			
			g.FillEllipse( brush, fretX - 10, stringY - 10, 20, 20 );

			if( mLeftHanded )
				fret = mFrets - fret;
			
			String label;
			if( ! mShowFrequencies ) {

				int noteIndex = NoteHelper.Instance().GetOrderedNotes().IndexOf( Strings[instrumentString - 1].Note ) + fret;
				int octave = Strings[instrumentString - 1].Octave;
				
				while( noteIndex > 11 ) {
					noteIndex -= 12;
					octave++;
				}
				label = NoteHelper.Instance().GetOrderedNoteNames()[ noteIndex ];
				
				if( mShowOctaves )
					label += "" + octave;
			} else {
				// Convert to int to display more cleanly:
				int step = AudioMonitor.TuningToStep( Strings[instrumentString - 1] );
				label = AudioMonitor.StepToFrequency( step + fret - 1 ) + "";
			}
			
			g.DrawString( label, Font, Brushes.Black, fretX - (g.MeasureString( label, Font ).ToSize().Width / 2), stringY - (g.MeasureString( label, Font ).ToSize().Height / 2) );
		}

		private void FingerInstrument( int instrumentString, int fret, bool sustain ) {		
			if( mLeftHanded )
				fret = mFrets - fret;
			
			if( fret >= 0 && instrumentString - 1 >= 0 && fret <= Frets && instrumentString - 1 < Strings.Length ) {
				double frequency = AudioMonitor.StepToFrequency( AudioMonitor.TuningToStep( Strings[instrumentString - 1] ) + fret );

			    if( ! sustain )
			        AudioMonitor.Instance().PlayNote( frequency, 500, this );
			    else
			        AudioMonitor.Instance().PlayNote( frequency, 0, this );
			}
		}

		private void StringedInstrument_Paint( object sender, PaintEventArgs e ) {
			mBufferGraphics.Clear( BackColor );
		
			Graphics g = mBufferGraphics;
			
			// Add one to the number to find the spacing, so
			// that there's an equal space at the top and bottom.
			int spacingFrets = Width / ( Frets + 2 );
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
				fretHanding = new int[]{ 0, Frets + 1, 1 };
			else
				fretHanding = new int[]{ Frets, -1, -1 };

				
			for( int i = stringHanding[0]; i != stringHanding[1]; i = i + stringHanding[2] ) {
				for( int ii = fretHanding[0]; ii != fretHanding[1]; ii = ii + fretHanding[2] ) {		
					DrawFingering( g, i + 1, ii, Brushes.White );

					if( i == stringHanding[0] ) {
						int stringY = spacingStrings * (Strings.Length + 1);
						int fretX = spacingFrets * (ii + 1);
						String fretNo = Math.Abs( ii - (mLeftHanded ? mFrets : 0) ) + "";
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
			
			if( e.Button == MouseButtons.Left || e.Button == MouseButtons.Right )
				FingerInstrument( instrumentString, fret, e.Button == MouseButtons.Right );
		}

		private void StringedInstrument_MouseMove(object sender, MouseEventArgs e) {
			int fret, instrumentString;
			FindFingering( e.X, e.Y, out fret, out instrumentString );
			
			// If the fingered note has changed:
			if( fret != mLastFret || instrumentString != mLastInstrumentString ) {			
				// Highlight selected note.
				if( fret >= 0 && instrumentString - 1 >= 0 && fret <= Frets && instrumentString - 1 < Strings.Length )
					DrawFingering( Graphics.FromHwnd( Handle ), instrumentString, fret, Brushes.SlateBlue );
				// White out old note.
				if( mLastFret >= 0 && mLastInstrumentString - 1 >= 0 && mLastFret <= Frets && mLastInstrumentString - 1 < Strings.Length )
				    DrawFingering( Graphics.FromHwnd( Handle ), mLastInstrumentString, mLastFret, Brushes.White );
				
				mLastFret = fret;
				mLastInstrumentString = instrumentString;
			}
		}
	}
}