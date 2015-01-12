using System;

class MaxSum
{
    static void Main()
    {
        ////Initialize the array
        Console.WriteLine("Enter the length of the array: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] myArr = new int[arrLen];
        int maxStartIndex = 0;
        int tempStartIndex = 0;
        int maxEndIndex = 0;

        //set the values of the array
        for (int i = 0; i < arrLen; i++)
        {
            Console.WriteLine("Enter element No {0} of the array: ", i);
            myArr[i] = int.Parse(Console.ReadLine());
        }

        //find the sequence with max sum of all numbers
        int maxSum  = myArr[0];
        int currentMaxSum = myArr[0];

        for (int i = 1; i < arrLen; i++)
        {
            if (currentMaxSum < 0)
            {
                currentMaxSum = myArr[i];
                tempStartIndex = i;
            }
            else
            {
                currentMaxSum += myArr[i];
            }

            if (currentMaxSum > maxSum) 
            {
                maxSum = currentMaxSum;
                maxStartIndex = tempStartIndex;
                maxEndIndex = i;
            }
        }

        //now print the sequence with max sum
        Console.WriteLine("The maximus sum is: {0}", maxSum);

        Console.WriteLine();

        Console.WriteLine("This is the sequence with maximum sum: ");

        for (int i = maxStartIndex; i <= maxEndIndex; i++)
        {
            Console.Write(myArr[i] + " ");
        }
        Console.WriteLine();
    }
}

