using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LothianProductions.Notrip {
	public partial class KeyedInstrument : UserControl {
		public KeyedInstrument() {
			InitializeComponent();
		}
	}
	
	public class PianoForm {
		List<BlackKey> BlackKeys = new List<BlackKey>();
		List<WhiteKey> WhiteKeys = new List<WhiteKey>();

	//	public static PianoKey CurrentKey = null;

		public PianoForm() {
	  int xpos = 20;
	  int ypos = 125;
	  for (int i = 0; i < 10; i ++) {
			WhiteKeys.Add(new WhiteKey(xpos, ypos, 0));
			xpos += WhiteKey.kWidth;
		}

     xpos  = 20 + WhiteKey.kWidth - BlackKey.kWidth/2;

 	 for (int i = 0; i < 10; i ++) {
		 if ((i == 2) || (i==6) || (i == 9)) {
			 // skip these
		 } else
			 BlackKeys.Add(new BlackKey(xpos, ypos, 0));
		 xpos += WhiteKey.kWidth;

		}
	}
		void DrawCurrentKey(Graphics g, WhiteKey p) {
			Rectangle r = p.Border;
			g.DrawRectangle(Pens.Red, r);
		}

		private void PianoForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			Graphics g = e.Graphics;

			foreach (PianoKey k  in WhiteKeys)
				k.Draw(g);

			foreach (PianoKey k  in BlackKeys)
				k.Draw(g);
		}
	}
	public class WhiteKey { 
		protected Point Position = new Point(0,0);
		protected int Frequency = 5000;

		protected Rectangle m_Border;

		public Rectangle Border {
			get{ return m_Border; }
		}	
		public static int kHeight = 150;
		int kWidth  = 50;

		public WhiteKey(int x, int y, int frequency) {
			Frequency = frequency;
			Position.X = x;
			Position.Y = y;
			m_Border = new Rectangle(x, y, kWidth, kHeight);
		}
		
		public void Draw (Graphics g)  {
			if (PianoForm.CurrentKey == this)
				g.FillRectangle(Brushes.White, Position.X, Position.Y, kWidth, kHeight);
			else
				g.FillRectangle(Brushes.SkyBlue, Position.X, Position.Y, kWidth, kHeight);


			g.DrawRectangle(Pens.Black, Position.X, Position.Y, kWidth, kHeight);
		}

		public bool IsContained(Point p) {
			Rectangle r = new Rectangle(Position.X, Position.Y, kWidth, kHeight);
			if (r.Contains(p))
				return true;

			return false;
		}
	}
	public class BlackKey : WhiteKey {
		int kHeight = 130;
		int kWidth  = 20;

		public BlackKey() {
			m_Border = new Rectangle(0, 0, kWidth, kHeight);
		}

		public BlackKey(int x, int y, int frequency) : base(x, y, frequency) {
			m_Border = new Rectangle(x, y, kWidth, kHeight);
		}

		public void Draw (Graphics g) {
			if (PianoForm.CurrentKey == this)
				g.FillRectangle(Brushes.LightBlue, Position.X, Position.Y, kWidth, kHeight);
			else
				g.FillRectangle(Brushes.Black, Position.X, Position.Y, kWidth, kHeight);
		}

		public bool IsContained(Point p) {
			Rectangle r = new Rectangle(Position.X, Position.Y, kWidth, kHeight);
			if (r.Contains(p))
				return true;

			return false;
		}
	}

	
}
