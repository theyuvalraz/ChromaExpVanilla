using System;
using System.Collections.Generic;
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
        public bool CurrentStateNeeded { get; set; } = true;
        public bool FirstAnimationNeeded { get; set; }
        public bool SecondAnimationNeeded { get; set; }
        public bool BaseNeeded { get; set; }
        private Action _thingsToDo;

        public IGetKeyboardLayout KeyboardLayout { get; set; } = new GetLayout();

        public async Task<Action> States(IKeyboardController control)
        {
            _thingsToDo = null;
            if (!CurrentStateNeeded) return await GetIsChangeStates(control);
            CurrentStateNeeded = false;
            return await GetStates( control );
        }

        private async Task<Action> GetStates(IKeyboardController control)
        {
            _thingsToDo += await CheckCaps(control);
            _thingsToDo += await CheckNumLock(control);
            _thingsToDo += await CheckLang( control);
            return _thingsToDo;
        }

        private async Task<Action> GetIsChangeStates(IKeyboardController control)
        {
            _thingsToDo += await IsCapsChange(control);
            _thingsToDo += await IsNumChange(control);
            _thingsToDo += await IsLangChange(control);
            return _thingsToDo;
        }
        private Action StartFirstAnimation( IKeyboardController control )
        {
            return control.FirstAnimation;
        }

        private Action StartSecondAnimation( IKeyboardController control )
        {
            return control.SecondAnimation;
        }

        private Action StartBaseSet( IKeyboardController control )
        {
            return control.SetBase;
        }

        private async Task<Action> IsCapsChange(IKeyboardController control) =>
            CapsStatus == Control.IsKeyLocked(Keys.CapsLock)
                ? null
                : await CheckCaps(control);

        private async Task<Action> IsNumChange(IKeyboardController control) =>
            NumStatus == Control.IsKeyLocked(Keys.NumLock)
                ? null
                : await CheckNumLock(control);

        private async Task<Action> IsLangChange(IKeyboardController control) =>
            LangStatus == KeyboardLayout.GetCurrentKeyboardLayout().ToString()
                ? null
                : await CheckLang(control);

        private async Task<Action> CheckCaps(IKeyboardController control)
        {
            if (await Task.Run( () => Control.IsKeyLocked( Keys.CapsLock)))
            {
                CapsStatus = true;
                return control.CapsLockOn;
            }
            CapsStatus = false;
            return control.CapsLockOff;
        }

        private async Task<Action> CheckNumLock(IKeyboardController control)
        {
            if (await Task.Run(() => Control.IsKeyLocked(Keys.NumLock)))
            {
                NumStatus = true;
                return control.NumLockOn;
            }
            NumStatus = false;
            return control.NumLockOff;
        }

        private async Task<Action> CheckLang(IKeyboardController control)
        {
            Thread.Sleep(250);
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