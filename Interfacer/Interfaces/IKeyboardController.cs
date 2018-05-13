using System.Collections.Generic;
using System.Threading.Tasks;
using Corale.Colore.Razer.Keyboard.Effects;

namespace Interfacer.Interfaces
{
    public interface IKeyboardController
    {
        void CapsLockOn();
        void CapsLockOff();
        void NumLockOn();
        void NumLockOff();
        void SetEng();
        void SetHeb();
        void Animation(List<List<IColoredKey>> keyBlocks);
        void FrameAnimation(List<List<IColoredKey>> blocksAnimationConceptStage2);
        Custom CustomLayer { get; set; }
        Task SetColorBase();
        void InitiateCustom();
        void TimeAnimation();
        void FirstAnimation();
        void SetBase();
        void SecondAnimation();
    }
}