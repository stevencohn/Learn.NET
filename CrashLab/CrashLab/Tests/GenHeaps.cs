//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;


	/// <summary>
	/// Follow an object across generations
	/// </summary>

	internal class GenHeaps : TestBase
	{

		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			var model = new ModelA();
			Log("ModelA instance just created");
			Win32.DebugBreak();

			GC.Collect();
			Log("GC run once, find ModelA");
			Win32.DebugBreak();

			GC.Collect();
			Log("GC run twice, find ModelA");
			Win32.DebugBreak();

			model = null;

			GC.Collect();
			Log("GC run after ModelA unrooted");
			Win32.DebugBreak();
		}
	}
}
