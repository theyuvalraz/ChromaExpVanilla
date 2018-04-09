using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ChromaExpVanilla.config;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using Corale.Colore.Razer.Keyboard.Effects;

namespace ChromaExpVanilla
{
    public class KeyControl
    {
        private readonly KeyBlocks _blocks = new KeyBlocks();
        private readonly IKeyboard _inst = Keyboard.Instance;
        private const uint BaseColor = 0x404040;
        public Custom CustomLayer = new Custom( Color.FromRgb( BaseColor ) );

        public void InitiateCustom()
        {
            _inst.SetCustom(CustomLayer);
        }

        public async Task SetColorBase()
        {
            await Task.Run( action: Action);

        }

        private void Action()
        {
            SetCustom( _blocks.MiscKeysToColor );
            SetCustom( _blocks.UsefulKeys, Color.Pink );
            SetCustom( _blocks.UselessKeys, Color.Black );
        }

        public void SetCustom( List<Tuple<Key, Color>> coloredKeyList)
        {

            foreach (var colorKey in coloredKeyList)
            {
                CustomLayer[colorKey.Item1] = colorKey.Item2;
            }
        }
        public void SetCustom( List<Key> keyList, Color color )
        {
            foreach (var keySetting in keyList)
            {
                CustomLayer[keySetting] = color;
            }
        }

        public void SetEng()
        {
            _inst.SetKeys(_blocks.AllLetterKeys, Color.FromRgb(BaseColor));
            SetCustom( _blocks.AllLetterKeys, Color.FromRgb( BaseColor ) );
            _inst.SetKeys(_blocks.EngKeys, Color.Green);
            SetCustom( _blocks.EngKeys, Color.Green );
            _inst.SetKeys(_blocks.EngKeysOther, Color.Orange);
            SetCustom(_blocks.EngKeysOther, Color.Orange);

        }

        public void SetHeb()
        {
            //Console.WriteLine( "SetHeb" );

            _inst.SetKeys(_blocks.AllLetterKeys, Color.FromRgb(BaseColor));
            SetCustom( _blocks.AllLetterKeys, Color.FromRgb( BaseColor ) );
            _inst.SetKeys(_blocks.HebKeys, Color.Red);
            SetCustom( _blocks.HebKeys, Color.Red);
            _inst.SetKeys(_blocks.HebKeysOther, Color.Orange);
            SetCustom(_blocks.HebKeysOther, Color.Orange);
        }

        public void TopNumChange(Color color)
        {
            _inst.SetKeys(_blocks.NumberKeys, color);
            SetCustom( _blocks.NumberKeys, color );
        }

        public void NumLockOn()
        {
            _inst.SetKeys(_blocks.Numpad, Color.Green);
            TopNumChange(Color.FromRgb(0x00008B));
        }

        public void NumLockOff()
        {
            Thread.Sleep(10);
            _inst.SetKeys(_blocks.AltNumPad1, Color.Orange);
            SetCustom( _blocks.AltNumPad1, Color.Orange );
            Thread.Sleep(10);
            _inst.SetKeys(_blocks.AltNumPad2, Color.Purple);
            SetCustom( _blocks.AltNumPad2, Color.Purple );
            Thread.Sleep(10);
            _inst.SetKeys(_blocks.AltNumPad3, Color.Black);
            SetCustom( _blocks.AltNumPad3, Color.Black );
            Thread.Sleep(10);
            TopNumChange(Color.Green);
        }

        public void CapsLockOn()
        {
            _inst.SetKeys(_blocks.CapsLk, Color.Red);
            SetCustom( _blocks.CapsLk, Color.Red);
        }

        public void CapsLockOff()
        {
            _inst.SetKeys(_blocks.CapsLk, Color.FromRgb(BaseColor));
            SetCustom( _blocks.CapsLk , Color.FromRgb( BaseColor ));
        }

        public Task Animation(List<List<Key>> keyBlocks)
        {
            _inst.Clear();
            if (keyBlocks != null)
                for (var i = 0; i < keyBlocks.Count(); i++)
                {
                    try
                    {
                        Thread.Sleep(100);
                        if (keyBlocks.Count > i) _inst.SetKeys(keyBlocks[i], Color.Red);
                        Thread.Sleep(10);
                        if (keyBlocks.Count > i - 1) _inst?.SetKeys(keyBlocks[i - 1], Color.Orange);
                        Thread.Sleep(10);
                        if (keyBlocks.Count > i - 2) _inst?.SetKeys(keyBlocks[i - 2], Color.Green);
                        Thread.Sleep(10);
                        if (keyBlocks.Count > i - 3) _inst?.SetKeys(keyBlocks[i - 3], Color.Yellow);
                        Thread.Sleep(10);
                        if (keyBlocks.Count > i - 4) _inst?.SetKeys(keyBlocks[i - 4], Color.FromRgb(BaseColor));
                        Thread.Sleep(10);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            return Task.CompletedTask;
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
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public void TimeAnimation()
        {
            var tempCustom = CustomLayer.Clone();
            var flow = _blocks.NumberKeys;
            for (var i = 0; i < _blocks.NumberKeys.Count(); i++)
            {
                try
                {
                    Thread.Sleep(50);
                    if (_inst != null)
                    {
                        _inst.SetKey(flow[i], Color.Red);
                        Thread.Sleep(50);
                        if (flow.Count > i + 1) _inst.SetKey(flow[i + 1], Color.Yellow);
                        if (flow.Count > i + 2) _inst.SetKey(flow[i + 1], Color.Red);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            CustomLayer = tempCustom;
            InitiateCustom();
        }
    }
}