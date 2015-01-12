using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Write the coefficetn a of your quadratic equation: ");
        string inputA = Console.ReadLine();
        double a;
        Console.WriteLine("Write the coefficent b of your quadratic equation: ");
        string inputB = Console.ReadLine();
        double b;
        Console.WriteLine("Write the coefficent c of your quadratic equation: ");
        string inputC = Console.ReadLine();
        double c;

        if ((double.TryParse(inputA, out a))&&(double.TryParse(inputB, out b))&&
            (double.TryParse(inputC, out c)))
        {
            double d = b * b - 4 * a * c;

            if (d > 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / 2 * a;
                double x2 = (-b - Math.Sqrt(d)) / 2 * a;
                Console.WriteLine("The two real solutions to your equation are: {0} and {1}", x1, x2);
            }
            else if (d == 0)
            {
                double x = (-b) / 2 * a;
                Console.WriteLine("The only real solution to your equation is: {0}",x);
            }
            else
            {
                Console.WriteLine("There are no real solutions to your equation!");
            }
        }
        else
        {
            Console.WriteLine("Please enter valid numbers!");
            Console.WriteLine();
            Main();
        }
    }
}

