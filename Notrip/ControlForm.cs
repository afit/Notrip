using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using Microsoft.DirectX.DirectSound;

namespace LothianProductions.Notrip {
	public partial class ControlForm : Form {
		public ControlForm() {
			InitializeComponent();
		}

		private void ControlForm_Load( object sender, EventArgs e ) {			
			AudioMonitor.Instance().AudioDataUpdate += new AudioDataHandler( ProcessAudioData );
		}

		private void button1_Click( object sender, EventArgs e ) {
			if( AudioMonitor.Instance().IsRunning )
			    AudioMonitor.Instance().Stop();
			else
				AudioMonitor.Instance().Start();
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
	}
}