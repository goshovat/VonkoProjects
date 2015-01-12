using System;
using System.Numerics;

class FibonacciNumbers
{
    static void Main()
    {
        BigInteger temp1 = 0;
        BigInteger temp2 = 1;
        BigInteger sum = 0;
        Console.WriteLine(temp1);
        Console.WriteLine(temp2);

        for (int i = 0; i < 98; i++)
        {
            sum = temp1 + temp2;
            Console.WriteLine(sum);
            temp1 = temp2;
            temp2 = sum;
        }
    }
}

