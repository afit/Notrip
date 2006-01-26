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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ControlForm ) );
			this.ComboKey = new System.Windows.Forms.ComboBox();
			this.CheckLefthanded = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.RadioDrawScales = new System.Windows.Forms.RadioButton();
			this.RadioDrawChords = new System.Windows.Forms.RadioButton();
			this.RadioDrawAudio = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.NumericStrings = new System.Windows.Forms.NumericUpDown();
			this.ComboInstrument = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.NumericSensitivity = new System.Windows.Forms.NumericUpDown();
			this.CheckPlayDetected = new System.Windows.Forms.CheckBox();
			this.CheckShowOctaves = new System.Windows.Forms.CheckBox();
			this.InstrumentMain = new LothianProductions.Notrip.StringedInstrument();
			this.CheckShowFrequencies = new System.Windows.Forms.CheckBox();
			this.NumericFrets = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.CheckReveal = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.NumericSpeed = new System.Windows.Forms.NumericUpDown();
			this.NumericNumber = new System.Windows.Forms.NumericUpDown();
			this.ButtonRepeat = new System.Windows.Forms.Button();
			this.ButtonPlay = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.mOscilloscope = new LothianProductions.Notrip.Oscilloscope();
			this.label6 = new System.Windows.Forms.Label();
			this.ComboChord = new System.Windows.Forms.ComboBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.ProgressAmplitude = new System.Windows.Forms.ProgressBar();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.TimerDemo = new System.Windows.Forms.Timer( this.components );
			this.groupBox1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericStrings ) ).BeginInit();
			this.groupBox3.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericSensitivity ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericFrets ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericSpeed ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericNumber ) ).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// ComboKey
			// 
			this.ComboKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboKey.FormattingEnabled = true;
			this.ComboKey.Items.AddRange( new object[] {
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
            "G#"} );
			this.ComboKey.Location = new System.Drawing.Point( 48, 47 );
			this.ComboKey.Name = "ComboKey";
			this.ComboKey.Size = new System.Drawing.Size( 66, 21 );
			this.ComboKey.TabIndex = 5;
			// 
			// CheckLefthanded
			// 
			this.CheckLefthanded.AutoSize = true;
			this.CheckLefthanded.Location = new System.Drawing.Point( 212, 47 );
			this.CheckLefthanded.Name = "CheckLefthanded";
			this.CheckLefthanded.Size = new System.Drawing.Size( 83, 17 );
			this.CheckLefthanded.TabIndex = 16;
			this.CheckLefthanded.Text = "Left-handed";
			this.CheckLefthanded.UseVisualStyleBackColor = true;
			this.CheckLefthanded.CheckedChanged += new System.EventHandler( this.CheckLefthanded_CheckedChanged );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 8, 51 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 28, 13 );
			this.label2.TabIndex = 17;
			this.label2.Text = "Key:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.RadioDrawScales );
			this.groupBox1.Controls.Add( this.RadioDrawChords );
			this.groupBox1.Controls.Add( this.RadioDrawAudio );
			this.groupBox1.Location = new System.Drawing.Point( 396, 237 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 106, 91 );
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Highlighting";
			// 
			// RadioDrawScales
			// 
			this.RadioDrawScales.AutoSize = true;
			this.RadioDrawScales.Enabled = false;
			this.RadioDrawScales.Location = new System.Drawing.Point( 11, 65 );
			this.RadioDrawScales.Name = "RadioDrawScales";
			this.RadioDrawScales.Size = new System.Drawing.Size( 83, 17 );
			this.RadioDrawScales.TabIndex = 22;
			this.RadioDrawScales.Text = "Draw scales";
			this.RadioDrawScales.UseVisualStyleBackColor = true;
			// 
			// RadioDrawChords
			// 
			this.RadioDrawChords.AutoSize = true;
			this.RadioDrawChords.Enabled = false;
			this.RadioDrawChords.Location = new System.Drawing.Point( 11, 42 );
			this.RadioDrawChords.Name = "RadioDrawChords";
			this.RadioDrawChords.Size = new System.Drawing.Size( 85, 17 );
			this.RadioDrawChords.TabIndex = 21;
			this.RadioDrawChords.Text = "Draw chords";
			this.RadioDrawChords.UseVisualStyleBackColor = true;
			// 
			// RadioDrawAudio
			// 
			this.RadioDrawAudio.AutoSize = true;
			this.RadioDrawAudio.Checked = true;
			this.RadioDrawAudio.Location = new System.Drawing.Point( 11, 19 );
			this.RadioDrawAudio.Name = "RadioDrawAudio";
			this.RadioDrawAudio.Size = new System.Drawing.Size( 79, 17 );
			this.RadioDrawAudio.TabIndex = 20;
			this.RadioDrawAudio.TabStop = true;
			this.RadioDrawAudio.Text = "Draw audio";
			this.RadioDrawAudio.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point( 57, 97 );
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size( 40, 17 );
			this.radioButton5.TabIndex = 17;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "9th";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point( 57, 74 );
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size( 40, 17 );
			this.radioButton3.TabIndex = 15;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "6th";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point( 11, 97 );
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size( 40, 17 );
			this.radioButton1.TabIndex = 13;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "7th";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// NumericStrings
			// 
			this.NumericStrings.Location = new System.Drawing.Point( 55, 44 );
			this.NumericStrings.Name = "NumericStrings";
			this.NumericStrings.Size = new System.Drawing.Size( 46, 20 );
			this.NumericStrings.TabIndex = 20;
			this.NumericStrings.Value = new decimal( new int[] {
            6,
            0,
            0,
            0} );
			this.NumericStrings.ValueChanged += new System.EventHandler( this.NumericStrings_ValueChanged );
			// 
			// ComboInstrument
			// 
			this.ComboInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboInstrument.Enabled = false;
			this.ComboInstrument.FormattingEnabled = true;
			this.ComboInstrument.Items.AddRange( new object[] {
            "Stringed instrument",
            "Keyed instrument"} );
			this.ComboInstrument.Location = new System.Drawing.Point( 55, 17 );
			this.ComboInstrument.Name = "ComboInstrument";
			this.ComboInstrument.Size = new System.Drawing.Size( 141, 21 );
			this.ComboInstrument.TabIndex = 22;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 6, 20 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 34, 13 );
			this.label3.TabIndex = 23;
			this.label3.Text = "Type:";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add( this.label8 );
			this.groupBox3.Controls.Add( this.NumericSensitivity );
			this.groupBox3.Controls.Add( this.CheckPlayDetected );
			this.groupBox3.Controls.Add( this.CheckShowOctaves );
			this.groupBox3.Controls.Add( this.InstrumentMain );
			this.groupBox3.Controls.Add( this.CheckShowFrequencies );
			this.groupBox3.Controls.Add( this.NumericFrets );
			this.groupBox3.Controls.Add( this.label5 );
			this.groupBox3.Controls.Add( this.label4 );
			this.groupBox3.Controls.Add( this.CheckLefthanded );
			this.groupBox3.Controls.Add( this.label3 );
			this.groupBox3.Controls.Add( this.NumericStrings );
			this.groupBox3.Controls.Add( this.ComboInstrument );
			this.groupBox3.Location = new System.Drawing.Point( 12, 8 );
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size( 753, 223 );
			this.groupBox3.TabIndex = 24;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Instrument";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point( 401, 48 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 57, 13 );
			this.label8.TabIndex = 41;
			this.label8.Text = "Sensitivity:";
			// 
			// NumericSensitivity
			// 
			this.NumericSensitivity.Location = new System.Drawing.Point( 464, 44 );
			this.NumericSensitivity.Maximum = new decimal( new int[] {
            25,
            0,
            0,
            0} );
			this.NumericSensitivity.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.NumericSensitivity.Name = "NumericSensitivity";
			this.NumericSensitivity.Size = new System.Drawing.Size( 42, 20 );
			this.NumericSensitivity.TabIndex = 40;
			this.NumericSensitivity.Value = new decimal( new int[] {
            5,
            0,
            0,
            0} );
			this.NumericSensitivity.ValueChanged += new System.EventHandler( this.NumericSensitivity_ValueChanged );
			// 
			// CheckPlayDetected
			// 
			this.CheckPlayDetected.AutoSize = true;
			this.CheckPlayDetected.Location = new System.Drawing.Point( 329, 19 );
			this.CheckPlayDetected.Name = "CheckPlayDetected";
			this.CheckPlayDetected.Size = new System.Drawing.Size( 91, 17 );
			this.CheckPlayDetected.TabIndex = 39;
			this.CheckPlayDetected.Text = "Play detected";
			this.CheckPlayDetected.UseVisualStyleBackColor = true;
			// 
			// CheckShowOctaves
			// 
			this.CheckShowOctaves.AutoSize = true;
			this.CheckShowOctaves.Location = new System.Drawing.Point( 301, 47 );
			this.CheckShowOctaves.Name = "CheckShowOctaves";
			this.CheckShowOctaves.Size = new System.Drawing.Size( 94, 17 );
			this.CheckShowOctaves.TabIndex = 30;
			this.CheckShowOctaves.Text = "Show octaves";
			this.CheckShowOctaves.UseVisualStyleBackColor = true;
			this.CheckShowOctaves.CheckedChanged += new System.EventHandler( this.CheckShowOctaves_CheckedChanged );
			// 
			// InstrumentMain
			// 
			this.InstrumentMain.Capo = 0;
			this.InstrumentMain.Frets = 24;
			this.InstrumentMain.Horizontal = true;
			this.InstrumentMain.LeftHanded = false;
			this.InstrumentMain.Location = new System.Drawing.Point( 6, 65 );
			this.InstrumentMain.Name = "InstrumentMain";
			this.InstrumentMain.ShowFrequencies = false;
			this.InstrumentMain.ShowOctaves = false;
			this.InstrumentMain.Size = new System.Drawing.Size( 651, 143 );
			this.InstrumentMain.Strings = new LothianProductions.Notrip.Tuning[] {
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentMain.Strings"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentMain.Strings1"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentMain.Strings2"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentMain.Strings3"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentMain.Strings4"))),
        ((LothianProductions.Notrip.Tuning)(resources.GetObject("InstrumentMain.Strings5")))};
			this.InstrumentMain.TabIndex = 29;
			// 
			// CheckShowFrequencies
			// 
			this.CheckShowFrequencies.AutoSize = true;
			this.CheckShowFrequencies.Location = new System.Drawing.Point( 212, 19 );
			this.CheckShowFrequencies.Name = "CheckShowFrequencies";
			this.CheckShowFrequencies.Size = new System.Drawing.Size( 111, 17 );
			this.CheckShowFrequencies.TabIndex = 28;
			this.CheckShowFrequencies.Text = "Show frequencies";
			this.CheckShowFrequencies.UseVisualStyleBackColor = true;
			this.CheckShowFrequencies.CheckedChanged += new System.EventHandler( this.CheckShowFrequencies_CheckedChanged );
			// 
			// NumericFrets
			// 
			this.NumericFrets.Location = new System.Drawing.Point( 146, 44 );
			this.NumericFrets.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.NumericFrets.Name = "NumericFrets";
			this.NumericFrets.Size = new System.Drawing.Size( 50, 20 );
			this.NumericFrets.TabIndex = 27;
			this.NumericFrets.Value = new decimal( new int[] {
            24,
            0,
            0,
            0} );
			this.NumericFrets.ValueChanged += new System.EventHandler( this.NumericFrets_ValueChanged );
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 107, 49 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 33, 13 );
			this.label5.TabIndex = 25;
			this.label5.Text = "Frets:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 7, 49 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 42, 13 );
			this.label4.TabIndex = 24;
			this.label4.Text = "Strings:";
			// 
			// CheckReveal
			// 
			this.CheckReveal.AutoSize = true;
			this.CheckReveal.Location = new System.Drawing.Point( 15, 139 );
			this.CheckReveal.Name = "CheckReveal";
			this.CheckReveal.Size = new System.Drawing.Size( 98, 17 );
			this.CheckReveal.TabIndex = 38;
			this.CheckReveal.Text = "Reveal random";
			this.CheckReveal.UseVisualStyleBackColor = true;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point( 12, 115 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 41, 13 );
			this.label7.TabIndex = 37;
			this.label7.Text = "Speed:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 12, 89 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 47, 13 );
			this.label1.TabIndex = 36;
			this.label1.Text = "Number:";
			// 
			// NumericSpeed
			// 
			this.NumericSpeed.Location = new System.Drawing.Point( 73, 113 );
			this.NumericSpeed.Maximum = new decimal( new int[] {
            10,
            0,
            0,
            0} );
			this.NumericSpeed.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.NumericSpeed.Name = "NumericSpeed";
			this.NumericSpeed.Size = new System.Drawing.Size( 38, 20 );
			this.NumericSpeed.TabIndex = 35;
			this.NumericSpeed.Value = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			// 
			// NumericNumber
			// 
			this.NumericNumber.Location = new System.Drawing.Point( 73, 87 );
			this.NumericNumber.Maximum = new decimal( new int[] {
            10,
            0,
            0,
            0} );
			this.NumericNumber.Minimum = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			this.NumericNumber.Name = "NumericNumber";
			this.NumericNumber.Size = new System.Drawing.Size( 38, 20 );
			this.NumericNumber.TabIndex = 34;
			this.NumericNumber.Value = new decimal( new int[] {
            1,
            0,
            0,
            0} );
			// 
			// ButtonRepeat
			// 
			this.ButtonRepeat.Location = new System.Drawing.Point( 15, 53 );
			this.ButtonRepeat.Name = "ButtonRepeat";
			this.ButtonRepeat.Size = new System.Drawing.Size( 96, 28 );
			this.ButtonRepeat.TabIndex = 32;
			this.ButtonRepeat.Text = "Repeat random";
			this.ButtonRepeat.UseVisualStyleBackColor = true;
			this.ButtonRepeat.Click += new System.EventHandler( this.ButtonRepeat_Click );
			// 
			// ButtonPlay
			// 
			this.ButtonPlay.Location = new System.Drawing.Point( 15, 19 );
			this.ButtonPlay.Name = "ButtonPlay";
			this.ButtonPlay.Size = new System.Drawing.Size( 96, 28 );
			this.ButtonPlay.TabIndex = 31;
			this.ButtonPlay.Text = "&Play random";
			this.ButtonPlay.UseVisualStyleBackColor = true;
			this.ButtonPlay.Click += new System.EventHandler( this.ButtonPlay_Click );
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add( this.mOscilloscope );
			this.groupBox4.Location = new System.Drawing.Point( 13, 237 );
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size( 377, 150 );
			this.groupBox4.TabIndex = 25;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Monitor analysis";
			// 
			// mOscilloscope
			// 
			this.mOscilloscope.ForeColor = System.Drawing.SystemColors.WindowText;
			this.mOscilloscope.Location = new System.Drawing.Point( 1, 19 );
			this.mOscilloscope.Name = "mOscilloscope";
			this.mOscilloscope.Size = new System.Drawing.Size( 375, 125 );
			this.mOscilloscope.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 8, 23 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 34, 13 );
			this.label6.TabIndex = 18;
			this.label6.Text = "Type:";
			// 
			// ComboChord
			// 
			this.ComboChord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboChord.FormattingEnabled = true;
			this.ComboChord.Items.AddRange( new object[] {
            "Major",
            "Minor",
            "Diminished"} );
			this.ComboChord.Location = new System.Drawing.Point( 48, 19 );
			this.ComboChord.Name = "ComboChord";
			this.ComboChord.Size = new System.Drawing.Size( 66, 21 );
			this.ComboChord.TabIndex = 19;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point( 11, 74 );
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size( 40, 17 );
			this.radioButton4.TabIndex = 18;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "5th";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add( this.radioButton5 );
			this.groupBox5.Controls.Add( this.radioButton1 );
			this.groupBox5.Controls.Add( this.radioButton4 );
			this.groupBox5.Controls.Add( this.label6 );
			this.groupBox5.Controls.Add( this.radioButton3 );
			this.groupBox5.Controls.Add( this.ComboChord );
			this.groupBox5.Controls.Add( this.label2 );
			this.groupBox5.Controls.Add( this.ComboKey );
			this.groupBox5.Enabled = false;
			this.groupBox5.Location = new System.Drawing.Point( 508, 237 );
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size( 127, 127 );
			this.groupBox5.TabIndex = 27;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Chords && Scales";
			// 
			// ProgressAmplitude
			// 
			this.ProgressAmplitude.Location = new System.Drawing.Point( 13, 393 );
			this.ProgressAmplitude.Maximum = 255;
			this.ProgressAmplitude.Minimum = 128;
			this.ProgressAmplitude.Name = "ProgressAmplitude";
			this.ProgressAmplitude.Size = new System.Drawing.Size( 377, 10 );
			this.ProgressAmplitude.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.ProgressAmplitude.TabIndex = 28;
			this.ProgressAmplitude.Value = 128;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add( this.ButtonPlay );
			this.groupBox6.Controls.Add( this.CheckReveal );
			this.groupBox6.Controls.Add( this.ButtonRepeat );
			this.groupBox6.Controls.Add( this.label7 );
			this.groupBox6.Controls.Add( this.label1 );
			this.groupBox6.Controls.Add( this.NumericSpeed );
			this.groupBox6.Controls.Add( this.NumericNumber );
			this.groupBox6.Location = new System.Drawing.Point( 641, 237 );
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size( 124, 166 );
			this.groupBox6.TabIndex = 29;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Recognition";
			// 
			// TimerDemo
			// 
			this.TimerDemo.Enabled = true;
			this.TimerDemo.Interval = 180000;
			this.TimerDemo.Tick += new System.EventHandler( this.TimerDemo_Tick );
			// 
			// ControlForm
			// 
			this.ClientSize = new System.Drawing.Size( 776, 412 );
			this.Controls.Add( this.groupBox6 );
			this.Controls.Add( this.ProgressAmplitude );
			this.Controls.Add( this.groupBox5 );
			this.Controls.Add( this.groupBox4 );
			this.Controls.Add( this.groupBox3 );
			this.Controls.Add( this.groupBox1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ControlForm";
			this.Text = "Notrip - 0.5 - See: lothianproductions.co.uk/notrip";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.ControlForm_FormClosing );
			this.Load += new System.EventHandler( this.ControlForm_Load );
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericStrings ) ).EndInit();
			this.groupBox3.ResumeLayout( false );
			this.groupBox3.PerformLayout();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericSensitivity ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericFrets ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericSpeed ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericNumber ) ).EndInit();
			this.groupBox4.ResumeLayout( false );
			this.groupBox5.ResumeLayout( false );
			this.groupBox5.PerformLayout();
			this.groupBox6.ResumeLayout( false );
			this.groupBox6.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		public Oscilloscope mOscilloscope;
		private System.Windows.Forms.ComboBox ComboKey;
		private System.Windows.Forms.CheckBox CheckLefthanded;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.NumericUpDown NumericStrings;
		private System.Windows.Forms.ComboBox ComboInstrument;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown NumericFrets;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton RadioDrawChords;
		private System.Windows.Forms.RadioButton RadioDrawAudio;
		private System.Windows.Forms.ComboBox ComboChord;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.ProgressBar ProgressAmplitude;
		private System.Windows.Forms.CheckBox CheckShowFrequencies;
		private StringedInstrument InstrumentMain;
		private System.Windows.Forms.CheckBox CheckShowOctaves;
		private System.Windows.Forms.RadioButton RadioDrawScales;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown NumericSpeed;
		private System.Windows.Forms.NumericUpDown NumericNumber;
		private System.Windows.Forms.Button ButtonRepeat;
		private System.Windows.Forms.Button ButtonPlay;
		private System.Windows.Forms.CheckBox CheckReveal;
		private System.Windows.Forms.CheckBox CheckPlayDetected;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown NumericSensitivity;
		private System.Windows.Forms.Timer TimerDemo;

	}
}