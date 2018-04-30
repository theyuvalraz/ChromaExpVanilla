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


        public List<EventTypes> States
        {
            get
            {
                var states = new List<EventTypes>();
                if (CurrentStateNeeded)
                {
                    states = GetStates().ToList();

                    CurrentStateNeeded = false;
                }
                else
                {
                    var tempState = GetIsChangeStates().ToList();
                    states = tempState.Where(x => x != EventTypes.Normal).ToList();
                }

                return states;
            }
        }


        private IEnumerable<EventTypes> GetStates()
        {
            yield return CheckCaps();
            yield return CheckNumLock();
            yield return CheckLang();
        }

        private IEnumerable<EventTypes> GetIsChangeStates()
        {
            yield return IsCapsChange();
            yield return IsNumChange();
            yield return IsLangChange();
        }

        private EventTypes IsCapsChange() =>
            CapsStatus == Control.IsKeyLocked(Keys.CapsLock) ? EventTypes.Normal : CheckCaps();

        private EventTypes IsNumChange() =>
            NumStatus == Control.IsKeyLocked(Keys.NumLock) ? EventTypes.Normal : CheckNumLock();

        private EventTypes IsLangChange() => LangStatus == GetLayout.GetCurrentKeyboardLayout().ToString()
            ? EventTypes.Normal
            : CheckLang();

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