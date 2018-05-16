using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using Interfacer.Interfaces;

namespace ChromaExpVanilla.config
{
    public class GetLayout : IGetKeyboardLayout
    {
        private readonly object _thisLock = new object();

        public CultureInfo GetCurrentKeyboardLayout()
        {
            lock (_thisLock)
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

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hwnd, IntPtr proccess);

        [DllImport("user32.dll")]
        private static extern IntPtr GetKeyboardLayout(uint thread);
    }
}