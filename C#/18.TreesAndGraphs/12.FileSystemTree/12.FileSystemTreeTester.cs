using System;
using System.Collections.Generic;

namespace FileSystemTree
{
    class FileSystemTreeTester
    {
        static void Main()
        {
            Folder baseFolder = new Folder("D:\\");

            double totalSize = SizeCalculator.CalculateSize(baseFolder);

            Console.WriteLine("The total size of the files is: {0} MB", totalSize);
        }
    }
}
