namespace CrashLab.Tests
{
	partial class DeadlockDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeadlockDialog));
			this.mainPanel = new System.Windows.Forms.Panel();
			this.backgroundBox = new System.Windows.Forms.CheckBox();
			this.resetRadio = new System.Windows.Forms.RadioButton();
			this.lockRadio = new System.Windows.Forms.RadioButton();
			this.cancelButton = new System.Windows.Forms.Button();
			this.startButton = new System.Windows.Forms.Button();
			this.helpBox = new System.Windows.Forms.TextBox();
			this.backgroundLabel = new System.Windows.Forms.Label();
			this.mainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.BackColor = System.Drawing.Color.DimGray;
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.backgroundLabel);
			this.mainPanel.Controls.Add(this.backgroundBox);
			this.mainPanel.Controls.Add(this.resetRadio);
			this.mainPanel.Controls.Add(this.lockRadio);
			this.mainPanel.Controls.Add(this.cancelButton);
			this.mainPanel.Controls.Add(this.startButton);
			this.mainPanel.Controls.Add(this.helpBox);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.ForeColor = System.Drawing.Color.White;
			this.mainPanel.Location = new System.Drawing.Point(5, 5);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Padding = new System.Windows.Forms.Padding(10);
			this.mainPanel.Size = new System.Drawing.Size(240, 170);
			this.mainPanel.TabIndex = 0;
			// 
			// backgroundBox
			// 
			this.backgroundBox.AutoSize = true;
			this.backgroundBox.Location = new System.Drawing.Point(59, 70);
			this.backgroundBox.Name = "backgroundBox";
			this.backgroundBox.Size = new System.Drawing.Size(126, 17);
			this.backgroundBox.TabIndex = 9;
			this.backgroundBox.Text = "Run in background";
			this.backgroundBox.UseVisualStyleBackColor = true;
			// 
			// resetRadio
			// 
			this.resetRadio.AutoSize = true;
			this.resetRadio.Location = new System.Drawing.Point(36, 95);
			this.resetRadio.Name = "resetRadio";
			this.resetRadio.Size = new System.Drawing.Size(120, 17);
			this.resetRadio.TabIndex = 8;
			this.resetRadio.Text = "ManualResetEvent";
			this.resetRadio.UseVisualStyleBackColor = true;
			this.resetRadio.CheckedChanged += new System.EventHandler(this.DoResetChanged);
			// 
			// lockRadio
			// 
			this.lockRadio.AutoSize = true;
			this.lockRadio.Checked = true;
			this.lockRadio.Location = new System.Drawing.Point(39, 51);
			this.lockRadio.Name = "lockRadio";
			this.lockRadio.Size = new System.Drawing.Size(117, 17);
			this.lockRadio.TabIndex = 7;
			this.lockRadio.TabStop = true;
			this.lockRadio.Text = "C# lock statement";
			this.lockRadio.UseVisualStyleBackColor = true;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.ForeColor = System.Drawing.Color.Black;
			this.cancelButton.Location = new System.Drawing.Point(153, 132);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.DoCancel);
			// 
			// startButton
			// 
			this.startButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.startButton.ForeColor = System.Drawing.Color.Black;
			this.startButton.Location = new System.Drawing.Point(72, 132);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 5;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.DoStart);
			// 
			// helpBox
			// 
			this.helpBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.helpBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.helpBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.helpBox.ForeColor = System.Drawing.Color.White;
			this.helpBox.Location = new System.Drawing.Point(10, 10);
			this.helpBox.Multiline = true;
			this.helpBox.Name = "helpBox";
			this.helpBox.ReadOnly = true;
			this.helpBox.Size = new System.Drawing.Size(218, 32);
			this.helpBox.TabIndex = 0;
			this.helpBox.TabStop = false;
			this.helpBox.Text = "Choose the synchronization mechanism used to create a deadlock.";
			// 
			// backgroundLabel
			// 
			this.backgroundLabel.AutoSize = true;
			this.backgroundLabel.ForeColor = System.Drawing.Color.DarkGray;
			this.backgroundLabel.Location = new System.Drawing.Point(75, 71);
			this.backgroundLabel.Name = "backgroundLabel";
			this.backgroundLabel.Size = new System.Drawing.Size(107, 13);
			this.backgroundLabel.TabIndex = 10;
			this.backgroundLabel.Text = "Run in background";
			this.backgroundLabel.Visible = false;
			// 
			// DeadlockDialog
			// 
			this.AcceptButton = this.startButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(250, 180);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DeadlockDialog";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pressure Settings";
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.TextBox helpBox;
		private System.Windows.Forms.RadioButton resetRadio;
		private System.Windows.Forms.RadioButton lockRadio;
		private System.Windows.Forms.CheckBox backgroundBox;
		private System.Windows.Forms.Label backgroundLabel;
	}
}