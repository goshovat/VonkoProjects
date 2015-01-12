using System;
using System.Numerics;


class FibonacciSequence
{
    static void Main()
    {
        BigInteger temp1 = 0;
        BigInteger temp2 = 1;
        Console.WriteLine(temp1);
        Console.WriteLine(temp2);
        BigInteger sum = 0;

        for (int i = 2; i < 100; i++)
        {
            sum = temp1 + temp2;
            Console.WriteLine(sum);
            temp1 = temp2;
            temp2 = sum;
        }
    }
}

