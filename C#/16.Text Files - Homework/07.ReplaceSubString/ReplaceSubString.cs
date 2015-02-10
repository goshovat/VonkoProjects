using System;
using System.IO;

class ReplaceSubString
{
    static void Main()
    {
       string sourcePathName = @"..\..\SomeText.txt";

        try {
            string wordToRemove = "get";
            string wordToAdd = "start";

            ChangeSubstrings(wordToRemove, wordToAdd, sourcePathName);
            Console.WriteLine("Operation succesfully executed.");
        }
        catch (FileNotFoundException fileNotFoundExc)
        {
            Console.WriteLine("Error! The source file " + sourcePathName + 
                "was not found. Details:\n{0}", fileNotFoundExc.StackTrace);
        }
        catch (NullReferenceException nullRefExc)
        {
            Console.WriteLine("Error! The list with the names is with null value! Details:\n{0}", 
                nullRefExc.StackTrace);
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

    private static void ChangeSubstrings(string wordToRemove, string wordToAdd, string sourcePathName)
    {
        //this is a temporary file to be deleted on the end
        string destPathName = @"..\..\EditedText.txt";

        StreamReader reader = new StreamReader(sourcePathName);
        StreamWriter writer = new StreamWriter(destPathName);

        using (reader)
        {
            string line = reader.ReadLine();

            using (writer)
            {
                while (line != null)
                {
                    string editedLine = line.Replace(wordToRemove, wordToAdd);
                    writer.WriteLine(editedLine);

                    line = reader.ReadLine();
                }
            }
        }

        string backupFile = @"..\..\Backup.txt";
        File.Replace(destPathName, sourcePathName, backupFile);
        File.Delete(backupFile);
    }
}
