using System;
using System.Threading;
using System.Windows.Forms;
using ChromaExpVanilla.config;
using Interfacer.Interfaces;

namespace ChromaExpVanilla
{
    public class CheckState : IStateChecker
    {
        private bool NumStatus { get; set; }
        private bool CapsStatus { get; set; }
        private string LangStatus { get; set; }
        public bool CurrentStateNeeded = true;
        public IGetKeyboardLayout KeyboardLayout { get; set; } = new GetLayout();

        public Action States(IKeyboardController control)
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

        private Action GetStates(IKeyboardController control)
        {
            Action thingsToDo = null;
            thingsToDo += CheckCaps(control);
            thingsToDo += CheckNumLock(control);
            thingsToDo += CheckLang(control);
            return thingsToDo;
        }

        private Action GetIsChangeStates(IKeyboardController control)
        {
            Action thingsToDo = null;

            thingsToDo += IsCapsChange(control);
            thingsToDo += IsNumChange(control);
            thingsToDo += IsLangChange(control);
            return thingsToDo;
        }

        private Action IsCapsChange(IKeyboardController control) =>
            CapsStatus == Control.IsKeyLocked(Keys.CapsLock) ? null : CheckCaps(control);

        private Action IsNumChange(IKeyboardController control) =>
            NumStatus == Control.IsKeyLocked(Keys.NumLock) ? null : CheckNumLock(control);

        private Action IsLangChange(IKeyboardController control) =>
            LangStatus == KeyboardLayout.GetCurrentKeyboardLayout().ToString()
                ? null
                : CheckLang(control);

        private Action CheckCaps(IKeyboardController control)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                CapsStatus = Control.IsKeyLocked(Keys.CapsLock);
                return control.CapsLockOn;
            }

            CapsStatus = Control.IsKeyLocked(Keys.CapsLock);
            return control.CapsLockOff;
        }

        private Action CheckNumLock(IKeyboardController control)
        {
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                NumStatus = Control.IsKeyLocked(Keys.NumLock);
                return control.NumLockOn;
            }

            NumStatus = Control.IsKeyLocked(Keys.NumLock);
            return control.NumLockOff;
        }

        private Action CheckLang(IKeyboardController control)
        {
            Thread.Sleep(250);
            var currentLayout = KeyboardLayout.GetCurrentKeyboardLayout().ToString();
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