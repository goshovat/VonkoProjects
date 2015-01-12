using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    class TestProgram
    {
        static void Main()
        {
            DirectoryInfo vonkoDir = new DirectoryInfo("C:\\");
            FileInfo[] childs = vonkoDir.GetFiles();

            foreach (FileInfo child in childs)
            {
                Console.WriteLine(child.FullName);
      
            }
        }
    }
}
