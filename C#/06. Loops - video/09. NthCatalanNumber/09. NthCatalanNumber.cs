using System;
using System.Numerics;


class NthCatalanNumber
{
    static void Main()
    {
        Console.WriteLine("Write a random positive integer N: ");
        BigInteger n = 0;

        try
        {
            n = BigInteger.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter valid number!");
            return;
        }

        BigInteger numerator = 1;
        BigInteger denominator = 1;
        BigInteger result = 1;

        for (BigInteger i = n + 2; i <= 2 * n; i++)
        {
            checked
            {
                numerator *= i;
            }
        }

        for (BigInteger i = 1; i <= n; i++)
        {
            checked
            {
                denominator *= i;
            }
        }

        result = numerator / denominator;

        Console.WriteLine("The Nth Catalan's number is: {0}", result);
    }
}
