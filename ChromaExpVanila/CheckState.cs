using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChromaExpVanilla.config;
using Corale.Colore.Core;

namespace ChromaExpVanilla
{
    internal class CheckState
    {
        public List<EventTypes> States()
        {
            var states = new List<EventTypes>();
            states.Clear();
            states.Add(CheckCaps());
            states.Add(CheckNumLock());
            states.Add(Time());
            states.Add(CheckLang());
            return states;
        }

        private EventTypes CheckCaps()
        {
            return Control.IsKeyLocked(Keys.CapsLock) ? EventTypes.CapsOn : EventTypes.CapsOff;
        }

        private EventTypes CheckNumLock()
        {
            return Control.IsKeyLocked(Keys.NumLock) ? EventTypes.NumLkOn : EventTypes.NumLkOff;
        }

        private EventTypes Time()
        {
            new KeyBlocks();
            if ((DateTime.Now.Minute == 00 || DateTime.Now.Minute == 30) && DateTime.Now.Second < 5)
            {
                return EventTypes.TimeRound;
            }
            else
            {
                return EventTypes.Normal;
            }
        }

        readonly GetLayout _theLayout = new GetLayout();
        private string _lang = string.Empty;

        private EventTypes CheckLang()
        {
            System.Threading.Thread.Sleep(1000);
            if (_lang == _theLayout.GetCurrentKeyboardLayout().ToString()) return EventTypes.Normal;
            _lang = _theLayout.GetCurrentKeyboardLayout().ToString();
            switch (_lang)
            {
                case "en-US":
                    _lang = _theLayout.GetCurrentKeyboardLayout().ToString();
                    return EventTypes.LangEng;
                case "he-IL":
                    _lang = _theLayout.GetCurrentKeyboardLayout().ToString();
                    return EventTypes.LangHeb;
                default:
                    return EventTypes.Normal;
            }
        }
    }
}
