using System;
using System.Collections.Generic;
using ChromaExpVanilla.config;

namespace ChromaExpVanilla
{
    public class Executor
    {
        //private readonly KeyControl _control = new KeyControl();
        //private readonly KeyBlocks _blocks = new KeyBlocks();
        //public CheckState checkState = new CheckState();

        //public async void Execute()
        //{
        //    var setColorsTask = _control.SetColorBase();
        //    await _control.Animation(_blocks.AnimationConcept);
        //    setColorsTask.Wait();
        //    _control.InitiateCustom();
        //    StateHandler(checkState.States, _control).Invoke();

        //    GetEventsLoop(checkState);
        //}

        //public Action GetEvents( CheckState check )
        //{
        //    var thingsToDo = StateHandler( check.States, _control );
        //    return thingsToDo;
        //}

        //public void GetEventsLoop( CheckState check )
        //{
        //    while (true)
        //    {
        //        GetEvents( check );
        //    }
        //}

        //public void GetEventsOnce(CheckState check)
        //{
        //    var thingsToDo = StateHandler( check.States, _control );
        //    thingsToDo?.Invoke();
        //}

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
                    //case EventTypes.TimeRound:
                    //    thingsToDo += control.TimeAnimation;
                    //    checkState.CurrentStateNeeded = true;
                    //    break;
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
                    //case EventTypes.UserChange:
                    //    thingsToDo += control.UserChangeAnimation;
                    //    checkState.CurrentStateNeeded = true;
                    //    break;
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