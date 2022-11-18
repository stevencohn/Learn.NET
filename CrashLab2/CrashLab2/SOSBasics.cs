namespace CrashLab2
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;

    public class SOSBasics
    {
        public static void BlockedFinalizer()
        {
            lock (MyFinalizableObject.lockVar)
            {
                for (int j = 0; j < 10; j++) // 1000
                {
                    int objectCount = 10; // 100
                    for (int i = 0; i < objectCount; i++)
                    {
                        MyFinalizableObject obj = new MyFinalizableObject();
                        obj.SuppressFinalizer = false;
                        obj.SleepDuringFinalizer = true;
                        Thread.Sleep(50);
                    }
                    Application.DoEvents();
                }
            }
        }

        public static void CorrectDisposePattern()
        {
            int objectCount = 10;
            for (int i = 0; i < objectCount; i++)
            {
                MyFinalizableObject obj = new MyFinalizableObject();
                obj.SuppressFinalizer = true;
                obj.SleepDuringFinalizer = false;
                obj.Dispose();
            }
        }

        public static void Deadlock()
        {
            new Hang("deadlock").Show();
        }

        [DllImport("kernel32")]
        public static extern void DebugBreak();
        public static void DumpingManagedObjects()
        {
            MyObject myObject = new MyObject();
            object obj = new object();
            DebugBreak();
        }

        public static void Except()
        {
            string str = @"c:\Workshops\dotNetDebug\Demos\SampleFile.txt";
            byte[] myBuffer = new byte[100];
            myBuffer = Encoding.ASCII.GetBytes(str);
            FileStream fs = new FileStream(str, FileMode.Open);
            fs.Write(myBuffer, 0, myBuffer.Length);
            fs.Close();
            MainForm.Output("Wrote to file successfully.");
        }

        [DllImport("kernel32")]
        public static extern int GetProcessHeap();
        [DllImport("kernel32")]
        public static extern int HeapAlloc(int heap, int flags, int size);
        public static void HighCPU()
        {
            new Hang("high").Show();
        }

        public static void InvestigateThreads()
        {
            MyTimer TestIt = new MyTimer();
            MainForm.Output("The timer has started and will count for five seconds.");
            TestIt.TimerEvent.WaitOne();
            MainForm.Output("...and control returned to the primary thread.");
        }

        public static void InvokeMDA()
        {
            Assembly.Load("IBelieveYouHaveMyStapler.dll");
        }

        public static void LowCPU()
        {
            new Hang("low").Show();
        }

        public static void ManagedBreakpoint()
        {
            MyObject obj = new MyObject();
            if (MyObject._jitted)
            {
                MainForm.Output("Method already called");
            }
            else
            {
                MainForm.Output("Set breakpoint now");
                DebugBreak();
            }
            obj.JitterBug();
        }

        public static void ManagedMemoryLeak()
        {
            new MemoryLeak(true).Show();
        }

        public static void NativeMemoryLeak()
        {
            new MemoryLeak(false).Show();
        }

        public static void NoSuppressFinalizer()
        {
            int objectCount = 10;
            for (int i = 0; i < objectCount; i++)
            {
                MyFinalizableObject obj = new MyFinalizableObject();
                obj.SuppressFinalizer = false;
                obj.SleepDuringFinalizer = false;
                obj.Dispose();
            }
        }

        public static void SOSBasicCommands()
        {
            int threadCount = 5;
            MyObject obj = new MyObject(0x2710);
            obj.SpinUpThreadpoolThreads(threadCount);
            obj.SpinUpThreads(threadCount);
            DebugBreak();
        }
    }
}

