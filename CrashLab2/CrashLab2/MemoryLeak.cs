namespace CrashLab2
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class MemoryLeak : Form
    {
        private bool _continue;
        private Button cmdStart;
        private Button cmdStop;
        private Container components;
        private Label label1;
        private Label label2;
        private RadioButton optManaged;
        private RadioButton optNative;
        private TextBox txtIterations;
        private TextBox txtSize;

        public MemoryLeak()
        {
            this.components = null;
            this._continue = true;
            this.InitializeComponent();
        }

        public MemoryLeak(bool managedLeak)
        {
            this.components = null;
            this._continue = true;
            this.InitializeComponent();
            if (managedLeak)
            {
                this.optManaged.Checked = true;
            }
            else
            {
                this.optNative.Checked = true;
            }
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            this._continue = true;
            int size = 0;
            int iterations = 0;
            size = int.Parse(this.txtSize.Text);
            iterations = int.Parse(this.txtIterations.Text);
            CrashLab2.State state = new CrashLab2.State(size, iterations);
            if (this.optManaged.Checked)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.ManagedLeak), state);
            }
            else
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.NativeLeak), state);
            }
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            this._continue = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        [DllImport("kernel32")]
        public static extern int GetProcessHeap();
        [DllImport("kernel32")]
        public static extern int HeapAlloc(int heap, int flags, int size);
        private void InitializeComponent()
        {
            this.cmdStart = new Button();
            this.cmdStop = new Button();
            this.optManaged = new RadioButton();
            this.optNative = new RadioButton();
            this.txtIterations = new TextBox();
            this.txtSize = new TextBox();
            this.label2 = new Label();
            this.label1 = new Label();
            base.SuspendLayout();
            this.cmdStart.Location = new Point(0x58, 0x60);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.TabIndex = 4;
            this.cmdStart.Text = "Start";
            this.cmdStart.Click += new EventHandler(this.cmdStart_Click);
            this.cmdStop.Location = new Point(8, 0x60);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.TabIndex = 5;
            this.cmdStop.Text = "Stop";
            this.cmdStop.Click += new EventHandler(this.cmdStop_Click);
            this.optManaged.Checked = true;
            this.optManaged.Location = new Point(0x60, 8);
            this.optManaged.Name = "optManaged";
            this.optManaged.Size = new Size(0x48, 0x18);
            this.optManaged.TabIndex = 11;
            this.optManaged.TabStop = true;
            this.optManaged.Text = "Managed";
            this.optNative.Location = new Point(0x10, 8);
            this.optNative.Name = "optNative";
            this.optNative.Size = new Size(0x40, 0x18);
            this.optNative.TabIndex = 10;
            this.optNative.Text = "Native";
            this.txtIterations.Location = new Point(80, 0x40);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new Size(0x48, 20);
            this.txtIterations.TabIndex = 6;
            this.txtIterations.Text = "1000";
            this.txtSize.Location = new Point(80, 40);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new Size(0x48, 20);
            this.txtSize.TabIndex = 7;
            this.txtSize.Text = "1024";
            this.label2.Location = new Point(8, 0x40);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x40, 0x17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Iterations";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            this.label1.Location = new Point(8, 40);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x40, 0x17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Size";
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            this.AutoScaleBaseSize = new Size(5, 13);
            base.ClientSize = new Size(0xb0, 0x7d);
            base.Controls.Add(this.optManaged);
            base.Controls.Add(this.optNative);
            base.Controls.Add(this.txtIterations);
            base.Controls.Add(this.txtSize);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.cmdStop);
            base.Controls.Add(this.cmdStart);
            base.Name = "MemoryLeak";
            this.Text = "Memory Leak";
            base.ResumeLayout(false);
        }

        private void ManagedLeak(object s)
        {
            CrashLab2.State state = (CrashLab2.State) s;
            ArrayList list = new ArrayList();
            for (int i = 0; i < state._iterations; i++)
            {
                if (!this._continue)
                {
                    break;
                }
                if ((i % 10) == 0)
                {
                    MainForm.Output(string.Format("Allocated: {0}", state._size * 10));
                }
                Thread.Sleep(10);
                list.Add(new byte[state._size]);
            }
        }

        private void NativeLeak(object s)
        {
            CrashLab2.State state = (CrashLab2.State) s;
            int heapHandle = GetProcessHeap();
            int address = 0;
            for (int i = 0; i < state._iterations; i++)
            {
                if (!this._continue)
                {
                    break;
                }
                if ((i % 10) == 0)
                {
                    MainForm.Output(string.Format("Allocated: {0}", state._size * 10));
                }
                Thread.Sleep(10);
                address = HeapAlloc(heapHandle, 0, state._size);
            }
        }
    }
}

