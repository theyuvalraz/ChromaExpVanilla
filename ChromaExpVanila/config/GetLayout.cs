using System;
using System.Runtime.InteropServices;

namespace ChromaExpVanilla.config
{
    public class GetLayout
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hwnd, IntPtr proccess);
        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint thread);

        public System.Globalization.CultureInfo GetCurrentKeyboardLayout()
        {
            try
            {
                var foregroundWindow = GetForegroundWindow();
                var foregroundProcess = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);

                var keyboardLayout = GetKeyboardLayout(foregroundProcess).ToInt32() & 0xFFFF;
                return new System.Globalization.CultureInfo(keyboardLayout);
            }
            catch (Exception)
            {
                return new System.Globalization.CultureInfo(1033);
            }
        }
    }
}
