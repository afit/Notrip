using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace LothianProductions.Notrip {

/// <summary>
/// First octave begins at	-32
/// Second					-24
/// Third					-12
/// Fourth					0
/// </summary>

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
	
	public class NoteHelper {
	
		protected static NoteHelper mInstance = new NoteHelper();
	
		public static NoteHelper Instance() {
			return mInstance;
		}
		
		protected List<Note> mOrderedNotes = new List<Note>();
		protected List<String> mOrderedNoteNames = new List<String>();
		
		protected NoteHelper() {
			foreach( Note orderedNote in Enum.GetValues( typeof(Note) ) ) {
				mOrderedNotes.Add( orderedNote );
				mOrderedNoteNames.Add( orderedNote.ToString().Replace( "sharp", "#" ).Replace( "flat", "b" ) );
			}	
		}
		
		public List<Note> GetOrderedNotes() {
			return mOrderedNotes;
		}
		
		public List<String> GetOrderedNoteNames() {
			return mOrderedNoteNames;
		}
	}
}
