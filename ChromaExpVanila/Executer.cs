using System;
using System.Collections.Generic;

namespace ChromaExpVanilla
{
    internal class Executor
    {
        private readonly KeyControl _control = new KeyControl();

        public delegate void ChunkOfThingsToDo();

        public void Execute()
        {
            _control.ColorBase();
            var check = new CheckState();
            StateHandler(check.States).Invoke();

            while (true)
            {
                var thingsToDo = StateHandler(check.States);
                thingsToDo?.Invoke();
            }
        }

        private void LangEng() => _control.SetEng();

        private void LangHeb() => _control.SetHeb();

        private void CapsLockOn() => _control.CapsLockOn();

        private void CapsLockOff() => _control.CapsLockOff();

        private void NumLockOff() => _control.NumLockOff();

        private void NumLockOn() => _control.NumLockOn();

        private void TimeRound() => _control.TimeAnimation();

        public ChunkOfThingsToDo StateHandler(List<EventTypes> states)
        {
            ChunkOfThingsToDo thingsToDo = null;
            foreach (var state in states)
            {
                switch (state)
                {
                    case EventTypes.CapsOn:
                        thingsToDo += CapsLockOn;
                        break;
                    case EventTypes.CapsOff:
                        thingsToDo += CapsLockOff;
                        break;
                    case EventTypes.TimeRound:
                        thingsToDo += TimeRound;
                        break;
                    case EventTypes.LangEng:
                        thingsToDo += LangEng;
                        break;
                    case EventTypes.LangHeb:
                        thingsToDo += LangHeb;
                        break;
                    case EventTypes.NumLkOn:
                        thingsToDo += NumLockOn;
                        break;
                    case EventTypes.NumLkOff:
                        thingsToDo += NumLockOff;
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