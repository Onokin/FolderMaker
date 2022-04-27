using System.Configuration;
using System.Globalization;
using System.Threading;

namespace FolderMaker
{
    static class SettingsManager
    {
        public static void SetAppSettings()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            string culture = "culture";
            if (settings[culture] != null)
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(settings[culture].Value);
        }

        public static void AddUpdateAppSettings(string key, string val)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, val);
            }
            else
            {
                settings[key].Value = val;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
    }
}
