using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

class RelevanceIndex
{
    private static string[] separators = new string[] { " ", ",", ".", "(", ")", ";", "-", "!", "?" };

    static void Main()
    {
        string searchWord = Console.ReadLine().ToUpper();
        int paragaphs = int.Parse(Console.ReadLine());
        SortedDictionary<int, List<int>> indexes =
            new SortedDictionary<int, List<int>>();

        List<string> inputStored = new List<string>();

        for (int i = 0; i < paragaphs; i++)
        {
            string line = Console.ReadLine();
            inputStored.Add(line);

            int occurences = FindOccurences(line.ToUpper(), searchWord);

            if (!indexes.ContainsKey(occurences))
                indexes.Add(occurences, new List<int>() { i });
            else
                indexes[occurences].Add(i);
        }

        StringBuilder result = new StringBuilder();

        while (indexes.Count > 0)
        {
            List<int> lines = indexes.Last().Value;
            int key = indexes.Last().Key;

            foreach (int index in lines)
            {
                string[] line = inputStored[index].Split(
                    separators, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i].ToUpper() == searchWord)
                        result.Append(searchWord);
                    else
                        result.Append(line[i]);

                    if (i < line.Length - 1)
                        result.Append(' ');
                }
                result.Append('\n');
            }

            indexes.Remove(key);
        }

        Console.WriteLine(result.ToString().Trim());
    }

    private static int FindOccurences(string line, string searchWord)
    {
        int result = 0;

        string[] words = line.Trim().Split(
            separators, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
            if (word.ToUpper() == searchWord)
                result++;

        return result;
    }
}