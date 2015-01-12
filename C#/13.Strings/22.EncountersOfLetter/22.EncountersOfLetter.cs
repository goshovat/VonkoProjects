using System;
using System.Collections.Generic;

class EncountersOfLetter
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

    static void PrintEncounters(string input)
    {
        if (input == null)
            throw new ApplicationException("You have given input with null value.");

        int len = input.Length;

        List<char> letters = new List<char>();
        List<int> encounters = new List<int>();

        for (int i = 0; i < input.Length; i++)
        {
            int index = letters.IndexOf(input[i]);

            if (index != -1)
            {
                encounters[index]++;
            }
            else
            {
                letters.Add(input[i]);
                encounters.Add(1);
            }
        }

        SortLetters(ref letters, ref encounters);

        Console.WriteLine("Encounters of each letter in the input:");
        for (int i = 0; i < letters.Count; i++)
        {
            Console.WriteLine("Letter {0} - {1} times", letters[i], encounters[i]);
        } 
    }

    //this will sort the letters in the selection sord algorithm
    private static void SortLetters(ref List<char> letters, ref List<int> encounters)
    {
        int len = letters.Count;

        for (int i = 0; i < len; i++)
        {
            int minIndex = i;

            for (int j = i + 1; j < len; j++)
            {
                if (letters[j].CompareTo(letters[minIndex]) < 0)
                    minIndex = j;
            }

            if (minIndex != i)
            {
                //exchange the letters to arange them alphabetically
                char temp = letters[i];
                letters[i] = letters[minIndex]; 
                letters[minIndex] = temp;
               
                //exchange their corresponding indexes
                int tempEnc = encounters[i];
                encounters[i] = encounters[minIndex];
                encounters[minIndex] = tempEnc;
            }
        }
    }
}
