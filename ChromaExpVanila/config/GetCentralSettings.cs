using System.Configuration;
using Interfacer.Properties;

namespace ChromaExpVanilla.config
{
    public class GetCentralSettings : ApplicationSettingsBase
    {
        public static uint BaseColor { get; set; } = Settings.Default.BaseColor;
        public static uint HebrewColor { get; set; } = Settings.Default.HebrewColor;
        public static uint HebrewAltColor { get; set; } = Settings.Default.HebrewAltColor;
        public static uint EnglishColor { get; set; } = Settings.Default.EnglishColor;
        public static uint EnglishAltColor { get; set; } = Settings.Default.EnglishAltColor;
        public static uint TopNumberNormalColor { get; set; } = Settings.Default.TopNumberNormalColor;
        public static uint NumpadNormalColor { get; set; } = Settings.Default.NumpadNormalColor;
        public static uint UsefulKeysColor { get; set; } = Settings.Default.UsefulKeysColor;
    }
}