using System.Collections.Generic;
using Corale.Colore.Razer.Keyboard;

namespace ChromaExpVanilla.config
{
    public class KeyBlocks
    {
        public List<Key> UsefulKeys = new List<Key>
        {
            Key.Home,
            Key.End,
            Key.Delete,
            Key.Backspace,
            Key.F12,
            Key.F7,
            Key.F2,
            Key.F5,
            Key.PageUp,
            Key.PageDown
        };

        public List<Key> NumberKeys = new List<Key>
        {
            Key.D1,
            Key.D2,
            Key.D3,
            Key.D4,
            Key.D5,
            Key.D6,
            Key.D7,
            Key.D8,
            Key.D9,
            Key.D0,
            Key.OemTilde,
            Key.Backspace,
            Key.OemEquals,
            Key.OemMinus
        };

        public List<Key> AllLetterKeys = new List<Key>
        {
            Key.Q,
            Key.W,
            Key.E,
            Key.R,
            Key.T,
            Key.Y,
            Key.U,
            Key.I,
            Key.O,
            Key.P,
            Key.A,
            Key.S,
            Key.D,
            Key.F,
            Key.G,
            Key.H,
            Key.J,
            Key.K,
            Key.L,
            Key.OemSemicolon,
            Key.Z,
            Key.X,
            Key.C,
            Key.V,
            Key.B,
            Key.N,
            Key.M,
            Key.OemComma,
            Key.OemPeriod,
            Key.Space
        };

        public List<Key> HebKeys = new List<Key>
        {
            Key.E,
            Key.R,
            Key.T,
            Key.Y,
            Key.U,
            Key.I,
            Key.O,
            Key.P,
            Key.A,
            Key.S,
            Key.D,
            Key.F,
            Key.G,
            Key.H,
            Key.J,
            Key.K,
            Key.L,
            Key.OemSemicolon,
            Key.Z,
            Key.X,
            Key.C,
            Key.V,
            Key.B,
            Key.N,
            Key.M,
            Key.OemComma,
            Key.OemPeriod,
            Key.Space
        };

        public List<Key> EngKeys = new List<Key>
        {
            Key.Q,
            Key.W,
            Key.E,
            Key.R,
            Key.T,
            Key.Y,
            Key.U,
            Key.I,
            Key.O,
            Key.P,
            Key.A,
            Key.S,
            Key.D,
            Key.F,
            Key.G,
            Key.H,
            Key.J,
            Key.K,
            Key.L,
            Key.Z,
            Key.X,
            Key.C,
            Key.V,
            Key.B,
            Key.N,
            Key.M,
            Key.Space
        };

        public List<Key> CapsLk = new List<Key>
        {
            Key.CapsLock
        };

        public List<Key> UselessKeys = new List<Key>
        {
            Key.F4,
            Key.F6,
            Key.F8,
            Key.F10,
            Key.Pause,
            Key.Insert,
            Key.RightMenu
        };

        public List<Key> Numpad = new List<Key>
        {
            Key.Num0,
            Key.Num1,
            Key.Num2,
            Key.Num3,
            Key.Num4,
            Key.Num5,
            Key.Num6,
            Key.Num7,
            Key.Num8,
            Key.Num9,
            Key.NumDecimal,
            Key.NumLock
        };

        public List<Key> AltNumPad1 = new List<Key>
        {
            Key.Num1,
            Key.Num3,
            Key.Num7,
            Key.Num9,
            Key.NumDecimal,
            Key.NumLock,
            Key.NumEnter
        };

        public List<Key> AltNumPad2 = new List<Key>
        {
            Key.Num2,
            Key.Num4,
            Key.Num6,
            Key.Num8
        };
        public List<Key> AltNumPad3 = new List<Key>
        {
            Key.Num0,
            Key.Num5
        };

        public List<Key> Logo = new List<Key>
        {
            Key.Logo
        };

        public List<Key> AnimationKeys = new List<Key>
        {
            Key.F7,
            Key.D9,
            Key.O,
            Key.L,
            Key.OemComma,
            Key.M,
            Key.J,
            Key.U,
            Key.D7,
            Key.D6,
            Key.T,
            Key.F,
            Key.V,
            Key.B,
            Key.H,
            Key.Y,
            Key.T,
            Key.F,
            Key.C,
            Key.D,
            Key.E,
            Key.D3,
            Key.F2,
            Key.D2,
            Key.Q,
            Key.CapsLock,
            Key.Macro4,
            Key.LeftControl,
            Key.R
        };
        public List<List<Key>> AnimationConcept = new List<List<Key>>()
        {
            new List<Key>(){Key.Backspace,      Key.LeftControl},
            new List<Key>(){Key.OemEquals,      Key.LeftWindows},
            new List<Key>(){Key.OemMinus,       Key.LeftAlt},
            new List<Key>(){Key.D0,             Key.LeftAlt},
            new List<Key>(){Key.D9,             Key.Space},
            new List<Key>(){Key.D8,             Key.Space},
            new List<Key>(){Key.D7,             Key.Space},
            new List<Key>(){Key.D6,             Key.Space},
            new List<Key>(){Key.D5,             Key.Space},
            new List<Key>(){Key.D4,             Key.RightAlt},
            new List<Key>(){Key.D3,             Key.RightAlt},
            new List<Key>(){Key.D2,             Key.Function},
            new List<Key>(){Key.D1,             Key.RightMenu},
            new List<Key>(){Key.OemTilde,       Key.RightControl},

            new List<Key>(){Key.Tab,            Key.RightShift},
            new List<Key>(){Key.Q,              Key.RightShift},
            new List<Key>(){Key.W,              Key.OemSlash},
            new List<Key>(){Key.E,              Key.OemPeriod},
            new List<Key>(){Key.R,              Key.OemComma},
            new List<Key>(){Key.T,              Key.M},
            new List<Key>(){Key.Y,              Key.N},
            new List<Key>(){Key.U,              Key.B},
            new List<Key>(){Key.I,              Key.V},
            new List<Key>(){Key.O,              Key.C},
            new List<Key>(){Key.P,              Key.X},
            new List<Key>(){Key.OemLeftBracket, Key.Z},
            new List<Key>(){Key.OemRightBracket,Key.LeftShift},
            new List<Key>(){Key.OemBackslash,   Key.LeftShift},

            new List<Key>(){Key.Enter,          Key.CapsLock},
            new List<Key>(){Key.OemApostrophe,  Key.A},
            new List<Key>(){Key.OemSemicolon,   Key.S},
            new List<Key>(){Key.L,              Key.D},
            new List<Key>(){Key.K,              Key.F},
            new List<Key>(){Key.J,              Key.G},
            new List<Key>(){Key.H},
            new List<Key>(){Key.H},
            new List<Key>(){Key.H},
            new List<Key>(){Key.H,Key.M,Key.T},
            new List<Key>(){Key.F,Key.K},
            new List<Key>(){Key.V,Key.I},
            new List<Key>(){Key.Space,Key.D8},
            new List<Key>(){Key.N,Key.F5},
            new List<Key>(){Key.J,Key.D5},
            new List<Key>(){Key.U,Key.R},

            new List<Key>(){Key.D7,Key.F},
            new List<Key>(){Key.T,Key.V},
            new List<Key>(){Key.F,Key.G},
            new List<Key>(){Key.G},
            new List<Key>(){Key.G},
            new List<Key>(){Key.G},
        };

    }
}