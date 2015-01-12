using System;
using System.Collections.Generic;
using System.Linq;

namespace GenerateSubsetsRecursion
{
    class GenerateSubsetsRecursion
    {
        static string[] words = { "море", "бира", "пари", "кеф" };

        static void Main()
        {
            GenerateSubsets(new HashSet<string>(), 0);
        }

        private static void GenerateSubsets(HashSet<string> currentSet, int index)
        {
            PrintSubset(currentSet);

            for (int i = index; i < words.Length; i++)
            {
                currentSet.Add(words[i]);
                GenerateSubsets(currentSet, i + 1);
                string lastWord = currentSet.Last();
                currentSet.Remove(lastWord);
            }
        }

        private static void PrintSubset(HashSet<string> currentSet)
        {
            Console.Write("{ ");
            foreach (string element in currentSet)
                Console.Write(element + " ");
            Console.WriteLine("}");
        }
    }
}
