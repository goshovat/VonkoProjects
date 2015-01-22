using System;

class CalculateGCD
{
    static void Main()
    {
        Console.WriteLine("Enter two integers to find their GCD:");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        while (a != 0 && b != 0)
        {
            if (Math.Abs(a) > Math.Abs(b))
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
            Console.WriteLine("The GCD is {0}", Math.Abs(b));
        }
        if (b == 0)
        {
            Console.WriteLine("The GCD is {0}", Math.Abs(a));
        }
    }
}
