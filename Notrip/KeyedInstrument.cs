using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LothianProductions.Notrip {

	public partial class KeyedInstrument : UserControl {
		public KeyedInstrument() {
			InitializeComponent();
			mMajorKeys = 24;
			mFirstKey = new Tuning();
			mShowOctaves = false;
			mShowFrequencies = false;
		}

		protected int mMajorKeys;
		public int MajorKeys {
			get{ return mMajorKeys; }
			set{
				mMajorKeys = value;
				Invalidate();
			}
		}
		
		protected Tuning mFirstKey;
		public Tuning FirstKey {
			get{ return mFirstKey; }
			set{
				mFirstKey = value;
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
		
		protected bool mShowFrequencies;
		public bool ShowFrequencies {
			get{ return mShowFrequencies; }
			set{
				mShowFrequencies = value;
				Invalidate();
			}
		}
		
		private void KeyedInstrument_Paint( object sender, PaintEventArgs e ) {
			int keyWidth = Width / mMajorKeys;
			int octave, step = AudioMonitor.TuningToStep( mFirstKey );
			Graphics g = e.Graphics;
			
			g.DrawLine( Pens.Black, 0, 0, 0, Height );
			
			int i;
			
			for( i = keyWidth; i <= Width; i += keyWidth ) {
				String label;
				
				if( ! mShowFrequencies ) {
					label = NoteHelper.Instance().GetNoteName( AudioMonitor.StepToNote( step++, out octave ) );
				
					if( mShowOctaves )
						label += octave;
				} else
					label = AudioMonitor.StepToFrequency( step++ ) + "";
				
				// Black key:
				if( NoteHelper.Instance().GetNoteName( AudioMonitor.StepToNote( step - 1, out octave ) ).Length > 1 ) {
					g.FillRectangle( Brushes.Black, i - (keyWidth / 3), 0, (float) (keyWidth / 1.5), Height / 2 );
					g.DrawString( label, Font, Brushes.White, i - (g.MeasureString( label, Font ).Width / 2), (Height / 3) * 1 );

					if( ! mShowFrequencies ) {
						label = NoteHelper.Instance().GetNoteName( AudioMonitor.StepToNote( step++, out octave ) );
					
						if( mShowOctaves )
							label += octave;
					} else
						label = AudioMonitor.StepToFrequency( step++ ) + "";			
				}
				
				g.DrawLine( Pens.Black, i, 0, i, Height );
				g.DrawString( label, Font, Brushes.Black, i - (keyWidth / 2) - (g.MeasureString( label, Font ).Width / 2), (Height / 3) * 2 );
			}
			
			g.DrawLine( Pens.Black, 0, 0, i - keyWidth, 0 );
			g.DrawLine( Pens.Black, 0, Height - 1, i - keyWidth, Height - 1 );
		}

		private void KeyedInstrument_Resize( object sender, EventArgs e ) {
			Invalidate();
		}
	}		
}