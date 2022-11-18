namespace CrashLab
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.selectLabel = new System.Windows.Forms.Label();
			this.selectionBox = new System.Windows.Forms.ComboBox();
			this.runButton = new System.Windows.Forms.Button();
			this.descriptionBox = new System.Windows.Forms.TextBox();
			this.logLabel = new System.Windows.Forms.Label();
			this.logBox = new System.Windows.Forms.TextBox();
			this.showCheckbox = new System.Windows.Forms.CheckBox();
			this.tabs = new System.Windows.Forms.TabControl();
			this.outPage = new System.Windows.Forms.TabPage();
			this.excPage = new System.Windows.Forms.TabPage();
			this.exceptionBox = new System.Windows.Forms.TextBox();
			this.stopButton = new System.Windows.Forms.Button();
			this.clearLink = new System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.runningManBox = new System.Windows.Forms.PictureBox();
			this.tabs.SuspendLayout();
			this.outPage.SuspendLayout();
			this.excPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.runningManBox)).BeginInit();
			this.SuspendLayout();
			// 
			// selectLabel
			// 
			this.selectLabel.AutoSize = true;
			this.selectLabel.Location = new System.Drawing.Point(12, 15);
			this.selectLabel.Name = "selectLabel";
			this.selectLabel.Size = new System.Drawing.Size(62, 13);
			this.selectLabel.TabIndex = 0;
			this.selectLabel.Text = "Select test:";
			// 
			// selectionBox
			// 
			this.selectionBox.BackColor = System.Drawing.Color.LightYellow;
			this.selectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.selectionBox.FormattingEnabled = true;
			this.selectionBox.Location = new System.Drawing.Point(78, 12);
			this.selectionBox.Name = "selectionBox";
			this.selectionBox.Size = new System.Drawing.Size(319, 21);
			this.selectionBox.TabIndex = 1;
			this.selectionBox.SelectedIndexChanged += new System.EventHandler(this.DoChangeSelection);
			// 
			// runButton
			// 
			this.runButton.ForeColor = System.Drawing.Color.Black;
			this.runButton.Location = new System.Drawing.Point(403, 10);
			this.runButton.Name = "runButton";
			this.runButton.Size = new System.Drawing.Size(75, 23);
			this.runButton.TabIndex = 2;
			this.runButton.Text = "Run!";
			this.runButton.UseVisualStyleBackColor = true;
			this.runButton.Click += new System.EventHandler(this.DoRun);
			// 
			// descriptionBox
			// 
			this.descriptionBox.BackColor = System.Drawing.Color.DimGray;
			this.descriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.descriptionBox.Cursor = System.Windows.Forms.Cursors.Default;
			this.descriptionBox.ForeColor = System.Drawing.Color.SkyBlue;
			this.descriptionBox.Location = new System.Drawing.Point(78, 63);
			this.descriptionBox.Multiline = true;
			this.descriptionBox.Name = "descriptionBox";
			this.descriptionBox.ReadOnly = true;
			this.descriptionBox.Size = new System.Drawing.Size(481, 41);
			this.descriptionBox.TabIndex = 3;
			// 
			// logLabel
			// 
			this.logLabel.AutoSize = true;
			this.logLabel.Location = new System.Drawing.Point(12, 121);
			this.logLabel.Name = "logLabel";
			this.logLabel.Size = new System.Drawing.Size(50, 13);
			this.logLabel.TabIndex = 5;
			this.logLabel.Text = "Test log:";
			// 
			// logBox
			// 
			this.logBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.logBox.Location = new System.Drawing.Point(3, 3);
			this.logBox.Multiline = true;
			this.logBox.Name = "logBox";
			this.logBox.ReadOnly = true;
			this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.logBox.Size = new System.Drawing.Size(467, 307);
			this.logBox.TabIndex = 6;
			this.logBox.Text = "Now is the time for all good men\r\nto come to the aid of the party";
			// 
			// showCheckbox
			// 
			this.showCheckbox.AutoSize = true;
			this.showCheckbox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.showCheckbox.Location = new System.Drawing.Point(78, 40);
			this.showCheckbox.Name = "showCheckbox";
			this.showCheckbox.Size = new System.Drawing.Size(190, 17);
			this.showCheckbox.TabIndex = 7;
			this.showCheckbox.Text = "Expose test names and descriptions";
			this.showCheckbox.UseVisualStyleBackColor = true;
			this.showCheckbox.CheckedChanged += new System.EventHandler(this.DoChangeMystery);
			// 
			// tabs
			// 
			this.tabs.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabs.Controls.Add(this.outPage);
			this.tabs.Controls.Add(this.excPage);
			this.tabs.Location = new System.Drawing.Point(78, 111);
			this.tabs.Multiline = true;
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(481, 339);
			this.tabs.TabIndex = 8;
			// 
			// outPage
			// 
			this.outPage.Controls.Add(this.logBox);
			this.outPage.Location = new System.Drawing.Point(4, 4);
			this.outPage.Name = "outPage";
			this.outPage.Padding = new System.Windows.Forms.Padding(3);
			this.outPage.Size = new System.Drawing.Size(473, 313);
			this.outPage.TabIndex = 0;
			this.outPage.Text = "Output";
			this.outPage.UseVisualStyleBackColor = true;
			// 
			// excPage
			// 
			this.excPage.Controls.Add(this.exceptionBox);
			this.excPage.Location = new System.Drawing.Point(4, 4);
			this.excPage.Name = "excPage";
			this.excPage.Padding = new System.Windows.Forms.Padding(3);
			this.excPage.Size = new System.Drawing.Size(473, 313);
			this.excPage.TabIndex = 1;
			this.excPage.Text = "Exception";
			this.excPage.UseVisualStyleBackColor = true;
			// 
			// exceptionBox
			// 
			this.exceptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.exceptionBox.Location = new System.Drawing.Point(3, 3);
			this.exceptionBox.Multiline = true;
			this.exceptionBox.Name = "exceptionBox";
			this.exceptionBox.ReadOnly = true;
			this.exceptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.exceptionBox.Size = new System.Drawing.Size(467, 307);
			this.exceptionBox.TabIndex = 0;
			this.exceptionBox.WordWrap = false;
			// 
			// stopButton
			// 
			this.stopButton.ForeColor = System.Drawing.Color.Black;
			this.stopButton.Location = new System.Drawing.Point(484, 10);
			this.stopButton.Name = "stopButton";
			this.stopButton.Size = new System.Drawing.Size(75, 23);
			this.stopButton.TabIndex = 9;
			this.stopButton.Text = "Stop";
			this.stopButton.UseVisualStyleBackColor = true;
			this.stopButton.Click += new System.EventHandler(this.DoAbort);
			// 
			// clearLink
			// 
			this.clearLink.ActiveLinkColor = System.Drawing.Color.White;
			this.clearLink.AutoSize = true;
			this.clearLink.LinkColor = System.Drawing.Color.White;
			this.clearLink.Location = new System.Drawing.Point(29, 153);
			this.clearLink.Name = "clearLink";
			this.clearLink.Size = new System.Drawing.Size(33, 13);
			this.clearLink.TabIndex = 11;
			this.clearLink.TabStop = true;
			this.clearLink.Text = "Clear";
			this.clearLink.VisitedLinkColor = System.Drawing.Color.White;
			this.clearLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DoClearLogs);
			this.clearLink.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DoLinkDown);
			this.clearLink.MouseEnter += new System.EventHandler(this.DoLinkEnter);
			this.clearLink.MouseLeave += new System.EventHandler(this.DoLinkLeave);
			this.clearLink.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DoLinkUp);
			// 
			// linkLabel1
			// 
			this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.LinkColor = System.Drawing.Color.White;
			this.linkLabel1.Location = new System.Drawing.Point(452, 438);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(109, 13);
			this.linkLabel1.TabIndex = 13;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Performance Report";
			this.linkLabel1.VisitedLinkColor = System.Drawing.Color.White;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DoPerfReport);
			this.linkLabel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DoLinkDown);
			this.linkLabel1.MouseEnter += new System.EventHandler(this.DoLinkEnter);
			this.linkLabel1.MouseLeave += new System.EventHandler(this.DoLinkLeave);
			this.linkLabel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DoLinkUp);
			// 
			// runningManBox
			// 
			this.runningManBox.Enabled = false;
			this.runningManBox.Image = global::CrashLab.Properties.Resources.RunningMan;
			this.runningManBox.Location = new System.Drawing.Point(15, 40);
			this.runningManBox.Name = "runningManBox";
			this.runningManBox.Size = new System.Drawing.Size(50, 50);
			this.runningManBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.runningManBox.TabIndex = 14;
			this.runningManBox.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.DimGray;
			this.ClientSize = new System.Drawing.Size(571, 462);
			this.Controls.Add(this.runningManBox);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.clearLink);
			this.Controls.Add(this.stopButton);
			this.Controls.Add(this.tabs);
			this.Controls.Add(this.descriptionBox);
			this.Controls.Add(this.showCheckbox);
			this.Controls.Add(this.selectLabel);
			this.Controls.Add(this.selectionBox);
			this.Controls.Add(this.runButton);
			this.Controls.Add(this.logLabel);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(587, 250);
			this.Name = "MainForm";
			this.Text = ".NET Test Dummy";
			this.tabs.ResumeLayout(false);
			this.outPage.ResumeLayout(false);
			this.outPage.PerformLayout();
			this.excPage.ResumeLayout(false);
			this.excPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.runningManBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label selectLabel;
		private System.Windows.Forms.ComboBox selectionBox;
		private System.Windows.Forms.Button runButton;
		private System.Windows.Forms.TextBox descriptionBox;
		private System.Windows.Forms.Label logLabel;
		private System.Windows.Forms.TextBox logBox;
		private System.Windows.Forms.CheckBox showCheckbox;
		private System.Windows.Forms.TabControl tabs;
		private System.Windows.Forms.TabPage outPage;
		private System.Windows.Forms.TabPage excPage;
		private System.Windows.Forms.TextBox exceptionBox;
		private System.Windows.Forms.Button stopButton;
		private System.Windows.Forms.LinkLabel clearLink;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.PictureBox runningManBox;
	}
}

