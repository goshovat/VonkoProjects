using System;

class MinMaxSumAverage
{
    static void Main()
    {
        Console.WriteLine("Enter how many numbers you will check: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a sequence of integers: ");
        int min = int.MaxValue;
        int max = int.MinValue;
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            sum += currentNumber;

            if (currentNumber < min)
            {
                min = currentNumber;
            }
            if (currentNumber > max)
            {
                max = currentNumber;
            }
        }

        Console.WriteLine("min = {0}", min);
        Console.WriteLine("max = {0}", max);
        Console.WriteLine("sum = {0}", sum);
        Console.WriteLine("average = {0:N2}", sum / (double)n);
    }
}

