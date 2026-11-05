using System;
using System.Windows.Forms;
using SampleOrderApp.Forms;

namespace SampleOrderApp
{
    internal static class Program
    {
        /// <summary>アプリケーションのエントリポイント</summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
