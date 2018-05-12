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

        public async Task<Action> States(IKeyboardController control)
        {
            Action thingsToDo;
            if (CurrentStateNeeded)
            {
                thingsToDo = await GetStates(control);
                CurrentStateNeeded = false;
            }
            else
            {
                thingsToDo = await GetIsChangeStates(control);
            }

            return thingsToDo;
        }

        private async Task<Action> GetStates(IKeyboardController control)
        {
            Action thingsToDo = null;
            thingsToDo += await Task.Run(() => CheckCaps(control));
            thingsToDo += await Task.Run(() => CheckNumLock(control));
            thingsToDo += await Task.Run(() => CheckLang(control));
            return thingsToDo;
        }

        private async Task<Action> GetIsChangeStates(IKeyboardController control)
        {
            Action thingsToDo = null;

            thingsToDo += await IsCapsChange(control);
            thingsToDo += await IsNumChange(control);
            thingsToDo += await IsLangChange(control);
            return thingsToDo;
        }

        private async Task<Action> IsCapsChange(IKeyboardController control) =>
            CapsStatus == Control.IsKeyLocked(Keys.CapsLock)
                ? null
                : await Task.Run(() => CheckCaps(control));

        private async Task<Action> IsNumChange(IKeyboardController control) =>
            NumStatus == Control.IsKeyLocked(Keys.NumLock)
                ? null
                : await Task.Run(() => CheckNumLock(control));

        private async Task<Action> IsLangChange(IKeyboardController control) =>
            LangStatus == KeyboardLayout.GetCurrentKeyboardLayout().ToString()
                ? null
                : await Task.Run(() => CheckLang(control));

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
            //Thread.Sleep(250);
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
    }
}