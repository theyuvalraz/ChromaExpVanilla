using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ChromaExpVanilla.config;

namespace ChromaExpVanilla
{
    public class CheckState
    {
        private bool NumStatus { get; set; }
        private bool CapsStatus { get; set; }
        private string LangStatus { get; set; }
        public bool CurrentStateNeeded = true;
        string userName { get; set; } 

        public List<EventTypes> States
        {
            get
            {
                var states = new List<EventTypes>();
                if (CurrentStateNeeded)
                {
                    states.Add(CheckCaps());
                    states.Add(CheckNumLock());
                    states.Add(CheckLang());
                    states.Add(Time());

                    CurrentStateNeeded = false;
                }
                else
                {
                    var tempState = new List<EventTypes>()
                    {
                        IsCapsChange(),
                        IsNumChange(),
                        IsLangChange(),
                        Time(),
                        IsUserNameChange()
                    };

                    states = tempState.Where(x => x != EventTypes.Normal).ToList();
                }

                return states;
            }
        }

        private EventTypes IsCapsChange() =>
            CapsStatus == Control.IsKeyLocked(Keys.CapsLock) ? EventTypes.Normal : CheckCaps();

        private EventTypes IsNumChange() =>
            NumStatus == Control.IsKeyLocked(Keys.NumLock) ? EventTypes.Normal : CheckNumLock();

        private EventTypes IsLangChange() => LangStatus == GetLayout.GetCurrentKeyboardLayout().ToString()
            ? EventTypes.Normal
            : CheckLang();

        private EventTypes IsUserNameChange() => userName == System.Security.Principal.WindowsIdentity.GetCurrent().Name
            ? EventTypes.Normal
            : UserName();

        // need to change this
        private EventTypes UserName()
        {
            userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            return EventTypes.UserChange;
        }

        private EventTypes CheckCaps()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                CapsStatus = Control.IsKeyLocked(Keys.CapsLock);
                return EventTypes.CapsOn;
            }

            CapsStatus = Control.IsKeyLocked(Keys.CapsLock);
            return EventTypes.CapsOff;
        }

        private EventTypes CheckNumLock()
        {
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                NumStatus = Control.IsKeyLocked(Keys.NumLock);
                return EventTypes.NumLkOn;
            }

            NumStatus = Control.IsKeyLocked(Keys.NumLock);
            return EventTypes.NumLkOff;
        }

        private EventTypes Time()
        {
            Thread.Sleep(100);
            if ((DateTime.Now.Minute == 00 || DateTime.Now.Minute == 30) && DateTime.Now.Second < 1)
            {
                return EventTypes.TimeRound;
            }

            return EventTypes.Normal;
        }

        private EventTypes CheckLang()
        {
            Thread.Sleep(250);
            var currentLayout = GetLayout.GetCurrentKeyboardLayout().ToString();
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

        private EventTypes StateNeeded()
        {
            if (CurrentStateNeeded)
            {
                CurrentStateNeeded = false;
                return EventTypes.CurrentStateNeeded;
            }

            return EventTypes.Normal;
        }
    }
}