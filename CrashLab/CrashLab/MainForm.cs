//************************************************************************************************
// Copyright © 2013 Steven M Cohn. All Rights Reserved.
//
//************************************************************************************************

namespace CrashLab
{
	using System;
	using System.Drawing;
	using System.Linq;
	using System.Windows.Forms;
	using System.Xml.Linq;
	using Resx = CrashLab.Properties.Resources;


	/// <summary>
	/// Implementation of main window
	/// </summary>

	internal partial class MainForm : Form, IHost
	{
		private bool mysterious;


		/// <summary>
		/// Constructor
		/// </summary>

		public MainForm ()
		{
			InitializeComponent();

			mysterious = true;
			showCheckbox.Checked = false;
			logBox.Clear();

			PopulateTestSelections();
			selectionBox.Focus();
		}


		/// <summary>
		/// 
		/// </summary>

		public event AbortHandler AbortTest;


		/// <summary>
		/// 
		/// </summary>

		public bool Mysterious { get { return mysterious; } }


		/// <summary>
		/// 
		/// </summary>

		private void CompletedTest ()
		{
			runningManBox.Enabled = false;
		}

		private void StartedTest ()
		{
			runningManBox.Enabled = true;
		}

	
		/// <summary>
		/// Abort the currently running test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void DoAbort (object sender, EventArgs e)
		{
			CompletedTest();
			if (AbortTest != null)
			{
				AbortTest();
			}
		}


		/// <summary>
		/// Handles changes to showCheckbox.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void DoChangeMystery (object sender, EventArgs e)
		{
			mysterious = !showCheckbox.Checked;

			int index = selectionBox.SelectedIndex;

			PopulateTestSelections();

			selectionBox.SelectedIndex = index;
			selectionBox.Focus();
		}


		/// <summary>
		/// Clear both the output log box and the exception box.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void DoClearLogs (object sender, LinkLabelLinkClickedEventArgs e)
		{
			logBox.Clear();
			exceptionBox.Clear();
		}

	
		/// <summary>
		/// Show the description of the selected test.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void DoChangeSelection (object sender, EventArgs e)
		{
			var item = selectionBox.SelectedItem as SelectionItem;
			descriptionBox.Text = mysterious ? item.Hint : item.Help;
		}


		#region LinkLabel Customizations
		private void DoLinkEnter (object sender, EventArgs e)
		{
			var link = sender as LinkLabel;
			link.LinkColor = Color.SkyBlue;
			link.ActiveLinkColor = Color.SkyBlue;
			link.VisitedLinkColor = Color.SkyBlue;
		}

		private void DoLinkLeave (object sender, EventArgs e)
		{
			var link = sender as LinkLabel;
			link.LinkColor = Color.White;
			link.ActiveLinkColor = Color.White;
			link.VisitedLinkColor = Color.White;
		}

		private void DoLinkDown (object sender, MouseEventArgs e)
		{
			var link = sender as LinkLabel;
			link.LinkColor = Color.CornflowerBlue;
			link.ActiveLinkColor = Color.CornflowerBlue;
			link.VisitedLinkColor = Color.CornflowerBlue;
		}

		private void DoLinkUp (object sender, MouseEventArgs e)
		{
			DoLinkEnter(sender, e);
		}
		#endregion LinkLabel Customizations


		private void DoPerfReport (object sender, LinkLabelLinkClickedEventArgs e)
		{
			var reporter = new PerfReporter(this);
			reporter.Report();
		}

	
		/// <summary>
		/// Run the currently selected test
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>

		private void DoRun (object sender, EventArgs e)
		{
			var item = selectionBox.SelectedItem as SelectionItem;
			if (item != null)
			{
				Log(String.Empty);

				var constructor = item.Type.GetConstructor(new Type[0]);
				var test = constructor.Invoke(new object[0]) as ITest;
				test.Started += StartedTest;
				test.Completed += CompletedTest;

				try
				{
					test.Execute(this);
				}
				catch (Exception exc)
				{
					runningManBox.Enabled = false;
					Log(exc);
					throw;
				}
			}
		}


		/// <summary>
		/// 
		/// </summary>

		private void PopulateTestSelections ()
		{
			var doc = XElement.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

			var names =
				from e in doc.Elements("Tests").Elements()
				select e.Value;

			if (names != null)
			{
				selectionBox.Items.Clear();

				int count = 1;
				foreach (string name in names)
				{
					var item = new SelectionItem(name);
					item.Index = (mysterious && !item.Exposed ? count++ : 0);

					selectionBox.Items.Add(item);
				}

				selectionBox.SelectedIndex = 0;
			}
		}


		#region Logging

		/// <summary>
		/// Write a single line of text to the output log.
		/// </summary>
		/// <param name="text"></param>

		public void Log (string text)
		{
			if (InvokeRequired)
			{
				Invoke((Action)delegate { Log(text); });
				return;
			}

			logBox.AppendText(text + Environment.NewLine);
			logBox.ScrollToCaret();
		}


		/// <summary>
		/// Write a formatted exception to the output log.
		/// </summary>
		/// <param name="exc"></param>

		public void Log (Exception exc)
		{
			if (InvokeRequired)
			{
				Invoke((Action)delegate { Log(exc); });
				return;
			}

			string text = ExceptionEncoder.Encode(exc);
			exceptionBox.AppendText(text + Environment.NewLine);
			exceptionBox.ScrollToCaret();
		}


		public void LogDot ()
		{
			if (InvokeRequired)
			{
				Invoke((Action)delegate { LogDot(); });
				return;
			}

			logBox.AppendText(".");
			logBox.ScrollToCaret();
		}

		#endregion Logging
	}
}
