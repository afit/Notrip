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
	
		public ControlForm() {
			InitializeComponent();
			UpdateInstrumentStringControls();
		}

		private void ControlForm_Load( object sender, EventArgs e ) {			
			AudioMonitor.Instance().AudioDataUpdate += new AudioDataHandler( ProcessAudioData );
			AudioMonitor.Instance().SpectralAnalysisUpdate += new SpectralAnalysisHandler( ProcessSpectralAnalysis );
		}

		private void ControlForm_FormClosing( object sender, FormClosingEventArgs e ) {
			if( AudioMonitor.Instance().IsRunning )
			    AudioMonitor.Instance().Stop();
		}
		
		private delegate void UpdateAudioDataDelegate( byte[] samples );
		private void UpdateAudioData( byte[] samples ) {
			mOscilloscope.AddSamples( samples );
			
			// Find and plot max amplitude for volume:
			byte max = (byte) 128;
			foreach( byte sample in samples )
				max = Math.Max( max, sample );
				
			ProgressAmplitude.Value = max;
		}
		public void ProcessAudioData( byte[] samples ) {
			try {
				Invoke(
					new UpdateAudioDataDelegate( UpdateAudioData ),
					new Object[] { samples }
				);
			} catch(ObjectDisposedException) {}
		}

		private delegate void UpdateSpectralAnalysisDelegate( Dictionary<double, int> frequencies );
		private void UpdateSpectralAnalysis( Dictionary<double, int> frequencies ) {
			InstrumentMain.Highlight( frequencies );
		}
		public void ProcessSpectralAnalysis( Dictionary<double, int> frequencies ) {
			try {
				Invoke(
					new UpdateSpectralAnalysisDelegate( UpdateSpectralAnalysis ),
					new Object[] { frequencies }
				);
			} catch(ObjectDisposedException) {}
		}

		private void CheckLefthanded_CheckedChanged( object sender, EventArgs e ) {
			InstrumentMain.LeftHanded = CheckLefthanded.Checked;
		}

		private void NumericStrings_ValueChanged(object sender, EventArgs e) {
			if( NumericStrings.Value < 1 ) {
				NumericStrings.Value = 1;
				return;
			}
				
			List<InstrumentString> list = new List<InstrumentString>();
			for( int i = 0; i < NumericStrings.Value; i++ )
				if( i > InstrumentMain.Strings.Length - 1 )
					list.Add( new InstrumentString( Note.A, 4 ) );
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
					mInstrumentStringTunings[i].SelectedIndex = NoteHelper.Instance().GetOrderedNotes().IndexOf( InstrumentMain.Strings[i].RootNote );
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
					newBox.SelectedIndex = NoteHelper.Instance().GetOrderedNotes().IndexOf( InstrumentMain.Strings[i].RootNote );
					
					NumericUpDown newUpDown = new NumericUpDown();
					newUpDown.Size = new Size( 40, InstrumentMain.Height / (InstrumentMain.Strings.Length + 1) );
					newUpDown.Location = new Point(
						InstrumentMain.Location.X + InstrumentMain.Width + 40,
						InstrumentMain.Top + ((InstrumentMain.Height / (InstrumentMain.Strings.Length + 1)) * (i + 1)) - newUpDown.Height / 2
						//InstrumentMain.Height / (InstrumentMain.Strings.Length + 1) * (i + 1) + InstrumentMain.Location.Y - (InstrumentMain.Height / (InstrumentMain.Strings.Length + 1)/2)
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
		}

		private void ComboTuning_SelectedIndexChanged( object sender, EventArgs e ) {
			int i = Int32.Parse( ((ComboBox) sender).Name.Substring( "InstrumentStringTuningBox".Length ) );
			InstrumentMain.Strings[i].RootNote = NoteHelper.Instance().GetOrderedNotes()[ mInstrumentStringTunings[i].SelectedIndex ];
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

		private void mOscilloscope_Click( object sender, EventArgs e ) {
			if( AudioMonitor.Instance().IsRunning )
			    AudioMonitor.Instance().Stop();
			else
				AudioMonitor.Instance().Start();
		}

		private void CheckShowFrequencies_CheckedChanged( object sender, EventArgs e ) {
			InstrumentMain.ShowFrequencies = CheckShowFrequencies.Checked;
		}
	}
}