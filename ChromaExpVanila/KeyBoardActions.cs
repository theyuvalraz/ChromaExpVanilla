using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ChromaExpVanilla.config;
using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;
using Interfacer.Interfaces;

namespace ChromaExpVanilla
{
    internal class KeyboardActions : KeyControl, IKeyboardController
    {
        public void ClearCustom()
        {
            Inst.Clear();
        }

        public void SetBase()
        {
            Inst.SetAll(BaseColor);
            SetCustom(Anim.UsefulKeys());
            SetCustom(KeyBlocks.MiscColoredKeys);
            SetCustom(KeyBlocks.NumberKeys);

            SetCustom(Anim.UsefulKeys());
            SetCustom(Anim.UselessKeys());
        }

        public void SetEng()
        {
            LangFrameAnimation(KeyBlocks.EngAnimation);
        }

        public void SetHeb()
        {
            LangFrameAnimation(KeyBlocks.HebAnimation);
        }

        public void NumLockOn()
        {
            Inst.SetKeys(new List<Key>(KeyBlocks.Numpad.Select(x => x.Key).ToList()),
                Color.FromRgb(GetCentralSettings.NumpadNormalColor));
            SetCustom(KeyBlocks.Numpad, Color.FromRgb(GetCentralSettings.NumpadNormalColor));
        }

        public void NumLockOff()
        {
            Thread.Sleep(10);
            foreach (var coloredKey in KeyBlocks.AltNumPad)
                Inst.SetKey(coloredKey.Key, coloredKey.Color);

            SetCustom(KeyBlocks.AltNumPad);
            Thread.Sleep(10);
        }

        public void CapsLockOn()
        {
            Inst.SetKeys(new List<Key>(KeyBlocks.CapsLk.Select(x => x.Key).ToList()), Color.Red);
            SetCustom(KeyBlocks.CapsLk, Color.Red);
        }

        public void CapsLockOff()
        {
            Inst.SetKeys(new List<Key>(KeyBlocks.CapsLk.Select(x => x.Key).ToList()), BaseColor);
            SetCustom(KeyBlocks.CapsLk, BaseColor);
        }

        public void FirstAnimation()
        {
            Animation(Anim.AnimationConcept());
        }

        public void SecondAnimation()
        {
            FrameAnimation(Anim.AnimationConceptStage2());
        }

        public void TimeAnimation()
        {
            for (var i = 0; i < 3; i++)
                NotificationAnimation(Color.Pink);
        }
    }
}