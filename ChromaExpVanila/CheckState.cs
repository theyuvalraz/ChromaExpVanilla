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
        public List<EventTypes> States()
        {
            List<EventTypes> states = new List<EventTypes>();





            return states;
        }
        public EventTypes CheckCaps(KeyControl control)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                control.CapsLockOn();
                return EventTypes.CapsOn;

            }
            else
            {
                control.CapsLockOff();
                return EventTypes.CapsOff;

            }
        }

        public EventTypes CheckNumLock(KeyControl control)
        {
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                control.NumLockOn();
                return EventTypes.NumLkOn;

            }
            else
            {
                control.NumLockOff();
                return EventTypes.NumLkOff;

            }
        }

        public EventTypes time(KeyControl control)
        {
            KeyBlocks keyBlocks = new KeyBlocks();
            if ((DateTime.Now.Minute == 00 || DateTime.Now.Minute == 30) && DateTime.Now.Second < 5)
            {
                control.Animation2(keyBlocks.numberKeys);
                return EventTypes.TimeRound;
            }
            else
            {
                return EventTypes.Normal;
            }
        }
        GetLayout theLayout = new GetLayout();
        string leng = String.Empty;

        public EventTypes CheckLeng(KeyControl control)
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
                    return EventTypes.LengEng;
                }

                if (leng == "he-IL")
                {
                    leng = theLayout.GetCurrentKeyboardLayout().ToString();
                    control.SetHeb();
                    return EventTypes.LengHeb;
                }
            }
            return EventTypes.Normal;
        }
    }
}
