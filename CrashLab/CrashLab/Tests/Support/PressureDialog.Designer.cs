namespace CrashLab.Tests
{
	partial class PressureDialog
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
			this.countBox = new System.Windows.Forms.NumericUpDown();
			this.sizeBox = new System.Windows.Forms.NumericUpDown();
			this.countLabel = new System.Windows.Forms.Label();
			this.sizeLabel = new System.Windows.Forms.Label();
			this.helpBox = new System.Windows.Forms.TextBox();
			this.mainPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.countBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeBox)).BeginInit();
			this.SuspendLayout();
			// 
			// mainPanel
			// 
			this.mainPanel.BackColor = System.Drawing.Color.DimGray;
			this.mainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mainPanel.Controls.Add(this.cancelButton);
			this.mainPanel.Controls.Add(this.startButton);
			this.mainPanel.Controls.Add(this.countBox);
			this.mainPanel.Controls.Add(this.sizeBox);
			this.mainPanel.Controls.Add(this.countLabel);
			this.mainPanel.Controls.Add(this.sizeLabel);
			this.mainPanel.Controls.Add(this.helpBox);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.ForeColor = System.Drawing.Color.White;
			this.mainPanel.Location = new System.Drawing.Point(5, 5);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Padding = new System.Windows.Forms.Padding(10);
			this.mainPanel.Size = new System.Drawing.Size(277, 157);
			this.mainPanel.TabIndex = 0;
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.ForeColor = System.Drawing.Color.Black;
			this.cancelButton.Location = new System.Drawing.Point(190, 120);
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
			this.startButton.Location = new System.Drawing.Point(109, 120);
			this.startButton.Name = "startButton";
			this.startButton.Size = new System.Drawing.Size(75, 23);
			this.startButton.TabIndex = 5;
			this.startButton.Text = "Start";
			this.startButton.UseVisualStyleBackColor = true;
			this.startButton.Click += new System.EventHandler(this.DoStart);
			// 
			// countBox
			// 
			this.countBox.Location = new System.Drawing.Point(100, 85);
			this.countBox.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.countBox.Name = "countBox";
			this.countBox.Size = new System.Drawing.Size(120, 22);
			this.countBox.TabIndex = 4;
			// 
			// sizeBox
			// 
			this.sizeBox.Location = new System.Drawing.Point(100, 57);
			this.sizeBox.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
			this.sizeBox.Name = "sizeBox";
			this.sizeBox.Size = new System.Drawing.Size(120, 22);
			this.sizeBox.TabIndex = 3;
			// 
			// countLabel
			// 
			this.countLabel.AutoSize = true;
			this.countLabel.Location = new System.Drawing.Point(35, 87);
			this.countLabel.Name = "countLabel";
			this.countLabel.Size = new System.Drawing.Size(59, 13);
			this.countLabel.TabIndex = 2;
			this.countLabel.Text = "Iterations:";
			// 
			// sizeLabel
			// 
			this.sizeLabel.AutoSize = true;
			this.sizeLabel.Location = new System.Drawing.Point(29, 59);
			this.sizeLabel.Name = "sizeLabel";
			this.sizeLabel.Size = new System.Drawing.Size(65, 13);
			this.sizeLabel.TabIndex = 1;
			this.sizeLabel.Text = "Buffer Size:";
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
			this.helpBox.Size = new System.Drawing.Size(255, 41);
			this.helpBox.TabIndex = 0;
			this.helpBox.TabStop = false;
			this.helpBox.Text = "Please, enter the size of a buffer to allocate and the number of times it should " +
    "be allocated";
			// 
			// PressureDialog
			// 
			this.AcceptButton = this.startButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.CancelButton = this.cancelButton;
			this.ClientSize = new System.Drawing.Size(287, 167);
			this.Controls.Add(this.mainPanel);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "PressureDialog";
			this.Padding = new System.Windows.Forms.Padding(5);
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Pressure Settings";
			this.mainPanel.ResumeLayout(false);
			this.mainPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.countBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sizeBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Button startButton;
		private System.Windows.Forms.NumericUpDown countBox;
		private System.Windows.Forms.NumericUpDown sizeBox;
		private System.Windows.Forms.Label countLabel;
		private System.Windows.Forms.Label sizeLabel;
		private System.Windows.Forms.TextBox helpBox;
	}
}