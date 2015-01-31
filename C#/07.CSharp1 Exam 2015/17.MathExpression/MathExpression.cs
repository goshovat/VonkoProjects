using System;

class MathExpression
{
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());

        int mDivRem = (int) m % 180;

        decimal result = 
            (n * n + 1 / (m * p) + 1337) / (n - (decimal)128.523123123 * p)
            + (decimal)Math.Sin(mDivRem);

        Console.WriteLine("{0:F6}", result);
    }
}
