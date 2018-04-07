using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChromaExpVanilla.config;

namespace ChromaExpVanilla
{
    internal class Executor
    {
        private readonly KeyControl _control = new KeyControl();
        private readonly KeyBlocks _blocks = new KeyBlocks();
        public delegate void ChunkOfThingsToDo();

        public async void Execute()
        {
            var setColorsTask = _control.SetColorBase();
            await _control.Animation(_blocks.AnimationConcept);
            var check = new CheckState();
            setColorsTask.Wait();
            _control.InitiateCustom();
            StateHandler( check.States ).Invoke();

            while (true)
            {
                var thingsToDo = StateHandler(check.States);
                thingsToDo?.Invoke();
            }
        }

        public ChunkOfThingsToDo StateHandler(List<EventTypes> states)
        {
            ChunkOfThingsToDo thingsToDo = null;
            foreach (var state in states)
            {
                switch (state)
                {
                    case EventTypes.CapsOn:
                        thingsToDo += _control.CapsLockOn;
                        break;
                    case EventTypes.CapsOff:
                        thingsToDo += _control.CapsLockOff;
                        break;
                    case EventTypes.TimeRound:
                        thingsToDo += _control.TimeAnimation;
                        break;
                    case EventTypes.LangEng:
                        thingsToDo += _control.SetEng;
                        break;
                    case EventTypes.LangHeb:
                        thingsToDo += _control.SetHeb;
                        break;
                    case EventTypes.NumLkOn:
                        thingsToDo += _control.NumLockOn;
                        break;
                    case EventTypes.NumLkOff:
                        thingsToDo += _control.NumLockOff;
                        break;
                    case EventTypes.Normal:
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            return thingsToDo;
        }
    }
}