using System;
using System.Threading.Tasks;

namespace Interfacer.Interfaces
{
    public interface IStateChecker
    {
        Task<Action> States();
        IGetKeyboardLayout KeyboardLayout { get; set; }
        bool CurrentStateNeeded { get; set; } 
        bool FirstAnimationNeeded { get; set; }
        bool SecondAnimationNeeded { get; set; }
        bool BaseNeeded { get; set; }
        bool ClearNeeded { get; set; }
        bool TimeAnimationNeeded { get; set; }
        IKeyboardController Control { get; set; }
    }
}