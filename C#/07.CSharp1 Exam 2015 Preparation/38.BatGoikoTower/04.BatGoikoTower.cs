using System;

class BatGoikoTower
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int baseOffset = 1;
        int previousRow = 0;

        for (int row = 0; row < n; row++)
        {
            Console.Write(new string('.', n - row - 1));
            Console.Write('/');
            if (row == previousRow + baseOffset)
            {
                previousRow = row;
                baseOffset++;
                Console.Write(new string('-', 2* row));
            }
            else
            {
                Console.Write(new string('.', 2 * row));
            }
            Console.Write('\\');
            Console.Write(new string('.', n - row - 1));
            Console.WriteLine();
        }
    }
}

