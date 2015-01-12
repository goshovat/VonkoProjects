using System;
using System.IO;
using System.Text;

class CompareLines
{
    static void Main()
    {
        string filePathName1 = @"..\..\TextFileBaby1.txt";
        string filePathName2 = @"..\..\TextFileBaby2.txt";

        try
        {
            PrintEqualDifferentLines(filePathName1, filePathName2);
        }
        catch (FileNotFoundException fileNotFoundExc)
        {
            Console.WriteLine("Error! One of the source files was not found. Details:\n{0}", fileNotFoundExc.StackTrace);
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

    private static void PrintEqualDifferentLines(string filePathName1, string filePathName2)
    {
        StreamReader reader1 = new StreamReader(filePathName1, Encoding.GetEncoding(1251));
        StreamReader reader2 = new StreamReader(filePathName2, Encoding.GetEncoding(1251));

        int equalLines = 0;
        int differentLines = 0;

        using (reader1)
        {
            using (reader2)
            {
                string line1 = reader1.ReadLine();
                string line2 = reader2.ReadLine();

                while (line1 != null && line2 != null)
                {
                    if (line1.Equals(line2))
                    {
                        equalLines++;
                    }
                    else
                    {
                        differentLines++;
                    }

                    line1 = reader1.ReadLine();
                    line2 = reader2.ReadLine();
                }
            }
        }

        Console.WriteLine("Equal lines: {0}\nDiffeent lines: {1}", equalLines, differentLines);
    }
}
