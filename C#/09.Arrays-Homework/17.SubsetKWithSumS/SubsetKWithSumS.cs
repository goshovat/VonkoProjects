using System;
using System.Collections.Generic;

class SubsetKWithSumS
{
    static void Main()
    {
        int[] testArray = { 2, 1, 2, 4, 3, 5, 2, 6 };
        int givenSum = 14;
        int givenCount = 4;
        bool subsetFound = false;
        int len = testArray.Length;
        int numberOfSubsets = (int)Math.Pow(2, len);

        for (int i = 1; i < numberOfSubsets; i++)
        {
            List<int> currentCombination = new List<int>();
            int currentSum = 0;
            int currentCount = 0;

            for (int j = 0; j < len; j++)
            {
                if ((1 << j & i) != 0)
                {
                    currentCombination.Add(testArray[len - j - 1]);
                    currentSum += testArray[len - j - 1];
                    currentCount++;
                }
            }

            if (currentSum == givenSum && currentCount == givenCount)
            {
                //print the result
                subsetFound = true;
                int[] listToArray = currentCombination.ToArray();
                Array.Sort(listToArray);
                Console.WriteLine("The elements with sum {0} are:", givenSum);
                Console.WriteLine(string.Join(",", listToArray));
                break;
            }
        }

        if (!subsetFound)
        {
            Console.WriteLine("No such subset exists");
        }
    }
}

