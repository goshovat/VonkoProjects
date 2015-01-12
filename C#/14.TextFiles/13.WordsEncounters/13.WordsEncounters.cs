using System;
using System.IO;
using System.Security;
using System.Text;

    class WordsEncounters
    {
        static void Main()
        {
            try
            {
                string pathWordsFile = @"..\..\Words.txt";
                string pathReferenceFile = @"..\..\text.txt";
                string pathResultFile = @"..\..\result.txt";

                string[] words = File.ReadAllLines(pathWordsFile, Encoding.GetEncoding(1251));
                int[] encounters = new int[words.Length];

                for (int i = 0; i < words.Length; i++)
                {
                    encounters[i] = GetWordOccurences(words[i], pathReferenceFile);
                }

                ArrangeWordsLexicographically(ref words, ref encounters);

                SaveResult(words, encounters, pathResultFile);

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
            StreamReader readerReferenceFile = new StreamReader(pathReferenceFile, Encoding.GetEncoding(1251));
            int encounters = 0;

            using (readerReferenceFile)
            {
                //i do not read the whole file at once, in case the file is too big
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
                            encounters++;

                        index = line.IndexOf(word, index + 1);
                    }

                    line = readerReferenceFile.ReadLine();
                }
            }

            return encounters;
        }

        //this method will arrange the words by the number of their encounters with bubble sort
        private static void SaveResult(string[] words, int[] encounters, string pathResultFile)
        {
            StreamWriter writerResultFile = new StreamWriter(pathResultFile, false, Encoding.GetEncoding(1251));

            using (writerResultFile)
            {
                for (int i = 0; i < words.Length; i++)
                {
                    writerResultFile.WriteLine("{0} -> {1} times", words[i], encounters[i]);
                }
            }
        }

        private static void ArrangeWordsLexicographically(ref string[] words, ref int[] encounters)
        {
            bool hasSwapped = true;

            while (hasSwapped)
            {
                hasSwapped = false;

                for (int i = 0; i < encounters.Length - 1; i++)
                {
                    if (encounters[i] < encounters[i + 1])
                    {
                        //exchange the encounters
                        int temp = encounters[i];
                        encounters[i] = encounters[i + 1];
                        encounters[i + 1] = temp;

                        //exchange the corresponding words
                        string tempWord = words[i];
                        words[i] = words[i + 1];
                        words[i + 1] = tempWord;

                        hasSwapped = true;
                    }
                }
            }
        }
    }
