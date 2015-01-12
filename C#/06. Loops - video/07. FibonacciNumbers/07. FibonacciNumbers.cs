using System;
using System.Numerics;

class FibonacciNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a random positive number N: ");
        uint n = 0;

        try
        {
            n = uint.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
            return;
        }

        BigInteger temp1 = 0;
        BigInteger temp2 = 1;
        BigInteger sum = 0;

        for (int i = 2; i <= n; i++)
        {
            sum = temp1 + temp2;
            temp1 = temp2;
            temp2 = sum;
        }

        Console.WriteLine("The sum of the first {0} members of the Fibonacci sequence is: {1}", n, sum);
    }
}
