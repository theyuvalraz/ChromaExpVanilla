using System;
using System.Threading.Tasks;
using Corale.Colore.Core;

namespace Interfacer.Interfaces
{
    public interface IStateChecker
    {
        Task<Action> States(IKeyboardController control);
        IGetKeyboardLayout KeyboardLayout { get; set; }
    }
}