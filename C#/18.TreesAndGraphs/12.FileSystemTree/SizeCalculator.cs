using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemTree
{
    public static class SizeCalculator
    {
        public static double CalculateSize(Folder baseFolder)
        {
            double totalSize = 0;

            try
            {
                CalculateSize(baseFolder, ref totalSize, "");
            }
            catch (ApplicationException applExc)
            {
                Console.WriteLine(applExc.Message);
            }
            catch (UnauthorizedAccessException unAuth)
            {
                Console.WriteLine(unAuth.Message);
            }

            return totalSize;
        }

        private static void CalculateSize(Folder folder, ref double totalSize, string spaces) 
        {
            File[] files = folder.GetFiles();

            //print then names of the files
            foreach (File file in files)
            {
                Console.WriteLine(spaces + "File: " + file.Name);
            }

            //get the total size of the files in this folder
            try
            {
                totalSize += folder.GetFilesTotalSize();
            }
            catch (OverflowException overFlow)
            {
                Console.WriteLine("Error! The size in MBs is too big to be stored in integer!");
            }

            Folder[] folders = folder.GetChildFolders();

            //print the name of the filders and go recursively down
            foreach (Folder fold in folders)
            {
                Console.WriteLine(spaces + "Folder: " + fold.Name);
                CalculateSize(fold, ref totalSize, spaces + "  ");
            }
        }
    }
}
