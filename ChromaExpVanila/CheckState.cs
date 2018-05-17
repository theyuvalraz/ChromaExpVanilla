using System;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaExpVanilla.config;
using Interfacer.Interfaces;

namespace ChromaExpVanilla
{
    [Synchronization]
    public class CheckState : IStateChecker
    {
        private Action _thingsToDo;
        private bool NumStatus { get; set; }
        private bool CapsStatus { get; set; }
        private string LangStatus { get; set; }
        public bool CurrentStateNeeded { private get; set; } = true;
        public bool ClearNeeded { private get; set; }
        public bool FirstAnimationNeeded { private get; set; }
        public bool SecondAnimationNeeded { private get; set; }
        public bool BaseNeeded { private get; set; }
        public bool TimeAnimationNeeded { private get; set; }
        public IKeyboardController Control { get; set; } = new KeyControl();

        public IGetKeyboardLayout KeyboardLayout { get; set; } = new GetLayout();

        public async Task<Action> States()
        {
            _thingsToDo = null;
            if (FirstAnimationNeeded)
            {
                FirstAnimationNeeded = false;
                _thingsToDo += await Task.Run(() => StartFirstAnimation(Control));
            }
            if (SecondAnimationNeeded)
            {
                SecondAnimationNeeded = false;
                _thingsToDo += await Task.Run(() => StartSecondAnimation(Control));
            }
            if (ClearNeeded)
            {
                ClearNeeded = false;
                _thingsToDo += await Task.Run(() => StartClearCustom(Control));
            }
            if (BaseNeeded)
            {
                BaseNeeded = false;
                _thingsToDo += await Task.Run(() => StartBaseSet(Control));
            }
            if (TimeAnimationNeeded)
            {
                TimeAnimationNeeded = false;
                _thingsToDo += await Task.Run(() => StartTimeAnimation(Control));
            }
            if (!CurrentStateNeeded) return await GetIsChangeStates(Control);
            CurrentStateNeeded = false;
            return await GetStates(Control);
        }

        private async Task<Action> GetStates(IKeyboardController control)
        {
            _thingsToDo += await CheckCaps(control);
            _thingsToDo += await CheckNumLock(control);
            _thingsToDo += await CheckLang(control);
             return _thingsToDo;
        }

        private async Task<Action> GetIsChangeStates(IKeyboardController control)
        {
            _thingsToDo += await IsCapsChange(control);
            _thingsToDo += await IsNumChange(control);
            _thingsToDo += await IsLangChange(control);
            return _thingsToDo;
        }

        private static Action StartFirstAnimation(IKeyboardController control)
        {
            return control.FirstAnimation;
        }

        private static Action StartSecondAnimation(IKeyboardController control)
        {
            return control.SecondAnimation;
        }

        private static Action StartBaseSet(IKeyboardController control)
        {
            return control.SetBase;
        }

        private static Action StartClearCustom(IKeyboardController control)
        {
            return control.ClearCustom;
        }

        private static Action StartTimeAnimation(IKeyboardController control)
        {
            return control.TimeAnimation;
        }

        private async Task<Action> IsCapsChange(IKeyboardController control)
        {
            return CapsStatus == System.Windows.Forms.Control.IsKeyLocked(Keys.CapsLock)
                ? null
                : await CheckCaps(control);
        }

        private async Task<Action> IsNumChange(IKeyboardController control)
        {
            return NumStatus == System.Windows.Forms.Control.IsKeyLocked(Keys.NumLock)
                ? null
                : await CheckNumLock(control);
        }

        private async Task<Action> IsLangChange(IKeyboardController control)
        {
            return LangStatus == KeyboardLayout.GetCurrentKeyboardLayout().ToString()
                ? null
                : await CheckLang(control);
        }

        private async Task<Action> CheckCaps(IKeyboardController control)
        {
            if (await Task.Run(() => System.Windows.Forms.Control.IsKeyLocked(Keys.CapsLock)))
            {
                CapsStatus = true;
                return control.CapsLockOn;
            }
            CapsStatus = false;
            return control.CapsLockOff;
        }

        private async Task<Action> CheckNumLock(IKeyboardController control)
        {
            if (await Task.Run(() => System.Windows.Forms.Control.IsKeyLocked(Keys.NumLock)))
            {
                NumStatus = true;
                return control.NumLockOn;
            }
            NumStatus = false;
            return control.NumLockOff;
        }

        private async Task<Action> CheckLang(IKeyboardController control)
        {

            var currentLayout = await Task.Run(() => KeyboardLayout.GetCurrentKeyboardLayout().ToString());
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