using System;
using System.Collections.Generic;

class SortByRemovingElements
{
    static void Main()
    {
        List<int> originalList = new List<int>() { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        int len = originalList.Count;

        List<int> resulltList = new List<int>();

        int numberOfCombinations = (int)Math.Pow(2, originalList.Count);
        int counter = 0;
        int maxCounter = 0;

        for (int i = 0; i < numberOfCombinations; i++)
        {
            List<int> currentSequence = new List<int>();
            counter = 0;

            for (int j = 0; j < len; j++) 
            {
                if ((i & 1 << (len - j - 1)) != 0)
                {
                    currentSequence.Add(originalList[j]);
                    counter++;
                }

                if (IsSorted(currentSequence) && counter > maxCounter)
                {
                    resulltList = currentSequence;
                    maxCounter = counter;
                }
            }
        }

        //now print the result
        Console.WriteLine("The sorted array is: {0}", string.Join(", ", resulltList));
    }

    private static bool IsSorted(List<int> currentSequence)
    {
        bool isSorted = true; 

        for (int i = 0; i < currentSequence.Count - 1; i++)
        {
            if (currentSequence[i] > currentSequence[i + 1])
            {
                isSorted = false;
                break;
            }
        }

        return isSorted;
    }
}
