using System;

class NFactorialDividedByKFactorial
{
    static void Main()
    {
        Console.WriteLine("Enter the first number N:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the second number K:");
        int k = int.Parse(Console.ReadLine());
        int result = 1;

        for (int i = k + 1; i <=n ; i++)
        {
            result *= i;
        }

        Console.WriteLine("n!/k! = {0}", result);

    }
}
