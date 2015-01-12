using System;
using System.Text;
using System.IO;

class MergeTwoTextFiles
{
    static void Main()
    {
        try
        {
            string pathToFile1 = @"..\..\TextFileBaby.txt";
            string pathToFile2 = @"..\..\TextFileBaby1.txt";

            string pahtToNewFile = @"..\..\NewFile.txt";
            StreamWriter writer = new StreamWriter(pahtToNewFile, false, Encoding.GetEncoding(1251));

            string mergedFilesString = File.ReadAllText(pathToFile1, Encoding.GetEncoding(1251)) + '\n'
                + File.ReadAllText(pathToFile2, Encoding.GetEncoding(1251));

            using (writer)
            {
                writer.WriteLine(mergedFilesString);
            }
        }
        catch (FileLoadException fileNotFoundExc)
        {
            Console.WriteLine("Error! One of the source files was not found. Details:\n{0}", fileNotFoundExc.StackTrace);
        }      
        catch (ArgumentException argExc)
        {
            Console.WriteLine("Error! The path to the file is invalid! Details:\r\n{0}", argExc.Message);
        }
        catch (PathTooLongException pathTooLongExc)
        {
            Console.WriteLine("Error! The path to the file exceeds the limit of 248 characters! Details:{0}", pathTooLongExc);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("Error! Error occured during working with the file. Details:\n{0}", ioExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something fucked up happened! Details:\n{0}", e.StackTrace);
        }
    }
}
