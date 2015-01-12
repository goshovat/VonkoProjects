using System;

class SubsetSums
{
    static void Main()
    {

        long sum = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        //put all input numbers into array
        long[] inputArray = new long[n];

        for (int i = 0; i < n; i++)
        {
            inputArray[i] = long.Parse(Console.ReadLine());
        }

        int combinationsToShow = 0;
        int numberOfCombinations = (int)Math.Pow(2, n) - 1;
        long currentCombinationSum = 0;

        for (int i = 1; i <= numberOfCombinations; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int mask = 1 << j;
                int iAndMask = mask & i;
                int bit = iAndMask >> j;

                if (bit == 1)
                {
                    currentCombinationSum += inputArray[n - j -1];
                }
            }

            //check if the sum of current combination equals the given sum
            if (currentCombinationSum == sum)
            {
                combinationsToShow++;
            }

            currentCombinationSum = 0;
        }

        //display the final result
        Console.WriteLine(combinationsToShow);
    }
}

