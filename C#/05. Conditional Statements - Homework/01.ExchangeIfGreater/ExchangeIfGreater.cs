using System;

class ExchangeIfGreater
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the real number a: ");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter the real number b: ");
        double b = double.Parse(Console.ReadLine());

        if (a > b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        Console.WriteLine("a -> {0}, b -> {1}", a, b);
    }
}
