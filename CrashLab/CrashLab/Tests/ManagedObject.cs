//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;


	/// <summary>
	/// Create a managed object to be investigated
	/// </summary>

	internal class ManagedObject : TestBase
	{

		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			var model = new ModelA();
			var other = new object();

			if (base.Mysterious)
			{
				Log(
					"Test run and Break called.  How many object do I own?  What are they?");
			}
			else
			{
				Log(
					"ManagedObject invoked and Break called..  How many object were just " +
					"created and what are their types?");
			}

			Win32.DebugBreak();
		}
	}
}
