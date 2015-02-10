using System;
using System.IO;
using System.Text;

class DeleteOddLines
{
    static void Main(string[] args)
    {
        string filePathName = @"..\..\TextFileBaby.txt";
        try
        {
            DeleteOddRows(filePathName);
            Console.WriteLine("Operation successfully completed.");
        }
        catch (FileNotFoundException fileNotFoundExc)
        {
            Console.WriteLine("Error! The source files was not found. Details:\n{0}",
                fileNotFoundExc.StackTrace);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("Error occured during operations with the files. Details:\n{0}",
                ioExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something fucked up happened! Details:\n{0}",
                e.StackTrace);
        }
    }

    private static void DeleteOddRows(string filePathName)
    {
        StreamReader reader = new StreamReader(filePathName, 
            Encoding.GetEncoding(1251));
        string tempFileName = @"..\..\TempFile.txt";
        StreamWriter tempFile = new StreamWriter(tempFileName, false, 
            Encoding.GetEncoding(1251));

        //first coppy the even rows in the dynamic memory
        using (reader)
        {
            string line = reader.ReadLine();
            int rowCount = 0;

            using (tempFile)
            {
                while (line != null)
                {
                    rowCount++;

                    if (rowCount % 2 == 0)
                        tempFile.WriteLine(line);

                    line = reader.ReadLine();
                }
            }

            string backupPathName = @"..\..\backup.txt";
            File.Replace(tempFileName, filePathName, backupPathName);
            File.Delete(backupPathName);
        }
    }
}
