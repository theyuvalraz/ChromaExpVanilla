using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;
using ChromaExpVanilla.config;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using Corale.Colore.Razer.Keyboard.Effects;
using Interfacer.Interfaces;

namespace ChromaExpVanilla
{
    [Synchronization]
    public sealed class KeyControl : IKeyboardController
    {
        private const uint BaseColor = 0x202020;
        private readonly KeyBlocks _blocks = new KeyBlocks();
        private readonly IKeyboard _inst = Keyboard.Instance;
        private Custom CustomLayer { get; set; } = new Custom(Color.FromRgb(BaseColor));

        public void InitiateCustom()
        {
            _inst.SetCustom(CustomLayer);
        }

        public void ClearCustom()
        {
            _inst.Clear();
        }

        public void SetBase()
        {
            _inst.SetAll(BaseColor);
            SetCustom(_blocks.UsefulKeys);
            SetCustom(_blocks.MiscColoredKeys);
            SetCustom(_blocks.NumberKeys);

            SetCustom(_blocks.UsefulKeys);
            SetCustom(_blocks.UselessKeys);
        }

        public void SetEng()
        {
            LangFrameAnimation(_blocks.EngAnimation);
        }

        public void SetHeb()
        {
            LangFrameAnimation(_blocks.HebAnimation);
        }

        public void NumLockOn()
        {
            _inst.SetKeys(new List<Key>(_blocks.Numpad.Select(x => x.Key).ToList()), Color.FromRgb(0x47E10C));
            SetCustom(_blocks.Numpad, Color.FromRgb(0x47E10C));
        }

        public void NumLockOff()
        {
            Thread.Sleep(10);
            foreach (var coloredKey in _blocks.AltNumPad)
                _inst.SetKey(coloredKey.Key, coloredKey.Color);

            SetCustom(_blocks.AltNumPad);
            Thread.Sleep(10);
        }

        public void CapsLockOn()
        {
            _inst.SetKeys(new List<Key>(_blocks.CapsLk.Select(x => x.Key).ToList()), Color.Red);
            SetCustom(_blocks.CapsLk, Color.Red);
        }

        public void CapsLockOff()
        {
            _inst.SetKeys(new List<Key>(_blocks.CapsLk.Select(x => x.Key).ToList()), Color.FromRgb(BaseColor));
            SetCustom(_blocks.CapsLk, Color.FromRgb(BaseColor));
        }

        public void FirstAnimation()
        {
            Animation(_blocks.AnimationConcept);
        }

        public void SecondAnimation()
        {
            FrameAnimation(_blocks.AnimationConceptStage2);
        }

        public void TimeAnimation()
        {
            for (var i = 0; i < 3; i++)
                NotificationAnimation(Color.Pink);
        }

        private void SetCustom(IEnumerable<IColoredKey> coloredKeyList)
        {
            foreach (var colorKey in coloredKeyList)
                SetCustomKey(colorKey.Key, colorKey.Color);
        }

        private void SetCustom(IEnumerable<IColoredKey> keyList, Color color)
        {
            foreach (var keySetting in keyList)
            {
                SetCustomKey(keySetting.Key, color);
                keySetting.Color = color;
            }
        }

        private void SetCustomKey(Key key, Color color)
        {
            var customLayer = CustomLayer;
            customLayer[key] = color;
            CustomLayer = customLayer;
        }


        private void Animation(IReadOnlyList<List<IColoredKey>> keyBlocks)
        {
            _inst.Clear();
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


        private void FrameAnimation(IReadOnlyList<List<IColoredKey>> keyBlocks)
        {
            for (var i = 0; i < keyBlocks.Count; i++)
            {
                Thread.Sleep(100);
                if (keyBlocks.Count > i)
                    SetCustom(keyBlocks[i]);
                InitiateCustom();
                Thread.Sleep(10);
            }
        }

        private void LangFrameAnimation(IReadOnlyList<List<IColoredKey>> keyBlocks)
        {
            for (var i = 0; i < keyBlocks.Count; i++)
            {
                Thread.Sleep(20);
                if (keyBlocks.Count > i)
                    SetCustom(keyBlocks[i]);
                InitiateCustom();
                Thread.Sleep(10);
            }
        }

        private void NotificationAnimation(Color color)
        {
            var tempCustom = CustomLayer.Clone();
            var flow = _blocks.AllLetterKeys;
            for (var i = 0; i < flow.Count; i++)
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

            InitiateCustom();
        }

        //public void ConstantAnimation()
        //{
        //    var tempCustom = CustomLayer.Clone();
        //    for (var j = 0; j < Constants.MaxColumns; j++)
        //    {
        //        for (var i = 0; i < Constants.MaxRows; i++)
        //        {
        //            try
        //            {
        //                Thread.Sleep(10);
        //                _inst[i, j] = Color.Green;
        //                InitiateCustom();
        //            }
        //            catch (Exception)
        //            {
        //                // ignored
        //            }
        //        }

        //        for (var i = 0; i < Constants.MaxRows; i++)
        //        {
        //            try
        //            {
        //                Thread.Sleep(50);
        //                _inst[i, j] = Color.Black;
        //                InitiateCustom();
        //            }
        //            catch (Exception)
        //            {
        //                // ignored
        //            }
        //        }
        //    }

        //    SetBase();
        //    InitiateCustom(tempCustom);
        //}
    }
}