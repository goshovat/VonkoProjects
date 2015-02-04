using System;

class Cube
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int width = n;
        int height = n;

        //build the top half
        int spaces = n - 1;
        for (int row = 0; row < height; row++)
        {
            for (int space = 0; space < spaces; space++)
                Console.Write(" ");

            if (row == 0)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(':');
            }
            else
            {
                Console.Write(':');

                if (row != height - 1)
                {
                    for (int i = 0; i < n - 2; i++)
                        Console.Write('/');
                }
                else
                {
                    for (int i = 0; i < n - 2; i++)
                        Console.Write(':');
                }

                Console.Write(':');
                for (int i = 0; i < 2 * width - spaces - 4 - (n - 2); i++)
                    Console.Write('X');

                Console.Write(':');
            }
            spaces--;
            Console.WriteLine();
        }
        //build the bottom half
        spaces = n - 2;
        int hixes = n - 3;
        for (int row = 0; row < height - 1; row++)
        {
            if (row != height - 2)
            {
                Console.Write(':');
                for (int i = 0; i < spaces; i++)
                    Console.Write(' ');

                Console.Write(':');
                for (int i = 0; i < hixes; i++)
                    Console.Write('X');

                Console.Write(':');
                hixes--;
            }
            else
            {
                for (int i = 0; i < width; i++)
                    Console.Write(':');
            }
            Console.WriteLine();
        }
    }
}
