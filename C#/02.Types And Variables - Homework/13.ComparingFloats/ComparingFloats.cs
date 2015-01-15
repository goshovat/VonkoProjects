using System;

class CompareFloatingPoints
{
    const double eps = 0.000001;

    static void Main()
    {
        Console.WriteLine("Input first number: ");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Input second number: ");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("The numbers are equal: {0}",
            a - b < eps ? true : false);
    }
}
