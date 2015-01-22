using System;

namespace CalculateN_DividedByXN
{
    class CalculateN_DividedByXN
    {
        static void Main()
        {
            Console.WriteLine("Enter the integer n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the integer x:");
            int x = int.Parse(Console.ReadLine());
            double baseComponent = 1.0 / (double)x;
            double result = 1 + baseComponent;

            for (int i = 2; i <= n; i++)
            {
                baseComponent *= i / (double)x;
                result += baseComponent;
            }

            Console.WriteLine("{0:N5}", result);
        }
    }
}
