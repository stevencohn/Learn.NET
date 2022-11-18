namespace CrashLab2
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class fobject : IDisposable
    {
        private byte[] byteArr;
        private int[] len;
        private object lockMon;
        private string longStr;
        private IntPtr procHandle;

        public fobject(object mon, int size)
        {
            this.lockMon = mon;
            this.byteArr = new byte[size];
            this.longStr = new StringBuilder(size / 2).ToString();
            this.procHandle = GetCurrentProcess();
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hObject);
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            CloseHandle(this.procHandle);
        }

        ~fobject()
        {
            lock (this.lockMon)
            {
                this.Dispose(false);
            }
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentProcess();
        public int lenOf(string item)
        {
            try
            {
                if (item == "byteArr")
                {
                    return this.len[0];
                }
                if (item == "longStr")
                {
                    return this.len[1];
                }
            }
            catch (NullReferenceException)
            {
                this.len = new int[] { this.byteArr.Length, this.longStr.Length };
                return this.lenOf(item);
            }
            return 0;
        }
    }
}

