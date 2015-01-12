using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Enter the coefficent a:");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("Enter the coefficent b:");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine();

        Console.WriteLine("Enter the coefficent c:");
        double c = double.Parse(Console.ReadLine());
        Console.WriteLine();

        double d = b * b - 4 * a * c;

        if (d > 0)
        {
            double x1 = (-b + Math.Sqrt(d)) / 2 * a;
            double x2 = (-b - Math.Sqrt(d)) / 2 * a;

            Console.WriteLine("The real solutions to the equation are: {0} and {1}", x1, x2);
        }
        else if (d == 0)
        {
            double x = -b / 2 * a;
            Console.WriteLine("The only real solution to the equation is: {0}", x);
        }
        else
        {
            Console.WriteLine("The equation has no real solutions!");
        }

    }
}

