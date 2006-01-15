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
			this.stringedInstrument1 = new LothianProductions.Notrip.StringedInstrument();
			this.button1 = new System.Windows.Forms.Button();
			this.TextRawData = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// stringedInstrument1
			// 
			this.stringedInstrument1.Capo = 0;
			this.stringedInstrument1.Frets = 24;
			this.stringedInstrument1.Horizontal = true;
			this.stringedInstrument1.Location = new System.Drawing.Point( 25, 389 );
			this.stringedInstrument1.Name = "stringedInstrument1";
			this.stringedInstrument1.Size = new System.Drawing.Size( 681, 143 );
			this.stringedInstrument1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point( 25, 12 );
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size( 157, 87 );
			this.button1.TabIndex = 2;
			this.button1.Text = "Start or stop monitoring";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler( this.button1_Click );
			// 
			// TextRawData
			// 
			this.TextRawData.Font = new System.Drawing.Font( "Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
			this.TextRawData.Location = new System.Drawing.Point( 25, 125 );
			this.TextRawData.Multiline = true;
			this.TextRawData.Name = "TextRawData";
			this.TextRawData.Size = new System.Drawing.Size( 681, 236 );
			this.TextRawData.TabIndex = 3;
			// 
			// ControlForm
			// 
			this.ClientSize = new System.Drawing.Size( 755, 594 );
			this.Controls.Add( this.TextRawData );
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
		private System.Windows.Forms.TextBox TextRawData;

	}
}