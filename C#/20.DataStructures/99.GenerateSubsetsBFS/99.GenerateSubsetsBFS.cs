using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;

namespace Test
{
    class Test
    {
        static void Main()
        {
            string[] words = { "море", "бира", "пари", "кеф" };
            Queue<List<int>> sets = new Queue<List<int>>();
            sets.Enqueue(new List<int>());

            while (sets.Count > 0)
            {
                List<int> currentSet = sets.Dequeue();
                PrintSet(currentSet, words);
                int start = -1;
                if (currentSet.Count > 0)
                {
                    start = currentSet[currentSet.Count - 1];
                }

                for (int i = start + 1; i < words.Length; i++)
                {
                    List<int> setToAdd = new List<int>(currentSet);
                    setToAdd.Add(i);
                    sets.Enqueue(setToAdd);
                }
            }
        }

        private static void PrintSet(List<int> currentSet, string[] words)
        {
            Console.Write("{ ");
            foreach (int index in currentSet)
                Console.Write(words[index] + " ");
            Console.WriteLine("}");
        }
    }
}
