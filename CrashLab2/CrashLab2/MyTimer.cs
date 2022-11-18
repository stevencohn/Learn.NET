namespace CrashLab2
{
    using System;
    using System.Threading;

    internal class MyTimer
    {
        public ManualResetEvent TimerEvent = new ManualResetEvent(false);

        public MyTimer()
        {
            Timer timer = new Timer(new TimerCallback(this.TimerMethod), null, TimeSpan.FromSeconds(5.0), TimeSpan.FromSeconds(5.0));
            Timer TickTimer = new Timer(new TimerCallback(this.Tick), null, TimeSpan.FromSeconds(1.0), TimeSpan.FromSeconds(1.0));
        }

        public void Tick(object state)
        {
            MainForm.Output(".");
        }

        public void TimerMethod(object state)
        {
            MainForm.Output("The Timer invoked this method.");
            this.TimerEvent.Set();
        }
    }
}

