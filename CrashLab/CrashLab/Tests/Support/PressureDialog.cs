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

	internal partial class PressureDialog : Form
	{

		/// <summary>
		/// 
		/// </summary>

		public PressureDialog ()
			: this(Pressure.DefaultIterations, Pressure.DefaultSize)
		{
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="iterations"></param>
		/// <param name="size"></param>

		public PressureDialog (int iterations, int size)
		{
			InitializeComponent();

			countBox.Value = iterations;
			sizeBox.Value = size;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>

		public Pressure Pressure { get; private set; }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void DoStart (object sender, EventArgs e)
		{
			Pressure = new Pressure((int)countBox.Value, (int)sizeBox.Value);
			this.DialogResult = DialogResult.OK;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void DoCancel (object sender, EventArgs e)
		{
			Pressure = null;
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
