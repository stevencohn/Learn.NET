namespace CrashLab2
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Resources;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class MainForm : Form
    {
        private static TextBox _output = null;
        private ComboBox cboDemos;
        private Button cmdGo;
        private Container components = null;
        private Label lblDemo;
        private string MOD1 = "Module 1";
        private string MOD2 = "Module 2";
        private string MOD3 = "Module 3";
        private string MOD4 = "Module 4";
		private string MOD5 = "Module 5";
        private TextBox txtOutput;
		private PictureBox pictureBox1;
        private string Whidbey = "Module Whidbey";

        public MainForm()
        {
            this.InitializeComponent();
            SetOutput(this.txtOutput);
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            string str = this.cboDemos.SelectedItem.ToString();
            PrintDemonstration(str);
            switch (str.Substring(str.IndexOf(":") + 2))
            {
                case "SOS Basics":								// DONE (threads)
                    SOSBasics.SOSBasicCommands();
                    break;

                case "Native Leak":								// DONE
                    SOSBasics.NativeMemoryLeak();
                    break;

				case "Managed Leak":							// DONE
                    SOSBasics.ManagedMemoryLeak();
                    break;

                case "Introductory Demo":						// DONE
                    SOSBasics.BlockedFinalizer();
                    break;

                case "Dispose Pattern w/ SuppressFinalizer":	// DONE
                    SOSBasics.CorrectDisposePattern();
                    break;

                case "Dispose Pattern w/o SuppressFinalizer":	// DONE
                    SOSBasics.NoSuppressFinalizer();
                    break;

                case "Dumping Managed Objects":					// DONE
                    SOSBasics.DumpingManagedObjects();
                    break;

                case "Thread Investigation":
                    SOSBasics.InvestigateThreads();
                    break;

                case "Setting Managed Breakpoints":
                    SOSBasics.ManagedBreakpoint();
                    break;

				case "Garbage Collect":							// DONE
                    GC.Collect();
                    break;

                case "Deadlock":								// DONE
                    SOSBasics.Deadlock();
                    break;

				case "High CPU":								// DONE
                    SOSBasics.HighCPU();
                    break;

				case "Low CPU":									// DONE
                    SOSBasics.LowCPU();
                    break;

				case "Managed Exception":						// DONE
                    SOSBasics.Except();
                    break;

                case "MDA":
                    SOSBasics.InvokeMDA();
                    break;

                case "Performance Analysis":					// DONE
                    new Perf().Show();
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
			this.cboDemos = new System.Windows.Forms.ComboBox();
			this.lblDemo = new System.Windows.Forms.Label();
			this.cmdGo = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// cboDemos
			// 
			this.cboDemos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboDemos.Items.AddRange(new object[] {
            "SOS Basics (!clrstack)",
            "SOS Basics (!threads)",
            "SOS Basics (!threadpool)",
            "SOS Basics (!dumpobj)",
            "SOS Basics (!dumpstackobjects)"});
			this.cboDemos.Location = new System.Drawing.Point(96, 8);
			this.cboDemos.Name = "cboDemos";
			this.cboDemos.Size = new System.Drawing.Size(267, 21);
			this.cboDemos.TabIndex = 0;
			// 
			// lblDemo
			// 
			this.lblDemo.Location = new System.Drawing.Point(8, 8);
			this.lblDemo.Name = "lblDemo";
			this.lblDemo.Size = new System.Drawing.Size(78, 23);
			this.lblDemo.TabIndex = 1;
			this.lblDemo.Text = "Demonstration";
			this.lblDemo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblDemo.Click += new System.EventHandler(this.lblDemo_Click);
			// 
			// cmdGo
			// 
			this.cmdGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdGo.Location = new System.Drawing.Point(396, 8);
			this.cmdGo.Name = "cmdGo";
			this.cmdGo.Size = new System.Drawing.Size(75, 23);
			this.cmdGo.TabIndex = 2;
			this.cmdGo.Text = "Go";
			this.cmdGo.Click += new System.EventHandler(this.cmdGo_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.AcceptsReturn = true;
			this.txtOutput.AcceptsTab = true;
			this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOutput.Location = new System.Drawing.Point(8, 40);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(355, 248);
			this.txtOutput.TabIndex = 3;
			this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(380, 40);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 248);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(492, 293);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.cmdGo);
			this.Controls.Add(this.lblDemo);
			this.Controls.Add(this.cboDemos);
			this.Name = "MainForm";
			this.Text = ".NETDebugWorkshop demo package";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        private void lblDemo_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.cboDemos.Items.Clear();
            this.cboDemos.Items.Add(string.Format("{0}: Introductory Demo", this.MOD1));
            this.cboDemos.Items.Add(string.Format("{0}: SOS Basics", this.MOD1));
            this.cboDemos.Items.Add(string.Format("{0}: Dumping Managed Objects", this.MOD2));
            this.cboDemos.Items.Add(string.Format("{0}: Thread Investigation", this.MOD2));
            this.cboDemos.Items.Add(string.Format("{0}: Setting Managed Breakpoints", this.MOD2));
            this.cboDemos.Items.Add(string.Format("{0}: Native Leak", this.MOD3));
            this.cboDemos.Items.Add(string.Format("{0}: Managed Leak", this.MOD3));
            this.cboDemos.Items.Add(string.Format("{0}: Dispose Pattern w/ SuppressFinalizer", this.MOD3));
            this.cboDemos.Items.Add(string.Format("{0}: Dispose Pattern w/o SuppressFinalizer", this.MOD3));
            this.cboDemos.Items.Add(string.Format("{0}: Garbage Collect", this.MOD3));
            this.cboDemos.Items.Add(string.Format("{0}: Deadlock", this.MOD4));
            this.cboDemos.Items.Add(string.Format("{0}: High CPU", this.MOD4));
            this.cboDemos.Items.Add(string.Format("{0}: Low CPU", this.MOD4));
            this.cboDemos.Items.Add(string.Format("{0}: Managed Exception", this.MOD5));
            this.cboDemos.Items.Add(string.Format("{0}: MDA", this.Whidbey));
            this.cboDemos.Items.Add(string.Format("{0}: Performance Analysis", this.Whidbey));
        }

        public static void Output(string str)
        {
            if (_output != null)
            {
                if (_output.InvokeRequired)
                {
                    SetOutputCallback soc = new SetOutputCallback(MainForm.Output);
                    _output.Invoke(soc, new object[] { str });
                    return;
                }
				_output.AppendText(str);
				_output.AppendText(Environment.NewLine);
                _output.ScrollToCaret();
            }
            Debug.WriteLine(str);
            Console.WriteLine(str);
        }

        private static void PrintDemonstration(string demo)
        {
            Output(new string('*', demo.Length + 6));
            Output(string.Format("** {0} **", demo));
            Output(new string('*', demo.Length + 6));
        }

        public static void SetOutput(TextBox txt)
        {
            _output = txt;
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
        }

        private delegate void SetOutputCallback(string str);
    }
}

