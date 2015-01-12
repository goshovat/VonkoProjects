using System;
using System.Numerics;

class FactorialZeroesAtTheEnd_ver2
{
    static void Main()
    {
        Console.WriteLine("Write a number to check how many are the 0s at the end of \r\n it's factorial: ");
        BigInteger n = 1;
        BigInteger counter = 0;

        try
        {
            n = BigInteger.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number!");
        }

        if (n > 0)
        {
            for (ulong i = 1; i <= n; i++)
            {
                counter += n / (BigInteger)Math.Pow(5, i);
            }


            Console.WriteLine("Result: {0}", counter);
        }
        else
        {
            Console.WriteLine("Please enter a valid number!");
        }
    }
}

