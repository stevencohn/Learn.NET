//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab.Tests
{
	using System;
	using System.Windows.Forms;

	
	/// <summary>
	/// 
	/// </summary>

	internal partial class HangDialog : Form
	{


		/// <summary>
		/// 
		/// </summary>

		public HangDialog ()
		{
			InitializeComponent();
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>

		public bool Background { get; private set; }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void DoStart (object sender, EventArgs e)
		{
			Background = backgroundRadio.Checked;
			this.DialogResult = DialogResult.OK;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void DoCancel (object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
