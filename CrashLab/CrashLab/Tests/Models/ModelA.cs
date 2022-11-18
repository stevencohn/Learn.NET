//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	
	internal class ModelA
	{
		private int number;
		private string text;
		private string[] quotes;
		private byte[] data;
		private DateTime dttm;
		private List<object> list;
		private object something;
		private ModelB child;
		private ModelC extra;


		/// <summary>
		/// 
		/// </summary>

		public ModelA ()
		{
			this.number = 29029;
			this.text = "Now is the time for all good men...";
			this.quotes = new string[] { "one", "two", "three", "four", "five" };
			this.data = new byte[] { 0xDE, 0xAD, 0xBE, 0xEF };
			this.dttm = DateTime.Now;
			this.list = new List<object>() { 111, 222 };
			this.something = new object();
			this.child = new ModelB();
			this.extra = new ModelC(0x0BADF00D);
		}


		public int Number { get { return number; } }
		public string Text { get { return text; } }
		public string[] Quotes { get { return quotes; } }
		public byte[] Data { get { return data; } }
		public DateTime Dttm { get { return dttm; } }
		public List<object> List { get { return list; } }
		public object Something { get { return something; } }
		public ModelB Child { get { return child; } }
		public ModelC Extra { get { return extra; } }
	}
}
