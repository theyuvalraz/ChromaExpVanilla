﻿using System;
using System.Runtime.Remoting.Contexts;
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
        public IGetIsLocked IsLocked { get; set; } = new GetIsLocked();
        public bool CurrentStateNeeded { private get; set; } = true;
        public bool ClearNeeded { private get; set; }
        public bool FirstAnimationNeeded { private get; set; }
        public bool SecondAnimationNeeded { private get; set; }
        public bool BaseNeeded { private get; set; }
        public bool TimeAnimationNeeded { private get; set; }
        public IKeyboardController Control { get; set; } = new KeyboardActions();

        public IGetKeyboardLayout KeyboardLayout { get; set; } = new GetLayout();

        public Action States()
        {
            _thingsToDo = null;
            if (FirstAnimationNeeded)
            {
                FirstAnimationNeeded = false;
                Control.FirstAnimation();
            }

            if (SecondAnimationNeeded)
            {
                SecondAnimationNeeded = false;
                Control.SecondAnimation();
            }

            if (ClearNeeded)
            {
                ClearNeeded = false;
                Control.ClearCustom();
            }

            if (BaseNeeded)
            {
                BaseNeeded = false;
                Control.SetBase();
            }

            if (TimeAnimationNeeded)
            {
                TimeAnimationNeeded = false;
                return StartTimeAnimation(Control);
            }

            if (!CurrentStateNeeded) return GetIsChangeStates(Control);
            CurrentStateNeeded = false;
            return GetStates(Control);
        }

        private Action GetStates(IKeyboardController control)
        {
            _thingsToDo += CheckCaps(control);
            _thingsToDo += CheckNumLock(control);
            _thingsToDo += CheckLang(control);
            return _thingsToDo;
        }

        private Action GetIsChangeStates(IKeyboardController control)
        {
            _thingsToDo += IsCapsChange(control);
            _thingsToDo += IsNumChange(control);
            _thingsToDo += IsLangChange(control);
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

        private Action IsCapsChange(IKeyboardController control)
        {
            return CapsStatus == IsLocked.IsCapsLocked
                ? null
                : CheckCaps(control);
        }

        private Action IsNumChange(IKeyboardController control)
        {
            return NumStatus == IsLocked.IsNumLocked
                ? null
                : CheckNumLock(control);
        }

        private Action IsLangChange(IKeyboardController control)
        {
            return LangStatus == KeyboardLayout.GetCurrentKeyboardLayout()
                ? null
                : CheckLang(control);
        }

        private Action CheckCaps(IKeyboardController control)
        {
            if (IsLocked.IsCapsLocked)
            {
                CapsStatus = true;
                return control.CapsLockOn;
            }

            CapsStatus = false;
            return control.CapsLockOff;
        }

        private Action CheckNumLock(IKeyboardController control)
        {
            if (IsLocked.IsNumLocked)
            {
                NumStatus = true;
                return control.NumLockOn;
            }

            NumStatus = false;
            return control.NumLockOff;
        }

        private Action CheckLang(IKeyboardController control)
        {
            var currentLayout = KeyboardLayout.GetCurrentKeyboardLayout();
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