using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LothianProductions.Notrip {

	[Serializable()]
	public enum Note : int {
		A,
		Bflat,
		B,
		C,
		Csharp,
		D,
		Dsharp,
		E,
		F,
		Fsharp,
		G,
		Gsharp
	}
}
