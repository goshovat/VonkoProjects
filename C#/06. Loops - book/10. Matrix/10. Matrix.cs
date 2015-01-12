using System;

class Matrix
{
    static void Main()
    {
        Console.Write("Enter an integer for [1 to 20]: ");
        sbyte n = sbyte.Parse(Console.ReadLine());

        if (n <= 20 && n > 0)
        {
            for (sbyte i = 1; i <= n; i++)
            {
                for (sbyte j = i; j < i + n; j++)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number!");
        }
    }
}

