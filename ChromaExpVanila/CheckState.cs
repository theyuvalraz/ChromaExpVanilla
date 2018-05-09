using System;
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

        public Action States(KeyControl control)
        {
            Action thingsToDo;
            if (CurrentStateNeeded)
            {
                thingsToDo = GetStates(control);
                CurrentStateNeeded = false;
            }
            else
            {
                thingsToDo = GetIsChangeStates(control);
            }

            return thingsToDo;
        }

        private Action GetStates(KeyControl control)
        {
            Action thingsToDo = null;
            thingsToDo += CheckCaps(control);
            thingsToDo += CheckNumLock(control);
            thingsToDo += CheckLang(control);
            return thingsToDo;
        }

        private Action GetIsChangeStates(KeyControl control)
        {
            Action thingsToDo = null;

            thingsToDo += IsCapsChange(control);
            thingsToDo += IsNumChange(control);
            thingsToDo += IsLangChange(control);
            return thingsToDo;
        }

        private Action IsCapsChange(KeyControl control) =>
            CapsStatus == Control.IsKeyLocked(Keys.CapsLock) ? null : CheckCaps(control);

        private Action IsNumChange(KeyControl control) =>
            NumStatus == Control.IsKeyLocked(Keys.NumLock) ? null : CheckNumLock(control);

        private Action IsLangChange(KeyControl control) => LangStatus == GetLayout.GetCurrentKeyboardLayout().ToString()
            ? null
            : CheckLang(control);

        private Action CheckCaps(KeyControl control)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                CapsStatus = Control.IsKeyLocked(Keys.CapsLock);
                return control.CapsLockOn;
            }

            CapsStatus = Control.IsKeyLocked(Keys.CapsLock);
            return control.CapsLockOff;
        }

        private Action CheckNumLock(KeyControl control)
        {
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                NumStatus = Control.IsKeyLocked(Keys.NumLock);
                return control.NumLockOn;
            }

            NumStatus = Control.IsKeyLocked(Keys.NumLock);
            return control.NumLockOff;
        }

        private Action CheckLang(KeyControl control)
        {
            Thread.Sleep(250);
            var currentLayout = GetLayout.GetCurrentKeyboardLayout().ToString();
            LangStatus = currentLayout;
            switch (LangStatus)
            {
                case "en-US":
                    return control.SetEng;
                case "he-IL":
                    return control.SetHeb;
                default:
                    return null;
            }
        }

        //private EventTypes StateNeeded()
        //{
        //    if (!CurrentStateNeeded) return EventTypes.Normal;
        //    CurrentStateNeeded = false;
        //    return EventTypes.CurrentStateNeeded;
        //}
    }
}