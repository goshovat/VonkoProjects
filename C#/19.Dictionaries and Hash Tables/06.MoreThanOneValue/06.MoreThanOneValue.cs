using System;
using System.Collections.Generic;

namespace MoreThanOneValue
{
    class MoreThanOneValue
    {
        static void Main()
        {
            Dictionary<string, List<int>> marks = new Dictionary<string, List<int>>();

            marks["vonko"] = new List<int>() { 2, 3, 3, 4, 6 };
            marks["goshko"] = new List<int>() { 4, 6, 6, 4 };
            marks["mimeto"] = new List<int>() { 5, 2, 6 };

            PrintMarks(marks);
        }

        private static void PrintMarks(Dictionary<string, List<int>> marks)
        {
            foreach (KeyValuePair<string, List<int>> pair in marks)
            {
                Console.Write("The marks of {0} are: ", pair.Key);
                foreach (int mark in pair.Value)
                {
                    Console.Write(mark + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
