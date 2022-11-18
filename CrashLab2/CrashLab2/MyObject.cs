namespace CrashLab2
{
    using System;
    using System.Collections;
    using System.Threading;

    internal class MyObject
    {
        public static bool _jitted = false;
        private string[] _myArray;
        private DateTime _myDate;
        private Hashtable _myHashtable;
        private object _myNullObject;
        private MyOtherObject _myOtherObject;
        private string _myProperty;
        private string _myString;
        private int _sleepTime;

        public MyObject()
        {
            this._myString = "hello world";
            this._myProperty = "hello world";
            this._myDate = DateTime.Now;
            this._myHashtable = null;
            this._myNullObject = null;
            this._myOtherObject = null;
            this._sleepTime = 0x2710;
            this._myArray = new string[] { "one", "two", "three", "four" };
            this._myHashtable = new Hashtable();
            this._myHashtable["one"] = "hello";
            this._myHashtable["two"] = "world";
            this._myHashtable["three"] = "foo";
            this._myHashtable["four"] = "bar";
            this._myOtherObject = new MyOtherObject();
            this._myNullObject = null;
        }

        public MyObject(int sleepTime) : this()
        {
            this._sleepTime = sleepTime;
        }

        private void DoSomeWorkInThreadpool()
        {
            this.Sleeping(this._sleepTime);
        }

        private void DoSomeWorkOnThread()
        {
            this.Sleeping(this._sleepTime);
        }

        public void JitterBug()
        {
            if (!_jitted)
            {
                MainForm.Output("Method has been called.");
                SOSBasics.DebugBreak();
                _jitted = true;
            }
        }

        public void MyMethod1()
        {
            this.MyMethod2();
        }

        public void MyMethod2()
        {
            this.MyMethod3();
        }

        public void MyMethod3()
        {
            SOSBasics.DebugBreak();
        }

        private void MyThreadFunc()
        {
            this.DoSomeWorkOnThread();
        }

        private void MyThreadpoolFunc(object data)
        {
            this.DoSomeWorkInThreadpool();
        }

        private void Sleeping(int time)
        {
            Thread.Sleep(time);
        }

        public void SpinUpThreadpoolThreads(int count)
        {
            for (int i = 0; i < count; i++)
            {
                MainForm.Output(string.Format("Creating ThreadPool Thread ...", new object[0]));
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.MyThreadpoolFunc), null);
            }
        }

        public void SpinUpThreads(int count)
        {
            for (int i = 0; i < count; i++)
            {
                MainForm.Output(string.Format("Creating Managed Thread ...", new object[0]));
                new Thread(new ThreadStart(this.MyThreadFunc)).Start();
            }
        }

        public DateTime MyDate
        {
            get
            {
                return this._myDate;
            }
            set
            {
                this._myDate = value;
            }
        }

        public string MyProperty
        {
            get
            {
                return this._myProperty;
            }
            set
            {
                this._myProperty = value;
            }
        }

        public int SleepTime
        {
            get
            {
                return this._sleepTime;
            }
            set
            {
                this._sleepTime = value;
            }
        }
    }
}

