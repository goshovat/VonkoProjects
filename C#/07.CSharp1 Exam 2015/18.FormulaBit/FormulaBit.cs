using System;

class FormulaBit
{
    private const int ROWS_COLS_COUNT = 8;
    private static int[,] grid = new int[ROWS_COLS_COUNT, ROWS_COLS_COUNT];

    static void Main()
    {
        FillGrid();

        PrintGrid();
    }

    private static void FillGrid()
    {
        for (int row = 0; row < ROWS_COLS_COUNT; row++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            uint mask = 1;

            for (int col = ROWS_COLS_COUNT - 1; col >= 0; col--)
            {
                if ((currentNumber & mask) != 0)
                    grid[row, col] = 1;
                else
                    grid[row, col] = 0;

                mask <<= 1;
            }
        }
    }

    private static void PrintGrid()
    {
        for (int row = 0; row < ROWS_COLS_COUNT; row++)
        {
            for (int col = 0; col < ROWS_COLS_COUNT; col++)
            {
                Console.Write(grid[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}

