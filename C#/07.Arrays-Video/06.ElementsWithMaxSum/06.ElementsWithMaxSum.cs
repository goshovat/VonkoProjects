using System;
using System.Collections.Generic;

class ElementsWithMaxSum
{
    static void Main()
    {
        //get the input data
        //Console.WriteLine("Enter the length of the array:");
        //int len = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the sum of how many elements yow will check: ");
        int numberOfElements = int.Parse(Console.ReadLine());

        int[] testArray = {5, 1, -22, 6, -8, 9, 10, 2};
        int len = testArray.Length;
        //int[] testArray = new int[len];
        //Console.WriteLine("Enter the elements fo the array: ");

        //for (int i = 0; i < len; i++)
        //{
        //    testArray[i] = int.Parse(Console.ReadLine());
        //}

        //find the maximum sum
        int numberOfCombinations = (int)Math.Pow(2, len);
        List<int> currentCombinationList = new List<int>();
        List<int> maxCombinationList = new List<int>();
        int maxSum = 0;

        for (int i = 0; i < numberOfCombinations; i++)
        {
            int currentSum = 0;
            int currentLen = 0;
            currentCombinationList = new List<int>();

            for (int j = 0; j < len; j++)
            {
                if ((1 << j & i) != 0)
                {
                    currentCombinationList.Add(testArray[len - j - 1]);
                    currentSum += testArray[len - j - 1];
                    currentLen++;
                }
            }

            if (currentSum > maxSum && currentLen == numberOfElements)
            {
                maxSum = currentSum;
                maxCombinationList = currentCombinationList;
            }
        }

        //print the result
        Console.WriteLine("The {0} elements with maximum sum in the array are: ", numberOfElements);
        for (int i = 0; i < maxCombinationList.Count; i++)
        {
            Console.Write(maxCombinationList[i] + " ");
        }
    }
}

