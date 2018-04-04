using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using ChromaExpVanila;

namespace DeleteThis
{
    class Program
    {
        static void Main()
        {
            Board keyBoard = new Board();

        }

        delegate void LengEventHandler(object source, LengEventArgs e);

        public class LengEventArgs : EventArgs
        {
            public string newLeng;
            public bool cancel;
            public LengEventArgs(string newLeng)
            {
                this.newLeng = newLeng;

            }
        }

        class Board
        {
            private string currentLenguage;
            public event LengEventHandler LengChanged;

            public string CurrentLenguage
            {
                get { return currentLenguage;}
                set
                {
                    if (currentLenguage != value)
                    {
                        if (LengChanged != null)
                        {
                            LengEventArgs args = new LengEventArgs(value);
                            LengChanged(this, args);
                            if (args.cancel)
                                return;
                        }
                        currentLenguage = value;
                    }
                }
            }

        }
    }
}
