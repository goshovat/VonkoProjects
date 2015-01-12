using System;

class Matrix
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a positive integer N (N < 20):");
        int n = 0;

        try
        {
            n = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
            return;
        }

        if (n < 20)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = i; j <= n + i - 1; j++)
                {
                    Console.Write(j.ToString().PadLeft(3));
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}
