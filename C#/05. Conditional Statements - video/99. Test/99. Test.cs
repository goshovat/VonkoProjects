using System;

class quadraticEquation
{
    static void Main()
    {
        Console.Write("input a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("input b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Input c: ");
        double c = double.Parse(Console.ReadLine());
        double d = (b * b) - 4 * a * c;
        if (a == 0)
        {
            double x = -b / (2 * a);
            Console.Write("One real root: {0}", -c / b);
        }
        else if (d > 0)
        {
            double xOne = (double)(-b + (Math.Sqrt(d))) / 2 * a;
            double xTwo = (double)(-b - (Math.Sqrt(d))) / 2 * a;
            Console.Write("Two real roots: {0} and {1}", xOne, xTwo);
        }
        else if (d == 0)
        {
            double xOne = -(b / 2 * a);
            Console.WriteLine("one real root-x1: {0}", xOne);
        }
        else
        {
            Console.WriteLine("There are no real roots");
        }
    }
}