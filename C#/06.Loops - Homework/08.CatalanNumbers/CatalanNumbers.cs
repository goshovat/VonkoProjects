using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a number n:");
        int n = int.Parse(Console.ReadLine());
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
}
