using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ChromaExpVanila.config;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using Corale.Colore.Razer.Keyboard.Effects;

namespace ChromaExpVanila
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
            SetCustom(_blocks.usefulKeys );
            SetCustom( _blocks.MiscColoredKeys );
            SetCustom( _blocks.usefulKeys, Color.Pink );
            SetCustom( _blocks.UselessKeys, Color.Black );
        }

        public void SetCustom( List<ColoredKey> coloredKeyList )
        {
            foreach (var colorKey in coloredKeyList)
            {
                SetCustomKey(colorKey.Key, colorKey.Color);
            }
        }

        public void SetCustom( List<ColoredKey> keyList, Color color )
        {
            foreach (var keySetting in keyList)
            {
                SetCustomKey(keySetting.Key, color);
                keySetting.Color = color;
            }
        }

        public void SetCustomKey(Key key, Color color)
        {
            CustomLayer[key] = color;
        }

        public void CurrentStateNeeded()
        {
            SetColorBase().RunSynchronously();
        }

        public void SetEng()
        {
            _inst.SetKeys( new List<Key>( _blocks.AllLetterKeys.Select( x => x.Key ).ToList() ), Color.FromRgb( BaseColor ) );
            SetCustom( _blocks.AllLetterKeys, Color.FromRgb( BaseColor ) );
            _inst.SetKeys( new List<Key>( _blocks.EngKeys.Select( x => x.Key ).ToList() ), Color.Green );
            SetCustom( _blocks.HebKeys, Color.Green );
            _inst.SetKeys( new List<Key>( _blocks.EngKeysOther.Select( x => x.Key ).ToList() ), Color.Orange );
            SetCustom( _blocks.HebKeysOther, Color.Orange );
        }

        public void SetHeb()
        {
            //Console.WriteLine( "SetHeb" );
            _inst.SetKeys( new List<Key>( _blocks.AllLetterKeys.Select( x => x.Key ).ToList() ), Color.FromRgb( BaseColor));
            SetCustom( _blocks.AllLetterKeys, Color.FromRgb( BaseColor ) );
            _inst.SetKeys( new List<Key>( _blocks.HebKeys.Select( x => x.Key ).ToList() ), Color.Red);
            SetCustom( _blocks.HebKeys, Color.Red);
            _inst.SetKeys( new List<Key>( _blocks.HebKeysOther.Select( x => x.Key ).ToList() ), Color.Orange);
            SetCustom(_blocks.HebKeysOther, Color.Orange);
        }

        public void TopNumChange(Color color)
        {
            _inst.SetKeys( new List<Key>( _blocks.NumberKeys.Select( x => x.Key ).ToList() ),  color );
            SetCustom( _blocks.NumberKeys, color );
        }

        public void NumLockOn()
        {
            _inst.SetKeys( new List<Key>( _blocks.Numpad.Select( x => x.Key ).ToList() ),Color.Green );
            TopNumChange(Color.FromRgb(0x00008B));
        }

        public void NumLockOff()
        {
            Thread.Sleep(10);
            foreach (ColoredKey coloredKey in _blocks.AltNumPad)
            {
                _inst.SetKey(coloredKey.Key,coloredKey.Color);
            }
            SetCustom( _blocks.AltNumPad);
            Thread.Sleep(10);
            TopNumChange(Color.Green);
        }

        public void CapsLockOn()
        {
            _inst.SetKeys( new List<Key>( _blocks.CapsLk.Select( x => x.Key ).ToList() ),  Color.Red );
            SetCustom( _blocks.CapsLk, Color.Red);
        }

        public void CapsLockOff()
        {
            _inst.SetKeys(new List<Key>(_blocks.CapsLk.Select(x => x.Key).ToList()), Color.FromRgb(BaseColor));
            SetCustom( _blocks.CapsLk , Color.FromRgb( BaseColor ));
        }

        public Task Animation(List<List<ColoredKey>> keyBlocks)
        {
            _inst.Clear();
            if (keyBlocks != null)
                for (var i = 0; i < keyBlocks.Count(); i++)
                {
                    try
                    {
                        Thread.Sleep(100);
                        if (keyBlocks.Count > i) _inst.SetKeys( new List<Key>( keyBlocks[i].Select( x => x.Key ).ToList() ),Color.Red );
                        Thread.Sleep(10);
                        if (keyBlocks.Count > i - 1) _inst?.SetKeys( new List<Key>( keyBlocks[i - 1].Select( x => x.Key ).ToList() ),  Color.Orange );
                        Thread.Sleep(10);
                        if (keyBlocks.Count > i - 2) _inst?.SetKeys( new List<Key>( keyBlocks[i - 2].Select( x => x.Key ).ToList() ),  Color.Green );
                        Thread.Sleep( 10 );
                        if (keyBlocks.Count > i - 3) _inst?.SetKeys( new List<Key>( keyBlocks[i - 3].Select( x => x.Key ).ToList() ),  Color.Yellow );
                        Thread.Sleep(10);
                        if (keyBlocks.Count > i - 4) _inst?.SetKeys( new List<Key>( keyBlocks[i - 4].Select( x => x.Key ).ToList() ), Color.FromRgb( BaseColor ) );
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
                        _inst.SetKey(flow[i].Key, Color.Red);
                        Thread.Sleep(50);
                        if (flow.Count > i + 1) _inst.SetKey(flow[i + 1].Key, Color.Yellow);
                        if (flow.Count > i + 2) _inst.SetKey(flow[i + 1].Key, Color.Red);
                    }
                    CustomLayer = tempCustom;

                }
                catch (Exception)
                {
                    // ignored
                }
            }
            InitiateCustom();
        }
    }
}