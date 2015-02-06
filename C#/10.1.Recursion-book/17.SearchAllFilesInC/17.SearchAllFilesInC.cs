using System;
using System.IO;

class SearchAllFilesInC
{
    static void Main()
    {
        DirSearch("D:\\");
    }

    static void DirSearch(string directory)
    {
        try
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                Console.WriteLine(file);
            }

            foreach (string subDirectory in Directory.GetDirectories(directory))
            {
                DirSearch(subDirectory);
            }
        }
        catch (System.Exception message)
        {
            Console.WriteLine(message.Message);
        }
    }
}
