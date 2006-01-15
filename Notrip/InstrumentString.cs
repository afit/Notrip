using System;
using System.Collections.Generic;
using System.Text;

namespace LothianProductions.Notrip {
	public class InstrumentString {

		public InstrumentString( Note note ) {
			mNote = note;
		}
	
		protected Note mNote = Note.E;
		public Note RootNote {
			get{ return mNote; }
			set{ mNote = value; }
		}
		
	}
}
