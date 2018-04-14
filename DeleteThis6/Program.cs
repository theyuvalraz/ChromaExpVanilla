using System.Windows.Forms;

namespace TrayApp
{
    static class Program
    {
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Magic());
        }
    }
}