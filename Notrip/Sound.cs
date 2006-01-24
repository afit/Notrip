using System;
using System.Collections.Generic;
using System.Text;

namespace LothianProductions.Notrip {

	[Serializable()]
	public class Sound : Tuning {
		public Sound( Note note, int octave, int step, int amplitude, double compensation ) : base( note, octave ) {
			mStep = step;
			mAmplitude = amplitude;
			mCompensation = compensation;
		}
		
		protected int mStep;
		public int Step {
			get{ return mStep; }
			set{ mStep = value; }
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
