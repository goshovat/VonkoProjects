using System;

class PrintNumbers1toN
{
    static void Main()
    {
        Console.WriteLine("Write a positive integer n: ");
        string input = Console.ReadLine();
        uint n;
        Console.WriteLine();

        if (uint.TryParse(input, out n))
        {
            Console.WriteLine("The numbers from 1 to {0} are: ", n);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Please enter valid positive integer!");
            Console.WriteLine();
            Main();
        }
    }
}

