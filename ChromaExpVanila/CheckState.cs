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

        public async Task<Action> States(IKeyboardController control)
        {
            if (!CurrentStateNeeded) return await GetIsChangeStates();
            CurrentStateNeeded = false;
            return await GetStates();
        }

        public IGetKeyboardLayout KeyboardLayout { get; set; } = new GetLayout();

        public async Task<Action> States()
        {
            if (!CurrentStateNeeded) return await GetIsChangeStates();
            CurrentStateNeeded = false;
            return await GetStates();
        }

        private async Task<Action> GetStates()
        {
            Action thingsToDo = null;
            thingsToDo += await CheckCaps();
            thingsToDo += await CheckNumLock();
            thingsToDo += await CheckLang();
            return thingsToDo;
        }

        private async Task<Action> GetIsChangeStates()
        {
            Action thingsToDo = null;
            thingsToDo += await IsCapsChange();
            thingsToDo += await IsNumChange();
            thingsToDo += await IsLangChange();
            return thingsToDo;
        }

        private async Task<Action> IsCapsChange() =>
            CapsStatus == Control.IsKeyLocked(Keys.CapsLock)
                ? null
                : await CheckCaps();

        private async Task<Action> IsNumChange() =>
            NumStatus == Control.IsKeyLocked(Keys.NumLock)
                ? null
                : await CheckNumLock();

        private async Task<Action> IsLangChange() =>
            LangStatus == KeyboardLayout.GetCurrentKeyboardLayout().ToString()
                ? null
                : await CheckLang();

        private async Task<Action> CheckCaps()
        {
            if (await Task.Run(() => Control.IsKeyLocked(Keys.CapsLock)))
            {
                CapsStatus = true;
                return KeyControl.Instance.CapsLockOn;
            }
            CapsStatus = false;
            return KeyControl.Instance.CapsLockOff;
        }

        private async Task<Action> CheckNumLock()
        {
            if (await Task.Run(() => Control.IsKeyLocked(Keys.NumLock)))
            {
                NumStatus = true;
                return KeyControl.Instance.NumLockOn;
            }
            NumStatus = false;
            return KeyControl.Instance.NumLockOff;
        }

        private async Task<Action> CheckLang()
        {
            Thread.Sleep(250);
            var currentLayout = await Task.Run(() => KeyboardLayout.GetCurrentKeyboardLayout().ToString());
            LangStatus = currentLayout;
            switch (LangStatus)
            {
                case "en-US":
                    return KeyControl.Instance.SetEng;
                case "he-IL":
                    return KeyControl.Instance.SetHeb;
                default:
                    return null;
            }
        }
    }
}