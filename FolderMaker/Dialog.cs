using FolderMaker.Resources;
using System;
using System.Globalization;
using System.Threading;

namespace FolderMaker
{
    static class Dialog
    {
        public static void UserDialog()
        {
            switch (Console.ReadLine())
            {
                case "lang":
                    ChangeCulture();
                    break;
                case "rset":
                    RegistryManager.SetupRegistryKey();
                    break;
                case "rdel":
                    RegistryManager.DeleteRegistryKey();
                    break;
                case "help":
                    HelpCommand();
                    break;
                default:
                    HelpCommand();
                    break;
            }
        }
        public static void ChangeCulture()
        {
            Console.WriteLine($"\n{Strings.ChangeLanguage}");
            Console.WriteLine(
                $"ru - русский\n" +
                $"en - english "
                );
            switch (Console.ReadLine())
            {
                case "ru":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
                    SettingsManager.AddUpdateAppSettings("culture", "ru-RU");
                    break;
                case "en":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
                    SettingsManager.AddUpdateAppSettings("culture", "en-us");
                    break;
                default:
                    Console.WriteLine($"{Strings.NoLanguage}!");
                    break;
            }
            Console.WriteLine($"{Strings.CurentLanguage} : {Thread.CurrentThread.CurrentUICulture}");
        }

        public static void HelpCommand()
        {
            Console.WriteLine($"\nrset - {Strings.rset}\n" +
                                $"rdel - {Strings.rdel}\n" +
                                $"help - {Strings.help}\n" +
                                $"lang - {Strings.ChangeLanguage}");
        }
    }
}
