using System;

class FactorialExpression3
{
    static void Main()
       {
        decimal n = 1;
        decimal x = 1;
        decimal result = 1;

        try
        {
            Console.Write("Enter a number n: ");
            n = decimal.Parse(Console.ReadLine());
            Console.Write("Enter a number x: ");
            x = decimal.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
        }

        if (n > 0)
        {
            decimal nFactorial = 1;
            decimal nPow = 1;

            for (decimal i = 1; i <= n; i++)
            {
                nFactorial *= i;
                nPow *= x;
                result += nFactorial / nPow;
            }

            Console.WriteLine("Result: {0}", result);
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}

