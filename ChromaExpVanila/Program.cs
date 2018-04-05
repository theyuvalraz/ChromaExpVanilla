using System;
using ChromaExpVanilla.config;
using Microsoft.Win32;

namespace ChromaExpVanilla
{
    internal class Program
    {
        private static void Main()
        {
            var executor = new Executor();
            executor.Execute();
        }
    }
}
