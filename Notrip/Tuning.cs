using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LothianProductions.Notrip {
	
	[Serializable()]
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
