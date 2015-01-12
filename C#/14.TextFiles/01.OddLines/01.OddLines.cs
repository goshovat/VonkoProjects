using System;
using System.IO;
using System.Text;

class OddLines
{
    static void Main()
    {
        try 
        {
            string pathToFile = @"..\..\TextFileBaby.txt";
            StreamReader reader = new StreamReader(pathToFile, Encoding.GetEncoding(1251));
            
            using (reader)
            {
                string line = reader.ReadLine();
                int lineCounter = 0;

                while (line != null)
                {
                    lineCounter++;

                    if (lineCounter % 2 != 0)
                        Console.WriteLine(line);

                    line = reader.ReadLine();
                }
            }
        }
        catch (FileLoadException fileNotFoundExc) 
        {
            Console.WriteLine("Error! The source file was not found. Details:\n{0}", fileNotFoundExc.StackTrace);
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

