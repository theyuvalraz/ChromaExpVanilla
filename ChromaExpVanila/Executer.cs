using System;

namespace ChromaExpVanilla
{
    internal class Executor
    {
        private readonly KeyControl _control = new KeyControl();

        public delegate void ChunkOfThingsToDo();

        public void Execute()
        {
            ChunkOfThingsToDo thingsToDo = null;
            _control.ColorBase();
            var check = new CheckState();

            while (true)
            {
                var states = check.States();
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

                    thingsToDo?.Invoke();
                    thingsToDo = null;
                }
            }
        }

        private void LangEng()
        {
            _control.SetEng();
        }

        private void LangHeb()
        {
            _control.SetHeb();
        }

        private void CapsLockOn()
        {
            _control.CapsLockOn();
        }

        private void CapsLockOff()
        {
            _control.CapsLockOff();
        }

        private void NumLockOff()
        {
            _control.NumLockOff();
        }

        private void NumLockOn()
        {
            _control.NumLockOn();
        }

        private void TimeRound()
        {
            _control.TimeAnimation();
        }
    }
}