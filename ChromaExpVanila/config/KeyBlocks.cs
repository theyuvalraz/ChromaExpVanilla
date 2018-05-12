using System.Collections.Generic;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using System.Configuration;
using Interfacer.Interfaces;

namespace ChromaExpVanilla.config
{
    public class KeyBlocks : ApplicationSettingsBase
    {
        private static readonly Color HebrewColor = Color.FromRgb(0xff1900);
        private static readonly Color HebrewAltColor = Color.FromRgb(0x00ffff);
        private static readonly Color EnglishAltColor = Color.FromRgb(0x9000ff);
        private static readonly Color EnglishColor = Color.FromRgb(0x24a504);
        private static readonly Color UselessKeysColor = Color.Black;
        private static readonly Color UsefulKeysColor = Color.FromRgb(0xa100ff);
        private static readonly Color TopNumberNormalColor = Color.FromRgb(0x00008B);
        private static readonly Color NumpadNormalColor = Color.FromRgb(0x24a504);

        private static readonly Color MiscSet1 = Color.Orange;
        private static readonly Color MiscSet2 = Color.Blue;
        private static readonly Color MiscSet3 = Color.White;
        private static readonly Color MiscSet4 = Color.Red;
        private static readonly Color MiscSet5 = Color.Yellow;

        public List<IColoredKey> MiscColoredKeys = new List<IColoredKey>()
        {
            new ColoredKey(Key.Macro1, MiscSet1),
            new ColoredKey(Key.Macro2, MiscSet2),
            new ColoredKey(Key.Macro3, MiscSet1),
            new ColoredKey(Key.Macro5, MiscSet3),
            new ColoredKey(Key.F3, MiscSet3),
            new ColoredKey(Key.PrintScreen, MiscSet2),
            new ColoredKey(Key.Scroll, MiscSet4),
            new ColoredKey(Key.NumEnter, MiscSet1),
            new ColoredKey(Key.Backspace, MiscSet1),
            new ColoredKey(Key.OemTilde, MiscSet1),
            new ColoredKey(Key.Delete, MiscSet1),
            new ColoredKey(Key.Pause, MiscSet5),
            new ColoredKey(Key.Insert, MiscSet4),
        };

        public List<IColoredKey> UsefulKeys = new List<IColoredKey>
        {
            new ColoredKey(Key.Enter, UsefulKeysColor),
            new ColoredKey(Key.Home, UsefulKeysColor),
            new ColoredKey(Key.End, UsefulKeysColor),
            new ColoredKey(Key.F12, UsefulKeysColor),
            new ColoredKey(Key.F7, UsefulKeysColor),
            new ColoredKey(Key.F2, UsefulKeysColor),
            new ColoredKey(Key.F5, UsefulKeysColor),
            new ColoredKey(Key.PageUp, UsefulKeysColor),
            new ColoredKey(Key.PageDown, UsefulKeysColor)
        };

        public List<IColoredKey> NumberKeys = new List<IColoredKey>
        {
            new ColoredKey(Key.D1, TopNumberNormalColor),
            new ColoredKey(Key.D2, TopNumberNormalColor),
            new ColoredKey(Key.D3, TopNumberNormalColor),
            new ColoredKey(Key.D4, TopNumberNormalColor),
            new ColoredKey(Key.D5, TopNumberNormalColor),
            new ColoredKey(Key.D6, TopNumberNormalColor),
            new ColoredKey(Key.D7, TopNumberNormalColor),
            new ColoredKey(Key.D8, TopNumberNormalColor),
            new ColoredKey(Key.D9, TopNumberNormalColor),
            new ColoredKey(Key.D0, TopNumberNormalColor),
            new ColoredKey(Key.OemMinus, TopNumberNormalColor),
            new ColoredKey(Key.OemEquals, TopNumberNormalColor),
        };

        public List<ColoredKey> AllLetterKeys = new List<ColoredKey>
        {
            new ColoredKey(Key.Q),
            new ColoredKey(Key.W),
            new ColoredKey(Key.E),
            new ColoredKey(Key.R),
            new ColoredKey(Key.T),
            new ColoredKey(Key.Y),
            new ColoredKey(Key.U),
            new ColoredKey(Key.I),
            new ColoredKey(Key.O),
            new ColoredKey(Key.P),
            new ColoredKey(Key.A),
            new ColoredKey(Key.S),
            new ColoredKey(Key.D),
            new ColoredKey(Key.F),
            new ColoredKey(Key.G),
            new ColoredKey(Key.H),
            new ColoredKey(Key.J),
            new ColoredKey(Key.K),
            new ColoredKey(Key.L),
            new ColoredKey(Key.OemSemicolon),
            new ColoredKey(Key.Z),
            new ColoredKey(Key.X),
            new ColoredKey(Key.C),
            new ColoredKey(Key.V),
            new ColoredKey(Key.B),
            new ColoredKey(Key.N),
            new ColoredKey(Key.M),
            new ColoredKey(Key.OemComma),
            new ColoredKey(Key.OemPeriod),
            new ColoredKey(Key.Space),
            new ColoredKey(Key.OemLeftBracket),
            new ColoredKey(Key.OemRightBracket),
            new ColoredKey(Key.OemSemicolon),
            new ColoredKey(Key.OemApostrophe),
            new ColoredKey(Key.OemComma),
            new ColoredKey(Key.OemPeriod),
            new ColoredKey(Key.OemSlash),
            new ColoredKey(Key.OemBackslash),
            new ColoredKey(Key.Logo)
        };

        public List<IColoredKey> EngKeys = new List<IColoredKey>
        {
            new ColoredKey(Key.Q, EnglishColor),
            new ColoredKey(Key.W, EnglishColor),
            new ColoredKey(Key.E, EnglishColor),
            new ColoredKey(Key.R, EnglishColor),
            new ColoredKey(Key.T, EnglishColor),
            new ColoredKey(Key.Y, EnglishColor),
            new ColoredKey(Key.U, EnglishColor),
            new ColoredKey(Key.I, EnglishColor),
            new ColoredKey(Key.O, EnglishColor),
            new ColoredKey(Key.P, EnglishColor),
            new ColoredKey(Key.A, EnglishColor),
            new ColoredKey(Key.S, EnglishColor),
            new ColoredKey(Key.D, EnglishColor),
            new ColoredKey(Key.F, EnglishColor),
            new ColoredKey(Key.G, EnglishColor),
            new ColoredKey(Key.H, EnglishColor),
            new ColoredKey(Key.J, EnglishColor),
            new ColoredKey(Key.K, EnglishColor),
            new ColoredKey(Key.L, EnglishColor),
            new ColoredKey(Key.Z, EnglishColor),
            new ColoredKey(Key.X, EnglishColor),
            new ColoredKey(Key.C, EnglishColor),
            new ColoredKey(Key.V, EnglishColor),
            new ColoredKey(Key.B, EnglishColor),
            new ColoredKey(Key.N, EnglishColor),
            new ColoredKey(Key.M, EnglishColor),
            new ColoredKey(Key.Space, EnglishColor)
        };

        public List<IColoredKey> EngKeysOther = new List<IColoredKey>
        {
            new ColoredKey(Key.OemLeftBracket, EnglishAltColor),
            new ColoredKey(Key.OemRightBracket, EnglishAltColor),
            new ColoredKey(Key.OemSemicolon, EnglishAltColor),
            new ColoredKey(Key.OemApostrophe, EnglishAltColor),
            new ColoredKey(Key.OemComma, EnglishAltColor),
            new ColoredKey(Key.OemPeriod, EnglishAltColor),
            new ColoredKey(Key.OemSlash, EnglishAltColor),
            new ColoredKey(Key.OemBackslash, EnglishAltColor)
        };

        public List<IColoredKey> HebKeys = new List<IColoredKey>
        {
            new ColoredKey(Key.E, HebrewColor),
            new ColoredKey(Key.R, HebrewColor),
            new ColoredKey(Key.T, HebrewColor),
            new ColoredKey(Key.Y, HebrewColor),
            new ColoredKey(Key.U, HebrewColor),
            new ColoredKey(Key.I, HebrewColor),
            new ColoredKey(Key.O, HebrewColor),
            new ColoredKey(Key.P, HebrewColor),
            new ColoredKey(Key.A, HebrewColor),
            new ColoredKey(Key.S, HebrewColor),
            new ColoredKey(Key.D, HebrewColor),
            new ColoredKey(Key.F, HebrewColor),
            new ColoredKey(Key.G, HebrewColor),
            new ColoredKey(Key.H, HebrewColor),
            new ColoredKey(Key.J, HebrewColor),
            new ColoredKey(Key.K, HebrewColor),
            new ColoredKey(Key.L, HebrewColor),
            new ColoredKey(Key.OemSemicolon, HebrewColor),
            new ColoredKey(Key.Z, HebrewColor),
            new ColoredKey(Key.X, HebrewColor),
            new ColoredKey(Key.C, HebrewColor),
            new ColoredKey(Key.V, HebrewColor),
            new ColoredKey(Key.B, HebrewColor),
            new ColoredKey(Key.N, HebrewColor),
            new ColoredKey(Key.M, HebrewColor),
            new ColoredKey(Key.OemComma, HebrewColor),
            new ColoredKey(Key.OemPeriod, HebrewColor),
            new ColoredKey(Key.Space, HebrewColor)
        };

        public List<IColoredKey> HebKeysOther = new List<IColoredKey>
        {
            new ColoredKey(Key.Q, HebrewAltColor),
            new ColoredKey(Key.W, HebrewAltColor),
            new ColoredKey(Key.OemApostrophe, HebrewAltColor),
            new ColoredKey(Key.OemSlash, HebrewAltColor),
        };

        public List<IColoredKey> CapsLk = new List<IColoredKey>
        {
            new ColoredKey(Key.CapsLock)
        };

        public List<IColoredKey> UselessKeys = new List<IColoredKey>
        {
            new ColoredKey(Key.F4, UselessKeysColor),
            new ColoredKey(Key.F6, UselessKeysColor),
            new ColoredKey(Key.F8, UselessKeysColor),
            new ColoredKey(Key.F10, UselessKeysColor),
            new ColoredKey(Key.RightMenu, UselessKeysColor),
            new ColoredKey(Key.Macro4, UselessKeysColor),
        };

        public List<IColoredKey> Numpad = new List<IColoredKey>
        {
            new ColoredKey(Key.Num0, NumpadNormalColor),
            new ColoredKey(Key.Num1, NumpadNormalColor),
            new ColoredKey(Key.Num2, NumpadNormalColor),
            new ColoredKey(Key.Num3, NumpadNormalColor),
            new ColoredKey(Key.Num4, NumpadNormalColor),
            new ColoredKey(Key.Num5, NumpadNormalColor),
            new ColoredKey(Key.Num6, NumpadNormalColor),
            new ColoredKey(Key.Num7, NumpadNormalColor),
            new ColoredKey(Key.Num8, NumpadNormalColor),
            new ColoredKey(Key.Num9, NumpadNormalColor),
            new ColoredKey(Key.NumDecimal, NumpadNormalColor),
            new ColoredKey(Key.NumLock, NumpadNormalColor)
        };

        public List<IColoredKey> AltNumPad = new List<IColoredKey>
        {
            new ColoredKey(Key.Num1, Color.Orange),
            new ColoredKey(Key.Num3, Color.Orange),
            new ColoredKey(Key.Num7, Color.Orange),
            new ColoredKey(Key.Num9, Color.Orange),
            new ColoredKey(Key.NumDecimal, Color.Orange),
            new ColoredKey(Key.NumLock, Color.Orange),
            new ColoredKey(Key.NumEnter, Color.Orange),
            new ColoredKey(Key.Num2, Color.Purple),
            new ColoredKey(Key.Num4, Color.Purple),
            new ColoredKey(Key.Num6, Color.Purple),
            new ColoredKey(Key.Num8, Color.Purple),
            new ColoredKey(Key.Num0, Color.Black),
            new ColoredKey(Key.Num5, Color.Black)
        };

        public List<IColoredKey> Logo = new List<IColoredKey>
        {
            new ColoredKey(Key.Logo)
        };

        public List<IColoredKey> AnimationKeys = new List<IColoredKey>
        {
            new ColoredKey(Key.F7),
            new ColoredKey(Key.D9),
            new ColoredKey(Key.O),
            new ColoredKey(Key.L),
            new ColoredKey(Key.OemComma),
            new ColoredKey(Key.M),
            new ColoredKey(Key.J),
            new ColoredKey(Key.U),
            new ColoredKey(Key.D7),
            new ColoredKey(Key.D6),
            new ColoredKey(Key.T),
            new ColoredKey(Key.F),
            new ColoredKey(Key.V),
            new ColoredKey(Key.B),
            new ColoredKey(Key.H),
            new ColoredKey(Key.Y),
            new ColoredKey(Key.T),
            new ColoredKey(Key.F),
            new ColoredKey(Key.C),
            new ColoredKey(Key.D),
            new ColoredKey(Key.E),
            new ColoredKey(Key.D3),
            new ColoredKey(Key.F2),
            new ColoredKey(Key.D2),
            new ColoredKey(Key.Q),
            new ColoredKey(Key.CapsLock),
            new ColoredKey(Key.Macro4),
            new ColoredKey(Key.LeftControl),
            new ColoredKey(Key.R)
        };

        public List<List<IColoredKey>> AnimationConcept = new List<List<IColoredKey>>()
        {
            new List<IColoredKey>() {new ColoredKey(Key.Backspace), new ColoredKey(Key.LeftControl)},
            new List<IColoredKey>() {new ColoredKey(Key.OemEquals), new ColoredKey(Key.LeftWindows)},
            new List<IColoredKey>() {new ColoredKey(Key.OemMinus), new ColoredKey(Key.LeftAlt)},
            new List<IColoredKey>() {new ColoredKey(Key.D0), new ColoredKey(Key.LeftAlt)},
            new List<IColoredKey>() {new ColoredKey(Key.D9), new ColoredKey(Key.Space)},
            new List<IColoredKey>() {new ColoredKey(Key.D8), new ColoredKey(Key.Space)},
            new List<IColoredKey>() {new ColoredKey(Key.D7)},
            new List<IColoredKey>() {new ColoredKey(Key.D6)},
            new List<IColoredKey>() {new ColoredKey(Key.D5)},
            new List<IColoredKey>() {new ColoredKey(Key.D4), new ColoredKey(Key.RightAlt)},
            new List<IColoredKey>() {new ColoredKey(Key.D3), new ColoredKey(Key.RightAlt)},
            new List<IColoredKey>() {new ColoredKey(Key.D2), new ColoredKey(Key.Function)},
            new List<IColoredKey>() {new ColoredKey(Key.D1), new ColoredKey(Key.RightMenu)},
            new List<IColoredKey>() {new ColoredKey(Key.OemTilde), new ColoredKey(Key.RightControl)},
            new List<IColoredKey>() {new ColoredKey(Key.Tab), new ColoredKey(Key.RightShift)},
            new List<IColoredKey>() {new ColoredKey(Key.Q), new ColoredKey(Key.RightShift)},
            new List<IColoredKey>() {new ColoredKey(Key.W), new ColoredKey(Key.OemSlash)},
            new List<IColoredKey>() {new ColoredKey(Key.E), new ColoredKey(Key.OemPeriod)},
            new List<IColoredKey>() {new ColoredKey(Key.R), new ColoredKey(Key.OemComma)},
            new List<IColoredKey>() {new ColoredKey(Key.T), new ColoredKey(Key.M)},
            new List<IColoredKey>() {new ColoredKey(Key.Y), new ColoredKey(Key.N)},
            new List<IColoredKey>() {new ColoredKey(Key.U), new ColoredKey(Key.B)},
            new List<IColoredKey>() {new ColoredKey(Key.I), new ColoredKey(Key.V)},
            new List<IColoredKey>() {new ColoredKey(Key.O), new ColoredKey(Key.C)},
            new List<IColoredKey>() {new ColoredKey(Key.P), new ColoredKey(Key.X)},
            new List<IColoredKey>() {new ColoredKey(Key.OemLeftBracket), new ColoredKey(Key.Z)},
            new List<IColoredKey>() {new ColoredKey(Key.OemRightBracket), new ColoredKey(Key.LeftShift)},
            new List<IColoredKey>() {new ColoredKey(Key.OemBackslash), new ColoredKey(Key.LeftShift)},
            new List<IColoredKey>() {new ColoredKey(Key.Enter), new ColoredKey(Key.CapsLock)},
            new List<IColoredKey>() {new ColoredKey(Key.OemApostrophe), new ColoredKey(Key.A)},
            new List<IColoredKey>() {new ColoredKey(Key.OemSemicolon), new ColoredKey(Key.S)},
            new List<IColoredKey>() {new ColoredKey(Key.L), new ColoredKey(Key.D)},
            new List<IColoredKey>() {new ColoredKey(Key.K), new ColoredKey(Key.F)},
            new List<IColoredKey>() {new ColoredKey(Key.J), new ColoredKey(Key.G)},
            new List<IColoredKey>() {new ColoredKey(Key.H)},
        };

        public List<List<IColoredKey>> AnimationConceptStage2 = new List<List<IColoredKey>>()
        {
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Red),

                new ColoredKey(Key.G, Color.White),
                new ColoredKey(Key.B, Color.White),
                new ColoredKey(Key.N, Color.White),
                new ColoredKey(Key.J, Color.White),
                new ColoredKey(Key.U, Color.White),
                new ColoredKey(Key.Y, Color.White),

                new ColoredKey(Key.Backspace, Color.White),
                new ColoredKey(Key.LeftControl, Color.White),
                new ColoredKey(Key.RightControl, Color.White),
                new ColoredKey(Key.OemTilde, Color.White),
                new ColoredKey(Key.OemEquals, Color.White),
                new ColoredKey(Key.OemBackslash, Color.White),
                new ColoredKey(Key.LeftWindows, Color.White),
                new ColoredKey(Key.LeftAlt, Color.White),
                new ColoredKey(Key.LeftShift, Color.White),
                new ColoredKey(Key.RightShift, Color.White),
                new ColoredKey(Key.RightMenu, Color.White),
                new ColoredKey(Key.Function, Color.White),
                new ColoredKey(Key.D1, Color.White),
                new ColoredKey(Key.Tab, Color.White),
                new ColoredKey(Key.D2, Color.White),
                new ColoredKey(Key.Q, Color.White),
                new ColoredKey(Key.OemMinus, Color.White),
                new ColoredKey(Key.OemRightBracket, Color.White),
                new ColoredKey(Key.OemLeftBracket, Color.White),
                new ColoredKey(Key.CapsLock, Color.White),
                new ColoredKey(Key.Z, Color.White),
                new ColoredKey(Key.X, Color.White),
                new ColoredKey(Key.A, Color.White),
                new ColoredKey(Key.W, Color.White),
                new ColoredKey(Key.D3, Color.White),
                new ColoredKey(Key.RightAlt, Color.White),
                new ColoredKey(Key.OemSlash, Color.White),
                new ColoredKey(Key.Enter, Color.White),
                new ColoredKey(Key.OemApostrophe, Color.White),
                new ColoredKey(Key.D0, Color.White),
                new ColoredKey(Key.D9, Color.White),
                new ColoredKey(Key.P, Color.White),
                new ColoredKey(Key.OemSemicolon, Color.White),
                new ColoredKey(Key.OemPeriod, Color.White),
                new ColoredKey(Key.Space, Color.White),
                new ColoredKey(Key.C, Color.White),
                new ColoredKey(Key.S, Color.White),
                new ColoredKey(Key.E, Color.White),
                new ColoredKey(Key.D4, Color.White),
                new ColoredKey(Key.D8, Color.White),
                new ColoredKey(Key.O, Color.White),
                new ColoredKey(Key.L, Color.White),
                new ColoredKey(Key.OemComma, Color.White),
                new ColoredKey(Key.D, Color.White),
                new ColoredKey(Key.R, Color.White),
                new ColoredKey(Key.D5, Color.White),
                new ColoredKey(Key.D6, Color.White),
                new ColoredKey(Key.D7, Color.White),
                new ColoredKey(Key.T, Color.White),
                new ColoredKey(Key.F, Color.White),
                new ColoredKey(Key.V, Color.White),
                new ColoredKey(Key.M, Color.White),
                new ColoredKey(Key.K, Color.White),
                new ColoredKey(Key.I, Color.White),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Orange)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Yellow)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.White),
                new ColoredKey(Key.Backspace, Color.Black),
                new ColoredKey(Key.LeftControl, Color.Black),
                new ColoredKey(Key.RightControl, Color.Black),
                new ColoredKey(Key.OemTilde, Color.Black),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Yellow),
                new ColoredKey(Key.Backspace, Color.Black),
                new ColoredKey(Key.LeftControl, Color.Black),
                new ColoredKey(Key.RightControl, Color.Black),
                new ColoredKey(Key.OemTilde, Color.Black),
                new ColoredKey(Key.OemEquals, Color.Black),
                new ColoredKey(Key.OemBackslash, Color.Black),
                new ColoredKey(Key.LeftWindows, Color.Black),
                new ColoredKey(Key.LeftAlt, Color.Black),
                new ColoredKey(Key.LeftShift, Color.Black),
                new ColoredKey(Key.RightShift, Color.Black),
                new ColoredKey(Key.RightMenu, Color.Black),
                new ColoredKey(Key.Function, Color.Black),
                new ColoredKey(Key.D1, Color.Black),
                new ColoredKey(Key.Tab, Color.Black),
                new ColoredKey(Key.D2, Color.Black),
                new ColoredKey(Key.Q, Color.Black),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Orange),
                new ColoredKey(Key.Backspace, Color.Black),
                new ColoredKey(Key.LeftControl, Color.Black),
                new ColoredKey(Key.RightControl, Color.Black),
                new ColoredKey(Key.OemTilde, Color.Black),
                new ColoredKey(Key.OemEquals, Color.Black),
                new ColoredKey(Key.OemBackslash, Color.Black),
                new ColoredKey(Key.LeftWindows, Color.Black),
                new ColoredKey(Key.LeftAlt, Color.Black),
                new ColoredKey(Key.LeftShift, Color.Black),
                new ColoredKey(Key.RightShift, Color.Black),
                new ColoredKey(Key.RightMenu, Color.Black),
                new ColoredKey(Key.Function, Color.Black),
                new ColoredKey(Key.D1, Color.Black),
                new ColoredKey(Key.Tab, Color.Black),
                new ColoredKey(Key.D2, Color.Black),
                new ColoredKey(Key.Q, Color.Black),
                new ColoredKey(Key.OemMinus, Color.Black),
                new ColoredKey(Key.OemRightBracket, Color.Black),
                new ColoredKey(Key.OemLeftBracket, Color.Black),
                new ColoredKey(Key.CapsLock, Color.Black),
                new ColoredKey(Key.Z, Color.Black),
                new ColoredKey(Key.X, Color.Black),
                new ColoredKey(Key.A, Color.Black),
                new ColoredKey(Key.W, Color.Black),
                new ColoredKey(Key.D3, Color.Black),
                new ColoredKey(Key.RightAlt, Color.Black),
                new ColoredKey(Key.OemSlash, Color.Black),
                new ColoredKey(Key.Enter, Color.Black),
                new ColoredKey(Key.OemApostrophe, Color.Black),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Red),
                new ColoredKey(Key.Backspace, Color.Black),
                new ColoredKey(Key.LeftControl, Color.Black),
                new ColoredKey(Key.RightControl, Color.Black),
                new ColoredKey(Key.OemTilde, Color.Black),
                new ColoredKey(Key.OemEquals, Color.Black),
                new ColoredKey(Key.OemBackslash, Color.Black),
                new ColoredKey(Key.LeftWindows, Color.Black),
                new ColoredKey(Key.LeftAlt, Color.Black),
                new ColoredKey(Key.LeftShift, Color.Black),
                new ColoredKey(Key.RightShift, Color.Black),
                new ColoredKey(Key.RightMenu, Color.Black),
                new ColoredKey(Key.Function, Color.Black),
                new ColoredKey(Key.D1, Color.Black),
                new ColoredKey(Key.Tab, Color.Black),
                new ColoredKey(Key.D2, Color.Black),
                new ColoredKey(Key.Q, Color.Black),
                new ColoredKey(Key.OemMinus, Color.Black),
                new ColoredKey(Key.OemRightBracket, Color.Black),
                new ColoredKey(Key.OemLeftBracket, Color.Black),
                new ColoredKey(Key.CapsLock, Color.Black),
                new ColoredKey(Key.Z, Color.Black),
                new ColoredKey(Key.X, Color.Black),
                new ColoredKey(Key.A, Color.Black),
                new ColoredKey(Key.W, Color.Black),
                new ColoredKey(Key.D3, Color.Black),
                new ColoredKey(Key.RightAlt, Color.Black),
                new ColoredKey(Key.OemSlash, Color.Black),
                new ColoredKey(Key.Enter, Color.Black),
                new ColoredKey(Key.OemApostrophe, Color.Black),

                new ColoredKey(Key.D0, Color.Black),
                new ColoredKey(Key.D9, Color.Black),
                new ColoredKey(Key.P, Color.Black),
                new ColoredKey(Key.OemSemicolon, Color.Black),
                new ColoredKey(Key.OemPeriod, Color.Black),
                new ColoredKey(Key.Space, Color.Black),
                new ColoredKey(Key.C, Color.Black),
                new ColoredKey(Key.S, Color.Black),
                new ColoredKey(Key.E, Color.Black),
                new ColoredKey(Key.D4, Color.Black),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Red),

                new ColoredKey(Key.G, Color.Yellow),
                new ColoredKey(Key.B, Color.Yellow),
                new ColoredKey(Key.N, Color.Yellow),
                new ColoredKey(Key.J, Color.Yellow),
                new ColoredKey(Key.U, Color.Yellow),
                new ColoredKey(Key.Y, Color.Yellow),

                new ColoredKey(Key.Backspace, Color.Black),
                new ColoredKey(Key.LeftControl, Color.Black),
                new ColoredKey(Key.RightControl, Color.Black),
                new ColoredKey(Key.OemTilde, Color.Black),
                new ColoredKey(Key.OemEquals, Color.Black),
                new ColoredKey(Key.OemBackslash, Color.Black),
                new ColoredKey(Key.LeftWindows, Color.Black),
                new ColoredKey(Key.LeftAlt, Color.Black),
                new ColoredKey(Key.LeftShift, Color.Black),
                new ColoredKey(Key.RightShift, Color.Black),
                new ColoredKey(Key.RightMenu, Color.Black),
                new ColoredKey(Key.Function, Color.Black),
                new ColoredKey(Key.D1, Color.Black),
                new ColoredKey(Key.Tab, Color.Black),
                new ColoredKey(Key.D2, Color.Black),
                new ColoredKey(Key.Q, Color.Black),
                new ColoredKey(Key.OemMinus, Color.Black),
                new ColoredKey(Key.OemRightBracket, Color.Black),
                new ColoredKey(Key.OemLeftBracket, Color.Black),
                new ColoredKey(Key.CapsLock, Color.Black),
                new ColoredKey(Key.Z, Color.Black),
                new ColoredKey(Key.X, Color.Black),
                new ColoredKey(Key.A, Color.Black),
                new ColoredKey(Key.W, Color.Black),
                new ColoredKey(Key.D3, Color.Black),
                new ColoredKey(Key.RightAlt, Color.Black),
                new ColoredKey(Key.OemSlash, Color.Black),
                new ColoredKey(Key.Enter, Color.Black),
                new ColoredKey(Key.OemApostrophe, Color.Black),
                new ColoredKey(Key.D0, Color.Black),
                new ColoredKey(Key.D9, Color.Black),
                new ColoredKey(Key.P, Color.Black),
                new ColoredKey(Key.OemSemicolon, Color.Black),
                new ColoredKey(Key.OemPeriod, Color.Black),
                new ColoredKey(Key.Space, Color.Black),
                new ColoredKey(Key.C, Color.Black),
                new ColoredKey(Key.S, Color.Black),
                new ColoredKey(Key.E, Color.Black),
                new ColoredKey(Key.D4, Color.Black),
                new ColoredKey(Key.D8, Color.Black),
                new ColoredKey(Key.O, Color.Black),
                new ColoredKey(Key.L, Color.Black),
                new ColoredKey(Key.OemComma, Color.Black),
                new ColoredKey(Key.D, Color.Black),
                new ColoredKey(Key.R, Color.Black),
                new ColoredKey(Key.D5, Color.Black),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Yellow),

                new ColoredKey(Key.G, Color.Red),
                new ColoredKey(Key.B, Color.Red),
                new ColoredKey(Key.N, Color.Red),
                new ColoredKey(Key.J, Color.Red),
                new ColoredKey(Key.U, Color.Red),
                new ColoredKey(Key.Y, Color.Red),

                new ColoredKey(Key.Backspace, Color.Black),
                new ColoredKey(Key.LeftControl, Color.Black),
                new ColoredKey(Key.RightControl, Color.Black),
                new ColoredKey(Key.OemTilde, Color.Black),
                new ColoredKey(Key.OemEquals, Color.Black),
                new ColoredKey(Key.OemBackslash, Color.Black),
                new ColoredKey(Key.LeftWindows, Color.Black),
                new ColoredKey(Key.LeftAlt, Color.Black),
                new ColoredKey(Key.LeftShift, Color.Black),
                new ColoredKey(Key.RightShift, Color.Black),
                new ColoredKey(Key.RightMenu, Color.Black),
                new ColoredKey(Key.Function, Color.Black),
                new ColoredKey(Key.D1, Color.Black),
                new ColoredKey(Key.Tab, Color.Black),
                new ColoredKey(Key.D2, Color.Black),
                new ColoredKey(Key.Q, Color.Black),
                new ColoredKey(Key.OemMinus, Color.Black),
                new ColoredKey(Key.OemRightBracket, Color.Black),
                new ColoredKey(Key.OemLeftBracket, Color.Black),
                new ColoredKey(Key.CapsLock, Color.Black),
                new ColoredKey(Key.Z, Color.Black),
                new ColoredKey(Key.X, Color.Black),
                new ColoredKey(Key.A, Color.Black),
                new ColoredKey(Key.W, Color.Black),
                new ColoredKey(Key.D3, Color.Black),
                new ColoredKey(Key.RightAlt, Color.Black),
                new ColoredKey(Key.OemSlash, Color.Black),
                new ColoredKey(Key.Enter, Color.Black),
                new ColoredKey(Key.OemApostrophe, Color.Black),
                new ColoredKey(Key.D0, Color.Black),
                new ColoredKey(Key.D9, Color.Black),
                new ColoredKey(Key.P, Color.Black),
                new ColoredKey(Key.OemSemicolon, Color.Black),
                new ColoredKey(Key.OemPeriod, Color.Black),
                new ColoredKey(Key.Space, Color.Black),
                new ColoredKey(Key.C, Color.Black),
                new ColoredKey(Key.S, Color.Black),
                new ColoredKey(Key.E, Color.Black),
                new ColoredKey(Key.D4, Color.Black),
                new ColoredKey(Key.D8, Color.Black),
                new ColoredKey(Key.O, Color.Black),
                new ColoredKey(Key.L, Color.Black),
                new ColoredKey(Key.OemComma, Color.Black),
                new ColoredKey(Key.D, Color.Black),
                new ColoredKey(Key.R, Color.Black),
                new ColoredKey(Key.D5, Color.Black),
                new ColoredKey(Key.D7, Color.Black),
                new ColoredKey(Key.D6, Color.Black),
                new ColoredKey(Key.T, Color.Black),
                new ColoredKey(Key.F, Color.Black),
                new ColoredKey(Key.V, Color.Black),
                new ColoredKey(Key.M, Color.Black),
                new ColoredKey(Key.K, Color.Black),
                new ColoredKey(Key.I, Color.Black),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.White),

                new ColoredKey(Key.G, Color.Black),
                new ColoredKey(Key.B, Color.Black),
                new ColoredKey(Key.N, Color.Black),
                new ColoredKey(Key.J, Color.Black),
                new ColoredKey(Key.U, Color.Black),
                new ColoredKey(Key.Y, Color.Black),

                new ColoredKey(Key.Backspace, Color.Black),
                new ColoredKey(Key.LeftControl, Color.Black),
                new ColoredKey(Key.RightControl, Color.Black),
                new ColoredKey(Key.OemTilde, Color.Black),
                new ColoredKey(Key.OemEquals, Color.Black),
                new ColoredKey(Key.OemBackslash, Color.Black),
                new ColoredKey(Key.LeftWindows, Color.Black),
                new ColoredKey(Key.LeftAlt, Color.Black),
                new ColoredKey(Key.LeftShift, Color.Black),
                new ColoredKey(Key.RightShift, Color.Black),
                new ColoredKey(Key.RightMenu, Color.Black),
                new ColoredKey(Key.Function, Color.Black),
                new ColoredKey(Key.D1, Color.Black),
                new ColoredKey(Key.Tab, Color.Black),
                new ColoredKey(Key.D2, Color.Black),
                new ColoredKey(Key.Q, Color.Black),
                new ColoredKey(Key.OemMinus, Color.Black),
                new ColoredKey(Key.OemRightBracket, Color.Black),
                new ColoredKey(Key.OemLeftBracket, Color.Black),
                new ColoredKey(Key.CapsLock, Color.Black),
                new ColoredKey(Key.Z, Color.Black),
                new ColoredKey(Key.X, Color.Black),
                new ColoredKey(Key.A, Color.Black),
                new ColoredKey(Key.W, Color.Black),
                new ColoredKey(Key.D3, Color.Black),
                new ColoredKey(Key.RightAlt, Color.Black),
                new ColoredKey(Key.OemSlash, Color.Black),
                new ColoredKey(Key.Enter, Color.Black),
                new ColoredKey(Key.OemApostrophe, Color.Black),
                new ColoredKey(Key.D0, Color.Black),
                new ColoredKey(Key.D9, Color.Black),
                new ColoredKey(Key.P, Color.Black),
                new ColoredKey(Key.OemSemicolon, Color.Black),
                new ColoredKey(Key.OemPeriod, Color.Black),
                new ColoredKey(Key.Space, Color.Black),
                new ColoredKey(Key.C, Color.Black),
                new ColoredKey(Key.S, Color.Black),
                new ColoredKey(Key.E, Color.Black),
                new ColoredKey(Key.D4, Color.Black),
                new ColoredKey(Key.D8, Color.Black),
                new ColoredKey(Key.O, Color.Black),
                new ColoredKey(Key.L, Color.Black),
                new ColoredKey(Key.OemComma, Color.Black),
                new ColoredKey(Key.D, Color.Black),
                new ColoredKey(Key.R, Color.Black),
                new ColoredKey(Key.D5, Color.Black),
                new ColoredKey(Key.D6, Color.Black),
                new ColoredKey(Key.D7, Color.Black),
                new ColoredKey(Key.T, Color.Black),
                new ColoredKey(Key.F, Color.Black),
                new ColoredKey(Key.V, Color.Black),
                new ColoredKey(Key.M, Color.Black),
                new ColoredKey(Key.K, Color.Black),
                new ColoredKey(Key.I, Color.Black),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Yellow)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Yellow)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Orange)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Orange)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Red)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Yellow),

                new ColoredKey(Key.G, Color.White),
                new ColoredKey(Key.B, Color.White),
                new ColoredKey(Key.N, Color.White),
                new ColoredKey(Key.J, Color.White),
                new ColoredKey(Key.U, Color.White),
                new ColoredKey(Key.Y, Color.White)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Orange),

                new ColoredKey(Key.G, Color.Yellow),
                new ColoredKey(Key.B, Color.Yellow),
                new ColoredKey(Key.N, Color.Yellow),
                new ColoredKey(Key.J, Color.Yellow),
                new ColoredKey(Key.U, Color.Yellow),
                new ColoredKey(Key.Y, Color.Yellow),

                new ColoredKey(Key.Space, Color.White),
                new ColoredKey(Key.D6, Color.White),
                new ColoredKey(Key.D7, Color.White),
                new ColoredKey(Key.T, Color.White),
                new ColoredKey(Key.F, Color.White),
                new ColoredKey(Key.V, Color.White),
                new ColoredKey(Key.M, Color.White),
                new ColoredKey(Key.K, Color.White),
                new ColoredKey(Key.I, Color.White),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Red),

                new ColoredKey(Key.G, Color.Orange),
                new ColoredKey(Key.B, Color.Orange),
                new ColoredKey(Key.N, Color.Orange),
                new ColoredKey(Key.J, Color.Orange),
                new ColoredKey(Key.U, Color.Orange),
                new ColoredKey(Key.Y, Color.Orange),

                new ColoredKey(Key.Space, Color.Yellow),

                new ColoredKey(Key.C, Color.White),

                new ColoredKey(Key.S, Color.Black),
                new ColoredKey(Key.E, Color.Black),
                new ColoredKey(Key.D4, Color.Black),

                new ColoredKey(Key.D8, Color.White),
                new ColoredKey(Key.O, Color.White),
                new ColoredKey(Key.L, Color.White),
                new ColoredKey(Key.OemComma, Color.White),
                new ColoredKey(Key.D, Color.White),
                new ColoredKey(Key.R, Color.White),
                new ColoredKey(Key.D5, Color.White),

                new ColoredKey(Key.D6, Color.Yellow),
                new ColoredKey(Key.D7, Color.Yellow),
                new ColoredKey(Key.T, Color.Yellow),
                new ColoredKey(Key.F, Color.Yellow),
                new ColoredKey(Key.V, Color.Yellow),
                new ColoredKey(Key.M, Color.Yellow),
                new ColoredKey(Key.K, Color.Yellow),
                new ColoredKey(Key.I, Color.Yellow),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Green),

                new ColoredKey(Key.G, Color.Red),
                new ColoredKey(Key.B, Color.Red),
                new ColoredKey(Key.N, Color.Red),
                new ColoredKey(Key.J, Color.Red),
                new ColoredKey(Key.U, Color.Red),
                new ColoredKey(Key.Y, Color.Red),

                new ColoredKey(Key.Space, Color.Orange),
                new ColoredKey(Key.D6, Color.Orange),
                new ColoredKey(Key.D7, Color.Orange),
                new ColoredKey(Key.T, Color.Orange),
                new ColoredKey(Key.F, Color.Orange),
                new ColoredKey(Key.V, Color.Orange),
                new ColoredKey(Key.M, Color.Orange),
                new ColoredKey(Key.K, Color.Orange),
                new ColoredKey(Key.I, Color.Orange),

                new ColoredKey(Key.C, Color.Yellow),
                new ColoredKey(Key.D8, Color.Yellow),
                new ColoredKey(Key.O, Color.Yellow),
                new ColoredKey(Key.L, Color.Yellow),
                new ColoredKey(Key.OemComma, Color.Yellow),
                new ColoredKey(Key.D, Color.Yellow),
                new ColoredKey(Key.R, Color.Yellow),
                new ColoredKey(Key.D5, Color.Yellow),

                new ColoredKey(Key.S, Color.White),
                new ColoredKey(Key.E, Color.White),
                new ColoredKey(Key.D4, Color.White),
                new ColoredKey(Key.X, Color.White),
                new ColoredKey(Key.D0, Color.White),
                new ColoredKey(Key.D9, Color.White),
                new ColoredKey(Key.P, Color.White),
                new ColoredKey(Key.OemSemicolon, Color.White),
                new ColoredKey(Key.OemPeriod, Color.White),
                new ColoredKey(Key.RightAlt, Color.White),
                new ColoredKey(Key.LeftAlt, Color.White),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Yellow),

                new ColoredKey(Key.G, Color.Green),
                new ColoredKey(Key.B, Color.Green),
                new ColoredKey(Key.N, Color.Green),
                new ColoredKey(Key.J, Color.Green),
                new ColoredKey(Key.U, Color.Green),
                new ColoredKey(Key.Y, Color.Green),

                new ColoredKey(Key.Space, Color.Red),
                new ColoredKey(Key.D6, Color.Red),
                new ColoredKey(Key.D7, Color.Red),
                new ColoredKey(Key.T, Color.Red),
                new ColoredKey(Key.F, Color.Red),
                new ColoredKey(Key.V, Color.Red),
                new ColoredKey(Key.M, Color.Red),
                new ColoredKey(Key.K, Color.Red),
                new ColoredKey(Key.I, Color.Red),

                new ColoredKey(Key.C, Color.Yellow),
                new ColoredKey(Key.D8, Color.Yellow),
                new ColoredKey(Key.O, Color.Yellow),
                new ColoredKey(Key.L, Color.Yellow),
                new ColoredKey(Key.OemComma, Color.Yellow),
                new ColoredKey(Key.D, Color.Yellow),
                new ColoredKey(Key.R, Color.Yellow),
                new ColoredKey(Key.D5, Color.Yellow),

                new ColoredKey(Key.S, Color.White),
                new ColoredKey(Key.E, Color.White),
                new ColoredKey(Key.D4, Color.White),
                new ColoredKey(Key.X, Color.White),
                new ColoredKey(Key.D0, Color.White),
                new ColoredKey(Key.D9, Color.White),
                new ColoredKey(Key.P, Color.White),
                new ColoredKey(Key.OemSemicolon, Color.White),
                new ColoredKey(Key.OemPeriod, Color.White),
                new ColoredKey(Key.RightAlt, Color.White),
                new ColoredKey(Key.LeftAlt, Color.White),

                new ColoredKey(Key.OemApostrophe, Color.White),
                new ColoredKey(Key.Function, Color.White),
                new ColoredKey(Key.OemMinus, Color.White),
                new ColoredKey(Key.OemLeftBracket, Color.White),
                new ColoredKey(Key.Z, Color.White),
                new ColoredKey(Key.A, Color.White),
                new ColoredKey(Key.W, Color.White),
                new ColoredKey(Key.D3, Color.White),
                new ColoredKey(Key.OemSlash, Color.White),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.White),

                new ColoredKey(Key.G, Color.Yellow),
                new ColoredKey(Key.B, Color.Yellow),
                new ColoredKey(Key.N, Color.Yellow),
                new ColoredKey(Key.J, Color.Yellow),
                new ColoredKey(Key.U, Color.Yellow),
                new ColoredKey(Key.Y, Color.Yellow),

                new ColoredKey(Key.Space, Color.Green),
                new ColoredKey(Key.D6, Color.Green),
                new ColoredKey(Key.D7, Color.Green),
                new ColoredKey(Key.T, Color.Green),
                new ColoredKey(Key.F, Color.Green),
                new ColoredKey(Key.V, Color.Green),
                new ColoredKey(Key.M, Color.Green),
                new ColoredKey(Key.K, Color.Green),
                new ColoredKey(Key.I, Color.Green),

                new ColoredKey(Key.C, Color.Red),
                new ColoredKey(Key.D8, Color.Red),
                new ColoredKey(Key.O, Color.Red),
                new ColoredKey(Key.L, Color.Red),
                new ColoredKey(Key.OemComma, Color.Red),
                new ColoredKey(Key.D, Color.Red),
                new ColoredKey(Key.R, Color.Red),
                new ColoredKey(Key.D5, Color.Red),

                new ColoredKey(Key.S, Color.Yellow),
                new ColoredKey(Key.E, Color.Yellow),
                new ColoredKey(Key.D4, Color.Yellow),
                new ColoredKey(Key.X, Color.Yellow),
                new ColoredKey(Key.D0, Color.Yellow),
                new ColoredKey(Key.D9, Color.Yellow),
                new ColoredKey(Key.P, Color.Yellow),
                new ColoredKey(Key.OemSemicolon, Color.Yellow),
                new ColoredKey(Key.OemPeriod, Color.Yellow),
                new ColoredKey(Key.RightAlt, Color.Yellow),
                new ColoredKey(Key.LeftAlt, Color.Yellow),

                new ColoredKey(Key.OemApostrophe, Color.Yellow),
                new ColoredKey(Key.Function, Color.Yellow),
                new ColoredKey(Key.OemMinus, Color.Yellow),
                new ColoredKey(Key.OemLeftBracket, Color.Yellow),
                new ColoredKey(Key.Z, Color.Yellow),
                new ColoredKey(Key.A, Color.Yellow),
                new ColoredKey(Key.W, Color.Yellow),
                new ColoredKey(Key.D3, Color.Yellow),
                new ColoredKey(Key.OemSlash, Color.Yellow),

                new ColoredKey(Key.OemEquals, Color.White),
                new ColoredKey(Key.LeftWindows, Color.White),
                new ColoredKey(Key.LeftShift, Color.White),
                new ColoredKey(Key.RightShift, Color.White),
                new ColoredKey(Key.RightMenu, Color.White),
                new ColoredKey(Key.D2, Color.White),
                new ColoredKey(Key.Q, Color.White),
                new ColoredKey(Key.OemRightBracket, Color.White),
                new ColoredKey(Key.CapsLock, Color.White),
                new ColoredKey(Key.Enter, Color.White),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Yellow),

                new ColoredKey(Key.G, Color.Orange),
                new ColoredKey(Key.B, Color.Orange),
                new ColoredKey(Key.N, Color.Orange),
                new ColoredKey(Key.J, Color.Orange),
                new ColoredKey(Key.U, Color.Orange),
                new ColoredKey(Key.Y, Color.Orange),

                new ColoredKey(Key.Space, Color.Red),
                new ColoredKey(Key.D6, Color.Red),
                new ColoredKey(Key.D7, Color.Red),
                new ColoredKey(Key.T, Color.Red),
                new ColoredKey(Key.F, Color.Red),
                new ColoredKey(Key.V, Color.Red),
                new ColoredKey(Key.M, Color.Red),
                new ColoredKey(Key.K, Color.Red),
                new ColoredKey(Key.I, Color.Red),

                new ColoredKey(Key.C, Color.Green),
                new ColoredKey(Key.D8, Color.Green),
                new ColoredKey(Key.O, Color.Green),
                new ColoredKey(Key.L, Color.Green),
                new ColoredKey(Key.OemComma, Color.Green),
                new ColoredKey(Key.D, Color.Green),
                new ColoredKey(Key.R, Color.Green),
                new ColoredKey(Key.D5, Color.Green),

                new ColoredKey(Key.S, Color.Orange),
                new ColoredKey(Key.E, Color.Orange),
                new ColoredKey(Key.D4, Color.Orange),
                new ColoredKey(Key.X, Color.Orange),
                new ColoredKey(Key.D0, Color.Orange),
                new ColoredKey(Key.D9, Color.Orange),
                new ColoredKey(Key.P, Color.Orange),
                new ColoredKey(Key.OemSemicolon, Color.Orange),
                new ColoredKey(Key.OemPeriod, Color.Orange),
                new ColoredKey(Key.RightAlt, Color.Orange),
                new ColoredKey(Key.LeftAlt, Color.Orange),

                new ColoredKey(Key.OemApostrophe, Color.Orange),
                new ColoredKey(Key.Function, Color.Orange),
                new ColoredKey(Key.OemMinus, Color.Orange),
                new ColoredKey(Key.OemLeftBracket, Color.Orange),
                new ColoredKey(Key.Z, Color.Orange),
                new ColoredKey(Key.A, Color.Orange),
                new ColoredKey(Key.W, Color.Orange),
                new ColoredKey(Key.D3, Color.Orange),
                new ColoredKey(Key.OemSlash, Color.Orange),

                new ColoredKey(Key.OemEquals, Color.Yellow),
                new ColoredKey(Key.LeftWindows, Color.Yellow),
                new ColoredKey(Key.LeftShift, Color.Yellow),
                new ColoredKey(Key.RightShift, Color.Yellow),
                new ColoredKey(Key.RightMenu, Color.Yellow),
                new ColoredKey(Key.D2, Color.Yellow),
                new ColoredKey(Key.Q, Color.Yellow),
                new ColoredKey(Key.OemRightBracket, Color.Yellow),
                new ColoredKey(Key.CapsLock, Color.Yellow),
                new ColoredKey(Key.Enter, Color.Yellow),

                new ColoredKey(Key.Backspace, Color.White),
                new ColoredKey(Key.LeftControl, Color.White),
                new ColoredKey(Key.RightControl, Color.White),
                new ColoredKey(Key.OemTilde, Color.White),
                new ColoredKey(Key.OemBackslash, Color.White),
                new ColoredKey(Key.D1, Color.White),
                new ColoredKey(Key.Tab, Color.White),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Orange),

                new ColoredKey(Key.G, Color.Red),
                new ColoredKey(Key.B, Color.Red),
                new ColoredKey(Key.N, Color.Red),
                new ColoredKey(Key.J, Color.Red),
                new ColoredKey(Key.U, Color.Red),
                new ColoredKey(Key.Y, Color.Red),

                new ColoredKey(Key.Space, Color.Red),
                new ColoredKey(Key.D6, Color.Red),
                new ColoredKey(Key.D7, Color.Red),
                new ColoredKey(Key.T, Color.Red),
                new ColoredKey(Key.F, Color.Red),
                new ColoredKey(Key.V, Color.Red),
                new ColoredKey(Key.M, Color.Red),
                new ColoredKey(Key.K, Color.Red),
                new ColoredKey(Key.I, Color.Red),

                new ColoredKey(Key.C, Color.Orange),
                new ColoredKey(Key.D8, Color.Orange),
                new ColoredKey(Key.O, Color.Orange),
                new ColoredKey(Key.L, Color.Orange),
                new ColoredKey(Key.OemComma, Color.Orange),
                new ColoredKey(Key.D, Color.Orange),
                new ColoredKey(Key.R, Color.Orange),
                new ColoredKey(Key.D5, Color.Orange),

                new ColoredKey(Key.S, Color.Green),
                new ColoredKey(Key.E, Color.Green),
                new ColoredKey(Key.D4, Color.Green),
                new ColoredKey(Key.X, Color.Green),
                new ColoredKey(Key.D0, Color.Green),
                new ColoredKey(Key.D9, Color.Green),
                new ColoredKey(Key.P, Color.Green),
                new ColoredKey(Key.OemSemicolon, Color.Green),
                new ColoredKey(Key.OemPeriod, Color.Green),
                new ColoredKey(Key.RightAlt, Color.Green),
                new ColoredKey(Key.LeftAlt, Color.Green),

                new ColoredKey(Key.OemApostrophe, Color.Orange),
                new ColoredKey(Key.Function, Color.Orange),
                new ColoredKey(Key.OemMinus, Color.Orange),
                new ColoredKey(Key.OemLeftBracket, Color.Orange),
                new ColoredKey(Key.Z, Color.Orange),
                new ColoredKey(Key.A, Color.Orange),
                new ColoredKey(Key.W, Color.Orange),
                new ColoredKey(Key.D3, Color.Orange),
                new ColoredKey(Key.OemSlash, Color.Orange),

                new ColoredKey(Key.OemEquals, Color.Red),
                new ColoredKey(Key.LeftWindows, Color.Red),
                new ColoredKey(Key.LeftShift, Color.Red),
                new ColoredKey(Key.RightShift, Color.Red),
                new ColoredKey(Key.RightMenu, Color.Red),
                new ColoredKey(Key.D2, Color.Red),
                new ColoredKey(Key.Q, Color.Red),
                new ColoredKey(Key.OemRightBracket, Color.Red),
                new ColoredKey(Key.CapsLock, Color.Red),
                new ColoredKey(Key.Enter, Color.Red),

                new ColoredKey(Key.Backspace, Color.Yellow),
                new ColoredKey(Key.LeftControl, Color.Yellow),
                new ColoredKey(Key.RightControl, Color.Yellow),
                new ColoredKey(Key.OemTilde, Color.Yellow),
                new ColoredKey(Key.OemBackslash, Color.Yellow),
                new ColoredKey(Key.D1, Color.Yellow),
                new ColoredKey(Key.Tab, Color.Yellow),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Red),

                new ColoredKey(Key.G, Color.Yellow),
                new ColoredKey(Key.B, Color.Yellow),
                new ColoredKey(Key.N, Color.Yellow),
                new ColoredKey(Key.J, Color.Yellow),
                new ColoredKey(Key.U, Color.Yellow),
                new ColoredKey(Key.Y, Color.Yellow),

                new ColoredKey(Key.Space, Color.Red),
                new ColoredKey(Key.D6, Color.Red),
                new ColoredKey(Key.D7, Color.Red),
                new ColoredKey(Key.T, Color.Red),
                new ColoredKey(Key.F, Color.Red),
                new ColoredKey(Key.V, Color.Red),
                new ColoredKey(Key.M, Color.Red),
                new ColoredKey(Key.K, Color.Red),
                new ColoredKey(Key.I, Color.Red),

                new ColoredKey(Key.C, Color.Red),
                new ColoredKey(Key.D8, Color.Red),
                new ColoredKey(Key.O, Color.Red),
                new ColoredKey(Key.L, Color.Red),
                new ColoredKey(Key.OemComma, Color.Red),
                new ColoredKey(Key.D, Color.Red),
                new ColoredKey(Key.R, Color.Red),
                new ColoredKey(Key.D5, Color.Red),

                new ColoredKey(Key.S, Color.Red),
                new ColoredKey(Key.E, Color.Red),
                new ColoredKey(Key.D4, Color.Red),
                new ColoredKey(Key.X, Color.Red),
                new ColoredKey(Key.D0, Color.Red),
                new ColoredKey(Key.D9, Color.Red),
                new ColoredKey(Key.P, Color.Red),
                new ColoredKey(Key.OemSemicolon, Color.Red),
                new ColoredKey(Key.OemPeriod, Color.Red),
                new ColoredKey(Key.RightAlt, Color.Red),
                new ColoredKey(Key.LeftAlt, Color.Red),

                new ColoredKey(Key.OemApostrophe, Color.Green),
                new ColoredKey(Key.Function, Color.Green),
                new ColoredKey(Key.OemMinus, Color.Green),
                new ColoredKey(Key.OemLeftBracket, Color.Green),
                new ColoredKey(Key.Z, Color.Green),
                new ColoredKey(Key.A, Color.Green),
                new ColoredKey(Key.W, Color.Green),
                new ColoredKey(Key.D3, Color.Green),
                new ColoredKey(Key.OemSlash, Color.Green),

                new ColoredKey(Key.OemEquals, Color.Red),
                new ColoredKey(Key.LeftWindows, Color.Red),
                new ColoredKey(Key.LeftShift, Color.Red),
                new ColoredKey(Key.RightShift, Color.Red),
                new ColoredKey(Key.RightMenu, Color.Red),
                new ColoredKey(Key.D2, Color.Red),
                new ColoredKey(Key.Q, Color.Red),
                new ColoredKey(Key.OemRightBracket, Color.Red),
                new ColoredKey(Key.CapsLock, Color.Red),
                new ColoredKey(Key.Enter, Color.Red),

                new ColoredKey(Key.Backspace, Color.Orange),
                new ColoredKey(Key.LeftControl, Color.Orange),
                new ColoredKey(Key.RightControl, Color.Orange),
                new ColoredKey(Key.OemTilde, Color.Orange),
                new ColoredKey(Key.OemBackslash, Color.Orange),
                new ColoredKey(Key.D1, Color.Orange),
                new ColoredKey(Key.Tab, Color.Orange),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Red),

                new ColoredKey(Key.G, Color.Yellow),
                new ColoredKey(Key.B, Color.Yellow),
                new ColoredKey(Key.N, Color.Yellow),
                new ColoredKey(Key.J, Color.Yellow),
                new ColoredKey(Key.U, Color.Yellow),
                new ColoredKey(Key.Y, Color.Yellow),

                new ColoredKey(Key.Space, Color.Red),
                new ColoredKey(Key.D6, Color.Red),
                new ColoredKey(Key.D7, Color.Red),
                new ColoredKey(Key.T, Color.Red),
                new ColoredKey(Key.F, Color.Red),
                new ColoredKey(Key.V, Color.Red),
                new ColoredKey(Key.M, Color.Red),
                new ColoredKey(Key.K, Color.Red),
                new ColoredKey(Key.I, Color.Red),

                new ColoredKey(Key.C, Color.Red),
                new ColoredKey(Key.D8, Color.Red),
                new ColoredKey(Key.O, Color.Red),
                new ColoredKey(Key.L, Color.Red),
                new ColoredKey(Key.OemComma, Color.Red),
                new ColoredKey(Key.D, Color.Red),
                new ColoredKey(Key.R, Color.Red),
                new ColoredKey(Key.D5, Color.Red),

                new ColoredKey(Key.S, Color.Red),
                new ColoredKey(Key.E, Color.Red),
                new ColoredKey(Key.D4, Color.Red),
                new ColoredKey(Key.X, Color.Red),
                new ColoredKey(Key.D0, Color.Red),
                new ColoredKey(Key.D9, Color.Red),
                new ColoredKey(Key.P, Color.Red),
                new ColoredKey(Key.OemSemicolon, Color.Red),
                new ColoredKey(Key.OemPeriod, Color.Red),
                new ColoredKey(Key.RightAlt, Color.Red),
                new ColoredKey(Key.LeftAlt, Color.Red),

                new ColoredKey(Key.OemApostrophe, Color.Red),
                new ColoredKey(Key.Function, Color.Red),
                new ColoredKey(Key.OemMinus, Color.Red),
                new ColoredKey(Key.OemLeftBracket, Color.Red),
                new ColoredKey(Key.Z, Color.Red),
                new ColoredKey(Key.A, Color.Red),
                new ColoredKey(Key.W, Color.Red),
                new ColoredKey(Key.D3, Color.Red),
                new ColoredKey(Key.OemSlash, Color.Red),

                new ColoredKey(Key.OemEquals, Color.Green),
                new ColoredKey(Key.LeftWindows, Color.Green),
                new ColoredKey(Key.LeftShift, Color.Green),
                new ColoredKey(Key.RightShift, Color.Green),
                new ColoredKey(Key.RightMenu, Color.Green),
                new ColoredKey(Key.D2, Color.Green),
                new ColoredKey(Key.Q, Color.Green),
                new ColoredKey(Key.OemRightBracket, Color.Green),
                new ColoredKey(Key.CapsLock, Color.Green),
                new ColoredKey(Key.Enter, Color.Green),

                new ColoredKey(Key.Backspace, Color.Orange),
                new ColoredKey(Key.LeftControl, Color.Orange),
                new ColoredKey(Key.RightControl, Color.Orange),
                new ColoredKey(Key.OemTilde, Color.Orange),
                new ColoredKey(Key.OemBackslash, Color.Orange),
                new ColoredKey(Key.D1, Color.Orange),
                new ColoredKey(Key.Tab, Color.Orange),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.H, Color.Red),

                new ColoredKey(Key.G, Color.Yellow),
                new ColoredKey(Key.B, Color.Yellow),
                new ColoredKey(Key.N, Color.Yellow),
                new ColoredKey(Key.J, Color.Yellow),
                new ColoredKey(Key.U, Color.Yellow),
                new ColoredKey(Key.Y, Color.Yellow),

                new ColoredKey(Key.Space, Color.Red),
                new ColoredKey(Key.D6, Color.Red),
                new ColoredKey(Key.D7, Color.Red),
                new ColoredKey(Key.T, Color.Red),
                new ColoredKey(Key.F, Color.Red),
                new ColoredKey(Key.V, Color.Red),
                new ColoredKey(Key.M, Color.Red),
                new ColoredKey(Key.K, Color.Red),
                new ColoredKey(Key.I, Color.Red),

                new ColoredKey(Key.C, Color.Red),
                new ColoredKey(Key.D8, Color.Red),
                new ColoredKey(Key.O, Color.Red),
                new ColoredKey(Key.L, Color.Red),
                new ColoredKey(Key.OemComma, Color.Red),
                new ColoredKey(Key.D, Color.Red),
                new ColoredKey(Key.R, Color.Red),
                new ColoredKey(Key.D5, Color.Red),

                new ColoredKey(Key.S, Color.Red),
                new ColoredKey(Key.E, Color.Red),
                new ColoredKey(Key.D4, Color.Red),
                new ColoredKey(Key.X, Color.Red),
                new ColoredKey(Key.D0, Color.Red),
                new ColoredKey(Key.D9, Color.Red),
                new ColoredKey(Key.P, Color.Red),
                new ColoredKey(Key.OemSemicolon, Color.Red),
                new ColoredKey(Key.OemPeriod, Color.Red),
                new ColoredKey(Key.RightAlt, Color.Red),
                new ColoredKey(Key.LeftAlt, Color.Red),

                new ColoredKey(Key.OemApostrophe, Color.Red),
                new ColoredKey(Key.Function, Color.Red),
                new ColoredKey(Key.OemMinus, Color.Red),
                new ColoredKey(Key.OemLeftBracket, Color.Red),
                new ColoredKey(Key.Z, Color.Red),
                new ColoredKey(Key.A, Color.Red),
                new ColoredKey(Key.W, Color.Red),
                new ColoredKey(Key.D3, Color.Red),
                new ColoredKey(Key.OemSlash, Color.Red),

                new ColoredKey(Key.OemEquals, Color.Red),
                new ColoredKey(Key.LeftWindows, Color.Red),
                new ColoredKey(Key.LeftShift, Color.Red),
                new ColoredKey(Key.RightShift, Color.Red),
                new ColoredKey(Key.RightMenu, Color.Red),
                new ColoredKey(Key.D2, Color.Red),
                new ColoredKey(Key.Q, Color.Red),
                new ColoredKey(Key.OemRightBracket, Color.Red),
                new ColoredKey(Key.CapsLock, Color.Red),
                new ColoredKey(Key.Enter, Color.Red),

                new ColoredKey(Key.Backspace, Color.Green),
                new ColoredKey(Key.LeftControl, Color.Green),
                new ColoredKey(Key.RightControl, Color.Green),
                new ColoredKey(Key.OemTilde, Color.Green),
                new ColoredKey(Key.OemBackslash, Color.Green),
                new ColoredKey(Key.D1, Color.Green),
                new ColoredKey(Key.Tab, Color.Green),
            },
        };

        public List<List<IColoredKey>> HebAnimation = new List<List<IColoredKey>>()
        {
            new List<IColoredKey>()
            {
                new ColoredKey(Key.OemRightBracket, HebrewAltColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.OemLeftBracket, HebrewAltColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.OemApostrophe, HebrewAltColor),
                new ColoredKey(Key.OemSlash, HebrewAltColor)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.P, HebrewColor),
                new ColoredKey(Key.OemSemicolon, HebrewColor),
                new ColoredKey(Key.OemPeriod, HebrewColor)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.O, HebrewColor),
                new ColoredKey(Key.L, HebrewColor),
                new ColoredKey(Key.OemComma, HebrewColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.I, HebrewColor),
                new ColoredKey(Key.K, HebrewColor),
                new ColoredKey(Key.M, HebrewColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.U, HebrewColor),
                new ColoredKey(Key.J, HebrewColor),
                new ColoredKey(Key.N, HebrewColor),
                new ColoredKey(Key.Space, HebrewColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.Y, HebrewColor),
                new ColoredKey(Key.H, HebrewColor),
                new ColoredKey(Key.B, HebrewColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.T, HebrewColor),
                new ColoredKey(Key.G, HebrewColor),
                new ColoredKey(Key.V, HebrewColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.R, HebrewColor),
                new ColoredKey(Key.F, HebrewColor),
                new ColoredKey(Key.C, HebrewColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.E, HebrewColor),
                new ColoredKey(Key.D, HebrewColor),
                new ColoredKey(Key.X, HebrewColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.W, HebrewAltColor),
                new ColoredKey(Key.S, HebrewColor),
                new ColoredKey(Key.Z, HebrewColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.A, HebrewColor),
                new ColoredKey(Key.Q, HebrewAltColor),
                new ColoredKey(Key.Logo, HebrewColor),
            },
        };

        public List<List<IColoredKey>> EngAnimation = new List<List<IColoredKey>>()
        {
            new List<IColoredKey>()
            {
                new ColoredKey(Key.A, EnglishColor),
                new ColoredKey(Key.Q, EnglishColor),
                new ColoredKey(Key.Z, EnglishColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.W, EnglishColor),
                new ColoredKey(Key.S, EnglishColor),
                new ColoredKey(Key.X, EnglishColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.E, EnglishColor),
                new ColoredKey(Key.D, EnglishColor),
                new ColoredKey(Key.C, EnglishColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.R, EnglishColor),
                new ColoredKey(Key.F, EnglishColor),
                new ColoredKey(Key.V, EnglishColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.T, EnglishColor),
                new ColoredKey(Key.G, EnglishColor),
                new ColoredKey(Key.B, EnglishColor),
                new ColoredKey(Key.Space, EnglishColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.Y, EnglishColor),
                new ColoredKey(Key.H, EnglishColor),
                new ColoredKey(Key.N, EnglishColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.U, EnglishColor),
                new ColoredKey(Key.J, EnglishColor),
                new ColoredKey(Key.M, EnglishColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.I, EnglishColor),
                new ColoredKey(Key.K, EnglishColor),
                new ColoredKey(Key.OemComma, EnglishAltColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.O, EnglishColor),
                new ColoredKey(Key.L, EnglishColor),
                new ColoredKey(Key.OemPeriod, EnglishAltColor)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.P, EnglishColor),
                new ColoredKey(Key.OemSemicolon, EnglishAltColor),
                new ColoredKey(Key.OemSlash, EnglishAltColor)
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.OemLeftBracket, EnglishAltColor),
                new ColoredKey(Key.OemApostrophe, EnglishAltColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.OemRightBracket, EnglishAltColor),
            },
            new List<IColoredKey>()
            {
                new ColoredKey(Key.OemBackslash, EnglishAltColor),
                new ColoredKey(Key.Logo, EnglishColor),
            },
        };
    }
}