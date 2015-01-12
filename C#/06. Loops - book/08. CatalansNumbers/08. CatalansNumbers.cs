using System;
using System.Numerics;

class CatalansNumbers
{
    static void Main()
    {
        Console.Write("Enter a positive number N to calculate the Catalan's number for N: ");
        BigInteger n = 1;

        try 
        {
            n = BigInteger.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
        }

        if (n > 0)
        {
            BigInteger numerator = 1;
            BigInteger denominator = 1;
            BigInteger cN = 1;

            for (BigInteger i = (n + 1); i <= (2 * n); i++)
            {
                numerator *= i;
            }

            for (BigInteger i = 1; i <= (n + 1); i++)
            {
                denominator *= i;
            }

            cN = numerator / denominator;
            Console.WriteLine("Cn = {0}", cN);
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}

    