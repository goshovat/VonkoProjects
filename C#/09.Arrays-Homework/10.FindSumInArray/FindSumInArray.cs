using System;

class FindSumInArray
{
    static void Main()
    {
        int[] testArray = { 4, 3, 1, 4, 2, 5, 8 };
        int len = testArray.Length;
        int givenSum = 11;
        bool sumFound = false;
        int startIndex = 0;
        int tempStartIndex = 0;
        int endIndex = 0;

        for (int i = 0; i < len - 1; i++)
        {
            int currentSum = testArray[i];
            tempStartIndex = i;

            for (int j = i + 1; j <= len; j++)
            {
                if (currentSum > givenSum)
                {
                    break;
                }
                else if (currentSum == givenSum)
                {
                    startIndex = i;
                    endIndex = j - 1;
                    sumFound = true;
                    break;
                }
                currentSum += testArray[j];
            }

            if (sumFound)
                break;
        }

        //print the result
        if (sumFound)
        {
            Console.WriteLine("The sum {0} is reached from the elements:", givenSum);
            for (int i = startIndex; i <= endIndex; i++)
            {
                Console.Write(testArray[i]);

                if (i != endIndex)
                    Console.Write(", ");
            }
        }
        else
        {
            Console.WriteLine("There is no such sequence");
        }
        Console.WriteLine();
    }
}
