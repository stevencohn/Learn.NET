//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab
{
	using System;


	internal delegate void AbortHandler ();


	/// <summary>
	/// Provides a simple interface for tests to communiate back to the
	/// host (MainWindow) without exposing its specific implementation.
	/// </summary>

	internal interface IHost
	{

		/// <summary>
		/// Signals that the subscriber should abort any ongoing test activity.
		/// This is managed by the TestBase class so tests do not need to worry
		/// about this themselves.
		/// </summary>

		event AbortHandler AbortTest;


		/// <summary>
		/// Gets a Boolean value indicating whether tests should be run in
		/// mysterious mode.
		/// </summary>

		bool Mysterious { get; }


		/// <summary>
		/// Write a single line message to the logger.
		/// </summary>
		/// <param name="text"></param>

		void Log (string text);


		/// <summary>
		/// Write a detailed exception to the logger.
		/// </summary>
		/// <param name="exc"></param>

		void Log (Exception exc);


		/// <summary>
		/// Writes a single period to the logger without a CR.  Used to indicate
		/// incremental steps within a long-running activity.
		/// </summary>

		void LogDot ();
	}
}
