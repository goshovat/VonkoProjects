using System;
using System.Numerics;

class FibonacciNumbers
{
    static void Main()
    {
        //use big integer no to overflow if n is too big
        Console.WriteLine("Enter how many numbers from the fibonacci sequence you want to see:");
        int n = int.Parse(Console.ReadLine());
        BigInteger temp1 = 0;
        BigInteger temp2 = 1;
        BigInteger sum = 0;

        Console.Write("{0}, {1}, ", temp1, temp2);
        for (int i = 2; i < n; i++)
        {
            sum = temp1 + temp2;
            Console.Write(sum);
            if (i < n - 1)
            {
                Console.Write(", ");
            }
            else
            {
                Console.WriteLine();
            }
            temp1 = temp2;
            temp2 = sum;
        }
    }
}

