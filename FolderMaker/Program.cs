using FolderMaker.Resources;
using System;


namespace FolderMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SettingsManager.SetAppSettings();
                if (args.Length < 1)
                {
                    Dialog.HelpCommand();
                    while (true)
                        Dialog.UserDialog();
                }
                else
                    FolderManager.CreateFolders(args);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine($"{Strings.Error}!");
                Console.ReadLine();
            }
        }
    }
}
