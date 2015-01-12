using System;

class NFactorialDividedByKFactorial
{
    static void Main()
    {
        Console.WriteLine("Enter two positive decimalegers N and K(N to be bigger than K)");
        Console.Write("N = ");
        decimal n = 1;
        decimal k = 1;

        try
        {
            n = decimal.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("K = ");
            k = decimal.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter valid numbers!");
            return;
        }

        if (n > k && k > 0)
        {
            decimal factorial = 1;

            for (decimal i = (k + 1); i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine("The N!/K! expression equals {0}", factorial);
        }
        else
        {
            Console.WriteLine("Wrong numbers!");
        }
    }
}
