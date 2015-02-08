using System;
using System.Collections.Generic;
using System.Linq;

class LettersCount
{
    static void Main()
    {
        string input = Console.ReadLine();
        PrintEncounters(input);
    }

    static void PrintEncounters(string input)
    {
        if (input == null)
            throw new ApplicationException("You have given input with null value.");

        int len = input.Length;
        Dictionary<char, int> encountersPerLetter = new Dictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (encountersPerLetter.ContainsKey(input[i]))
                encountersPerLetter[input[i]]++;
            else
                encountersPerLetter.Add(input[i], 1);
        }

        var sortedByEcnounters = encountersPerLetter.OrderBy(e => e.Value);
        Console.WriteLine("Encounters of each letter in the input:");
        foreach (var item in sortedByEcnounters)
        {
            Console.WriteLine("Encouters:{0}, Letter:{1}", 
                item.Key, item.Value);
        }
    }
}
