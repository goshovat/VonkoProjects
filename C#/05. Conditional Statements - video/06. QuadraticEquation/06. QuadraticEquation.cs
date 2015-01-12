using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Enter the coefficents of your quadratic equation:");
        double a = 0;
        double b = 0;
        double c = 0;

        try
        {
            a = double.Parse(Console.ReadLine());
            b = double.Parse(Console.ReadLine());
            c = double.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number!");
            return;
        }

        double d = b * b - 4 * a * c;

        if (a == 0)
        {
            double x = -c / b;
            Console.WriteLine("The only real solution is {0}", x);
            return;
        }

        if (d > 0)
        {
            double x1 = (-b + Math.Sqrt(d)) / 2 * a;
            double x2 = (-b - Math.Sqrt(d)) / 2 * a;
            Console.WriteLine("The two real solutions are {0:F3} and {1:F3}", x1,x2);
        }
        else if (d == 0)
        {
            double x = -b / (2 * a);
            Console.WriteLine("The only real solution is: {0:F3}", x);
        }
        else
        {
            Console.WriteLine("There are no real solutions!");
        }
    }
}

