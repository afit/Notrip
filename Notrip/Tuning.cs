using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LothianProductions.Notrip {
	
	[Serializable()]
	// FIXME rename to Tuning?
	public class Tuning {

		public Tuning( Note note, int octave ) {
			mNote = note;
			mOctave = octave;
		}
	
		protected Note mNote = Note.E;
		public Note Note {
			get{ return mNote; }
			set{ mNote = value; }
		}
		
		protected int mOctave = 4;
		public int Octave {
			get{ return mOctave; }
			set{ mOctave = value; }
		}	
	}
}
