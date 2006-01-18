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
			this.button1 = new System.Windows.Forms.Button();
			this.mOscilloscope = new LothianProductions.Notrip.Oscilloscope();
			this.stringedInstrument1 = new LothianProductions.Notrip.StringedInstrument();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 12, 12 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 157, 34 );
			this.button1.TabIndex = 2;
			this.button1.Text = "Start or stop monitoring";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// mOscilloscope
			// 
			this.mOscilloscope.BackColor = System.Drawing.SystemColors.Control;
			this.mOscilloscope.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mOscilloscope.Location = new System.Drawing.Point( 181, 12 );
			this.mOscilloscope.Name = "mOscilloscope";
			this.mOscilloscope.Size = new System.Drawing.Size( 512, 255 );
			this.mOscilloscope.TabIndex = 4;
			// 
			// stringedInstrument1
			// 
			this.stringedInstrument1.Capo = 0;
			this.stringedInstrument1.Frets = 24;
			this.stringedInstrument1.Horizontal = true;
			this.stringedInstrument1.Location = new System.Drawing.Point( 12, 273 );
			this.stringedInstrument1.Name = "stringedInstrument1";
			this.stringedInstrument1.Size = new System.Drawing.Size( 681, 143 );
			this.stringedInstrument1.TabIndex = 0;
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point( 34, 73 );
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size( 134, 21 );
			this.comboBox1.TabIndex = 5;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point( 30, 106 );
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size( 52, 17 );
			this.checkBox1.TabIndex = 6;
			this.checkBox1.Text = "&Minor";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point( 30, 130 );
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size( 40, 17 );
			this.radioButton1.TabIndex = 7;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "7th";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point( 30, 154 );
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size( 52, 17 );
			this.radioButton2.TabIndex = 8;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "5th??";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point( 30, 178 );
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size( 40, 17 );
			this.radioButton3.TabIndex = 9;
			this.radioButton3.TabStop = true;
			this.radioButton3.Text = "6th";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point( 30, 202 );
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size( 82, 17 );
			this.radioButton4.TabIndex = 10;
			this.radioButton4.TabStop = true;
			this.radioButton4.Text = "Diminished?";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point( 30, 226 );
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size( 40, 17 );
			this.radioButton5.TabIndex = 11;
			this.radioButton5.TabStop = true;
			this.radioButton5.Text = "9th";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 66, 438 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 145, 13 );
			this.label1.TabIndex = 12;
			this.label1.Text = "number frets, draw fret circles";
			// 
			// ControlForm
			// 
			this.ClientSize = new System.Drawing.Size( 705, 504 );
			this.Controls.Add( this.label1 );
			this.Controls.Add( this.radioButton5 );
			this.Controls.Add( this.radioButton4 );
			this.Controls.Add( this.radioButton3 );
			this.Controls.Add( this.radioButton2 );
			this.Controls.Add( this.radioButton1 );
			this.Controls.Add( this.checkBox1 );
			this.Controls.Add( this.comboBox1 );
			this.Controls.Add( this.mOscilloscope );
			this.Controls.Add( this.button1 );
			this.Controls.Add( this.stringedInstrument1 );
			this.Name = "ControlForm";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.ControlForm_FormClosing );
			this.Load += new System.EventHandler( this.ControlForm_Load );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private StringedInstrument stringedInstrument1;
		private System.Windows.Forms.Button button1;
		public Oscilloscope mOscilloscope;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.Label label1;

	}
}