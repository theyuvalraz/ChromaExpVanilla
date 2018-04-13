using System;
using System.Collections.Generic;
using ChromaExpVanila.config;

namespace ChromaExpVanila
{
    public class Executor
    {
        private readonly KeyControl _control = new KeyControl();
        private readonly KeyBlocks _blocks = new KeyBlocks();
        public CheckState checkState = new CheckState();

        public delegate void ChunkOfThingsToDo();

        public async void Execute()
        {
            var setColorsTask = _control.SetColorBase();
            await _control.Animation(_blocks.AnimationConcept);
            setColorsTask.Wait();
            _control.InitiateCustom();
            StateHandler(checkState.States, _control).Invoke();

            GetEventsLoop(checkState);
        }

        public void GetEventsLoop(CheckState check)
        {
            while (true)
            {
                var thingsToDo = StateHandler(check.States, _control);
                thingsToDo?.Invoke();
            }
        }

        public ChunkOfThingsToDo StateHandler(List<EventTypes> states, KeyControl control)
        {
            ChunkOfThingsToDo thingsToDo = null;
            foreach (var state in states)
            {
                switch (state)
                {
                    case EventTypes.CapsOn:
                        thingsToDo += control.CapsLockOn;
                        break;
                    case EventTypes.CapsOff:
                        thingsToDo += control.CapsLockOff;
                        break;
                    case EventTypes.TimeRound:
                        thingsToDo += control.TimeAnimation;
                        checkState.CurrentStateNeeded = true;
                        break;
                    case EventTypes.LangEng:
                        thingsToDo += control.SetEng;
                        break;
                    case EventTypes.LangHeb:
                        thingsToDo += control.SetHeb;
                        break;
                    case EventTypes.NumLkOn:
                        thingsToDo += control.NumLockOn;
                        break;
                    case EventTypes.NumLkOff:
                        thingsToDo += control.NumLockOff;
                        break;
                    case EventTypes.CurrentStateNeeded:
                        thingsToDo += control.CurrentStateNeeded;
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