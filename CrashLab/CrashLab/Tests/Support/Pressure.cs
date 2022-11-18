//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	

	/// <summary>
	/// Basic pressure input variables like iterations and allocation size.
	/// </summary>

	internal class Pressure
	{

		public const int DefaultSize = 1024;
		public const int DefaultIterations = 100000;


		/// <summary>
		/// Initialize a new pressure item.
		/// </summary>
		/// <param name="iterations">Default 1000</param>
		/// <param name="size">Default 1024</param>

		public Pressure (int iterations, int size)
		{
			this.Iterations = iterations;
			this.Size = size;
		}


		/// <summary>
		/// Gets the number of iterations to execute.
		/// </summary>

		public int Iterations { get; private set; }


		/// <summary>
		/// Gets the size of memory to allocate.
		/// </summary>

		public int Size { get; private set; }
	}
}
