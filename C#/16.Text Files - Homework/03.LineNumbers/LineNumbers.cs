using System;
using System.IO;
using System.Text;

class LineNumbers
{
    static void Main()
    {
        string filePathName = @"..\..\TextFileBaby.txt";
        try
        {
            AddLineNumbers(filePathName);
        }
        catch (FileNotFoundException fileNotFoundExc)
        {
            Console.WriteLine("Error! The source file is missing. Details:\n{0}", fileNotFoundExc.StackTrace);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("Error during operations with the file! Details:\n{0}", ioExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something fucked up happened! Details:\n{0}", e.StackTrace);
        }
    }

    static void AddLineNumbers(string filePathName)
    {
        StreamReader reader = new StreamReader(filePathName, 
            Encoding.GetEncoding(1251));
        StringBuilder builder = new StringBuilder();

        using (reader)
        {
            string line = reader.ReadLine();
            int lineNumber = 0;

            while (line != null)
            {
                lineNumber++;
                builder.Append(lineNumber).Append(". ").Append(line).Append("\r\n");
                line = reader.ReadLine();
            }
        }
        File.WriteAllText(filePathName, builder.ToString(), 
            Encoding.GetEncoding(1251));
    }
}
