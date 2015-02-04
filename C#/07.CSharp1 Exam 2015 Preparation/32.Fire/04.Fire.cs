using System;

class Fire
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        //the top half of the fire
        for (int row = 0; row < n / 2; row++)
        {
            Console.Write(new string('.', n / 2 - row - 1));
            Console.Write("#");
            Console.Write(new string('.', 2 * row));
            Console.Write("#");
            Console.Write(new string('.', n / 2 - row - 1));

            Console.WriteLine();
        }

        //the bottom half of the fire
        int rowDiff = 2;
        for (int row = 0; row < n / 4; row++)
        {
            Console.Write(new string('.', row));
            Console.Write("#");
            Console.Write(new string('.', n - rowDiff));
            Console.Write("#");
            Console.Write(new string('.', row));

            rowDiff += 2;
            Console.WriteLine();
        }

        //the middle line
        Console.Write(new string('-', n));
        Console.WriteLine();

        //the handle of the torch
        for (int row = 0; row < n / 2; row++)
        {
            Console.Write(new string('.', row));
            Console.Write(new string('\\', n / 2 - row));
            Console.Write(new string('/', n / 2 - row));
            Console.Write(new string('.', row));
            Console.WriteLine();
        }
    }
}

