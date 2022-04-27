using FolderMaker.Resources;
using System;
using System.IO;

namespace FolderMaker
{
    static class FolderManager
    {
        public static void CreateFolders(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            var lines = File.ReadAllLines(args[0]);
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                dirInfo.CreateSubdirectory(line);
            }
            Console.WriteLine($"{Strings.TaskCompletedSuccesfully}!");
            Console.ReadLine();
        }
    }
}
