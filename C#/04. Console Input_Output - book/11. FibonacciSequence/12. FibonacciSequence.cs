using System;
using System.Numerics;

class FibonacciSequence
{
    static void Main()
    {
        Console.WriteLine("The first 100 numbers of the Fibonacci sequence are: ");
        Console.WriteLine();

        BigInteger sum = 1;
        BigInteger temp1 = 0;
        BigInteger temp2 = 1;

        Console.WriteLine("0. " + temp1);
        Console.WriteLine("1. " + temp2);


        checked
        {
            for (int i = 2; i < 100; i++)
            {
                sum = temp1 + temp2;
                Console.WriteLine(i + ". " + sum);
                temp1 = temp2;
                temp2 = sum;
            }
        }
        
    }
}

