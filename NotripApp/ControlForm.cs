using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace LothianProductions.Notrip {
	public partial class ControlForm : Form {
		protected List<ComboBox> mInstrumentStringTunings = new List<ComboBox>();
		protected List<NumericUpDown> mInstrumentStringOctaves = new List<NumericUpDown>();
		protected List<Tuning> mRandomNotes = new List<Tuning>();
	
		public ControlForm() {
			InitializeComponent();
			ComboInstrument.SelectedIndex = 0;
			ComboKey.SelectedIndex = 0;
			ComboChord.SelectedIndex = 0;
			UpdateInstrumentStringControls();
		}

		private void ControlForm_Load( object sender, EventArgs e ) {			
			AudioMonitor.Instance().AudioDataUpdate += new AudioDataHandler( ProcessAudioData );
			AudioMonitor.Instance().Start();
		}

		private void ControlForm_FormClosing( object sender, FormClosingEventArgs e ) {
			if( AudioMonitor.Instance().IsRunning )
			    AudioMonitor.Instance().Stop();
			Application.Exit();
		}
		
		private delegate void UpdateAudioDataDelegate( byte[] samples, List<Sound> sounds );
		private void UpdateAudioData( byte[] samples, List<Sound> sounds ) {
			mOscilloscope.AddSamples( samples );
			InstrumentMain.Highlight( sounds, CheckPlayDetected.Checked );
			
			// Find and plot max amplitude for volume:
			byte max = (byte) 128;
			foreach( byte sample in samples )
			    max = Math.Max( max, sample );
				
			ProgressAmplitude.Value = max;
		}
		public void ProcessAudioData( byte[] samples, List<Sound> sounds ) {
			try {
				Invoke(
					new UpdateAudioDataDelegate( UpdateAudioData ),
					new Object[] { samples, sounds }
				);
			} catch(ObjectDisposedException) {}
			catch(InvalidOperationException) {}
		}

		private void CheckLefthanded_CheckedChanged( object sender, EventArgs e ) {
			InstrumentMain.LeftHanded = CheckLefthanded.Checked;
		}

		private void NumericStrings_ValueChanged(object sender, EventArgs e) {
			if( NumericStrings.Value < 1 ) {
				NumericStrings.Value = 1;
				return;
			}
				
			List<Tuning> list = new List<Tuning>();
			for( int i = 0; i < NumericStrings.Value; i++ )
				if( i > InstrumentMain.Strings.Length - 1 )
					list.Add( new Tuning( Note.A, 4 ) );
				else
					list.Add( InstrumentMain.Strings[i] );

			InstrumentMain.Strings = list.ToArray();
			UpdateInstrumentStringControls();
		}
		
		protected void UpdateInstrumentStringControls() {
			for( int i = 0; i < InstrumentMain.Strings.Length; i++ ) {
				// Control already exists:
				if( mInstrumentStringTunings.Count > i ) {
					mInstrumentStringTunings[i].Top = InstrumentMain.Top + ((InstrumentMain.Height / (InstrumentMain.Strings.Length + 1)) * (i + 1) ) - mInstrumentStringTunings[i].Height / 2;
					mInstrumentStringOctaves[i].Top = InstrumentMain.Top + ((InstrumentMain.Height / (InstrumentMain.Strings.Length + 1)) * (i + 1) ) - mInstrumentStringOctaves[i].Height / 2;
					mInstrumentStringTunings[i].SelectedIndex = NoteHelper.Instance().GetOrderedNotes().IndexOf( InstrumentMain.Strings[i].Note );
					mInstrumentStringOctaves[i].Value = InstrumentMain.Strings[i].Octave;
					mInstrumentStringTunings[i].Visible = true;
					mInstrumentStringOctaves[i].Visible = true;
				} else {
					ComboBox newBox = new ComboBox();
					newBox.FormattingEnabled = true;
					
					// FIXME can we optimise this?
					foreach( String note in NoteHelper.Instance().GetOrderedNoteNames() )
					    newBox.Items.Add( note );
					
					newBox.Size = new Size( 40, InstrumentMain.Height / (InstrumentMain.Strings.Length + 1) );
					newBox.Location = new Point(
						InstrumentMain.Location.X + InstrumentMain.Width,						
						InstrumentMain.Top + ((InstrumentMain.Height / (InstrumentMain.Strings.Length + 1)) * (i + 1)) - newBox.Height / 2
					);
					newBox.Name = "InstrumentStringTuningBox" + i;
					
					newBox.DropDownStyle = ComboBoxStyle.DropDownList;
					newBox.SelectedIndex = NoteHelper.Instance().GetOrderedNotes().IndexOf( InstrumentMain.Strings[i].Note );
					
					NumericUpDown newUpDown = new NumericUpDown();
					newUpDown.Size = new Size( 40, InstrumentMain.Height / (InstrumentMain.Strings.Length + 1) );
					newUpDown.Location = new Point(
						InstrumentMain.Location.X + InstrumentMain.Width + 40,
						InstrumentMain.Top + ((InstrumentMain.Height / (InstrumentMain.Strings.Length + 1)) * (i + 1)) - newUpDown.Height / 2
					);
					newUpDown.Name = "InstrumentStringOctaveNumeric" + i;
					newUpDown.Value = InstrumentMain.Strings[i].Octave;
					newUpDown.Minimum = 1;
					newUpDown.Maximum = 8;
					
					newBox.SelectedIndexChanged += new EventHandler( ComboTuning_SelectedIndexChanged );
					newUpDown.ValueChanged += new EventHandler( NumericOctave_ValueChanged );
					
					this.groupBox3.Controls.Add( newBox );
					this.groupBox3.Controls.Add( newUpDown);
					
					newUpDown.Show();
					newBox.Show();
					
					mInstrumentStringTunings.Add( newBox );
					mInstrumentStringOctaves.Add( newUpDown );
				}
			}
			
			// Hide older controls:
			for( int i = InstrumentMain.Strings.Length; i < mInstrumentStringTunings.Count; i++ ) {
				mInstrumentStringTunings[i].Visible = false;
				mInstrumentStringOctaves[i].Visible = false;
			}
			
			List<double> frequencies = new List<double>();
			
			foreach( Tuning instrumentString in InstrumentMain.Strings ) {
				for( int i = 0; i < InstrumentMain.Frets; i++ ) {
					double frequency = AudioMonitor.StepToFrequency( AudioMonitor.TuningToStep( instrumentString ) + i );
					
					if( ! frequencies.Contains( frequency ) )
						frequencies.Add( frequency );
				}
			}
			
			AudioMonitor.Instance().Frequencies = frequencies;
		}

		private void ComboTuning_SelectedIndexChanged( object sender, EventArgs e ) {
			int i = Int32.Parse( ((ComboBox) sender).Name.Substring( "InstrumentStringTuningBox".Length ) );
			InstrumentMain.Strings[i].Note = NoteHelper.Instance().GetOrderedNotes()[ mInstrumentStringTunings[i].SelectedIndex ];
			InstrumentMain.Invalidate();
		}

		private void NumericOctave_ValueChanged( object sender, EventArgs e ) {
			int i = Int32.Parse( ((NumericUpDown) sender).Name.Substring( "InstrumentStringOctaveNumeric".Length ) );
			InstrumentMain.Strings[i].Octave = (int) mInstrumentStringOctaves[i].Value;
			InstrumentMain.Invalidate();
		}

		private void NumericFrets_ValueChanged( object sender, EventArgs e ) {
			if( NumericStrings.Value < 1 ) {
				NumericStrings.Value = 1;
				return;
			}
		
			InstrumentMain.Frets = (int) NumericFrets.Value;
		}

		private void CheckShowFrequencies_CheckedChanged( object sender, EventArgs e ) {
			InstrumentMain.ShowFrequencies = CheckShowFrequencies.Checked;
		}

		private void CheckShowOctaves_CheckedChanged( object sender, EventArgs e ) {
			InstrumentMain.ShowOctaves = CheckShowOctaves.Checked;
		}

		private void ButtonPlay_Click( object sender, EventArgs e ) {
			Random r = new Random();
			
			lock( mRandomNotes ) {
				mRandomNotes.Clear();
				
				for( int i = 0; i < (int) NumericNumber.Value; i++ ) {
					// Find range:
					int min = 36, max = -36;
					foreach( Tuning instrumentString in InstrumentMain.Strings ) {
						max = Math.Max( max, AudioMonitor.TuningToStep( instrumentString ) + InstrumentMain.Frets - 1 );
						min = Math.Min( min, AudioMonitor.TuningToStep( instrumentString ) );
					}

					mRandomNotes.Add( AudioMonitor.StepToTuning( r.Next( min, max ) ) );
				}
			}
			ButtonRepeat_Click( sender, e );
		}

		private void ButtonRepeat_Click( object sender, EventArgs e ) {
			new Thread( new ThreadStart( PlayNotes ) ).Start();
		}
		
		private void PlayNotes() {
			Invoke(
				new PlayNotesDelegate( PlayNotesDelegated ),
				new Object[] {}
			);
		}

		private delegate void PlayNotesDelegate();
		private void PlayNotesDelegated() {
			lock( mRandomNotes ) {
				foreach( Tuning tuning in mRandomNotes ) {
					AudioMonitor.Instance().PlayNote( AudioMonitor.StepToFrequency( AudioMonitor.TuningToStep( tuning ) ), (int) NumericSpeed.Value * 500, this );
					Thread.Sleep( (int) NumericSpeed.Value * 500 );
				}
			}
		}

		private void NumericSensitivity_ValueChanged( object sender, EventArgs e ) {
			AudioMonitor.Instance().Sensitivity = (int) NumericSensitivity.Value;
		}

		private void TimerDemo_Tick( object sender, EventArgs e ) {
			if( AudioMonitor.Instance().IsRunning )
				AudioMonitor.Instance().Stop();
			Hide();
			
			MessageBox.Show( this, "This test version of Notrip may only be run for three minutes. It will now shut down.\n\nA newer version might be available, let's see...", "Notrip", MessageBoxButtons.OK, MessageBoxIcon.Information );
			System.Diagnostics.Process.Start( "http://www.lothianproductions.co.uk/notrip" );
			Application.Exit();		
		}
	}
}