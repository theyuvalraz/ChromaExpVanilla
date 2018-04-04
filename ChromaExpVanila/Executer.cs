using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ChromaExpVanila
{
    class Executer
    {
        private readonly KeyControl control = new KeyControl();

        public delegate void ChunkOfthingsToDo(KeyControl control);
        public void Execute()
        {
            ChunkOfthingsToDo thingsToDo = null;
            control.ColorBase();
            System.Threading.Thread.Sleep(500);

            CheckState check = new CheckState();

            while (true)
            {
                check.time(control);
                check.CheckNumLock(control);
                check.CheckCaps(control);
                System.Threading.Thread.Sleep(500);
                check.CheckLeng(control);
            }
        }
    }
}
