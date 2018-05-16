using System;
using System.Windows.Forms;

namespace TrayApp
{
    internal static class Program
    {
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Magic());
        }
    }
}