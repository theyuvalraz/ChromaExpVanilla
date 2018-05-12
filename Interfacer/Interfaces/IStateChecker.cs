using System;
using System.Threading.Tasks;

namespace Interfacer.Interfaces
{
    public interface IStateChecker
    {
        Task<Action> States(IKeyboardController control);
        IGetKeyboardLayout KeyboardLayout { get; set; }
    }
}