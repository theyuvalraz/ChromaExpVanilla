using System;
using System.Collections.Generic;
using System.Linq;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;

namespace ChromaExpVanila.config
{
    public class KeyBlocks
    {

        public List<ColoredKey> MiscColoredKeys = new List<ColoredKey>()
        {
            new ColoredKey(Key.Macro1, Color.Orange),
            new ColoredKey(Key.Macro2, Color.Blue),
            new ColoredKey(Key.Macro3, Color.Orange),
            new ColoredKey(Key.Macro4, Color.Black),
            new ColoredKey(Key.Macro5, Color.White),
            new ColoredKey(Key.F3, Color.White),
            new ColoredKey(Key.PrintScreen, Color.Blue),
            new ColoredKey(Key.Scroll, Color.Red),
            new ColoredKey(Key.NumEnter, Color.Orange),
            new ColoredKey(Key.Backspace, Color.Orange),
            new ColoredKey(Key.OemTilde, Color.Orange),
            new ColoredKey(Key.Delete, Color.Orange),
            new ColoredKey(Key.Pause, Color.Yellow),
            new ColoredKey(Key.Insert, Color.Red),
        };


        public List<ColoredKey> usefulKeys = new List<ColoredKey>
        {
            new ColoredKey(Key.Enter),
            new ColoredKey(Key.Home),
            new ColoredKey(Key.End),
            new ColoredKey(Key.F12),
            new ColoredKey(Key.F7),
            new ColoredKey(Key.F2),
            new ColoredKey(Key.F5),
            new ColoredKey(Key.PageUp),
            new ColoredKey(Key.PageDown)
        };

        public List<ColoredKey> NumberKeys = new List<ColoredKey>
        {
            new ColoredKey(Key.D1),
            new ColoredKey(Key.D2),
            new ColoredKey(Key.D3),
            new ColoredKey(Key.D4),
            new ColoredKey(Key.D5),
            new ColoredKey(Key.D6),
            new ColoredKey(Key.D7),
            new ColoredKey(Key.D8),
            new ColoredKey(Key.D9),
            new ColoredKey(Key.D0),
            new ColoredKey(Key.OemMinus),
            new ColoredKey(Key.OemEquals),
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
            new ColoredKey(Key.OemBackslash)
        };

        public List<ColoredKey> HebKeys = new List<ColoredKey>
        {
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
            new ColoredKey(Key.Space)
        };

        public List<ColoredKey> EngKeys = new List<ColoredKey>
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
            new ColoredKey(Key.Z),
            new ColoredKey(Key.X),
            new ColoredKey(Key.C),
            new ColoredKey(Key.V),
            new ColoredKey(Key.B),
            new ColoredKey(Key.N),
            new ColoredKey(Key.M),
            new ColoredKey(Key.Space)
        };

        public List<ColoredKey> EngKeysOther = new List<ColoredKey>
        {
            new ColoredKey(Key.OemLeftBracket),
            new ColoredKey(Key.OemRightBracket),
            new ColoredKey(Key.OemSemicolon),
            new ColoredKey(Key.OemApostrophe),
            new ColoredKey(Key.OemComma),
            new ColoredKey(Key.OemPeriod),
            new ColoredKey(Key.OemSlash),
            new ColoredKey(Key.OemBackslash)
        };

        public List<ColoredKey> HebKeysOther = new List<ColoredKey>
        {
            new ColoredKey(Key.Q),
            new ColoredKey(Key.W),
            new ColoredKey(Key.OemApostrophe),
            new ColoredKey(Key.OemSlash),
        };


        public List<ColoredKey> CapsLk = new List<ColoredKey>
        {
            new ColoredKey(Key.CapsLock)
        };

        public List<ColoredKey> UselessKeys = new List<ColoredKey>
        {
            new ColoredKey(Key.F4),
            new ColoredKey(Key.F6),
            new ColoredKey(Key.F8),
            new ColoredKey(Key.F10),
            new ColoredKey(Key.RightMenu)
        };

        public List<ColoredKey> Numpad = new List<ColoredKey>
        {
            new ColoredKey(Key.Num0),
            new ColoredKey(Key.Num1),
            new ColoredKey(Key.Num2),
            new ColoredKey(Key.Num3),
            new ColoredKey(Key.Num4),
            new ColoredKey(Key.Num5),
            new ColoredKey(Key.Num6),
            new ColoredKey(Key.Num7),
            new ColoredKey(Key.Num8),
            new ColoredKey(Key.Num9),
            new ColoredKey(Key.NumDecimal),
            new ColoredKey(Key.NumLock)
        };


        public List<ColoredKey> AltNumPad = new List<ColoredKey>
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

        public List<ColoredKey> Logo = new List<ColoredKey>
        {
            new ColoredKey(Key.Logo)
        };

        public List<ColoredKey> AnimationKeys = new List<ColoredKey>
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

        public List<List<ColoredKey>> AnimationConcept = new List<List<ColoredKey>>()
        {
            new List<ColoredKey>() {new ColoredKey(Key.Backspace), new ColoredKey(Key.LeftControl)},
            new List<ColoredKey>() {new ColoredKey(Key.OemEquals), new ColoredKey(Key.LeftWindows)},
            new List<ColoredKey>() {new ColoredKey(Key.OemMinus), new ColoredKey(Key.LeftAlt)},
            new List<ColoredKey>() {new ColoredKey(Key.D0), new ColoredKey(Key.LeftAlt)},
            new List<ColoredKey>() {new ColoredKey(Key.D9), new ColoredKey(Key.Space)},
            new List<ColoredKey>() {new ColoredKey(Key.D8), new ColoredKey(Key.Space)},
            new List<ColoredKey>() {new ColoredKey(Key.D7), new ColoredKey(Key.Space)},
            new List<ColoredKey>() {new ColoredKey(Key.D6), new ColoredKey(Key.Space)},
            new List<ColoredKey>() {new ColoredKey(Key.D5), new ColoredKey(Key.Space)},
            new List<ColoredKey>() {new ColoredKey(Key.D4), new ColoredKey(Key.RightAlt)},
            new List<ColoredKey>() {new ColoredKey(Key.D3), new ColoredKey(Key.RightAlt)},
            new List<ColoredKey>() {new ColoredKey(Key.D2), new ColoredKey(Key.Function)},
            new List<ColoredKey>() {new ColoredKey(Key.D1), new ColoredKey(Key.RightMenu)},
            new List<ColoredKey>() {new ColoredKey(Key.OemTilde), new ColoredKey(Key.RightControl)},
            new List<ColoredKey>() {new ColoredKey(Key.Tab), new ColoredKey(Key.RightShift)},
            new List<ColoredKey>() {new ColoredKey(Key.Q), new ColoredKey(Key.RightShift)},
            new List<ColoredKey>() {new ColoredKey(Key.W), new ColoredKey(Key.OemSlash)},
            new List<ColoredKey>() {new ColoredKey(Key.E), new ColoredKey(Key.OemPeriod)},
            new List<ColoredKey>() {new ColoredKey(Key.R), new ColoredKey(Key.OemComma)},
            new List<ColoredKey>() {new ColoredKey(Key.T), new ColoredKey(Key.M)},
            new List<ColoredKey>() {new ColoredKey(Key.Y), new ColoredKey(Key.N)},
            new List<ColoredKey>() {new ColoredKey(Key.U), new ColoredKey(Key.B)},
            new List<ColoredKey>() {new ColoredKey(Key.I), new ColoredKey(Key.V)},
            new List<ColoredKey>() {new ColoredKey(Key.O), new ColoredKey(Key.C)},
            new List<ColoredKey>() {new ColoredKey(Key.P), new ColoredKey(Key.X)},
            new List<ColoredKey>() {new ColoredKey(Key.OemLeftBracket), new ColoredKey(Key.Z)},
            new List<ColoredKey>() {new ColoredKey(Key.OemRightBracket), new ColoredKey(Key.LeftShift)},
            new List<ColoredKey>() {new ColoredKey(Key.OemBackslash), new ColoredKey(Key.LeftShift)},
            new List<ColoredKey>() {new ColoredKey(Key.Enter), new ColoredKey(Key.CapsLock)},
            new List<ColoredKey>() {new ColoredKey(Key.OemApostrophe), new ColoredKey(Key.A)},
            new List<ColoredKey>() {new ColoredKey(Key.OemSemicolon), new ColoredKey(Key.S)},
            new List<ColoredKey>() {new ColoredKey(Key.L), new ColoredKey(Key.D)},
            new List<ColoredKey>() {new ColoredKey(Key.K), new ColoredKey(Key.F)},
            new List<ColoredKey>() {new ColoredKey(Key.J), new ColoredKey(Key.G)},
            new List<ColoredKey>() {new ColoredKey(Key.H)},
            new List<ColoredKey>() {new ColoredKey(Key.H)},
            new List<ColoredKey>() {new ColoredKey(Key.H)},
            new List<ColoredKey>() {new ColoredKey(Key.H), new ColoredKey(Key.M), new ColoredKey(Key.T)},
            new List<ColoredKey>() {new ColoredKey(Key.F), new ColoredKey(Key.K)},
            new List<ColoredKey>() {new ColoredKey(Key.V), new ColoredKey(Key.I)},
            new List<ColoredKey>() {new ColoredKey(Key.Space), new ColoredKey(Key.D8)},
            new List<ColoredKey>() {new ColoredKey(Key.N), new ColoredKey(Key.F5 )},
            new List<ColoredKey>(){ new ColoredKey(Key.J), new ColoredKey( Key.D5)},
            new List<ColoredKey>(){ new ColoredKey(Key.U), new ColoredKey( Key.R)},
            new List<ColoredKey>(){new ColoredKey( Key.D7), new ColoredKey( Key.F)},
            new List<ColoredKey>(){new ColoredKey( Key.T), new ColoredKey( Key.V)},
            new List<ColoredKey>(){new ColoredKey( Key.F), new ColoredKey( Key.G)},
            new List<ColoredKey>(){ new ColoredKey( Key.G)},
            new List<ColoredKey>(){ new ColoredKey( Key.G)},
            new List<ColoredKey>(){ new ColoredKey( Key.G)},
        };
        }

    }
