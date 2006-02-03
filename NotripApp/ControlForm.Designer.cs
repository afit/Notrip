namespace LothianProductions.Notrip {
	partial class ControlForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if( disposing && ( components != null ) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
			this.ComboKey = new System.Windows.Forms.ComboBox();
			this.CheckLefthanded = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.RadioDrawScales = new System.Windows.Forms.RadioButton();
			this.RadioDrawChords = new System.Windows.Forms.RadioButton();
			this.RadioDrawAudio = new System.Windows.Forms.RadioButton();
			this.RadioNinth = new System.Windows.Forms.RadioButton();
			this.RadioSixth = new System.Windows.Forms.RadioButton();
			this.RadioSeventh = new System.Windows.Forms.RadioButton();
			this.NumericStrings = new System.Windows.Forms.NumericUpDown();
			this.ComboInstrument = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.InstrumentKeyed = new LothianProductions.Notrip.KeyedInstrument();
			this.label8 = new System.Windows.Forms.Label();
			this.NumericSensitivity = new System.Windows.Forms.NumericUpDown();
			this.CheckPlayDetected = new System.Windows.Forms.CheckBox();
			this.CheckShowOctaves = new System.Windows.Forms.CheckBox();
			this.InstrumentStringed = new LothianProductions.Notrip.StringedInstrument();
			this.CheckShowFrequencies = new System.Windows.Forms.CheckBox();
			this.NumericFrets = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.NumericSpeed = new System.Windows.Forms.NumericUpDown();
			this.NumericNumber = new System.Windows.Forms.NumericUpDown();
			this.ButtonRepeat = new System.Windows.Forms.Button();
			this.ButtonPlay = new System.Windows.Forms.Button();
			this.GroupWaveformPreview = new System.Windows.Forms.GroupBox();
			this.ProgressAmplitude = new System.Windows.Forms.ProgressBar();
			this.mOscilloscope = new LothianProductions.Notrip.Oscilloscope();
			this.label6 = new System.Windows.Forms.Label();
			this.ComboChord = new System.Windows.Forms.ComboBox();
			this.RadioFifth = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.TimerDemo = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericStrings)).BeginInit();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericSensitivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericFrets)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericNumber)).BeginInit();
			this.GroupWaveformPreview.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// ComboKey
			// 
			this.ComboKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboKey.FormattingEnabled = true;
			this.ComboKey.Items.AddRange(new object[] {
            "A",
            "Bb",
            "B",
            "C",
            "C#",
            "D",
            "D#",
            "E",
            "F",
            "F#",
            "G",
            "G#"});
			this.ComboKey.Location = new System.Drawing.Point(48, 47);
			this.ComboKey.Name = "ComboKey";
			this.ComboKey.Size = new System.Drawing.Size(66, 21);
			this.ComboKey.TabIndex = 5;
			// 
			// CheckLefthanded
			// 
			this.CheckLefthanded.AutoSize = true;
			this.CheckLefthanded.Location = new System.Drawing.Point(275, 47);
			this.CheckLefthanded.Name = "CheckLefthanded";
			this.CheckLefthanded.Size = new System.Drawing.Size(83, 17);
			this.CheckLefthanded.TabIndex = 16;
			this.CheckLefthanded.Text = "Left-handed";
			this.CheckLefthanded.UseVisualStyleBackColor = true;
			this.CheckLefthanded.CheckedChanged += new System.EventHandler(this.CheckLefthanded_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Key:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.RadioDrawScales);
			this.groupBox1.Controls.Add(this.RadioDrawChords);
			this.groupBox1.Controls.Add(this.RadioDrawAudio);
			this.groupBox1.Location = new System.Drawing.Point(396, 237);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(106, 91);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Highlighting";
			// 
			// RadioDrawScales
			// 
			this.RadioDrawScales.AutoSize = true;
			this.RadioDrawScales.Enabled = false;
			this.RadioDrawScales.Location = new System.Drawing.Point(11, 65);
			this.RadioDrawScales.Name = "RadioDrawScales";
			this.RadioDrawScales.Size = new System.Drawing.Size(83, 17);
			this.RadioDrawScales.TabIndex = 22;
			this.RadioDrawScales.Text = "Draw scales";
			this.RadioDrawScales.UseVisualStyleBackColor = true;
			// 
			// RadioDrawChords
			// 
			this.RadioDrawChords.AutoSize = true;
			this.RadioDrawChords.Enabled = false;
			this.RadioDrawChords.Location = new System.Drawing.Point(11, 42);
			this.RadioDrawChords.Name = "RadioDrawChords";
			this.RadioDrawChords.Size = new System.Drawing.Size(85, 17);
			this.RadioDrawChords.TabIndex = 21;
			this.RadioDrawChords.Text = "Draw chords";
			this.RadioDrawChords.UseVisualStyleBackColor = true;
			// 
			// RadioDrawAudio
			// 
			this.RadioDrawAudio.AutoSize = true;
			this.RadioDrawAudio.Checked = true;
			this.RadioDrawAudio.Location = new System.Drawing.Point(11, 19);
			this.RadioDrawAudio.Name = "RadioDrawAudio";
			this.RadioDrawAudio.Size = new System.Drawing.Size(79, 17);
			this.RadioDrawAudio.TabIndex = 20;
			this.RadioDrawAudio.TabStop = true;
			this.RadioDrawAudio.Text = "Draw audio";
			this.RadioDrawAudio.UseVisualStyleBackColor = true;
			// 
			// RadioNinth
			// 
			this.RadioNinth.AutoSize = true;
			this.RadioNinth.Location = new System.Drawing.Point(57, 97);
			this.RadioNinth.Name = "RadioNinth";
			this.RadioNinth.Size = new System.Drawing.Size(40, 17);
			this.RadioNinth.TabIndex = 17;
			this.RadioNinth.TabStop = true;
			this.RadioNinth.Text = "9th";
			this.RadioNinth.UseVisualStyleBackColor = true;
			// 
			// RadioSixth
			// 
			this.RadioSixth.AutoSize = true;
			this.RadioSixth.Location = new System.Drawing.Point(57, 74);
			this.RadioSixth.Name = "RadioSixth";
			this.RadioSixth.Size = new System.Drawing.Size(40, 17);
			this.RadioSixth.TabIndex = 15;
			this.RadioSixth.TabStop = true;
			this.RadioSixth.Text = "6th";
			this.RadioSixth.UseVisualStyleBackColor = true;
			// 
			// RadioSeventh
			// 
			this.RadioSeventh.AutoSize = true;
			this.RadioSeventh.Location = new System.Drawing.Point(11, 97);
			this.RadioSeventh.Name = "RadioSeventh";
			this.RadioSeventh.Size = new System.Drawing.Size(40, 17);
			this.RadioSeventh.TabIndex = 13;
			this.RadioSeventh.TabStop = true;
			this.RadioSeventh.Text = "7th";
			this.RadioSeventh.UseVisualStyleBackColor = true;
			// 
			// NumericStrings
			// 
			this.NumericStrings.Location = new System.Drawing.Point(55, 44);
			this.NumericStrings.Name = "NumericStrings";
			this.NumericStrings.Size = new System.Drawing.Size(46, 20);
			this.NumericStrings.TabIndex = 20;
			this.NumericStrings.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
			this.NumericStrings.ValueChanged += new System.EventHandler(this.NumericStrings_ValueChanged);
			// 
			// ComboInstrument
			// 
			this.ComboInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboInstrument.FormattingEnabled = true;
			this.ComboInstrument.Items.AddRange(new object[] {
            "Stringed instrument",
            "Keyed instrument"});
			this.ComboInstrument.Location = new System.Drawing.Point(55, 17);
			this.ComboInstrument.Name = "ComboInstrument";
			this.ComboInstrument.Size = new System.Drawing.Size(141, 21);
			this.ComboInstrument.TabIndex = 22;
			this.ComboInstrument.SelectedIndexChanged += new System.EventHandler(this.ComboInstrument_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 23;
			this.label3.Text = "Type:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.InstrumentKeyed);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.NumericSensitivity);
			this.groupBox3.Controls.Add(this.CheckPlayDetected);
			this.groupBox3.Controls.Add(this.CheckShowOctaves);
			this.groupBox3.Controls.Add(this.InstrumentStringed);
			this.groupBox3.Controls.Add(this.CheckShowFrequencies);
			this.groupBox3.Controls.Add(this.NumericFrets);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.CheckLefthanded);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.NumericStrings);
			this.groupBox3.Controls.Add(this.ComboInstrument);
			this.groupBox3.Location = new System.Drawing.Point(12, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(753, 223);
			this.groupBox3.TabIndex = 24;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Instrument";
			// 
			// InstrumentKeyed
			// 
			this.InstrumentKeyed.FirstKey = ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentKeyed.FirstKey")));
			this.InstrumentKeyed.Location = new System.Drawing.Point(6, 86);
			this.InstrumentKeyed.MajorKeys = 24;
			this.InstrumentKeyed.Name = "InstrumentKeyed";
			this.InstrumentKeyed.ShowFrequencies = false;
			this.InstrumentKeyed.ShowOctaves = false;
			this.InstrumentKeyed.Size = new System.Drawing.Size(651, 109);
			this.InstrumentKeyed.TabIndex = 30;
			this.InstrumentKeyed.Visible = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(536, 21);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 13);
			this.label8.TabIndex = 41;
			this.label8.Text = "Sensitivity:";
			// 
			// NumericSensitivity
			// 
			this.NumericSensitivity.Location = new System.Drawing.Point(599, 19);
			this.NumericSensitivity.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.NumericSensitivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumericSensitivity.Name = "NumericSensitivity";
			this.NumericSensitivity.Size = new System.Drawing.Size(42, 20);
			this.NumericSensitivity.TabIndex = 40;
			this.NumericSensitivity.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.NumericSensitivity.ValueChanged += new System.EventHandler(this.NumericSensitivity_ValueChanged);
			// 
			// CheckPlayDetected
			// 
			this.CheckPlayDetected.AutoSize = true;
			this.CheckPlayDetected.Location = new System.Drawing.Point(329, 19);
			this.CheckPlayDetected.Name = "CheckPlayDetected";
			this.CheckPlayDetected.Size = new System.Drawing.Size(91, 17);
			this.CheckPlayDetected.TabIndex = 39;
			this.CheckPlayDetected.Text = "Play detected";
			this.CheckPlayDetected.UseVisualStyleBackColor = true;
			// 
			// CheckShowOctaves
			// 
			this.CheckShowOctaves.AutoSize = true;
			this.CheckShowOctaves.Location = new System.Drawing.Point(426, 19);
			this.CheckShowOctaves.Name = "CheckShowOctaves";
			this.CheckShowOctaves.Size = new System.Drawing.Size(94, 17);
			this.CheckShowOctaves.TabIndex = 30;
			this.CheckShowOctaves.Text = "Show octaves";
			this.CheckShowOctaves.UseVisualStyleBackColor = true;
			this.CheckShowOctaves.CheckedChanged += new System.EventHandler(this.CheckShowOctaves_CheckedChanged);
			// 
			// InstrumentStringed
			// 
			this.InstrumentStringed.Frets = 23;
			this.InstrumentStringed.Horizontal = true;
			this.InstrumentStringed.LeftHanded = false;
			this.InstrumentStringed.Location = new System.Drawing.Point(6, 65);
			this.InstrumentStringed.Name = "InstrumentStringed";
			this.InstrumentStringed.ShowFrequencies = false;
			this.InstrumentStringed.ShowOctaves = false;
			this.InstrumentStringed.Size = new System.Drawing.Size(651, 143);
			this.InstrumentStringed.Strings = new LothianProductions.Notrip.Tuning[] {
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentStringed.Strings"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentStringed.Strings1"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentStringed.Strings2"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentStringed.Strings3"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentStringed.Strings4"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentStringed.Strings5")))};
			this.InstrumentStringed.TabIndex = 29;
			// 
			// CheckShowFrequencies
			// 
			this.CheckShowFrequencies.AutoSize = true;
			this.CheckShowFrequencies.Location = new System.Drawing.Point(212, 19);
			this.CheckShowFrequencies.Name = "CheckShowFrequencies";
			this.CheckShowFrequencies.Size = new System.Drawing.Size(111, 17);
			this.CheckShowFrequencies.TabIndex = 28;
			this.CheckShowFrequencies.Text = "Show frequencies";
			this.CheckShowFrequencies.UseVisualStyleBackColor = true;
			this.CheckShowFrequencies.CheckedChanged += new System.EventHandler(this.CheckShowFrequencies_CheckedChanged);
			// 
			// NumericFrets
			// 
			this.NumericFrets.Location = new System.Drawing.Point(208, 47);
			this.NumericFrets.Name = "NumericFrets";
			this.NumericFrets.Size = new System.Drawing.Size(50, 20);
			this.NumericFrets.TabIndex = 27;
			this.NumericFrets.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
			this.NumericFrets.ValueChanged += new System.EventHandler(this.NumericFrets_ValueChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(107, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(95, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "Frets / Major keys:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 49);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 24;
			this.label4.Text = "Strings:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 115);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(41, 13);
			this.label7.TabIndex = 37;
			this.label7.Text = "Speed:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 36;
			this.label1.Text = "Number:";
			// 
			// NumericSpeed
			// 
			this.NumericSpeed.Location = new System.Drawing.Point(73, 113);
			this.NumericSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NumericSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumericSpeed.Name = "NumericSpeed";
			this.NumericSpeed.Size = new System.Drawing.Size(38, 20);
			this.NumericSpeed.TabIndex = 35;
			this.NumericSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// NumericNumber
			// 
			this.NumericNumber.Location = new System.Drawing.Point(73, 87);
			this.NumericNumber.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.NumericNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumericNumber.Name = "NumericNumber";
			this.NumericNumber.Size = new System.Drawing.Size(38, 20);
			this.NumericNumber.TabIndex = 34;
			this.NumericNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ButtonRepeat
			// 
			this.ButtonRepeat.Location = new System.Drawing.Point(15, 53);
			this.ButtonRepeat.Name = "ButtonRepeat";
			this.ButtonRepeat.Size = new System.Drawing.Size(96, 28);
			this.ButtonRepeat.TabIndex = 32;
			this.ButtonRepeat.Text = "Repeat random";
			this.ButtonRepeat.UseVisualStyleBackColor = true;
			this.ButtonRepeat.Click += new System.EventHandler(this.ButtonRepeat_Click);
			// 
			// ButtonPlay
			// 
			this.ButtonPlay.Location = new System.Drawing.Point(15, 19);
			this.ButtonPlay.Name = "ButtonPlay";
			this.ButtonPlay.Size = new System.Drawing.Size(96, 28);
			this.ButtonPlay.TabIndex = 31;
			this.ButtonPlay.Text = "&Play random";
			this.ButtonPlay.UseVisualStyleBackColor = true;
			this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
			// 
			// GroupWaveformPreview
			// 
			this.GroupWaveformPreview.Controls.Add(this.ProgressAmplitude);
			this.GroupWaveformPreview.Controls.Add(this.mOscilloscope);
			this.GroupWaveformPreview.Location = new System.Drawing.Point(13, 237);
			this.GroupWaveformPreview.Name = "GroupWaveformPreview";
			this.GroupWaveformPreview.Size = new System.Drawing.Size(377, 144);
			this.GroupWaveformPreview.TabIndex = 25;
			this.GroupWaveformPreview.TabStop = false;
			this.GroupWaveformPreview.Text = "Waveform Preview";
			// 
			// ProgressAmplitude
			// 
			this.ProgressAmplitude.Location = new System.Drawing.Point(8, 128);
			this.ProgressAmplitude.Maximum = 255;
			this.ProgressAmplitude.Minimum = 128;
			this.ProgressAmplitude.Name = "ProgressAmplitude";
			this.ProgressAmplitude.Size = new System.Drawing.Size(358, 10);
			this.ProgressAmplitude.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressAmplitude.TabIndex = 28;
			this.ProgressAmplitude.Value = 128;
			// 
			// mOscilloscope
			// 
			this.mOscilloscope.ForeColor = System.Drawing.SystemColors.WindowText;
			this.mOscilloscope.Location = new System.Drawing.Point(1, 19);
			this.mOscilloscope.Name = "mOscilloscope";
			this.mOscilloscope.Size = new System.Drawing.Size(375, 108);
			this.mOscilloscope.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 23);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 18;
			this.label6.Text = "Type:";
			// 
			// ComboChord
			// 
			this.ComboChord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboChord.FormattingEnabled = true;
			this.ComboChord.Items.AddRange(new object[] {
            "Major",
            "Minor",
            "Diminished",
            "Augmented"});
			this.ComboChord.Location = new System.Drawing.Point(48, 19);
			this.ComboChord.Name = "ComboChord";
			this.ComboChord.Size = new System.Drawing.Size(66, 21);
			this.ComboChord.TabIndex = 19;
			// 
			// RadioFifth
			// 
			this.RadioFifth.AutoSize = true;
			this.RadioFifth.Location = new System.Drawing.Point(11, 74);
			this.RadioFifth.Name = "RadioFifth";
			this.RadioFifth.Size = new System.Drawing.Size(40, 17);
			this.RadioFifth.TabIndex = 18;
			this.RadioFifth.TabStop = true;
			this.RadioFifth.Text = "5th";
			this.RadioFifth.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.RadioNinth);
			this.groupBox5.Controls.Add(this.RadioSeventh);
			this.groupBox5.Controls.Add(this.RadioFifth);
			this.groupBox5.Controls.Add(this.label6);
			this.groupBox5.Controls.Add(this.RadioSixth);
			this.groupBox5.Controls.Add(this.ComboChord);
			this.groupBox5.Controls.Add(this.label2);
			this.groupBox5.Controls.Add(this.ComboKey);
			this.groupBox5.Enabled = false;
			this.groupBox5.Location = new System.Drawing.Point(508, 237);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(127, 127);
			this.groupBox5.TabIndex = 27;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Chords && Scales";
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.ButtonPlay);
			this.groupBox6.Controls.Add(this.ButtonRepeat);
			this.groupBox6.Controls.Add(this.label7);
			this.groupBox6.Controls.Add(this.label1);
			this.groupBox6.Controls.Add(this.NumericSpeed);
			this.groupBox6.Controls.Add(this.NumericNumber);
			this.groupBox6.Location = new System.Drawing.Point(641, 237);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(124, 144);
			this.groupBox6.TabIndex = 29;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Recognition";
			// 
			// TimerDemo
			// 
			this.TimerDemo.Interval = 180000;
			this.TimerDemo.Tick += new System.EventHandler(this.TimerDemo_Tick);
			// 
			// ControlForm
			// 
			this.ClientSize = new System.Drawing.Size(776, 393);
			this.Controls.Add(this.groupBox6);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.GroupWaveformPreview);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ControlForm";
			this.Text = "Notrip - 0.6 - See: http://www.lothianproductions.co.uk/notrip";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
			this.Load += new System.EventHandler(this.ControlForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericStrings)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericSensitivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericFrets)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericNumber)).EndInit();
			this.GroupWaveformPreview.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		public Oscilloscope mOscilloscope;
		private System.Windows.Forms.ComboBox ComboKey;
		private System.Windows.Forms.CheckBox CheckLefthanded;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton RadioNinth;
		private System.Windows.Forms.RadioButton RadioSixth;
		private System.Windows.Forms.RadioButton RadioSeventh;
		private System.Windows.Forms.NumericUpDown NumericStrings;
		private System.Windows.Forms.ComboBox ComboInstrument;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown NumericFrets;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox GroupWaveformPreview;
		private System.Windows.Forms.RadioButton RadioDrawChords;
		private System.Windows.Forms.RadioButton RadioDrawAudio;
		private System.Windows.Forms.ComboBox ComboChord;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton RadioFifth;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ProgressBar ProgressAmplitude;
		private System.Windows.Forms.CheckBox CheckShowFrequencies;
		private StringedInstrument InstrumentStringed;
		private System.Windows.Forms.CheckBox CheckShowOctaves;
		private System.Windows.Forms.RadioButton RadioDrawScales;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown NumericSpeed;
		private System.Windows.Forms.NumericUpDown NumericNumber;
		private System.Windows.Forms.Button ButtonRepeat;
		private System.Windows.Forms.Button ButtonPlay;
		private System.Windows.Forms.CheckBox CheckPlayDetected;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown NumericSensitivity;
		private System.Windows.Forms.Timer TimerDemo;
		private KeyedInstrument InstrumentKeyed;
//		private KeyedInstrument keyedInstrument1;

	}
}