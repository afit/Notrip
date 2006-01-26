using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LothianProductions.Notrip {
	public static class Program {
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>	
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler( UnhandledExceptionHandler );
			
			Application.Run( new ControlForm() );
		}
		
		private static void UnhandledExceptionHandler(Object sender, UnhandledExceptionEventArgs e) { 
			if( e.ExceptionObject != null )
				MessageBox.Show(
					"A fatal, unhandled error has occurred within Notrip, and the application must close." +
					"We're very sorry this happened. If you report the error below to the developers, at " +
					"notrip@lothianproductions.co.uk, they may be able to help you fix the problem.\n\n" +
					e.ExceptionObject.ToString(), "Notrip", MessageBoxButtons.OK );
		}
	}
}