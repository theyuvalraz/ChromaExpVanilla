using System.Configuration;
using Interfacer.Properties;

namespace ChromaExpVanilla.config
{
    public class GetCentralSettings : ApplicationSettingsBase
    {
        public static uint BaseColor { get; set; } = Interfacer.Properties.Settings.Default.BaseColor;
        public static uint HebrewColor { get; set; } = Interfacer.Properties.Settings.Default.HebrewColor;
        public static uint HebrewAltColor { get; set; } = Interfacer.Properties.Settings.Default.HebrewAltColor;
        public static uint EnglishColor { get; set; } = Interfacer.Properties.Settings.Default.EnglishColor;
        public static uint EnglishAltColor { get; set; } = Interfacer.Properties.Settings.Default.EnglishAltColor;
        public static uint TopNumberNormalColor { get; set; } = Interfacer.Properties.Settings.Default.TopNumberNormalColor;
        public static uint NumpadNormalColor { get; set; } = Interfacer.Properties.Settings.Default.NumpadNormalColor;


    }
}