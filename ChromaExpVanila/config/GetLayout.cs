using System;
using System.Globalization;
using System.Runtime.InteropServices;
using Interfacer.Interfaces;

namespace ChromaExpVanilla.config
{
    public class GetLayout : IGetKeyboardLayout
    {
        private readonly object _thisLock = new object();

        public string GetCurrentKeyboardLayout()
        {
            lock (_thisLock)
            {
                try
                {
                    var foregroundWindow = GetForegroundWindow();
                    var foregroundProcess = GetWindowThreadProcessId(foregroundWindow, IntPtr.Zero);

                    var keyboardLayout = GetKeyboardLayout(foregroundProcess).ToInt32() & 0xFFFF;
                    return new CultureInfo(keyboardLayout).ToString();
                }
                catch (Exception)
                {
                    return new CultureInfo(1033).ToString();
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hwnd, IntPtr proccess);

        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint thread);
    }
}