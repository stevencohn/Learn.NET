//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.IO;
	using System.Text;


	/// <summary>
	/// Raise an handled/unhandled wrapped exception.
	/// </summary>

	internal class ManagedException : TestBase
	{

		/// <summary>
		/// Run the test...
		/// </summary>

		protected override void Execute ()
		{
			if (base.Mysterious)
			{
				Log(
					"Test run but did it work?  What happened?  "
					+ "(Don't cheat by looking at the error dialog!)");
			}
			else
			{
				Log(
					"Attempting to open a file with an invalid path. "
					+ "Find the offending line of code and why the file can't be found.");
			}

			var path = @"C:\"
				+ Path.GetFileNameWithoutExtension(Path.GetRandomFileName())
				+ @"\Random.txt";

			try
			{
				WriteToFile(path);
			}
			catch (Exception exc)
			{
				Log("Raising wrapped exception...");
				throw new RandomAccessException("Random access problem", exc);
			}
		}


		private void WriteToFile (string path)
		{
			using (var stream = new FileStream(path, FileMode.Open))
			{
				byte[] data = Encoding.ASCII.GetBytes(path);
				stream.Write(data, 0, data.Length);
				stream.Close();
			}
		}
	}


	/// <summary>
	/// Simple wrapper of a managed exception to demonstrate inner exceptions.
	/// </summary>

	internal class RandomAccessException : Exception
	{
		public RandomAccessException ()
			: base()
		{
		}


		public RandomAccessException (string message)
			: base(message)
		{
		}


		public RandomAccessException (string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
