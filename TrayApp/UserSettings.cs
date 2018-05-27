using System.Configuration;
using Interfacer.Properties;

namespace TrayApp
{
    internal class UserSettings : ApplicationSettingsBase
    {
        public void ChangeBaseColorToGreen()
        {
            Settings.Default.BaseColor = 2401540;
            Settings.Default.Save();
        }
    }
}