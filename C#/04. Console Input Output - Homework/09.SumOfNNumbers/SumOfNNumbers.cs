using System;

class SumOfNNumbers
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a number n:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Now enter {0} numbers to see their sum:", n);

        double sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += double.Parse(Console.ReadLine());
        }

        Console.WriteLine("The sum is: {0}", sum);
    }
}
