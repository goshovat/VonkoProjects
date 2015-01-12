using System;
using System.IO;
using System.Text;

class DeleteWordsFromOtherFIle
{
    static void Main()
    {
        string wordsFilePathName = @"..\..\Words.txt";
        string referenceFilePathName = @"..\..\Reference.txt";      

        try
        {
            DeleteWords(wordsFilePathName, referenceFilePathName);
            Console.WriteLine("Operation completed successfully.");
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

    //this method will delete the words from the first file contained in the reference file
    private static void DeleteWords(string wordsFilePathName, string referenceFilePathName)
    {
        StreamReader readerWordFile = new StreamReader(wordsFilePathName);

        //Create a temp file to save the words that are not contained in the other file. At the end 
        //we copy the content of the original file with the temp file
        string tempFilePathName = @"Reference.txt";
        StreamWriter writerTempFile = new StreamWriter(tempFilePathName);

        using (readerWordFile)
        {
            using (writerTempFile)
            {
                string line = readerWordFile.ReadLine();

                while (line != null)
                {
                    string word = line.Trim();

                    if (!WordContained(word, referenceFilePathName))
                        writerTempFile.WriteLine(word);

                    line = readerWordFile.ReadLine();
                }         
            }
        }

        string backupFilePathName = @"..\..\backup.txt";
        File.Replace(tempFilePathName, wordsFilePathName, backupFilePathName);
        File.Decrypt(backupFilePathName);
    }

    //this method will check every word from the first file if it is contained in the reference file
    private static bool WordContained(string word, string referenceFilePathName)
    {
        StreamReader readerReferenceFile = new StreamReader(referenceFilePathName);

        using (readerReferenceFile)
        {
            string line = readerReferenceFile.ReadLine();

            while (line != null)
            {
                int index = line.IndexOf(word);

                //the word is contained as a substring, but we dont know is it a separate word
                while (index != -1)
                {
                    bool isWord = true;

                    if (index != 0) 
                    {
                        if (line[index - 1] != ' ')
                            isWord = false;
                    }
                    if (index != line.Length - word.Length)
                    {
                        if (line[index + word.Length] != ' ')
                            isWord = false; 
                    }

                    if (isWord)
                        return true;

                    index = line.IndexOf(word, index + 1);
                }

                line = readerReferenceFile.ReadLine();
            }
        }

        return false;
    }
}
