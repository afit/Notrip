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
		public ControlForm() {
			InitializeComponent();
		}

		private void ControlForm_Load( object sender, EventArgs e ) {			
			AudioMonitor.Instance().AudioDataUpdate += new AudioDataHandler( ProcessAudioData );
		}

		private void ControlForm_FormClosing( object sender, FormClosingEventArgs e ) {
			if( AudioMonitor.Instance().IsRunning )
			    AudioMonitor.Instance().Stop();
		}
		
		private delegate void UpdateRawDataDelegate( byte[] samples );
		private void UpdateRawData( byte[] samples ) {
			mOscilloscope.AddSamples( samples );
		}
		
		public void ProcessAudioData( byte[] samples ) {
			try {
				Invoke(
					new UpdateRawDataDelegate( UpdateRawData ),
					new Object[] { samples }
				);
			} catch(ObjectDisposedException ) {}
		}

		private void CheckLefthanded_CheckedChanged( object sender, EventArgs e ) {
			InstrumentMain.LeftHanded = CheckLefthanded.Checked;
		}

		private void NumericStrings_ValueChanged(object sender, EventArgs e) {
			//if( NumericStrings.Value > InstrumentMain.Strings.Count )
			//    InstrumentMain.Strings.Add( new InstrumentString( Note.E, 7 ) );
			//else
			//    InstrumentMain.Strings.RemoveAt( InstrumentMain.Strings.Count - 1 );
			//InstrumentMain.Invalidate();
		}

		private void NumericFrets_ValueChanged( object sender, EventArgs e ) {
			InstrumentMain.Frets = (int) NumericFrets.Value;
		}

		private void mOscilloscope_Click( object sender, EventArgs e ) {
			if( AudioMonitor.Instance().IsRunning )
			    AudioMonitor.Instance().Stop();
			else
				AudioMonitor.Instance().Start();
		}
	}
}