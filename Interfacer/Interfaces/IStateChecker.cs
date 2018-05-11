using System;
using Corale.Colore.Core;

namespace Interfacer.Interfaces
{
    public interface IStateChecker
    {
        Action States(IKeyboardController control);
    }
}