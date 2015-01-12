using System;

class MaxSumSequence
{
    static void Main()
    {
        //Initialize the array
        Console.WriteLine("Enter the length of the array: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] myArr = new int[arrLen];

        //set the length of the subsequence k
        Console.WriteLine("Enter the length of the subsequce K: ");
        int subsequeceLength = int.Parse(Console.ReadLine());

        //set the values of the array
        for (int i = 0; i < arrLen; i++)
        {
            Console.WriteLine("Enter element No {0} of the array: ", i);
            myArr[i] = int.Parse(Console.ReadLine());
        }

        //find the sequence of k elements with greatest sum
        int maxSum = int.MinValue;
        int currentSum = 0;
        int[] maxSumsArr = new int[arrLen];

        for (int i = 0; i <= arrLen - subsequeceLength; i++)
        {
            currentSum = 0;

            for (int j = i; j < i + subsequeceLength; j++)
            {
                currentSum += myArr[j];
            }

            //store the largest lengths in a separate array
            if (currentSum > maxSum)
            {
                maxSum = currentSum;

                for (int k = 0; k < arrLen; k++)
                {
                    maxSumsArr[k] = 0;
                }

                maxSumsArr[i] = maxSum;
            }
            else if (currentSum == maxSum)
            {
                maxSumsArr[i] = maxSum;
            }
        }

        
        //print the max sum sequence or sequeces if more than one
        Console.WriteLine("The sequence with maximum sum is: ");

        for (int i = 0; i <= maxSumsArr.Length - subsequeceLength; i++)
        {
            if (maxSumsArr[i] != 0)
            {
                for (int j = i; j < i + subsequeceLength; j++)
                {
                    Console.Write(myArr[j] + " ");
                }

                Console.WriteLine();
                Console.WriteLine(new string('-', 10));
            }
        }
    }
}

