using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaExpVanila.config;
using Corale.Colore.Core;

namespace ChromaExpVanila
{
    class CheckState
    {
        public List<int> States()
        {
             
            return new List<int> {5};
        }
        public void CheckCaps(KeyControl control)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                control.CapsLockOn();
            }
            else
            {
                control.CapsLockOff();
            }
        }

        public void CheckNumLock(KeyControl control)
        {
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                control.NumLockOn();
            }
            else
            {
                control.NumLockOff();
            }
        }

        public void time(KeyControl control)
        {
            KeyBlocks keyBlocks = new KeyBlocks();
            if ((DateTime.Now.Minute == 00 || DateTime.Now.Minute == 30) && DateTime.Now.Second < 5)
            {
                control.Animation2(keyBlocks.numberKeys);
            }
        }
        GetLayout theLayout = new GetLayout();
        string leng = String.Empty;

        public void CheckLeng(KeyControl control)
        {
            System.Threading.Thread.Sleep(1000);
            if (leng != theLayout.GetCurrentKeyboardLayout().ToString())
            {
                control.PreSetLeng();
                leng = theLayout.GetCurrentKeyboardLayout().ToString();
                if (leng == "en-US")
                {
                    leng = theLayout.GetCurrentKeyboardLayout().ToString();
                    control.SetEng();
                }

                if (leng == "he-IL")
                {
                    leng = theLayout.GetCurrentKeyboardLayout().ToString();
                    control.SetHeb();
                }
            }

        }

    }
}
