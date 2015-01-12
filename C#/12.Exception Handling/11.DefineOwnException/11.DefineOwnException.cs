using System;
using System.IO;

class DefineOwnException
{
    static void Main()
    {
        string filePath = @"..\..\numbers.txt";

        try
        {
            ReadAndPrintNumbers(filePath);
        }
        catch (FileParseException fpExc)
        {
            Console.WriteLine("Error occured during parsing the numbers to int. Details:\r\n{0}", fpExc.ExceptionMesssage);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during execution of the program. Details:\r\n{0}", e.Message);
        }
    }

    //this metho will read and print the numbers to test our exception
    static void ReadAndPrintNumbers(string filePath)
    {
        try
        {
            StreamReader reader = new StreamReader(filePath);

            using (reader)
            {

                int currentRow = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    int number = 0;

                    if (!int.TryParse(line, out number))
                    {
                        throw new FileParseException(filePath, currentRow);
                    }

                    Console.WriteLine(number);
                    line = reader.ReadLine();
                    currentRow++;
                }
            }
        }
        catch (FileNotFoundException fnfe)
        {
            Console.WriteLine("Source file missing. Details:\r\n{0}", fnfe.Message);
        }
        catch (DirectoryNotFoundException dnfe)
        {
            Console.WriteLine("Could not access the directory of the source file. Details:\r\n{0}", dnfe.Message);
        }
        catch (DriveNotFoundException driveNfE)
        {
            Console.WriteLine("Could not access the drive of the source file. Details:\r\n{0}", driveNfE.Message);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("Error occured during reading the file: Details:\r\n{0}", ioExc.Message);
        }
    }
}
