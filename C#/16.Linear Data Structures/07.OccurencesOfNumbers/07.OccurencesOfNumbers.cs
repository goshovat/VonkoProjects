using System;
using System.Collections.Generic;

namespace OccurencesOfNumbers
{
    class OccurencesOfNumbers
    {
        static void Main()
        {
            int[] array = { 3, 4, 4, 2, 3, 3, 4, 3, 2, 2, 2 };
            Array.Sort(array);

            int[] occurences = new int[1000];

            //store the occurences of all the numbers
            foreach (int number in array)
            {
                occurences[number]++;
            }

            //print the occurences and the numbers
            foreach (int number in array)
            {
                int index = number;

                if (occurences[index] != 0)
                {
                    int numberOccurences = occurences[index];
                    Console.WriteLine("The number {0} -> {1} times", number, numberOccurences);
                    occurences[index] = 0;
                }
            }
        }
    }
}
