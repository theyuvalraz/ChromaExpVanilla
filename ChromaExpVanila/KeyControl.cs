using System;
using System.Collections.Generic;
using System.Linq;
using ChromaExpVanila.config;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using Corale.Colore.Razer;

namespace ChromaExpVanila
{

    public class KeyControl
    {

        KeyBlocks blocks = new KeyBlocks();
        IKeyboard inst = Keyboard.Instance;

        private uint BaseColor = 0x202020;
        public void ColorBase()
        {
            inst.Clear();
            Animation(blocks.AllLetterKeys);
            

            inst.SetAll(Color.FromRgb(BaseColor));
            System.Threading.Thread.Sleep(100);
            inst.SetKey(Key.Macro1, Color.Orange);
            System.Threading.Thread.Sleep(100);
            inst.SetKey(Key.Macro2, Color.Blue);
            System.Threading.Thread.Sleep(100);
            inst.SetKey(Key.Macro3, Color.Orange);
            System.Threading.Thread.Sleep(100);
            inst.SetKey(Key.Macro4, Color.Black);
            System.Threading.Thread.Sleep(100);
            inst.SetKey(Key.Macro5, Color.White);
            System.Threading.Thread.Sleep(100);
            inst.SetKey(Key.F3, Color.White);
            System.Threading.Thread.Sleep(100);
            inst.SetKey(Key.PrintScreen, Color.Blue);
            System.Threading.Thread.Sleep(100);
            inst.SetKey(Key.Scroll, Color.Red);
            System.Threading.Thread.Sleep(100);

            inst.SetKeys(blocks.UsefullKeys, Color.Pink);
            inst.SetKeys(blocks.UselessKeys, Color.Black);
            System.Threading.Thread.Sleep(100);
        }


        public void SetEng()
        {
            System.Threading.Thread.Sleep(100);
            inst.SetKeys(blocks.AllLetterKeys, Color.FromRgb(BaseColor));
            inst.SetKeys(blocks.EngKeys, Color.Green);
        }
        public void SetHeb()
        {
            System.Threading.Thread.Sleep(100);
            inst.SetKeys(blocks.AllLetterKeys, Color.FromRgb(BaseColor));
            inst.SetKeys(blocks.HebKeys, Color.Red);
        }

        public void PreSetLeng()
        {
            System.Threading.Thread.Sleep(100);
            inst.SetKeys(blocks.AllLetterKeys, Color.FromRgb(BaseColor));
        }

        public void TopNumChange(Color color)
        {
            inst.SetKeys(blocks.numberKeys, color);
            System.Threading.Thread.Sleep(100);
        }

        public void NumLockOn()
        {
            inst.SetKeys(blocks.Numpad, Color.Green);
            System.Threading.Thread.Sleep(100);
            TopNumChange(Color.FromRgb(BaseColor));

        }
        public void NumLockOff()
        {
            inst.SetKeys(blocks.Numpad, Color.FromRgb(BaseColor));
            System.Threading.Thread.Sleep(100);
            TopNumChange(Color.Green);

        }

        public void CapsLockOn()
        {
            inst.SetKeys(blocks.Caps_lk, Color.Yellow);
            System.Threading.Thread.Sleep(100);
        }
        public void CapsLockOff()
        {
            inst.SetKeys(blocks.Caps_lk, Color.FromRgb(BaseColor));
            System.Threading.Thread.Sleep(100);
        }

        public void Animation(IEnumerable<Key> keyBlocks)
        {
            
            List<Key> flow = keyBlocks.ToList();
            inst.Clear();
            for (int i = 0; i < keyBlocks.Count(); i++)
            {
                try
                {
                    System.Threading.Thread.Sleep(100);
                    inst.SetKey(flow[i + 1], Color.Red);
                    System.Threading.Thread.Sleep(10);
                    inst.SetKey(flow[i], Color.Yellow);
                    System.Threading.Thread.Sleep(10);
                    inst.SetKey(flow[i + 1], Color.Red);
                    System.Threading.Thread.Sleep(10);
                    inst.SetKey(flow[i + 2], Color.Blue);
                    System.Threading.Thread.Sleep(10);
                    inst.SetKey(flow[i + 3], Color.Green);
                    System.Threading.Thread.Sleep(10);
                    inst.SetKey(flow[i + 4], Color.Purple);
                    System.Threading.Thread.Sleep(10);
                    inst.SetKey(flow[i], Color.FromRgb(0x505050));
                    inst.SetKey(flow[i + 1], Color.FromRgb(0x404040));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

            }
        }
        
        public void Animation2(IEnumerable<Key> keyBlocks)
        {
            List<Key> flow = keyBlocks.ToList();
            for (int i = 0; i < keyBlocks.Count(); i++)
            {
                try
                {
                    System.Threading.Thread.Sleep(100);
                    inst.SetKey(flow[i + 1], Color.Yellow);
                    System.Threading.Thread.Sleep(30);
                    inst.SetKey(flow[i], Color.Yellow);
                    System.Threading.Thread.Sleep(30);
                    inst.SetKeys(keyBlocks, Color.FromRgb(0x404040));
                    inst.SetKeys(keyBlocks, Color.FromRgb(0x505050));
                    System.Threading.Thread.Sleep(100);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
