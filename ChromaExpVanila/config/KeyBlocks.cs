using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using Interfacer.Interfaces;

namespace ChromaExpVanilla.config
{
    public static class KeyBlocks
    {
        // i really should vectorize this
        private static readonly Color HebrewColor = Color.FromRgb(0xff1900);

        private static readonly Color HebrewAltColor = Color.FromRgb(0x00ffff);
        private static readonly Color EnglishAltColor = Color.FromRgb(0x9000ff);
        private static readonly Color EnglishColor = Color.FromRgb(0x24a504);
        private static readonly Color TopNumberNormalColor = Color.FromRgb(0x00008B);
        private static readonly Color NumpadNormalColor = Color.FromRgb(0x24a504);

        private static readonly Color MiscSet1 = Color.Orange;
        private static readonly Color MiscSet2 = Color.Blue;
        private static readonly Color MiscSet3 = Color.White;
        private static readonly Color MiscSet4 = Color.Red;
        private static readonly Color MiscSet5 = Color.Yellow;

        public static readonly IColoredKey[] AltNumPad =
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

        public static readonly IColoredKey[] CapsLk =
        {
            new ColoredKey(Key.CapsLock)
        };

        public static readonly IColoredKey[][] EngAnimation =
        {
            new IColoredKey[]
            {
                new ColoredKey(Key.A, EnglishColor),
                new ColoredKey(Key.Q, EnglishColor),
                new ColoredKey(Key.Z, EnglishColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.W, EnglishColor),
                new ColoredKey(Key.S, EnglishColor),
                new ColoredKey(Key.X, EnglishColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.E, EnglishColor),
                new ColoredKey(Key.D, EnglishColor),
                new ColoredKey(Key.C, EnglishColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.R, EnglishColor),
                new ColoredKey(Key.F, EnglishColor),
                new ColoredKey(Key.V, EnglishColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.T, EnglishColor),
                new ColoredKey(Key.G, EnglishColor),
                new ColoredKey(Key.B, EnglishColor),
                new ColoredKey(Key.Space, EnglishColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.Y, EnglishColor),
                new ColoredKey(Key.H, EnglishColor),
                new ColoredKey(Key.N, EnglishColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.U, EnglishColor),
                new ColoredKey(Key.J, EnglishColor),
                new ColoredKey(Key.M, EnglishColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.I, EnglishColor),
                new ColoredKey(Key.K, EnglishColor),
                new ColoredKey(Key.OemComma, EnglishAltColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.O, EnglishColor),
                new ColoredKey(Key.L, EnglishColor),
                new ColoredKey(Key.OemPeriod, EnglishAltColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.P, EnglishColor),
                new ColoredKey(Key.OemSemicolon, EnglishAltColor),
                new ColoredKey(Key.OemSlash, EnglishAltColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.OemLeftBracket, EnglishAltColor),
                new ColoredKey(Key.OemApostrophe, EnglishAltColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.OemRightBracket, EnglishAltColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.OemBackslash, EnglishAltColor),
                new ColoredKey(Key.Logo, EnglishColor)
            }
        };

        public static readonly IColoredKey[][] HebAnimation =
        {
            new IColoredKey[]
            {
                new ColoredKey(Key.OemRightBracket, HebrewAltColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.OemLeftBracket, HebrewAltColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.OemApostrophe, HebrewAltColor),
                new ColoredKey(Key.OemSlash, HebrewAltColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.P, HebrewColor),
                new ColoredKey(Key.OemSemicolon, HebrewColor),
                new ColoredKey(Key.OemPeriod, HebrewColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.O, HebrewColor),
                new ColoredKey(Key.L, HebrewColor),
                new ColoredKey(Key.OemComma, HebrewColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.I, HebrewColor),
                new ColoredKey(Key.K, HebrewColor),
                new ColoredKey(Key.M, HebrewColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.U, HebrewColor),
                new ColoredKey(Key.J, HebrewColor),
                new ColoredKey(Key.N, HebrewColor),
                new ColoredKey(Key.Space, HebrewColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.Y, HebrewColor),
                new ColoredKey(Key.H, HebrewColor),
                new ColoredKey(Key.B, HebrewColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.T, HebrewColor),
                new ColoredKey(Key.G, HebrewColor),
                new ColoredKey(Key.V, HebrewColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.R, HebrewColor),
                new ColoredKey(Key.F, HebrewColor),
                new ColoredKey(Key.C, HebrewColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.E, HebrewColor),
                new ColoredKey(Key.D, HebrewColor),
                new ColoredKey(Key.X, HebrewColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.W, HebrewAltColor),
                new ColoredKey(Key.S, HebrewColor),
                new ColoredKey(Key.Z, HebrewColor)
            },
            new IColoredKey[]
            {
                new ColoredKey(Key.A, HebrewColor),
                new ColoredKey(Key.Q, HebrewAltColor),
                new ColoredKey(Key.Logo, HebrewColor)
            }
        };

        public static readonly IColoredKey[] MiscColoredKeys =
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
            new ColoredKey(Key.Insert, MiscSet4)
        };

        public static readonly IColoredKey[] NumberKeys =
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
            new ColoredKey(Key.OemEquals, TopNumberNormalColor)
        };

        public static readonly IColoredKey[] Numpad =
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
    }
}