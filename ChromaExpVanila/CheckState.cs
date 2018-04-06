using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static ChromaExpVanilla.config.GetLayout;
using static System.Windows.Forms.Control;

namespace ChromaExpVanilla
{
    internal class CheckState
    {
        
        public bool NumStatus { get; set; }
        public bool CapsStatus { get; set; }
        public string LangStatus { get; set; }

        public CheckState()
        {
            LangStatus = GetCurrentKeyboardLayout().ToString();
            CapsStatus = IsKeyLocked(Keys.CapsLock);
            NumStatus = IsKeyLocked(Keys.NumLock);
            States();
        }


        public List<EventTypes> States()
        {
            var states = new List<EventTypes>();
            states.Clear();
            states.Add(CheckCaps());
            states.Add(CheckNumLock());
            states.Add(Time());
            states.Add(CheckLang());
            try
            {
                states = states.Where(x => x != EventTypes.Normal).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return states;
        }

        private EventTypes CheckCaps()
        {
            if (CapsStatus == IsKeyLocked(Keys.CapsLock)){return EventTypes.Normal;}
            if (IsKeyLocked(Keys.CapsLock))
            {
                CapsStatus = IsKeyLocked(Keys.CapsLock);
                return EventTypes.CapsOn;
            }
            CapsStatus = IsKeyLocked(Keys.CapsLock);
            return EventTypes.CapsOff;
        }

        private EventTypes CheckNumLock()
        {
            if (NumStatus == IsKeyLocked(Keys.NumLock)) { return EventTypes.Normal; }
            if (IsKeyLocked(Keys.NumLock))
            {
                NumStatus = IsKeyLocked(Keys.NumLock);
                return EventTypes.NumLkOn;
            }
            NumStatus = IsKeyLocked(Keys.NumLock);
            return EventTypes.NumLkOff;
        }

        private EventTypes Time()
        {
            if ((DateTime.Now.Minute == 00 || DateTime.Now.Minute == 30) && DateTime.Now.Second < 5)
            {       
                return EventTypes.TimeRound;
            }
            return EventTypes.Normal;
        }

        private EventTypes CheckLang()
        {
            Thread.Sleep(250);
            if (LangStatus == GetCurrentKeyboardLayout().ToString()) return EventTypes.Normal;
            LangStatus = GetCurrentKeyboardLayout().ToString();
            switch (LangStatus)
            {
                case "en-US":
                    LangStatus = GetCurrentKeyboardLayout().ToString();
                    return EventTypes.LangEng;
                case "he-IL":
                    LangStatus = GetCurrentKeyboardLayout().ToString();
                    return EventTypes.LangHeb;
                default:
                    return EventTypes.Normal;
            }
        }
    }
}