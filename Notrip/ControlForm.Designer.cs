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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlForm));
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.CheckLefthanded = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.NumericStrings = new System.Windows.Forms.NumericUpDown();
			this.mOscilloscope = new LothianProductions.Notrip.Oscilloscope();
			this.InstrumentMain = new LothianProductions.Notrip.StringedInstrument();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericStrings)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 361);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(157, 34);
			this.button1.TabIndex = 2;
			this.button1.Text = "Start or stop monitoring";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
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
			this.comboBox1.Location = new System.Drawing.Point(43, 9);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(134, 21);
			this.comboBox1.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(441, 190);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(145, 13);
			this.label1.TabIndex = 12;
			this.label1.Text = "number frets, draw fret circles";
			// 
			// CheckLefthanded
			// 
			this.CheckLefthanded.AutoSize = true;
			this.CheckLefthanded.Location = new System.Drawing.Point(355, 161);
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
			this.label2.Location = new System.Drawing.Point(9, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Key:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton5);
			this.groupBox1.Controls.Add(this.radioButton4);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(13, 51);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(164, 217);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Chord";
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(6, 139);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(40, 17);
			this.radioButton5.TabIndex = 17;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "9th";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(6, 115);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(82, 17);
			this.radioButton4.TabIndex = 16;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Diminished?";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(6, 91);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(40, 17);
			this.radioButton3.TabIndex = 15;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "6th";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(6, 67);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(52, 17);
			this.radioButton2.TabIndex = 14;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "5th??";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(6, 43);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(40, 17);
			this.radioButton1.TabIndex = 13;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "7th";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(6, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(52, 17);
			this.checkBox1.TabIndex = 12;
			this.checkBox1.Text = "&Minor";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(183, 51);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(129, 165);
			this.groupBox2.TabIndex = 19;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Scale";
			// 
			// NumericStrings
			// 
			this.NumericStrings.Location = new System.Drawing.Point(355, 196);
			this.NumericStrings.Name = "NumericStrings";
			this.NumericStrings.Size = new System.Drawing.Size(46, 20);
			this.NumericStrings.TabIndex = 20;
			this.NumericStrings.ValueChanged += new System.EventHandler(this.NumericStrings_ValueChanged);
			// 
			// mOscilloscope
			// 
			this.mOscilloscope.BackColor = System.Drawing.SystemColors.Control;
			this.mOscilloscope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mOscilloscope.Location = new System.Drawing.Point(174, 222);
			this.mOscilloscope.Name = "mOscilloscope";
			this.mOscilloscope.Size = new System.Drawing.Size(512, 255);
			this.mOscilloscope.TabIndex = 4;
			// 
			// InstrumentMain
			// 
			this.InstrumentMain.Capo = 0;
			this.InstrumentMain.Frets = 12;
			this.InstrumentMain.Horizontal = true;
			this.InstrumentMain.LeftHanded = false;
			this.InstrumentMain.Location = new System.Drawing.Point(346, 12);
			this.InstrumentMain.Name = "InstrumentMain";
			this.InstrumentMain.Size = new System.Drawing.Size(340, 143);
			this.InstrumentMain.Strings = ((System.Collections.Generic.List<LothianProductions.Notrip.InstrumentString>)(resources.GetObject("InstrumentMain.Strings")));
			this.InstrumentMain.TabIndex = 21;
			// 
			// ControlForm
			// 
			this.ClientSize = new System.Drawing.Size(707, 489);
			this.Controls.Add(this.InstrumentMain);
			this.Controls.Add(this.NumericStrings);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.CheckLefthanded);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.mOscilloscope);
			this.Controls.Add(this.button1);
			this.Name = "ControlForm";
			this.Text = "Notrip";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlForm_FormClosing);
			this.Load += new System.EventHandler(this.ControlForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.NumericStrings)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		public Oscilloscope mOscilloscope;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox CheckLefthanded;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown NumericStrings;
		private StringedInstrument InstrumentMain;

	}
}