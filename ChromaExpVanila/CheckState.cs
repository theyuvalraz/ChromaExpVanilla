using System;
using System.Collections;
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
        private bool NumStatus { get; set; }
        private bool CapsStatus { get; set; }
        private string LangStatus { get; set; }
        private bool _firstRun = true;

        public List<EventTypes> States
        {
            get
            {
                var states = new List<EventTypes>();
                if (_firstRun)
                {
                    states.Add(CheckCaps());
                    states.Add(CheckNumLock());
                    states.Add(CheckLang());
                    states.Add( Time() );

                    _firstRun = false;
                }
                else
                {
                    var tempState = new List<EventTypes>()
                    {
                        IsCapsChange(),
                        IsNumChange(),
                        IsLangChange(),
                        Time()
                    };

                    states = tempState.Where(x => x != EventTypes.Normal).ToList();
                }
                return states;
            }
        }

        private EventTypes IsCapsChange() => CapsStatus == IsKeyLocked( Keys.CapsLock ) ? EventTypes.Normal : CheckCaps();
        private EventTypes IsNumChange() => NumStatus == IsKeyLocked( Keys.NumLock ) ? EventTypes.Normal : CheckNumLock();
        private EventTypes IsLangChange() => LangStatus == GetCurrentKeyboardLayout().ToString() ? EventTypes.Normal : CheckLang();

        private EventTypes CheckCaps()
        {
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
            Thread.Sleep( 100 );
            if ((DateTime.Now.Minute == 00 || DateTime.Now.Minute == 30) && DateTime.Now.Second < 5)
            {
                return EventTypes.TimeRound;
            }
            return EventTypes.Normal;
        }

        private EventTypes CheckLang()
        {
            Thread.Sleep(250);
            var currentLayout = GetCurrentKeyboardLayout().ToString();
            LangStatus = currentLayout;
            switch (LangStatus)
            {
                case "en-US":
                    return EventTypes.LangEng;
                case "he-IL":
                    return EventTypes.LangHeb;
                default:
                    return EventTypes.Normal;
            }
        }
    }
}