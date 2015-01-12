using System;
using System.Collections.Generic;

namespace OddOccurences
{
    class OddOccurences
    {
        static void Main()
        {
            int[] array =  { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            int [] sortedArray = new int[array.Length];
            
            Array.Copy(array, sortedArray, array.Length);
            Array.Sort(sortedArray);

            List<int> numbers = new List<int>();
            List<int> occurences = new List<int>();            

            int currentOccurences = 1;
            int currentNumber = sortedArray[0];

            for (int i = 1; i < sortedArray.Length; i++)
            {
                if (sortedArray[i] == currentNumber)
                {
                    currentOccurences++;
                }
                else if (currentNumber != sortedArray[i])
                {
                    occurences.Add(currentOccurences);
                    numbers.Add(currentNumber);

                    currentNumber = sortedArray[i];
                    currentOccurences = 1;
                }
            }

            numbers.Add(currentNumber);
            occurences.Add(currentOccurences);

            //print the appropriate numbers
            for (int i = 0; i < array.Length; i++)
            {
                int index = Array.IndexOf(numbers.ToArray(), array[i]);

                currentOccurences = occurences[index];

                if (currentOccurences % 2 == 0)
                    Console.Write(array[i] + " ");
            }
        }
    }
}
