using System;

class CalculateSum
{
    static void Main()
    {
        Console.WriteLine("Enter random positive numbers N and X(type decimal):");
        decimal n = 0;
        decimal x = 0;
        try
        {
            Console.Write("N= ");
            n = decimal.Parse(Console.ReadLine());
            Console.Write("X= ");
            x = decimal.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
            return;
        }

        decimal sum = 1;
        decimal factorial = 1;
        decimal nPow = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial *= (decimal)i;
            nPow *= x;
            sum += factorial / nPow;
        }

        Console.WriteLine("The sum from the formula equals: {0}", sum);
    }
}
