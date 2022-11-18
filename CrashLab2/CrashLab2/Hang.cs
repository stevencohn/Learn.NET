namespace CrashLab2
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Forms;

    public class Hang : Form
    {
        private bool _stop;
        private ManualResetEvent _stopEvent;
        private ManualResetEvent _thread1;
        private ManualResetEvent _thread2;
        private Button cmdStart;
        private Button cmdStop;
        private Container components;
        private RadioButton optDeadlock;
        private RadioButton optHighCPU;
        private RadioButton optLowCPU;

        public Hang()
        {
            this.components = null;
            this._stop = false;
            this._stopEvent = new ManualResetEvent(false);
            this._thread1 = new ManualResetEvent(false);
            this._thread2 = new ManualResetEvent(false);
            this.InitializeComponent();
        }

        public Hang(string type)
        {
            this.components = null;
            this._stop = false;
            this._stopEvent = new ManualResetEvent(false);
            this._thread1 = new ManualResetEvent(false);
            this._thread2 = new ManualResetEvent(false);
            this.InitializeComponent();
            if (type.Equals("low"))
            {
                this.optLowCPU.Checked = true;
            }
            else if (type.Equals("high"))
            {
                this.optHighCPU.Checked = true;
            }
            else
            {
                this.optDeadlock.Checked = true;
            }
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            this._stop = false;
            if (this.optHighCPU.Checked)
            {
                new Thread(new ThreadStart(this.HighCPU)).Start();
            }
            else if (this.optLowCPU.Checked)
            {
                for (int i = 0; i < 10; i++)
                {
                    ThreadPool.QueueUserWorkItem(new WaitCallback(this.LowCPU), null);
                }
            }
            else if (this.optDeadlock.Checked)
            {
                this._stopEvent.Reset();
                new Thread(new ThreadStart(this.DeadlockThread1)).Start();
                new Thread(new ThreadStart(this.DeadlockThread2)).Start();
            }
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            this._stop = true;
            this._stopEvent.Set();
        }

        private void DeadlockThread1()
        {
            this._thread1.Reset();
            Thread.Sleep(1000);
            MainForm.Output("Thread 1 waiting ...");
            WaitHandle.WaitAny(new WaitHandle[] { this._thread2, this._stopEvent });
            MainForm.Output("Thread 1 done ...");
        }

        private void DeadlockThread2()
        {
            this._thread2.Reset();
            Thread.Sleep(1000);
            MainForm.Output("Thread 2 waiting ...");
            WaitHandle.WaitAny(new WaitHandle[] { this._thread1, this._stopEvent });
            MainForm.Output("Thread 2 done ...");
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
        public static extern int GetCurrentThreadId();
        private void HighCPU()
        {
            Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
            long x = 0L;
            long z = 0L;
            while (!this._stop)
            {
                x += 1L;
                z = 0L;
                for (int y = 0; y < 1000; y++)
                {
                    z += 1L;
                }
            }
            Thread.CurrentThread.Priority = ThreadPriority.Normal;
        }

        private void InitializeComponent()
        {
            this.optLowCPU = new RadioButton();
            this.optHighCPU = new RadioButton();
            this.cmdStop = new Button();
            this.cmdStart = new Button();
            this.optDeadlock = new RadioButton();
            base.SuspendLayout();
            this.optLowCPU.Checked = true;
            this.optLowCPU.Location = new Point(0x58, 8);
            this.optLowCPU.Name = "optLowCPU";
            this.optLowCPU.Size = new Size(0x48, 0x18);
            this.optLowCPU.TabIndex = 0x13;
            this.optLowCPU.TabStop = true;
            this.optLowCPU.Text = "Low CPU";
            this.optHighCPU.Location = new Point(8, 8);
            this.optHighCPU.Name = "optHighCPU";
            this.optHighCPU.Size = new Size(0x48, 0x18);
            this.optHighCPU.TabIndex = 0x12;
            this.optHighCPU.Text = "High CPU";
            this.cmdStop.Location = new Point(0x30, 0x30);
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.TabIndex = 13;
            this.cmdStop.Text = "Stop";
            this.cmdStop.Click += new EventHandler(this.cmdStop_Click);
            this.cmdStart.Location = new Point(0x80, 0x30);
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.TabIndex = 12;
            this.cmdStart.Text = "Start";
            this.cmdStart.Click += new EventHandler(this.cmdStart_Click);
            this.optDeadlock.Location = new Point(0xa8, 8);
            this.optDeadlock.Name = "optDeadlock";
            this.optDeadlock.Size = new Size(80, 0x18);
            this.optDeadlock.TabIndex = 20;
            this.optDeadlock.Text = "Deadlock";
            this.AutoScaleBaseSize = new Size(5, 13);
            base.ClientSize = new Size(0xf8, 0x4d);
            base.Controls.Add(this.optDeadlock);
            base.Controls.Add(this.optLowCPU);
            base.Controls.Add(this.optHighCPU);
            base.Controls.Add(this.cmdStop);
            base.Controls.Add(this.cmdStart);
            base.Name = "Hang";
            this.Text = "Hang";
            base.ResumeLayout(false);
        }

        private void LowCPU(object s)
        {
            MainForm.Output(string.Format("Waiting for lock: threadid={0}", GetCurrentThreadId()));
            lock (this)
            {
                MainForm.Output(string.Format("Acquired lock: threadid={0}", GetCurrentThreadId()));
                while (!this._stop)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}

