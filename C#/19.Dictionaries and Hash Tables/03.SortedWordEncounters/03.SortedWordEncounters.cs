using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedWordEncounters
{
    class SortedWordEncounters
    {
        static void Main()
        {
            string text = "This is the TEXT. Text, text, text – THIS TEXT! Is this the text?";

            Dictionary<string, int> wordEncounters = GetEncounters(text);

            PrintResult(wordEncounters);
        }

        private static Dictionary<string, int> GetEncounters(string text)
        {
            Dictionary<string, int> wordEncounters = new Dictionary<string, int>(new TextComparer());

            char[] separators = { ' ', ',', '.', '?', '!', '-', '–' };
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (wordEncounters.ContainsKey(word))
                    wordEncounters[word]++;
                else
                    wordEncounters[word] = 1;
            }

            return wordEncounters;
        }

        private static void PrintResult(Dictionary<string, int> wordEncounters)
        {
            foreach (KeyValuePair<string, int> pair in wordEncounters.OrderBy(pair => pair.Value))
                Console.WriteLine("{0} - > {1} times", pair.Key, pair.Value);
        }
    }
}
