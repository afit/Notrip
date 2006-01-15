using System;
using System.Collections.Generic;
using System.Text;

namespace LothianProductions.Notrip {
	public class InstrumentString {

		public InstrumentString( Note note, int steps ) {
			mNote = note;
			mStep = steps;
		}
	
		protected Note mNote = Note.E;
		public Note RootNote {
			get{ return mNote; }
			set{ mNote = value; }
		}
		
		protected int mStep = -17;
		public int RootSteps {
			get{ return mStep; }
			set{ mStep = value; }
		}
		
	}
}
