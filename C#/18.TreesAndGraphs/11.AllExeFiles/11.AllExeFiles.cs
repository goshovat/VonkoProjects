using System;
using System.Collections.Generic;
using System.IO;

namespace AllExeFiles
{
    class AllExeFiles
    {
        static void Main()
        {
            DirectoryInfo startDirecotry = new DirectoryInfo("D:\\");

            try
            {
                PrintExeFiles(startDirecotry);
            }
            catch (UnauthorizedAccessException unAccess)
            {
                Console.WriteLine(unAccess.Message);
            }
        }

        private static void PrintExeFiles(DirectoryInfo startDirecotry)
        {
            FileInfo[] files = startDirecotry.GetFiles();

            //print the files with exe
            foreach (FileInfo file in files)
            {
                if (file.FullName.Contains(".exe") &&
                    file.FullName.IndexOf(".exe") == file.FullName.Length - 4)
                    Console.WriteLine(file.FullName);
            }

            DirectoryInfo[] directories = startDirecotry.GetDirectories();

            foreach (DirectoryInfo directory in directories)
            {
                PrintExeFiles(directory);
            }
        }
    }
}
