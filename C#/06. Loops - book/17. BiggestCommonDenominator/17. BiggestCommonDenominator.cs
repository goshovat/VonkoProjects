using System;

class BiggestCommonDenominator
{
    static void Main()
    {
        int n = 0;
        int m = 0;
        int biggerNumber = n;
        int smallerNumber = m;
        int biggestDenominator = 0;

        try
        {
            Console.WriteLine("Write a random number N: ");
            n = Math.Abs(int.Parse(Console.ReadLine()));
            Console.WriteLine("Write a random number M: ");
            m = Math.Abs(int.Parse(Console.ReadLine()));
        }
        catch (FormatException) 
        {
            Console.WriteLine("Please enter valid numbers!");
        }

        if (m > n)
        {
            biggerNumber = m;
            smallerNumber = n;
        }

        int divider = 2;

        for (int i = divider; i <= smallerNumber; i++)
        {
            if (n % i == 0 && m % i == 0)
            {
                if (i > biggestDenominator)
                {
                    biggestDenominator = i;
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine("The biggest common divider is: {0}",biggestDenominator);
    }
}

