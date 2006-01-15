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

		const int ROOT_FREQ = 440;
		protected InstrumentString[] mStrings = new InstrumentString[] {
			new InstrumentString( Note.E, -17 ),
			new InstrumentString( Note.A, -12 ),
			new InstrumentString( Note.D, -7 ),
			new InstrumentString( Note.G, -2 ),
			new InstrumentString( Note.B, 2 ),
			new InstrumentString( Note.E, 7 )
		};
		protected IList<int[]> mSelectedNotes = new List<int[]>();
		protected int[] mSelectedNote = new int[] { 0, 0 };
		protected int oldX;
		protected int oldY;
		protected string[,] notes;
		Font noteFont = new Font("Arial", 8);

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
			int spacingFrets = Width / ( Frets + 1 );
			for( int i = 0; i < Frets; i++ ) {
				Point[] points = new Point[] {
					new Point( spacingFrets * (i + 1), 0 ),
					new Point( spacingFrets * (i + 1), Height )
				};
				g.DrawLines( pen, points );
			}

			pen.Width = 2f;					
			int spacingStrings = Height / ( Strings.Length + 1 );
			
			for( int i = 0; i < Strings.Length; i++ ) {
				//InstrumentString instrumentString = Strings[ i ];
				Point[] points = new Point[] {
					new Point( 0, spacingStrings * (i + 1) ),
					new Point( Width, spacingStrings * (i + 1) )
				};
				g.DrawLines( pen, points );
			}

			int numberOfNotes = Enum.GetValues(typeof(Note)).Length;
			int intNoteCounter = 0;
			for (int i = 0; i < Strings.Length; i++) {
				InstrumentString instrumentString = Strings[i];
				int rootNote = (int)instrumentString.RootNote;
				intNoteCounter = rootNote;
				for (int ii = 0; ii < Frets; ii++) {
					string noteName = Enum.GetName( typeof(Note), intNoteCounter );
					noteName = noteName.Replace("sharp", "#");
					noteName = noteName.Replace("flat", "b");
					intNoteCounter++;
					if ( intNoteCounter == numberOfNotes )
						intNoteCounter = 0;
					int noteTextWidth = g.MeasureString( noteName, noteFont ).ToSize().Width;
					int noteTextHeight = g.MeasureString( noteName, noteFont ).ToSize().Height;
					int fretX = (spacingFrets * (ii + 1));
					int stringY = (spacingStrings * (i + 1));
					float x = fretX - (noteTextWidth / 2);
					float y = stringY - (noteTextHeight / 2);
					g.FillEllipse(Brushes.White, fretX - 8, stringY - 8, 16, 16);
					g.DrawEllipse(Pens.Blue, fretX - 8, stringY - 8, 16, 16);
					g.DrawString(noteName, noteFont, Brushes.Black, x, y);
					notes[i, ii] = noteName;
				}
			}

			drawSelectedNotes();

		}

		private void StringedInstrument_Resize( object sender, EventArgs e ) {
			this.Invalidate();
		}

		private void StringedInstrument_MouseUp(object sender, MouseEventArgs e) {
			int spacingFrets = Width / (Frets + 1);
			int spacingStrings = Height / (Strings.Length + 1);
			float fretX = (float)e.X / (float)spacingFrets;
			float stringsY = (float)e.Y / (float)spacingStrings;
			int x = (int)Math.Round(fretX, 0);
			int y = (int)Math.Round(stringsY,0);
			System.Diagnostics.Debug.WriteLine("X: " + x + " - Y: " + y + " - Mouse X: " + e.X + " - Mouse Y: " + e.Y + " Fret X: " + fretX + " - Spacing Y: " + stringsY);
			int chosenFret = x;
			int chosenString = y;
			int[] note = new int[] { chosenFret, chosenString };
			if (mSelectedNotes.Contains(note)) {
				mSelectedNotes.Remove(note);
			} else {
				mSelectedNotes.Add(note);
			}
			drawSelectedNotes();
			playNote(x, y);
		}

		private void StringedInstrument_MouseMove(object sender, MouseEventArgs e) {
			int spacingFrets = Width / (Frets + 1);
			int spacingStrings = Height / (Strings.Length + 1);
			float fretX = (float)e.X / (float)spacingFrets;
			float stringsY = (float)e.Y / (float)spacingStrings;
			int x = (int)Math.Round(fretX, 0);
			int y = (int)Math.Round(stringsY, 0);
			if ( ( x != oldX || y != oldY)  ) {
				moveFret(x, y, oldX, oldY);
				oldX = x;
				oldY = y;
			}
		}

		private void moveFret(int x, int y, int oldX, int oldY) {
			x -= 1;
			y -= 1;
			oldX -= 1;
			oldY -= 1;
			int spacingFrets = Width / (Frets + 1);
			int spacingStrings = Height / (Strings.Length + 1);
			Graphics g = this.CreateGraphics();
			if (x >= 0 && y >= 0 && x < Frets && y < Strings.Length )
				g.FillEllipse(Brushes.SlateBlue, (spacingFrets * (x + 1)) - 8, (spacingStrings * (y + 1)) - 8, 16, 16);
			if (oldX >= 0 && oldY >= 0 && oldX < Frets && oldY < Strings.Length ) {
				g.FillEllipse(Brushes.White, (spacingFrets * (oldX + 1)) - 8, (spacingStrings * (oldY + 1)) - 8, 16, 16);
				int noteTextWidth = g.MeasureString(notes[oldY, oldX], noteFont).ToSize().Width;
				int noteTextHeight = g.MeasureString(notes[oldY, oldX], noteFont).ToSize().Height;
				g.DrawString(notes[oldY, oldX], noteFont, Brushes.Black, (spacingFrets * (oldX + 1)) - ( noteTextWidth / 2), (spacingStrings * (oldY + 1)) - ( noteTextHeight / 2));
				drawSelectedNotes();
			}
		}

		private void drawSelectedNotes() {
			int spacingFrets = Width / (Frets + 1);
			int spacingStrings = Height / (Strings.Length + 1);
			Graphics g = this.CreateGraphics();
			Brush b = Brushes.Blue;
			foreach (int[] note in mSelectedNotes) {
				int instrumentString = note[0];
				int instrumentFret = note[1];
				int x = spacingFrets * instrumentString - 5;
				int y = spacingStrings * instrumentFret - 5;
				g.FillEllipse(b, x, y, 10, 10);
			}
		}

		private void playNote(int x, int y) {
			InstrumentString instrumentString = Strings[y - 1];
			double steps = instrumentString.RootSteps + x - 1;
			double freq = ROOT_FREQ * Math.Pow(2, steps / 12);
			BeepCl beeper = new BeepCl();
			beeper.Beep(freq, 500);
		}

		private void StringedInstrument_Load(object sender, EventArgs e) {
			if (notes == null)
				notes = new String[Strings.Length, Frets];
		}
	}
}
