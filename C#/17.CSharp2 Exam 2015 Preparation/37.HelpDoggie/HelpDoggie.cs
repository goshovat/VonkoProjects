using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class HelpDoggie
{
    static void Main()
    {
        string[] sizes = Console.ReadLine().Split();
        int rows = int.Parse(sizes[0]);
        int cols = int.Parse(sizes[1]);

        string[] foodCoords = Console.ReadLine().Split();
        int foodRow = int.Parse(foodCoords[0]);
        int foodCol = int.Parse(foodCoords[1]);

        BigInteger[,] grid = new BigInteger[rows, cols];
        int enemies = int.Parse(Console.ReadLine());

        for (int i = 0; i < enemies; i++)
        {
            string[] enemyCoords = Console.ReadLine().Split();
            int enemyRow = int.Parse(enemyCoords[0]);
            int enemyCol = int.Parse(enemyCoords[1]);

            grid[enemyRow, enemyCol] = -1;
        }

        //start fiiling the grid with number of possible paths to every cell
        grid[0, 0] = 1;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (grid[row, col] == -1)
                    continue;

                if (col > 0 && grid[row, col - 1] != -1)
                    grid[row, col] += grid[row, col - 1];//check if there is a path from left
                if (row > 0 && grid[row - 1, col] != -1)
                    grid[row, col] += grid[row - 1, col];

                if (row == foodRow && col == foodCol)
                    break;
            }
        }

        Console.WriteLine(grid[foodRow, foodCol]);
    }
}
