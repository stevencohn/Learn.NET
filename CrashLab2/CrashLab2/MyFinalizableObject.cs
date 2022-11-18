namespace CrashLab2
{
    using System;
    using System.Threading;

    internal class MyFinalizableObject : IDisposable
    {
        private byte[] _data = new byte[0x2800];
        private int _id = 0;
        private static int _idPriv = 0;
        private static int _refCount = 0;
        private bool _sleepDuringFinalizer = true;
        private bool _suppressFinalizer = true;
        public static object lockVar = new object();

        public MyFinalizableObject()
        {
            _idPriv = Interlocked.Increment(ref _idPriv);
            this._id = _idPriv;
            _refCount = Interlocked.Increment(ref _refCount);
            MainForm.Output(string.Format("Created MyFinalizableObject: count={0} id={1}", _refCount, this._id));
        }

        public void Dispose()
        {
            this.Dispose(true);
            if (this._suppressFinalizer)
            {
                GC.SuppressFinalize(this);
            }
        }

        private void Dispose(bool dispose)
        {
            if (dispose && this._suppressFinalizer)
            {
                Interlocked.Decrement(ref _refCount);
            }
            MainForm.Output(string.Format("Disposing MyFinalizableObject: count={0} id={1}", _refCount, this._id));
        }

        ~MyFinalizableObject()
        {
            MainForm.Output(string.Format("Finalizer MyFinalizableObject: count={0} id={1}", _refCount, this._id));
            if (this._sleepDuringFinalizer)
            {
                lock (lockVar)
                {
                    Interlocked.Decrement(ref _refCount);
                }
            }
            this.Dispose(false);
        }

        public bool SleepDuringFinalizer
        {
            get
            {
                return this._sleepDuringFinalizer;
            }
            set
            {
                this._sleepDuringFinalizer = value;
            }
        }

        public bool SuppressFinalizer
        {
            get
            {
                return this._suppressFinalizer;
            }
            set
            {
                this._suppressFinalizer = value;
            }
        }
    }
}

