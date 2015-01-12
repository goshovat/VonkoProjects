using System;
using System.Collections.Generic;
using System.IO;

namespace PrintAllDirectories_DFS
{
    class PrintAllDirectories_DFS
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
            Stack<string> directoriesStack = new Stack<string>();
            directoriesStack.Push(directory);

            while (directoriesStack.Count > 0)
            {
                string currentDirectory = directoriesStack.Pop();
                Console.WriteLine(currentDirectory);

                foreach (string dir in Directory.GetDirectories(currentDirectory))
                {
                    directoriesStack.Push(dir);
                }
            }
        }
    }
}
