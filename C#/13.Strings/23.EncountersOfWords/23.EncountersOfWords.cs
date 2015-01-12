using System;
using System.Collections.Generic;

class EncountersOfWords
{
    static void Main()
    {
        string input = Console.ReadLine();

        try
        {
            PrintEncounters(input);
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error! Details:\n{0}", applExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\n{0}", e.StackTrace);
        }
    }

    private static void PrintEncounters(string input)
    {
        if (input == null)
            throw new ApplicationException("You have given input with null value.");

        char[] separators = { ' ', ',', '.', '!', '?', '-', '/', '\\' };

        string[] wordsString = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        List<string> words = new List<string>();
        List<int> encounters = new List<int>();

        for (int i = 0; i < wordsString.Length; i++)
        {
            int index = words.IndexOf(wordsString[i]);

            if (index != -1)
            {
                encounters[index]++;
            }
            else
            {
                words.Add(wordsString[i]);
                encounters.Add(1);
            }
        }

        SortWords(ref words, ref encounters);

        Console.WriteLine("Encounters of each letter in the input:");
        for (int i = 0; i < words.Count; i++)
        {
            Console.WriteLine("Word {0} - {1} times", words[i], encounters[i]);
        } 
    }

    //this method will sort the words ant their corresponing numbers of encounters
    private static void SortWords(ref List<string> words, ref List<int> encounters)
    {
        for (int i = 0; i < words.Count; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < words.Count; j++)
            {
                if (words[j].CompareTo(words[minIndex]) < 0)
                    minIndex = j;
            }

            if (minIndex != i)
            {
                string temp = words[i];
                words[i] = words[minIndex];
                words[minIndex] = temp;

                int tempEnc = encounters[i];
                encounters[i] = encounters[minIndex];
                encounters[minIndex] = tempEnc;
            }
        }
    }
}
