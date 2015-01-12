using System;
using System.Collections.Generic;
using System.IO;

namespace PrintAllDirectoriesBFS
{
    class PrintAllDirectoriesBFS
    {
        static void Main()
        {
            try
            {
                DirSearch("D:\\Series");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void DirSearch(string directory)
        {
            Queue<string> directoriesQueue = new Queue<string>();
            directoriesQueue.Enqueue(directory);

            while (directoriesQueue.Count > 0)
            {
                string currentDirectory = directoriesQueue.Dequeue();
                Console.WriteLine(currentDirectory);

                foreach (string dir in Directory.GetDirectories(currentDirectory))
                {
                    directoriesQueue.Enqueue(dir);
                }
            }
        }
    }
}
