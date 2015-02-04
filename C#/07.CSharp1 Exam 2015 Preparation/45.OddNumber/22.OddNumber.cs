using System;

class OddNumber
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());

        long[] inputArray = new long[n];

        for (int i = 0; i < n; i++)
        {
            inputArray[i] = long.Parse(Console.ReadLine());
        }

        //now find the number that is met odd number of times
        long result = inputArray[0];

        for (int i = 1; i < n; i++)
        {
            result ^= inputArray[i];
        }

        Console.WriteLine(result);
    }
}

