using System.Configuration;
using Corale.Colore.Razer.Keyboard;
using TrayApp.Properties;

namespace TrayApp
{
    class UserSettings : ApplicationSettingsBase
    {
        public Key TKey = Settings.Default.F10;

        public void changeTo8()
        {
            Settings.Default.F10 = Key.F8;
            Settings.Default.Save();
        }
    }
}