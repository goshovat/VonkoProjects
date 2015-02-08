using System;
using System.Collections.Generic;
using System.Linq;

class WordsCount
{
    static void Main()
    {
        string input = Console.ReadLine();
        PrintEncounters(input);
    }

    private static void PrintEncounters(string input)
    {
        if (input == null)
            throw new ApplicationException("You have given input with null value.");

        char[] separators = { ' ', ',', '.', '!', '?', '-', '/', '\\' };

        string[] wordsString = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> wordsCount = new Dictionary<string, int>();

        for (int i = 0; i < wordsString.Length; i++)
        {
            if (wordsCount.ContainsKey(wordsString[i]))
                wordsCount[wordsString[i]]++;
            else
                wordsCount.Add(wordsString[i], 1);
        }

        var sortedWords = wordsCount.OrderBy(w => w.Value);

        Console.WriteLine("Encounters of each letter in the input:");
        foreach (var word in sortedWords)
            Console.WriteLine("Word:{0} Encounters:{1}", word.Key, word.Value);
    }
}
