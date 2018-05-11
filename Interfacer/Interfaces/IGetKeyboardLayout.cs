using System.Globalization;

namespace Interfacer.Interfaces
{
    public interface IGetKeyboardLayout
    {
        CultureInfo GetCurrentKeyboardLayout();
    }
}