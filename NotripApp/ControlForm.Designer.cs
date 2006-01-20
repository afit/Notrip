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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ControlForm ) );
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CheckLefthanded = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.NumericStrings = new System.Windows.Forms.NumericUpDown();
			this.mOscilloscope = new LothianProductions.Notrip.Oscilloscope();
			this.InstrumentMain = new LothianProductions.Notrip.StringedInstrument();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.NumericFrets = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericStrings ) ).BeginInit();
			this.groupBox3.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericFrets ) ).BeginInit();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange( new object[] {
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
			this.comboBox1.Location = new System.Drawing.Point( 55, 20 );
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size( 134, 21 );
			this.comboBox1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 380, 350 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 115, 13 );
			this.label1.TabIndex = 12;
			this.label1.Text = "TODO draw fret circles";
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
			this.label2.Location = new System.Drawing.Point( 7, 23 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 28, 13 );
			this.label2.TabIndex = 17;
			this.label2.Text = "Key:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add( this.radioButton7 );
			this.groupBox1.Controls.Add( this.radioButton6 );
			this.groupBox1.Controls.Add( this.comboBox1 );
			this.groupBox1.Controls.Add( this.label2 );
			this.groupBox1.Location = new System.Drawing.Point( 12, 241 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 196, 175 );
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Highlighting";
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point( 16, 90 );
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
			this.radioButton3.Location = new System.Drawing.Point( 16, 44 );
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
			this.radioButton1.Location = new System.Drawing.Point( 16, 67 );
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
			// mOscilloscope
			// 
			this.mOscilloscope.ForeColor = System.Drawing.SystemColors.WindowText;
			this.mOscilloscope.Location = new System.Drawing.Point( 1, 19 );
			this.mOscilloscope.Name = "mOscilloscope";
			this.mOscilloscope.Size = new System.Drawing.Size( 256, 198 );
			this.mOscilloscope.TabIndex = 4;
			this.mOscilloscope.Click += new System.EventHandler( this.mOscilloscope_Click );
			// 
			// InstrumentMain
			// 
			this.InstrumentMain.Capo = 0;
			this.InstrumentMain.Frets = 12;
			this.InstrumentMain.Horizontal = true;
			this.InstrumentMain.LeftHanded = false;
			this.InstrumentMain.Location = new System.Drawing.Point( 6, 65 );
			this.InstrumentMain.Name = "InstrumentMain";
			this.InstrumentMain.Size = new System.Drawing.Size( 340, 143 );
			this.InstrumentMain.Strings = new LothianProductions.Notrip.InstrumentString[] {
        ((LothianProductions.Notrip.InstrumentString)(resources.GetObject("InstrumentMain.Strings"))),
        ((LothianProductions.Notrip.InstrumentString)(resources.GetObject("InstrumentMain.Strings1"))),
        ((LothianProductions.Notrip.InstrumentString)(resources.GetObject("InstrumentMain.Strings2"))),
        ((LothianProductions.Notrip.InstrumentString)(resources.GetObject("InstrumentMain.Strings3"))),
        ((LothianProductions.Notrip.InstrumentString)(resources.GetObject("InstrumentMain.Strings4"))),
        ((LothianProductions.Notrip.InstrumentString)(resources.GetObject("InstrumentMain.Strings5")))};
			this.InstrumentMain.TabIndex = 21;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange( new object[] {
            "Stringed instrument",
            "Keyed instrument"} );
			this.comboBox2.Location = new System.Drawing.Point( 55, 17 );
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size( 141, 21 );
			this.comboBox2.TabIndex = 22;
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
			this.groupBox3.Controls.Add( this.NumericFrets );
			this.groupBox3.Controls.Add( this.label5 );
			this.groupBox3.Controls.Add( this.label4 );
			this.groupBox3.Controls.Add( this.InstrumentMain );
			this.groupBox3.Controls.Add( this.CheckLefthanded );
			this.groupBox3.Controls.Add( this.label3 );
			this.groupBox3.Controls.Add( this.NumericStrings );
			this.groupBox3.Controls.Add( this.comboBox2 );
			this.groupBox3.Location = new System.Drawing.Point( 12, 12 );
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size( 364, 223 );
			this.groupBox3.TabIndex = 24;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Instrument";
			// 
			// NumericFrets
			// 
			this.NumericFrets.Location = new System.Drawing.Point( 146, 44 );
			this.NumericFrets.Name = "NumericFrets";
			this.NumericFrets.Size = new System.Drawing.Size( 50, 20 );
			this.NumericFrets.TabIndex = 27;
			this.NumericFrets.Value = new decimal( new int[] {
            12,
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
			// groupBox4
			// 
			this.groupBox4.Controls.Add( this.mOscilloscope );
			this.groupBox4.Location = new System.Drawing.Point( 382, 12 );
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size( 258, 223 );
			this.groupBox4.TabIndex = 25;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Monitor analysis";
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
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange( new object[] {
            "Major",
            "Minor",
            "Diminished"} );
			this.comboBox3.Location = new System.Drawing.Point( 48, 20 );
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size( 133, 21 );
			this.comboBox3.TabIndex = 19;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point( 10, 47 );
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size( 85, 17 );
			this.radioButton6.TabIndex = 20;
			this.radioButton6.TabStop = true;
			this.radioButton6.Text = "Draw chords";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point( 10, 70 );
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size( 83, 17 );
			this.radioButton7.TabIndex = 21;
			this.radioButton7.TabStop = true;
			this.radioButton7.Text = "Draw scales";
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add( this.radioButton4 );
			this.groupBox2.Controls.Add( this.radioButton1 );
			this.groupBox2.Controls.Add( this.radioButton5 );
			this.groupBox2.Controls.Add( this.radioButton3 );
			this.groupBox2.Location = new System.Drawing.Point( 214, 302 );
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size( 100, 114 );
			this.groupBox2.TabIndex = 26;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Scales";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add( this.label6 );
			this.groupBox5.Controls.Add( this.comboBox3 );
			this.groupBox5.Location = new System.Drawing.Point( 214, 241 );
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size( 194, 55 );
			this.groupBox5.TabIndex = 27;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Chords";
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point( 16, 21 );
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size( 40, 17 );
			this.radioButton4.TabIndex = 18;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "5th";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// ControlForm
			// 
			this.ClientSize = new System.Drawing.Size( 655, 428 );
			this.Controls.Add( this.groupBox5 );
			this.Controls.Add( this.groupBox2 );
			this.Controls.Add( this.groupBox4 );
			this.Controls.Add( this.groupBox3 );
			this.Controls.Add( this.groupBox1 );
			this.Controls.Add( this.label1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "ControlForm";
			this.Text = "Notrip";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.ControlForm_FormClosing );
			this.Load += new System.EventHandler( this.ControlForm_Load );
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericStrings ) ).EndInit();
			this.groupBox3.ResumeLayout( false );
			this.groupBox3.PerformLayout();
			( (System.ComponentModel.ISupportInitialize) ( this.NumericFrets ) ).EndInit();
			this.groupBox4.ResumeLayout( false );
			this.groupBox2.ResumeLayout( false );
			this.groupBox2.PerformLayout();
			this.groupBox5.ResumeLayout( false );
			this.groupBox5.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		public Oscilloscope mOscilloscope;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox CheckLefthanded;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.NumericUpDown NumericStrings;
		private StringedInstrument InstrumentMain;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown NumericFrets;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.GroupBox groupBox5;

	}
}