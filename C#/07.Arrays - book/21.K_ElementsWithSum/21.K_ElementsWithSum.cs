using System;

class SubSetSum
{
    static void Main()
    {
        Console.WriteLine("Enter the wanted sum: ");
        long wantedSum = long.Parse(Console.ReadLine());
        Console.WriteLine("Enter the length of the subsets");
        long subsetLength = int.Parse(Console.ReadLine());
        long currentSubsetLength = 0;

        long[] elements = { 2, 1, 2, 4, 3, 5, 2, 6 };
        long numberOfElements = elements.Length;
        int counter = 0;
        string subset = "";

        int maxSubsets = (int)Math.Pow(2, numberOfElements) - 1;

        for (int i = 1; i <= maxSubsets; i++)
        {
            subset = "";
            long checkingSum = 0;
            currentSubsetLength = 0;

            for (int j = 0; j <= numberOfElements; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;

                if (bit == 1)
                {
                    checkingSum = checkingSum + elements[j];
                    subset += elements[j] + " ";
                    currentSubsetLength++;
                }
            }

            if (checkingSum == wantedSum && currentSubsetLength == subsetLength)
            {
                //Console.WriteLine("Number of subest that have the sum of {0}", wantedSum);
                counter++;
                Console.WriteLine("This subset has a sum of {0} : {1} ", wantedSum, subset);
            }
        }

        Console.WriteLine("Number of subsets with the desired sum: {0}", counter);
    }
}
