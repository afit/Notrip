using System;
using System.Collections.Generic;
using System.Text;

namespace LothianProductions.Notrip {
	public class Sound : Tuning {
		public Sound( Note note, int octave, int amplitude, double compensation ) : base( note, octave ) {
			mAmplitude = amplitude;
			mCompensation = compensation;
		}

		protected int mAmplitude;
		public int Amplitude {
			get{ return mAmplitude; }
			set{ mAmplitude = value; }
		}
		
		protected double mCompensation;
		public double Compensation {
			get{ return mCompensation; }
			set{ mCompensation = value; }
		}
	}
}
