using System;
using System.Collections.Generic;
using System.Linq;

class DogeCoins
{
    static void Main()
    {
        int[] dims = Console.ReadLine()
            .Split().Select(int.Parse).ToArray();
        int rows = dims[0];
        int cols = dims[1];

        int[,] grid = new int[rows, cols];
        int coinsCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < coinsCount; i++)
        {
            int[] coords = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            int coinRow = coords[0];
            int coinCol = coords[1];
            grid[coinRow, coinCol] += 1;
        }

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int firstPossOrigin = 0, seconPossOrigin = 0;

                if (col > 0)
                    firstPossOrigin = grid[row, col - 1];
                if (row > 0)
                    seconPossOrigin = grid[row - 1, col];

                grid[row, col] += Math.Max(firstPossOrigin, seconPossOrigin);
            }
        }

        Console.WriteLine(grid[rows - 1, cols - 1]);
    }
}
