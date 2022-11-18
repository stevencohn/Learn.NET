namespace CrashLab2
{
    using System;
    using System.Windows.Forms;

    public class Startup
    {
        [STAThread]
        private static void Main()
        {
            Application.Run(new MainForm());
        }
    }
}

