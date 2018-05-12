using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ChromaExpVanilla.config;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using Corale.Colore.Razer.Keyboard.Effects;
using Interfacer.Interfaces;

namespace ChromaExpVanilla
{
    public class KeyControl : IKeyboardController
    {
        private readonly KeyBlocks _blocks = new KeyBlocks();
        private readonly IKeyboard _inst = Keyboard.Instance;
        private const uint BaseColor = 0x202020;
        public Custom CustomLayer { get; set; } = new Custom(Color.FromRgb(BaseColor));
        private readonly object _threadLock = new object();


        public void InitiateCustom()
        {
            lock (_threadLock)
            {
                _inst.SetCustom(CustomLayer);
            }
        }

        public void InitiateCustom(Custom customLayer)
        {
            lock (_threadLock)
            {
                _inst.SetCustom(customLayer);
            }
        }

        public async Task SetColorBase()
        {
            await Task.Run(action: SetBase);
        }

        private void SetBase()
        {
            lock (_threadLock)
            {
                _inst.SetAll(BaseColor);
                SetCustom(_blocks.UsefulKeys);
                SetCustom(_blocks.MiscColoredKeys);
                SetCustom(_blocks.NumberKeys);

                SetCustom(_blocks.UsefulKeys);
                SetCustom(_blocks.UselessKeys);
            }
        }

        public void SetCustom(List<IColoredKey> coloredKeyList)
        {
            lock (_threadLock)
            {
                foreach (var colorKey in coloredKeyList)
                {
                    SetCustomKey(colorKey.Key, colorKey.Color);
                }
            }
        }

        public void SetCustom(List<IColoredKey> keyList, Color color)
        {
            lock (_threadLock)
            {
                foreach (var keySetting in keyList)
                {
                    SetCustomKey(keySetting.Key, color);
                    keySetting.Color = color;
                }
            }
        }

        public void SetCustomKey(Key key, Color color)
        {
            lock (_threadLock)
            {
                var customLayer = CustomLayer;
                customLayer[key] = color;
            }
        }

        public void CurrentStateNeeded()
        {
            lock (_threadLock)
            {
                SetColorBase().RunSynchronously();
            }
        }

        public void SetEng()
        {
            lock (_threadLock)
            {
                LangFrameAnimation(_blocks.EngAnimation);
            }
        }

        public void SetHeb()
        {
            lock (_threadLock)
            {
                LangFrameAnimation(_blocks.HebAnimation);
            }
        }


        public void TopNumChange(Color color)
        {
            lock (_threadLock)
            {
                _inst.SetKeys(new List<Key>(_blocks.NumberKeys.Select(x => x.Key).ToList()), color);
                SetCustom(_blocks.NumberKeys, color);
            }
        }

        public void NumLockOn()
        {
            lock (_threadLock)
            {
                _inst.SetKeys(new List<Key>(_blocks.Numpad.Select(x => x.Key).ToList()), Color.FromRgb(0x47E10C));
            }
        }

        public void NumLockOff()
        {
            lock (_threadLock)
            {
                Thread.Sleep(10);
                foreach (var coloredKey in _blocks.AltNumPad)
                {
                    _inst.SetKey(coloredKey.Key, coloredKey.Color);
                }

                SetCustom(_blocks.AltNumPad);
                Thread.Sleep(10);
            }
        }


        public void CapsLockOn()
        {
            lock (_threadLock)
            {
                _inst.SetKeys(new List<Key>(_blocks.CapsLk.Select(x => x.Key).ToList()), Color.Red);
                SetCustom(_blocks.CapsLk, Color.Red);
            }
        }

        public void CapsLockOff()
        {
            lock (_threadLock)
            {
                _inst.SetKeys(new List<Key>(_blocks.CapsLk.Select(x => x.Key).ToList()), Color.FromRgb(BaseColor));
                SetCustom(_blocks.CapsLk, Color.FromRgb(BaseColor));
            }
        }

        public void Animation(List<List<IColoredKey>> keyBlocks)
        {
            lock (_threadLock)
            {
                _inst.Clear();
                if (keyBlocks != null)
                    for (var i = 0; i < keyBlocks.Count; i++)
                    {
                        Thread.Sleep(40 - i);
                        if (keyBlocks.Count > i)
                            _inst.SetKeys(new List<Key>(keyBlocks[i].Select(x => x.Key).ToList()), Color.Red);
                        Thread.Sleep(8);
                        if (keyBlocks.Count > i - 1 && i - 1 >= 0)
                            _inst?.SetKeys(new List<Key>(keyBlocks[i - 1].Select(x => x.Key).ToList()), Color.Orange);
                        Thread.Sleep(8);
                        if (keyBlocks.Count > i - 2 && i - 2 >= 0)
                            _inst?.SetKeys(new List<Key>(keyBlocks[i - 2].Select(x => x.Key).ToList()), Color.Green);
                        Thread.Sleep(8);
                        if (keyBlocks.Count > i - 3 && i - 3 >= 0)
                            _inst?.SetKeys(new List<Key>(keyBlocks[i - 3].Select(x => x.Key).ToList()), Color.Yellow);
                        Thread.Sleep(8);
                        if (keyBlocks.Count > i - 4 && i - 4 >= 0)
                            _inst?.SetKeys(new List<Key>(keyBlocks[i - 4].Select(x => x.Key).ToList()), Color.White);
                    }
            }
        }

        public void FrameAnimation(List<List<IColoredKey>> keyBlocks)
        {
            lock (_threadLock)
            {
                if (keyBlocks != null)
                    for (var i = 0; i < keyBlocks.Count; i++)
                    {
                        Thread.Sleep(100);
                        if (keyBlocks.Count > i)
                            SetCustom(keyBlocks[i]);
                        InitiateCustom();
                        Thread.Sleep(10);
                    }
            }
        }

        public void LangFrameAnimation(List<List<IColoredKey>> keyBlocks)
        {
            lock (_threadLock)
            {
                if (keyBlocks == null) return;
                for (var i = 0; i < keyBlocks.Count; i++)
                {
                    Thread.Sleep(20);
                    if (keyBlocks.Count > i)
                        SetCustom(keyBlocks[i]);
                    InitiateCustom();
                    Thread.Sleep(10);
                }
            }
        }

        public void TimeAnimation()
        {
            lock (_threadLock)
            {
                for (var i = 0; i < 3; i++)
                {
                    NotificationAnimation(Color.Pink);
                }
            }
        }

        //public void UserChangeAnimation()
        //{
        //    NotificationAnimation(Color.Pink);
        //}

        public void NotificationAnimation(Color color)
        {
            lock (_threadLock)
            {
                var tempCustom = CustomLayer.Clone();
                var flow = _blocks.AllLetterKeys;
                for (var i = 0; i < flow.Count; i++)
                {
                    try
                    {
                        Thread.Sleep(50);
                        if (_inst != null)
                        {
                            _inst.SetKey(flow[i].Key, color);
                            Thread.Sleep(20);
                            if (flow.Count > i + 1) _inst.SetKey(flow[i + 1].Key, color);
                            if (flow.Count > i + 2) _inst.SetKey(flow[i + 2].Key, color);
                            if (flow.Count > i + 3) _inst.SetKey(flow[i + 3].Key, color);
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

        public void ConstantAnimation()
        {
            lock (_threadLock)
            {
                var tempCustom = CustomLayer.Clone();
                for (var j = 0; j < Constants.MaxColumns; j++)
                {
                    for (var i = 0; i < Constants.MaxRows; i++)
                    {
                        try
                        {
                            Thread.Sleep(10);
                            _inst[i, j] = Color.Green;
                            InitiateCustom();
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }

                    for (var i = 0; i < Constants.MaxRows; i++)
                    {
                        try
                        {
                            Thread.Sleep(50);
                            _inst[i, j] = Color.Black;
                            InitiateCustom();
                        }
                        catch (Exception)
                        {
                            // ignored
                        }
                    }
                }

                SetBase();
                InitiateCustom(tempCustom);
            }
        }
    }
}