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

	internal partial class DeadlockDialog : Form
	{


		/// <summary>
		/// 
		/// </summary>

		public DeadlockDialog ()
		{
			InitializeComponent();
		}


		/// <summary>
		/// 
		/// </summary>

		public bool Background { get { return backgroundBox.Checked; } }


		/// <summary>
		/// 
		/// </summary>

		public bool UseLock { get { return lockRadio.Checked; } }



		private void DoCancel (object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}


		private void DoResetChanged (object sender, EventArgs e)
		{
			backgroundBox.Enabled = lockRadio.Checked;
			backgroundLabel.Visible = !backgroundBox.Enabled;
		}


		private void DoStart (object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
	}
}
