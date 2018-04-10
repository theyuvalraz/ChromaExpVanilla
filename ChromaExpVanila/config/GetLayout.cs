using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ChromaExpVanila.config
{
    public static class GetLayout
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hwnd, IntPtr proccess);

        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint thread);

        public static CultureInfo GetCurrentKeyboardLayout()
        {
            try
            {
                var foregroundWindow = GetForegroundWindow();
                var foregroundProcess = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);

                var keyboardLayout = GetKeyboardLayout(foregroundProcess).ToInt32() & 0xFFFF;
                return new CultureInfo(keyboardLayout);
            }
            catch (Exception)
            {
                return new CultureInfo(1033);
            }
        }
    }
}