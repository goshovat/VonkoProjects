using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;
using System.Linq;

class CountWords
{
    static void Main()
    {
        try
        {
            string pathWordsFile = @"..\..\Words.txt";
            string pathReferenceFile = @"..\..\text.txt";
            string pathResultFile = @"..\..\result.txt";

            string[] words = File.ReadAllLines(pathWordsFile, Encoding.GetEncoding(1251));
            Dictionary<string, int> encounters = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                encounters.Add(words[i], GetWordOccurences(words[i], pathReferenceFile));
            }

            SaveResult(encounters, pathResultFile);

            Console.WriteLine("Operation completed successfully.");
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error occured during deleting of the word. Details: {0}", applExc.Message);
        }
        catch (ArgumentNullException argNull)
        {
            Console.WriteLine(argNull.Message);
        }
        catch (ArgumentException argEx)
        {
            Console.WriteLine(argEx.Message);
        }
        catch (PathTooLongException tooLong)
        {
            Console.WriteLine(tooLong.Message);
        }
        catch (DirectoryNotFoundException notFoundDir)
        {
            Console.WriteLine(notFoundDir.Message);
        }
        catch (UnauthorizedAccessException access)
        {
            Console.WriteLine(access.Message);
        }
        catch (NotSupportedException notSupport)
        {
            Console.WriteLine(notSupport.Message);
        }
        catch (SecurityException secEx)
        {
            Console.WriteLine(secEx.Message);
        }
        catch (FileNotFoundException fileNotFoundExc)
        {
            Console.WriteLine("Error! The source file was not found. Details:\n{0}", fileNotFoundExc.StackTrace);
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

    //this method will return how many times each word is met in the reference file
    private static int GetWordOccurences(string word, string pathReferenceFile)
    {
        StreamReader readerReferenceFile = new StreamReader(
            pathReferenceFile, Encoding.GetEncoding(1251));
        int encounters = 0;

        using (readerReferenceFile)
        {
            //i do not read the whole file at once, in case the file is too big
            string line = readerReferenceFile.ReadLine();

            while (line != null)
            {
                string[] lineEntities = line.Split();

                foreach (string curWord in lineEntities)
                {
                    if (curWord == word)
                        encounters++;
                }
                line = readerReferenceFile.ReadLine();
            }
        }
        return encounters;
    }

    private static void SaveResult(Dictionary<string, int> encounters, string pathResultFile)
    {
        StreamWriter writerResultFile =
            new StreamWriter(pathResultFile, false, Encoding.GetEncoding(1251));

        var sortedEncounters = encounters.OrderByDescending(e => e.Value);

        using (writerResultFile)
        {
            foreach(var word in sortedEncounters) 
            {
                writerResultFile.WriteLine("{0} -> {1} times", word.Key, word.Value);
            }
        }
    }
}
