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
    public class KeyControl
    {
        internal static Color BaseColor = Color.FromRgb( GetCentralSettings.BaseColor);
        internal readonly StartAnimations Anim = new StartAnimations();
        internal readonly IKeyboard Inst = Keyboard.Instance;
        internal Custom CustomLayer { get; set; } = new Custom(BaseColor);


        public void InitiateCustom()
        {
            Inst.SetCustom(CustomLayer);
        }

        internal void SetCustom(IEnumerable<IColoredKey> coloredKeyList)
        {
            foreach (var colorKey in coloredKeyList)
                SetCustomKey(colorKey.Key, colorKey.Color);
        }

        internal void SetCustom(IEnumerable<IColoredKey> keyList, Color color)
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


        internal void Animation(IReadOnlyList<IColoredKey[]> keyBlocks)
        {
            Inst.Clear();
            for (var i = 0; i < keyBlocks.Count; i++)
            {
                Thread.Sleep(40 - i);
                if (keyBlocks.Count > i)
                    Inst.SetKeys(keyBlocks[i].Select(x => x.Key), Color.Red);
                Thread.Sleep(8);
                if (keyBlocks.Count > i - 1 && i - 1 >= 0)
                    Inst?.SetKeys(keyBlocks[i - 1].Select(x => x.Key), Color.Orange);
                Thread.Sleep(8);
                if (keyBlocks.Count > i - 2 && i - 2 >= 0)
                    Inst?.SetKeys(keyBlocks[i - 2].Select(x => x.Key), Color.Green);
                Thread.Sleep(8);
                if (keyBlocks.Count > i - 3 && i - 3 >= 0)
                    Inst?.SetKeys(keyBlocks[i - 3].Select(x => x.Key), Color.Yellow);
                Thread.Sleep(8);
                if (keyBlocks.Count > i - 4 && i - 4 >= 0)
                    Inst?.SetKeys(keyBlocks[i - 4].Select(x => x.Key), Color.White);
            }
        }


        internal void FrameAnimation(IReadOnlyList<IColoredKey[]> keyBlocks)
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

        internal void LangFrameAnimation(IReadOnlyList<IColoredKey[]> keyBlocks)
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

        internal void NotificationAnimation(Color color)
        {
            var tempCustom = CustomLayer.Clone();
            var flow = Anim.AllLetterKeys();
            for (var i = 0; i < flow.Length; i++)
                try
                {
                    Thread.Sleep(50);

                    Inst.SetKey(flow[i].Key, color);
                    Thread.Sleep(20);
                    if (flow.Length > i + 1) Inst.SetKey(flow[i + 1].Key, color);
                    if (flow.Length > i + 2) Inst.SetKey(flow[i + 2].Key, color);
                    if (flow.Length > i + 3) Inst.SetKey(flow[i + 3].Key, color);


                    CustomLayer = tempCustom;
                }
                catch (Exception)
                {
                    // ignored
                }

            InitiateCustom();
        }
    }
}