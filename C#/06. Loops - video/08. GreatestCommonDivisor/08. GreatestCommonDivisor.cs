using System;


class GreatestCommonDivisor
{
    static void Main()
    {
        Console.WriteLine("Enter two integers to find their GCD:");
        int a = 0;
        int b = 0;

        try
        {
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter valid numbers!");
            return;
        }

        while (a != 0 && b != 0)
        {
            if (a > b)
            {
                a %= b;
            }
            else
            {
                b %= a;
            }
        }

        if (a == 0)
        {
            Console.WriteLine("The GCD is {0}", b);
        }
        if (b == 0)
        {
            Console.WriteLine("The GCD is {0}", a);
        }
    }
}
