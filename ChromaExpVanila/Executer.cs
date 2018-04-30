using System;
using System.Collections.Generic;
using ChromaExpVanilla.config;

namespace ChromaExpVanilla
{
    public class Executor
    {

        public Action StateHandler(List<EventTypes> states, KeyControl control)
        {
            Action thingsToDo = null;
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