using System.Collections.Generic;
using Corale.Colore.Razer.Keyboard;

namespace ChromaExpVanilla.config
{
    public class KeyBlocks
    {
        public IEnumerable<Key> UsefulKeys = new List<Key>()
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

        public IEnumerable<Key> NumberKeys = new List<Key>()
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

        public IEnumerable<Key> AllLetterKeys = new List<Key>()
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

        public IEnumerable<Key> HebKeys = new List<Key>()
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

        public IEnumerable<Key> EngKeys = new List<Key>()
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

        public IEnumerable<Key> CapsLk = new List<Key>()
        {
            Key.CapsLock
        };

        public IEnumerable<Key> UselessKeys = new List<Key>()
        {
            Key.F4,
            Key.F6,
            Key.F8,
            Key.F10,
            Key.Pause,
            Key.Insert,
            Key.RightMenu,
        };

        public IEnumerable<Key> Numpad = new List<Key>()
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

        public IEnumerable<Key> Logo = new List<Key>()
        {
            Key.Logo
        };

        public IEnumerable<Key> AnimationKeys = new List<Key>()
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
            Key.R,
        };
    }
}