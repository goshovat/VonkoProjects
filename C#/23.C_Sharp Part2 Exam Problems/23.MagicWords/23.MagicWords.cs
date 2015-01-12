namespace MagicWords
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    class MagicWords
    {
        private static List<string> words;

        static void Main()
        {
            GetInput();

            ReorderWords();

            Print();
        }

        private static void GetInput()
        {
            int numberWords = int.Parse(Console.ReadLine());
            words = new List<string>();

            for (int i = 0; i < numberWords; i++)
                words.Add(Console.ReadLine());
        }

        private static void ReorderWords()
        {
            int len = words.Count;
            for (int i = 0; i < len; i++)
            {
                string currentWord = words[i];
                int newIndex = currentWord.Length % (len + 1);

                words[i] = null;
                words.Insert(newIndex, currentWord);
                words.Remove(null);
            }
        }

        private static void Print()
        {
            StringBuilder result = new StringBuilder();
            var sorted = words.OrderBy(n => n.Length);
            int longestLen = sorted.Last().Length;

            for (int i = 0; i < longestLen; i++)
            {
                for (int j = 0; j < words.Count; j++)
                {
                    if (i < words[j].Length)
                    {
                        result.Append(words[j][i]);
                    }
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
