using System;
using System.IO;
using System.Text.RegularExpressions;

class PrefixTest
{
    static void Main()
    {
        string filePathName = @"..\..\SomeText.txt";
        string phrase = "test";

        try
        {
            DeleteWords(filePathName, phrase);
            Console.WriteLine("Operation completed successfully.");
        }
        catch (FileNotFoundException fileNotFoundExc)
        {
            Console.WriteLine("Error! The source files was not found. Details:\n{0}", fileNotFoundExc.StackTrace);
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error occured during deleting of the word. Details: {0}", applExc.Message);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("Error occured during operations with the files. Details:\n{0}", ioExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something fucked up happened! Details:\n{0}", e.StackTrace);
        }
    }

    //this method will read every line from the source file and replace it with the edited line using a temporary file
    private static void DeleteWords(string filePathName, string phrase)
    {
        StreamReader reader = new StreamReader(filePathName);

        string tempFilePathName = @"..\..\TempFile.txt";

        StreamWriter writer = new StreamWriter(tempFilePathName);

        using (reader)
        {
            string line = reader.ReadLine();

            using (writer)
            {
                while (line != null)
                {
                    writer.WriteLine(RemoveWordsFromLine(line, phrase));
                    line = reader.ReadLine();
                }
            }
        }

        string backupPathName = @"..\..\backup.txt";
        File.Replace(tempFilePathName, filePathName, backupPathName);
        File.Delete(backupPathName);
    }

    //this method will remove the words containing the phrase from every single line
    private static string RemoveWordsFromLine(string line, string phrase)
    {
        string regexPattern = phrase + @"\w+";
        line = Regex.Replace(line, regexPattern, "");

        return line;
    }
}
