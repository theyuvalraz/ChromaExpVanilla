using System;
using System.Threading;
using System.Threading.Tasks;
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
            thingsToDo += IsLangChange(control).Result;
            return thingsToDo;
        }

        private Action IsCapsChange(IKeyboardController control) =>
            CapsStatus == Control.IsKeyLocked(Keys.CapsLock) ? null : CheckCaps(control);

        private Action IsNumChange(IKeyboardController control) =>
            NumStatus == Control.IsKeyLocked(Keys.NumLock) ? null : CheckNumLock(control);

        private async Task<Action> IsLangChange(IKeyboardController control) =>
            LangStatus == KeyboardLayout.GetCurrentKeyboardLayout().ToString()
                ? null
                : await Task.Run( ()=> CheckLang(control));
        //CheckLang(control);

        private Action CheckCaps(IKeyboardController control)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                CapsStatus = true;
                return control.CapsLockOn;
            }
            CapsStatus = false;
            return control.CapsLockOff;
        }

        private Action CheckNumLock(IKeyboardController control)
        {
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                NumStatus = true;
                return control.NumLockOn;
            }
            NumStatus = false;
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