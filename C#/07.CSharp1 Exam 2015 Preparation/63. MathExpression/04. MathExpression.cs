using System;

class MathExpression
{
    static void Main(string[] args)
    {
        double n = double.Parse(Console.ReadLine());
        double m = double.Parse(Console.ReadLine());
        double p = double.Parse(Console.ReadLine());

        const double const1 = 1337;
        const double const2 = 128.523123123;

        double numerator = n * n + 1 / (m * p) + const1;
        double denominator = n - const2 * p;
        double addition = Math.Sin((int)(m % 180));

        double result = numerator / denominator + addition;

        Console.WriteLine("{0:F6}", result);

    }
}

