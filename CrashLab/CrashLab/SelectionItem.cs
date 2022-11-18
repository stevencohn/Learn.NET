//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab
{
	using System;
	using System.Reflection;
	using Resx = CrashLab.Properties.Resources;
	

	/// <summary>
	/// Represents a single item in the test selection combobox.
	/// </summary>
	
	internal class SelectionItem
	{
		private string hint;


		/// <summary>
		/// Initialize a new selection item.
		/// </summary>
		/// <param name="descriptor"></param>

		public SelectionItem (string descriptor)
		{
			var assembly = Assembly.GetExecutingAssembly();
			this.Type = assembly.GetType(descriptor);
			string name = this.Type.Name;

			this.Help = Resx.ResourceManager.GetString(name + "_Help");
			this.hint = Resx.ResourceManager.GetString(name + "_Hint");
			this.Exposed = String.IsNullOrEmpty(this.hint);

			this.Name = Resx.ResourceManager.GetString(name + "_Name");
		}


		/// <summary>
		/// Gets a Boolean value indicating whether this item should always be exposed
		/// regardless of the mysterious mode.
		/// </summary>

		public bool Exposed { get; private set; }


		/// <summary>
		/// Gets the full help of this test selection.
		/// </summary>

		public string Help { get; private set; }


		/// <summary>
		/// Gets the full help of this test selection.
		/// </summary>

		public string Hint
		{
			get { return hint ?? Help; }
		}


		/// <summary>
		/// Sets the item mystery index
		/// </summary>

		public int Index { get; set; }


		/// <summary>
		/// Gets the full text name of this test selection.
		/// </summary>

		public string Name { get; private set; }


		/// <summary>
		/// Get the type of the test selection.
		/// </summary>
	
		public Type Type { get; private set; }


		/// <summary>
		/// Returns the name of the test.
		/// </summary>
		/// <returns></returns>

		public override string ToString ()
		{
			return Index == 0 ? Name : "Mystery " + Index;
		}
	}
}
