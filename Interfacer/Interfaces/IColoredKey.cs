using Corale.Colore.Core;
using Corale.Colore.Razer.Keyboard;

namespace Interfacer.Interfaces
{
    public interface IColoredKey
    {
        Key Key { get; set; }
        Color Color { get; set; }
        int Group { get; set; }
    }
}