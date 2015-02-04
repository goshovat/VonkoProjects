using System;

class MaximalSum
{
    static void Main()
    {
        int[] testArray = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };

        int currentSum = testArray[0];
        int maxSum = testArray[0];
        int tempStartIndex = 0;
        int startIndex = 0;
        int endIndex = 0;

        for (int i = 1; i < testArray.Length; i++)
        {
            if (currentSum < 0)
            {
                tempStartIndex = i;
                currentSum = testArray[i];
            }
            else
            {
                currentSum += testArray[i];
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = tempStartIndex;
                endIndex = i;
            }
        }

        Console.WriteLine("Max sum: {0}", maxSum);
        Console.WriteLine("Elements with max sum:");
        //now print the sequence
        for (int i = startIndex; i <= endIndex; i++)
        {
            Console.Write(testArray[i] + " ");
        }
        Console.WriteLine();
    }
}
