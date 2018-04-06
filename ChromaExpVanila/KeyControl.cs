using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ChromaExpVanilla.config;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;

namespace ChromaExpVanilla
{
    public class KeyControl
    {
        private readonly KeyBlocks _blocks = new KeyBlocks();
        private readonly IKeyboard _inst = Keyboard.Instance;
        private const uint BaseColor = 0x202020;

        public void ColorBase()
        {
            _inst.Clear();
            Animation(_blocks.AllLetterKeys);

            _inst.SetAll(Color.FromRgb(BaseColor));
            Thread.Sleep(100);
            _inst.SetKey(Key.Macro1, Color.Orange);
            Thread.Sleep(100);
            _inst.SetKey(Key.Macro2, Color.Blue);
            Thread.Sleep(100);
            _inst.SetKey(Key.Macro3, Color.Orange);
            Thread.Sleep(100);
            _inst.SetKey(Key.Macro4, Color.Black);
            Thread.Sleep(100);
            _inst.SetKey(Key.Macro5, Color.White);
            Thread.Sleep(100);
            _inst.SetKey(Key.F3, Color.White);
            Thread.Sleep(100);
            _inst.SetKey(Key.PrintScreen, Color.Blue);
            Thread.Sleep(100);
            _inst.SetKey(Key.Scroll, Color.Red);
            Thread.Sleep(100);

            _inst.SetKeys(_blocks.UsefulKeys, Color.Pink);
            _inst.SetKeys(_blocks.UselessKeys, Color.Black);
            Thread.Sleep(100);
        }

        public void SetEng()
        {
            _inst.SetKeys(_blocks.AllLetterKeys, Color.FromRgb(BaseColor));
            _inst.SetKeys(_blocks.EngKeys, Color.Green);
        }

        public void SetHeb()
        {
            _inst.SetKeys(_blocks.AllLetterKeys, Color.FromRgb(BaseColor));
            _inst.SetKeys(_blocks.HebKeys, Color.Red);
        }

        public void PreSetLang()
        {
            _inst.SetKeys(_blocks.AllLetterKeys, Color.FromRgb(BaseColor));
        }

        public void TopNumChange(Color color)
        {
            _inst.SetKeys(_blocks.NumberKeys, color);
        }

        public void NumLockOn()
        {
            _inst.SetKeys(_blocks.Numpad, Color.Green);
            TopNumChange(Color.FromRgb(BaseColor));
        }

        public void NumLockOff()
        {
            Thread.Sleep(100);
            _inst.SetKeys(_blocks.AltNumPad1, Color.Orange);
            Thread.Sleep(100);
            _inst.SetKeys(_blocks.AltNumPad2, Color.Purple);
            Thread.Sleep(100);
            _inst.SetKeys(_blocks.AltNumPad3, Color.Black);
            Thread.Sleep(100);
            TopNumChange(Color.Green);
        }

        public void CapsLockOn()
        {
            _inst.SetKeys(_blocks.CapsLk, Color.Yellow);
        }

        public void CapsLockOff()
        {
            _inst.SetKeys(_blocks.CapsLk, Color.FromRgb(BaseColor));
        }

        public void Animation(List<Key> keyBlocks)
        {
            var flow = keyBlocks;
            _inst.Clear();
            for (var i = 0; i < flow.Count(); i++)
            {
                try
                {
                    Thread.Sleep(100);
                    _inst.SetKey(flow[i + 1], Color.Red);
                    Thread.Sleep(10);
                    _inst.SetKey(flow[i], Color.Yellow);
                    Thread.Sleep(10);
                    _inst.SetKey(flow[i + 1], Color.Red);
                    Thread.Sleep(10);
                    _inst.SetKey(flow[i + 2], Color.Blue);
                    Thread.Sleep(10);
                    _inst.SetKey(flow[i + 3], Color.Green);
                    Thread.Sleep(10);
                    _inst.SetKey(flow[i + 4], Color.Purple);
                    Thread.Sleep(10);
                    _inst.SetKey(flow[i], Color.FromRgb(0x505050));
                    _inst.SetKey(flow[i + 1], Color.FromRgb(0x404040));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void TimeAnimation()
        {
            var flow = _blocks.NumberKeys;
            for (var i = 0; i < _blocks.NumberKeys.Count(); i++)
            {
                try
                {
                    Thread.Sleep(100);
                    _inst.SetKey(flow[i], Color.Yellow);
                    Thread.Sleep(100);
                    _inst.SetKey(flow[i + 1], Color.Red);
                    Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            _inst.SetKeys(_blocks.NumberKeys, Color.FromRgb(BaseColor));

        }
    }
}