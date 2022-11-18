namespace CrashLab.Tests
{
	partial class HangDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HangDialog));
			this.mainPanel = new System.Windows.Forms.Panel();
			this.cancelButton = new System.Windows.Forms.Button();
			this.startButton = new System.Windows.Forms.Button();
			this.helpBox = new System.Windows.Forms.TextBox();
			this.backgroundRadio = new System.Windows.Forms.RadioButton();
			this.uiRadio = new System.Windows.Forms.RadioButton();
			this.mainPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.BackColor = System.Drawing.Color.DimGray;
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.uiRadio);
			this.mainPanel.Controls.Add(this.backgroundRadio);
			this.mainPanel.Controls.Add(this.cancelButton);
			this.mainPanel.Controls.Add(this.startButton);
			this.mainPanel.Controls.Add(this.helpBox);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.ForeColor = System.Drawing.Color.White;
			this.mainPanel.Location = new System.Drawing.Point(5, 5);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Padding = new System.Windows.Forms.Padding(10);
			this.mainPanel.Size = new System.Drawing.Size(240, 157);
			this.mainPanel.TabIndex = 0;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.ForeColor = System.Drawing.Color.Black;
			this.cancelButton.Location = new System.Drawing.Point(153, 120);
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
			this.startButton.Location = new System.Drawing.Point(72, 120);
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
			this.helpBox.Size = new System.Drawing.Size(218, 41);
			this.helpBox.TabIndex = 0;
			this.helpBox.TabStop = false;
			this.helpBox.Text = "Would you like to run this test from a background thread or on the UI thread?";
			// 
			// backgroundRadio
			// 
			this.backgroundRadio.AutoSize = true;
			this.backgroundRadio.Checked = true;
			this.backgroundRadio.Location = new System.Drawing.Point(49, 58);
			this.backgroundRadio.Name = "backgroundRadio";
			this.backgroundRadio.Size = new System.Drawing.Size(145, 17);
			this.backgroundRadio.TabIndex = 7;
			this.backgroundRadio.TabStop = true;
			this.backgroundRadio.Text = "Run in the background";
			this.backgroundRadio.UseVisualStyleBackColor = true;
			// 
			// uiRadio
			// 
			this.uiRadio.AutoSize = true;
			this.uiRadio.Location = new System.Drawing.Point(49, 81);
			this.uiRadio.Name = "uiRadio";
			this.uiRadio.Size = new System.Drawing.Size(134, 17);
			this.uiRadio.TabIndex = 8;
			this.uiRadio.Text = "Run on the UI thread";
			this.uiRadio.UseVisualStyleBackColor = true;
			// 
			// HangDialog
			// 
			this.AcceptButton = this.startButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(250, 167);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "HangDialog";
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
		private System.Windows.Forms.RadioButton uiRadio;
		private System.Windows.Forms.RadioButton backgroundRadio;
	}
}