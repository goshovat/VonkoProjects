using System;

class Trapezoid
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int widthTopSide = n;
        int widthBottomSide = 2 * n;
        int height = n + 1;
        int numberDots = widthTopSide;

        for (int row = 0; row < height; row++)
        {
            for (int i = 0; i < numberDots; i++)
            {
                Console.Write('.');
            }
            if (row == 0)
            {
                for (int i = 0; i < widthTopSide; i++)
                    Console.Write('*');
            }
            else if (row == height - 1)
            {
                for (int i = 0; i < widthBottomSide; i++)
                    Console.Write('*');
            }
            else
            {
                Console.Write('*');
                for (int i = 0; i < widthBottomSide - numberDots - 2; i++)
                    Console.Write('.');

                Console.Write('*');
            }
            numberDots--;
            Console.WriteLine();
        }
    }
}
