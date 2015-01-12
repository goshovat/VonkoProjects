using System;
using System.IO;
using System.Text;

class ReadTextFile
{
    static void Main()
    {
        string filePath = @"..\..\TextFileBaby.txt";
        string finalResult = null;

        try
        {
            finalResult = PrintTextFile(filePath);
        }
        catch (Exception generalException)
        {
            Console.WriteLine("Something fucked up happened:\r\n{0}", generalException.StackTrace);
        }

        Console.WriteLine("Now we will print the contents of this text file on the console: ");
        Console.WriteLine(finalResult);
    }

    //this is the method that will read the contents of the file and print it on the console
    static string PrintTextFile(string filePath)
    {
        string finalResult = null;

        try
        {           
            StreamReader fileReader = new StreamReader(filePath, Encoding.GetEncoding("Windows-1251"));
            
            //even if exception occurs while reading the file, the file will be closed
            using (fileReader)
            {
                int lineCounter = 1;
                string currentLine = fileReader.ReadLine();

                while (currentLine != null)
                {
                    finalResult += "Line: " + lineCounter + " " + currentLine + "\r\n";
                    currentLine = fileReader.ReadLine();
                    lineCounter++;
                }
            }
        }
        catch (FileNotFoundException fileNotFoundExc)
        {
            Console.WriteLine("The file is missing, you will get empty string! Details:\r\n{0}", fileNotFoundExc.Message);
        }
        catch (DirectoryNotFoundException directNotFoundExc)
        {
            Console.WriteLine("The directory of the file cannot be reached! Details:\r\n{0}", directNotFoundExc.Message);
        }
        catch (IOException ioException)
        {
            Console.WriteLine("Error during file reading:\r\n{0}", ioException.Message);
        }

        return finalResult;
    }
}