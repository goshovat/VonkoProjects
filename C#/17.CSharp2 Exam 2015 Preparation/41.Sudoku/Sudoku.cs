using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Sudoku
{
    static void Main()
    {
        int[,] grid = new int[9, 9];

        for (int row = 0; row < 9; row++)
        {
            string line = Console.ReadLine();

            for (int col = 0; col < 9; col++)
            {
                if (line[col] != '-')
                    grid[row, col] = (int)(line[col] - '0');
            }
        }

        List<HashSet<int>> rowsMemory = new List<HashSet<int>>();
        List<HashSet<int>> colsMemory = new List<HashSet<int>>();
        List<HashSet<int>> squaresMemory = new List<HashSet<int>>();


        Console.WriteLine();
    }
}
