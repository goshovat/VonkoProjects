using System;

class NFactorialKFactorialExpression
{
    static void Main()
    {
        ulong n = 0;
        ulong k = 0;
        Console.WriteLine("Enter random positive numbers N and K(K>N>1):");

        try
        {
            Console.Write("N= ");
            n = ulong.Parse(Console.ReadLine());
            Console.Write("K= ");
            k = ulong.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter valid numbers!");
            return;
        }

        ulong nFactorial = 1;
        ulong otherFactorial = 1;
        ulong result = 1;

        if (k > n)
        {
            for (ulong i = 1; i <= n; i++)
            {
                nFactorial *= i;
            }

            for (ulong i = (k - n + 1); i <= k; i++)
            {
                otherFactorial *= i;
            }

            result = nFactorial * otherFactorial;
            Console.WriteLine("The exression N!*K!/(K-N) equals: {0}", result);
        }
        else
        {
            Console.WriteLine("Enter valid numbers!");
        }
    }
}
