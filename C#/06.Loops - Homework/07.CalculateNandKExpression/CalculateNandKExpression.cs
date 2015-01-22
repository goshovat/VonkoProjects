using System;

class CalculateNandKExpression
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number n:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number k:");
        int k = int.Parse(Console.ReadLine());

        decimal result = 1;
        for (int i = 1; i <= k; i++)
        {
            result *= n - (k - i);
            result /= i;
        }

        Console.WriteLine("N! / (K! * (N-K)!) = {0}", result);
    }
}
