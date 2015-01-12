using System;
using System.Collections.Generic;

class SubsetOfSumS
{
    static void Main()
    {
        int[] testArray = { 2, 1, 2, 4, 3, 5, 2, 6};
        int givenSum = 14;

        int len = testArray.Length;

        int numberOfSubsets = (int)Math.Pow(2.00, (double)len);

        for (int i = 1; i < numberOfSubsets; i++)
        {
            List<int> currentCombination = new List<int>();
            int currentSum = 0;

            for (int j = 0; j < len; j++)
            {
                if ((1 << j & i) != 0)
                {
                    currentCombination.Add(testArray[len - j - 1]);
                    currentSum += testArray[len - j - 1];
                }
            }

            if (currentSum == givenSum)
            {
                //print the result
                int[] listToArray = currentCombination.ToArray();
                Array.Sort(listToArray);
                Console.WriteLine(string.Join(",", listToArray));
            }
        }
    }
}

