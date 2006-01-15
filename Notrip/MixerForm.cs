using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

using WaveLib.AudioMixer;

using WaveLib.NativeApi;

namespace MixerTest {
	public class MixerForm : System.Windows.Forms.Form {
		private System.Windows.Forms.Label			lblOutput;
		private System.Windows.Forms.Label			lblInput;
		private System.Windows.Forms.Label			lblMixer;
		private System.Windows.Forms.ComboBox		cboOutputDevices;
		private System.Windows.Forms.ComboBox		cboInputDevices;
		private System.Windows.Forms.TrackBar[][]	tBarArray;
		private System.Windows.Forms.TrackBar[][]	tBarBalanceArray;
		private System.Windows.Forms.Label[][]		lblArray;
		private System.Windows.Forms.CheckBox[][]	chkBoxArray;
		private System.Windows.Forms.GroupBox		gbSplit;
		private System.ComponentModel.IContainer	components = null;

		private Mixers	mMixers;
		private bool	mAvoidEvents;

		public MixerForm()
		{
			InitializeComponent();
			tBarArray		= new TrackBar[2][];
			tBarBalanceArray= new TrackBar[2][];
			lblArray		= new Label[2][];
			chkBoxArray		= new CheckBox[2][];

			//Initialization
			mMixers = new Mixers();
			mMixers.Playback.MixerLineChanged += new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(mMixer_MixerLineChanged);
			mMixers.Recording.MixerLineChanged += new WaveLib.AudioMixer.Mixer.MixerLineChangeHandler(mMixer_MixerLineChanged);
		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				this.Load -= new System.EventHandler(this.Form1_Load);
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MixerForm));
			this.cboOutputDevices = new System.Windows.Forms.ComboBox();
			this.lblOutput = new System.Windows.Forms.Label();
			this.lblInput = new System.Windows.Forms.Label();
			this.cboInputDevices = new System.Windows.Forms.ComboBox();
			this.lblMixer = new System.Windows.Forms.Label();
			this.gbSplit = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// cboOutputDevices
			// 
			this.cboOutputDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboOutputDevices.Location = new System.Drawing.Point(88, 32);
			this.cboOutputDevices.Name = "cboOutputDevices";
			this.cboOutputDevices.Size = new System.Drawing.Size(192, 21);
			this.cboOutputDevices.TabIndex = 2;
			this.cboOutputDevices.SelectedIndexChanged += new System.EventHandler(this.cboOutputDevices_SelectedIndexChanged);
			// 
			// lblOutput
			// 
			this.lblOutput.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblOutput.Location = new System.Drawing.Point(12, 32);
			this.lblOutput.Name = "lblOutput";
			this.lblOutput.Size = new System.Drawing.Size(100, 16);
			this.lblOutput.TabIndex = 4;
			this.lblOutput.Text = "Playback";
			// 
			// lblInput
			// 
			this.lblInput.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblInput.Location = new System.Drawing.Point(12, 259);
			this.lblInput.Name = "lblInput";
			this.lblInput.Size = new System.Drawing.Size(100, 20);
			this.lblInput.TabIndex = 8;
			this.lblInput.Text = "Recording";
			// 
			// cboInputDevices
			// 
			this.cboInputDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboInputDevices.Location = new System.Drawing.Point(88, 259);
			this.cboInputDevices.Name = "cboInputDevices";
			this.cboInputDevices.Size = new System.Drawing.Size(192, 21);
			this.cboInputDevices.TabIndex = 6;
			this.cboInputDevices.SelectedIndexChanged += new System.EventHandler(this.cboInputDevices_SelectedIndexChanged);
			// 
			// lblMixer
			// 
			this.lblMixer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblMixer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMixer.Location = new System.Drawing.Point(16, 8);
			this.lblMixer.Name = "lblMixer";
			this.lblMixer.Size = new System.Drawing.Size(776, 16);
			this.lblMixer.TabIndex = 9;
			this.lblMixer.Text = "Mixer Controls";
			this.lblMixer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// gbSplit
			// 
			this.gbSplit.Location = new System.Drawing.Point(0, 243);
			this.gbSplit.Name = "gbSplit";
			this.gbSplit.Size = new System.Drawing.Size(800, 8);
			this.gbSplit.TabIndex = 10;
			this.gbSplit.TabStop = false;
			// 
			// MixerForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(800, 486);
			this.Controls.Add(this.gbSplit);
			this.Controls.Add(this.cboInputDevices);
			this.Controls.Add(this.cboOutputDevices);
			this.Controls.Add(this.lblMixer);
			this.Controls.Add(this.lblInput);
			this.Controls.Add(this.lblOutput);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(2000, 520);
			this.MinimumSize = new System.Drawing.Size(0, 520);
			this.Name = "MixerForm";
			this.Text = "Mixer";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion


		private void Form1_Load(object sender, System.EventArgs e)
		{
			LoadComboSettings();
		}

		private void cboInputDevices_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadLines(MixerType.Recording);
		}

		private void cboOutputDevices_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadLines(MixerType.Playback);
		}

		private void tBar_ValueChanged(object sender, EventArgs e)
		{
			if (mAvoidEvents)
				return;

			TrackBar tBar = (TrackBar) sender;
			MixerLine line = (MixerLine) tBar.Tag;
			if (line.Channels != 2)
			{
				// One channel or more than two let set the volume uniform
				line.Channel = Channel.Uniform;
				line.Volume = tBar.Value;
			}
			else
			{
				//Set independent volume
				foreach(TrackBar tBarBalance in tBarBalanceArray[(int) line.Mixer.MixerType])
				{
					MixerLine frontEndLine = (MixerLine) tBarBalance.Tag;
					if (frontEndLine == line)
					{
						if (tBarBalance.Value == 0)
						{
							line.Channel = Channel.Uniform;
							line.Volume = tBar.Value;
						}
						if (tBarBalance.Value <= 0)
						{
							// Left channel is bigger
							line.Channel = Channel.Left;
							line.Volume = tBar.Value;
							line.Channel = Channel.Right;
							line.Volume = (int) (tBar.Value * (1 + (tBarBalance.Value / (float) tBarBalance.Maximum)));
						}
						else
						{
							// Right channel is bigger
							line.Channel = Channel.Right;
							line.Volume = tBar.Value;
							line.Channel = Channel.Left;
							line.Volume = (int) (tBar.Value * (1 - (tBarBalance.Value / (float) tBarBalance.Maximum)));
						}
						break;
					}
				}			
			}
		}

		private void tBarBalance_ValueChanged(object sender, EventArgs e)
		{
			if (mAvoidEvents)
				return;

			TrackBar tBarBalance = (TrackBar) sender;
			MixerLine line = (MixerLine) tBarBalance.Tag;

			//This demo just set balance when they are just 2 channels
			if (line.Channels == 2)
			{
				//Set independent volume
				foreach(TrackBar tBarVolume in tBarArray[(int) line.Mixer.MixerType])
				{
					MixerLine frontEndLine = (MixerLine) tBarVolume.Tag;
					if (frontEndLine == line)
					{
						if (tBarBalance.Value == 0)
						{
							line.Channel = Channel.Uniform;
							line.Volume = tBarVolume.Value;
						}
						if (tBarBalance.Value <= 0)
						{
							// Left channel is bigger
							line.Channel = Channel.Left;
							line.Volume = tBarVolume.Value;
							line.Channel = Channel.Right;
							line.Volume = (int) (tBarVolume.Value * (1 + (tBarBalance.Value / (float) tBarBalance.Maximum)));
						}
						else
						{
							// Rigth channel is bigger
							line.Channel = Channel.Right;
							line.Volume = tBarVolume.Value;
							line.Channel = Channel.Left;
							line.Volume = (int) (tBarVolume.Value * (1 - (tBarBalance.Value / (float) tBarBalance.Maximum)));
						}
						break;
					}
				}			
			}
		}

		private void Form1_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox chkBox = (CheckBox) sender;
			MixerLine line = (MixerLine) chkBox.Tag;
			if (line.Direction == MixerType.Recording)
				line.Selected = chkBox.Checked;
			else
				line.Mute = chkBox.Checked;
		}

		private void mMixer_MixerLineChanged(Mixer mixer, MixerLine line)
		{
			mAvoidEvents = true;

			try
			{
				float balance = -1;
				foreach(TrackBar tBar in tBarArray[(int) mixer.MixerType])
				{
					MixerLine frontEndLine = (MixerLine) tBar.Tag;
					if (frontEndLine == line)
					{
						int volume = 0;
						if (line.Channels != 2)
							volume = line.Volume;
						else
						{
							line.Channel = Channel.Left;
							int left	= line.Volume;
							line.Channel = Channel.Right;
							int right	= line.Volume;
							if (left > right)
							{
								volume = left;
								// TIP: Do not reset the balance if both left and right channel have 0 value
								if (left != 0 && right != 0)
									balance = (volume > 0) ? -(1 - (right / (float) left)) : 0;
							}
							else
							{
								volume = right;
								// TIP: Do not reset the balance if both left and right channel have 0 value
								if (left != 0 && right != 0)
									balance = (volume > 0) ? 1 - (left / (float) right) : 0;
							}
						}

						if (volume >= 0)
							tBar.Value = volume;
						break;
					}
				}
				//Set the balance
				if (balance != -1)
				{
					foreach(TrackBar tBar in tBarBalanceArray[(int) mixer.MixerType])
					{
						MixerLine frontEndLine = (MixerLine) tBar.Tag;
						if (frontEndLine == line)
						{
							tBar.Value = (int) (tBar.Maximum * balance);
							break;
						}
					}
				}

				foreach(CheckBox checkBox in chkBoxArray[(int) mixer.MixerType])
				{
					MixerLine frontEndLine = (MixerLine) checkBox.Tag;
					if (frontEndLine == line)
					{
						if (line.Direction == MixerType.Recording)
							checkBox.Checked = line.Selected;
						else
							checkBox.Checked = line.Mute;
						break;
					}
				}
			}
			finally
			{
				mAvoidEvents = false;
			}
		}

		private void LoadComboSettings()
		{
			//Load Output Combo
			MixerDetail mixerDetailDefault		= new MixerDetail();
			mixerDetailDefault.DeviceId			= -1;
			mixerDetailDefault.MixerName		= "Default";
			mixerDetailDefault.SupportWaveOut	= true;
			cboOutputDevices.Items.Add(mixerDetailDefault);

			foreach(MixerDetail mixerDetail in mMixers.Playback.Devices)
				cboOutputDevices.Items.Add(mixerDetail);
			cboOutputDevices.SelectedIndex = 0;

			//Load Input Combo
			mixerDetailDefault					= new MixerDetail();
			mixerDetailDefault.DeviceId			= -1;
			mixerDetailDefault.MixerName		= "Default";
			mixerDetailDefault.SupportWaveIn	= true;
			cboInputDevices.Items.Add(mixerDetailDefault);

			foreach(MixerDetail mixerDetail in mMixers.Recording.Devices)
				cboInputDevices.Items.Add(mixerDetail);
			cboInputDevices.SelectedIndex = 0;
		}

		private void LoadLines(MixerType mixerType)
		{
			//Reload Line. Clear old controls
			if (tBarArray[(int) mixerType] != null)
				for(int i=0;i<tBarArray[(int) mixerType].Length;i++)	
				{
					tBarArray[(int) mixerType][i].ValueChanged -= new System.EventHandler(this.tBar_ValueChanged);
					tBarArray[(int) mixerType][i].Dispose();
					tBarBalanceArray[(int) mixerType][i].Dispose();
					lblArray[(int) mixerType][i].Dispose();
					chkBoxArray[(int) mixerType][i].Dispose();
					this.Controls.Remove(tBarArray[(int) mixerType][i]);
					this.Controls.Remove(tBarBalanceArray[(int) mixerType][i]);
					this.Controls.Remove(lblArray[(int) mixerType][i]);
					this.Controls.Remove(chkBoxArray[(int) mixerType][i]);
				}

			MixerLines	lines;

			//Get info about the lines
			if (mixerType == MixerType.Recording)
			{
				mMixers.Recording.DeviceId = ((MixerDetail) cboInputDevices.SelectedItem).DeviceId;
				lines = mMixers.Recording.UserLines;
			}
			else
			{
				mMixers.Playback.DeviceId = ((MixerDetail) cboOutputDevices.SelectedItem).DeviceId;
				lines = mMixers.Playback.UserLines;
			}
			
			tBarArray[(int) mixerType]			= new TrackBar[lines.Count];
			tBarBalanceArray[(int) mixerType]	= new TrackBar[lines.Count];
			lblArray[(int) mixerType]			= new Label[lines.Count];
			chkBoxArray[(int) mixerType]		= new CheckBox[lines.Count];
			
			//foreach(MixerLine line in lines)
			for(int i=0;i<lines.Count;i++)
			{
				MixerLine line = lines[i];

				// TrackBar creation
				this.tBarArray[(int) mixerType][i] = new System.Windows.Forms.TrackBar();
				this.tBarArray[(int) mixerType][i].LargeChange = 10000;
				this.tBarArray[(int) mixerType][i].Location = new System.Drawing.Point(i * 60 + 10, 120 + (int) mixerType * 225);
				this.tBarArray[(int) mixerType][i].Maximum = 65535;
				this.tBarArray[(int) mixerType][i].Name = "tBarArray" + ((int) mixerType).ToString() + i.ToString();
				this.tBarArray[(int) mixerType][i].Orientation = Orientation.Vertical;
				this.tBarArray[(int) mixerType][i].Size = new System.Drawing.Size(45, 100);
				this.tBarArray[(int) mixerType][i].SmallChange = 6553;
				this.tBarArray[(int) mixerType][i].TabIndex = i;
				this.tBarArray[(int) mixerType][i].TickFrequency = 6553;
				this.tBarArray[(int) mixerType][i].TickStyle = System.Windows.Forms.TickStyle.Both;
				this.tBarArray[(int) mixerType][i].Tag = line;

				//If it is 2 channels then ask both and set the volume to the bigger but keep relation between them (Balance)
				int volume = 0;
				float balance = 0;
				if (lines[i].Channels != 2)
					volume = lines[i].Volume;
				else
				{
					lines[i].Channel = Channel.Left;
					int left	= lines[i].Volume;
					lines[i].Channel = Channel.Right;
					int right	= lines[i].Volume;
					if (left > right)
					{
						volume = left;
						balance = (volume > 0) ? -(1 - (right / (float) left)) : 0;
					}
					else
					{
						volume = right;
						balance = (volume > 0) ? (1 - (left / (float) right)) : 0;
					}
				}

				if (volume >= 0)
					this.tBarArray[(int) mixerType][i].Value = volume;
				else
					this.tBarArray[(int) mixerType][i].Enabled = false;
				this.tBarArray[(int) mixerType][i].ValueChanged += new System.EventHandler(this.tBar_ValueChanged);

				this.Controls.Add(this.tBarArray[(int) mixerType][i]);

				//TrackBar Balance Creation
				this.tBarBalanceArray[(int) mixerType][i] = new System.Windows.Forms.TrackBar();
				this.tBarBalanceArray[(int) mixerType][i].AutoSize	= false;
				this.tBarBalanceArray[(int) mixerType][i].Location = new System.Drawing.Point(i * 60, 85 + (int) mixerType * 225);
				this.tBarBalanceArray[(int) mixerType][i].Maximum = 320;
				this.tBarBalanceArray[(int) mixerType][i].Minimum = -320;
				this.tBarBalanceArray[(int) mixerType][i].Name = "tBarBalanceArray" + ((int) mixerType).ToString() + i.ToString();
				this.tBarBalanceArray[(int) mixerType][i].Size = new System.Drawing.Size(60, 30);
				this.tBarBalanceArray[(int) mixerType][i].TickFrequency = 320;
				this.tBarBalanceArray[(int) mixerType][i].TabIndex = i;
				this.tBarBalanceArray[(int) mixerType][i].SmallChange = 10;
				this.tBarBalanceArray[(int) mixerType][i].LargeChange = 50;
				this.tBarBalanceArray[(int) mixerType][i].Tag = line;
				
				//MONO OR MORE THAN 2 CHANNELS, then let disable balance
				if (lines[i].Channels != 2)
					this.tBarBalanceArray[(int) mixerType][i].Enabled = false;
				else
					this.tBarBalanceArray[(int) mixerType][i].Value = (int) (this.tBarBalanceArray[(int) mixerType][i].Maximum * balance);

				this.tBarBalanceArray[(int) mixerType][i].ValueChanged += new System.EventHandler(this.tBarBalance_ValueChanged);

				this.Controls.Add(this.tBarBalanceArray[(int) mixerType][i]);

				//Label Creation
				this.lblArray[(int) mixerType][i] = new System.Windows.Forms.Label();
				this.lblArray[(int) mixerType][i].Location = new System.Drawing.Point(i * 60, 60 + (int) mixerType * 225);
				this.lblArray[(int) mixerType][i].Name = "lblArray" + ((int) mixerType).ToString() + i.ToString();
				this.lblArray[(int) mixerType][i].Size = new System.Drawing.Size(65, 26);
				this.lblArray[(int) mixerType][i].TabIndex = 10;
				this.lblArray[(int) mixerType][i].TextAlign = System.Drawing.ContentAlignment.BottomCenter;
				this.lblArray[(int) mixerType][i].Text = line.Name;
				this.Controls.Add(this.lblArray[(int) mixerType][i]);

				//CheckBox Creation
				this.chkBoxArray[(int) mixerType][i] = new System.Windows.Forms.CheckBox();
				this.chkBoxArray[(int) mixerType][i].Location = new System.Drawing.Point(i * 60 + 10, 225 + (int) mixerType * 225);
				this.chkBoxArray[(int) mixerType][i].Name = "chkMuteSelect" + ((int) mixerType).ToString() + i.ToString();
				this.chkBoxArray[(int) mixerType][i].Size = new System.Drawing.Size(60, 16);
				this.chkBoxArray[(int) mixerType][i].Enabled = false;
				this.chkBoxArray[(int) mixerType][i].TabIndex = 10;
				this.chkBoxArray[(int) mixerType][i].Tag = line;
				if (mixerType == MixerType.Recording)
				{
					this.chkBoxArray[(int) mixerType][i].Text = "Select";
					if (line.ContainsSelected)
					{
						this.chkBoxArray[(int) mixerType][i].Enabled = true;
						this.chkBoxArray[(int) mixerType][i].Checked = line.Selected;
					}
				}
				else
				{
					this.chkBoxArray[(int) mixerType][i].Text = "Mute";
					if (line.ContainsMute)
					{
						this.chkBoxArray[(int) mixerType][i].Enabled = true;
						this.chkBoxArray[(int) mixerType][i].Checked = line.Mute;
					}
				}
				this.chkBoxArray[(int) mixerType][i].CheckedChanged += new EventHandler(Form1_CheckedChanged);
				this.Controls.Add(this.chkBoxArray[(int) mixerType][i]);
			}
		}
		protected override void OnResize(EventArgs e)
		{
			gbSplit.Width = this.ClientRectangle.Width;
			base.OnResize (e);
		}
	}
}
