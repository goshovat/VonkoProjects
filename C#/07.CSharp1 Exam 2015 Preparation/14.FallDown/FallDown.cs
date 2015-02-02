using System;

class FallDown
{
    private const int ROWS_COLS_COUNT = 8;
    private static int[,] grid = new int[ROWS_COLS_COUNT, ROWS_COLS_COUNT];

    static void Main()
    {
        FillGrid();

        FallDownBits();

        //PrintGrid();

        PrintResult();
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

    //private static void PrintGrid()
    //{
    //    for (int row = 0; row < ROWS_COLS_COUNT; row++)
    //    {
    //        for (int col = 0; col < ROWS_COLS_COUNT; col++)
    //        {
    //            Console.Write(grid[row, col] + " ");
    //        }
    //        Console.WriteLine();
    //    }
    //}

    private static void FallDownBits()
    {
        for (int row = ROWS_COLS_COUNT - 1; row >= 0; row--)
        {
            for (int col = 0; col < ROWS_COLS_COUNT; col++)
            {
                if (grid[row, col] == 1 && row + 1 < ROWS_COLS_COUNT &&
                    grid[row + 1, col] == 0)
                    DropBit(row, col);
            }
        }
    }

    private static void DropBit(int row, int col)
    {
        grid[row, col] = 0;
        row++;
        while (row < ROWS_COLS_COUNT && grid[row, col] == 0)
            row++;

        row--;
        grid[row, col] = 1;
    }

    private static void PrintResult()
    {
        for (int row = 0; row < ROWS_COLS_COUNT; row++)
        {
            int currentNumber = 0;
            int mask = 1;

            for (int col = ROWS_COLS_COUNT - 1; col >= 0; col--)
            {
                if (grid[row, col] == 1)
                    currentNumber |= mask;

                mask <<= 1;
            }

            Console.WriteLine(currentNumber);
        }
    }
}
