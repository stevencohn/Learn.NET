namespace CrashLab2
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;

    public class Perf : Form
    {
        private bool _continue = true;
        private CrashLab2.State _state = new CrashLab2.State(700, 100000);
        private Button butGo;
        private Button butStop;
        private Container components = null;
        private Label label1;
        private Label label2;
        private TextBox txtIterations;
        private TextBox txtSize;

        public Perf()
        {
            this.InitializeComponent();
            this.txtIterations.Text = this._state._iterations.ToString();
            this.txtSize.Text = this._state._size.ToString();
        }

        private void butGo_Click(object sender, EventArgs e)
        {
            this._continue = true;
            this._state._iterations = int.Parse(this.txtIterations.Text);
            this._state._size = int.Parse(this.txtSize.Text);
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.PerfRun));
        }

        private void butStop_Click(object sender, EventArgs e)
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

        private void InitializeComponent()
        {
            this.txtIterations = new TextBox();
            this.txtSize = new TextBox();
            this.butGo = new Button();
            this.butStop = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            base.SuspendLayout();
            this.txtIterations.Location = new Point(8, 0x20);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new Size(0x80, 20);
            this.txtIterations.TabIndex = 0;
            this.txtIterations.Text = "";
            this.txtSize.Location = new Point(8, 0x58);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new Size(0x80, 20);
            this.txtSize.TabIndex = 1;
            this.txtSize.Text = "";
            this.butGo.Location = new Point(8, 120);
            this.butGo.Name = "butGo";
            this.butGo.Size = new Size(0x80, 0x17);
            this.butGo.TabIndex = 2;
            this.butGo.Text = "Go";
            this.butGo.Click += new EventHandler(this.butGo_Click);
            this.butStop.Location = new Point(8, 0x98);
            this.butStop.Name = "butStop";
            this.butStop.Size = new Size(0x80, 0x17);
            this.butStop.TabIndex = 3;
            this.butStop.Text = "Stop";
            this.butStop.Click += new EventHandler(this.butStop_Click);
            this.label1.Location = new Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x80, 0x10);
            this.label1.TabIndex = 4;
            this.label1.Text = "Iterations";
            this.label2.Location = new Point(8, 0x40);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x80, 0x10);
            this.label2.TabIndex = 5;
            this.label2.Text = "Size";
            this.AutoScaleBaseSize = new Size(5, 13);
            base.ClientSize = new Size(0x90, 0xb6);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.butStop);
            base.Controls.Add(this.butGo);
            base.Controls.Add(this.txtSize);
            base.Controls.Add(this.txtIterations);
            base.Name = "Perf";
            this.Text = "Perf";
            base.ResumeLayout(false);
        }

        private void PerfRun(object s)
        {
            DateTime start = DateTime.Now;
            MainForm.Output(string.Format("Begin - {0}", start.TimeOfDay.ToString()));
            ArrayList list = new ArrayList();
            int interval = this._state._iterations / 10;
            for (int i = 0; i < this._state._iterations; i++)
            {
                if (!this._continue)
                {
                    break;
                }
                if ((i % interval) == 0)
                {
                    long totalLen = 0L;
                    foreach (fobject o in list)
                    {
                        totalLen += o.lenOf("longStr");
                        totalLen += o.lenOf("byteArr");
                    }
                    MainForm.Output(string.Format("Allocated: {0} vs. {1}", this._state._size * 100, totalLen));
                    list.Clear();
                }
                list.Add(new fobject(this._state, this._state._size));
            }
            DateTime finish = DateTime.Now;
            MainForm.Output(string.Format("Done - {0}", finish.TimeOfDay.ToString()));
            finish.Subtract(start).ToString();
            MainForm.Output(string.Format("Elapsed - {0}", finish.Subtract(start).ToString()));
        }
    }
}

