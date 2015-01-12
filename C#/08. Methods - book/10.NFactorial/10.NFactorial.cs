using System;
using System.Numerics;

class NFactorial
{
    static void Main()
    {
        Test1();
    }

    //our method
    static BigInteger CalculateNFactorial(int n)
    {
        BigInteger result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    //test method
    static void Test1()
    {
        int n = 100;

        Console.WriteLine("The result of {0} factorial is:\n\r{1}",
            n, CalculateNFactorial(n));
    }
}
