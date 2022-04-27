using FolderMaker.Resources;
using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace FolderMaker
{
    static class RegistryManager
    {
        public static void SetupRegistryKey()
        {
            // adds right click button
            try
            {
                RegistryKey rightClickMenuKey = Registry.ClassesRoot.OpenSubKey("*").OpenSubKey("shell", true);
                var a = rightClickMenuKey.GetSubKeyNames();
                string caption = Strings.RightClickCommand;
                string exePath = Process.GetCurrentProcess().MainModule.FileName;
                string command = String.Concat("\"", $@"{exePath}", "\"", " \"%1\"");
                var openWithKey = rightClickMenuKey.CreateSubKey("Open with FolderMaker", true);
                openWithKey.SetValue(null, caption);
                openWithKey.SetValue("icon", exePath);
                openWithKey.CreateSubKey("command", true).SetValue(null, command);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException);
                Console.WriteLine($"{Strings.Error}!");
                Console.ReadLine();
            }
        }

        public static void DeleteRegistryKey()
        {
            // removes right click button
            try
            {
                RegistryKey rightClickMenuKey = Registry.ClassesRoot.OpenSubKey("*").OpenSubKey("shell", true);
                rightClickMenuKey.DeleteSubKeyTree("Open with FolderMaker", true);
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
