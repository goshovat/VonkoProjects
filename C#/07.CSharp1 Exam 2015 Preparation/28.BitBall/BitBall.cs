using System;

class BitBall
{
    private static int ROWS_COLS_COUNT = 8;
    private static char[,] grid = new char[ROWS_COLS_COUNT, ROWS_COLS_COUNT];

    static void Main()
    {
        FillGrid();

        //PrintGrid();

        int topScore = 0;
        int bottomScore = 0;

        PlayMatch(ref topScore, ref bottomScore);

        Console.WriteLine("{0}:{1}", topScore, bottomScore);
    }

    private static void FillGrid()
    {
        for (int row = 0; row < ROWS_COLS_COUNT * 2; row++)
        {
            int currentNumber = int.Parse(Console.ReadLine());
            uint mask = 1;

            for (int col = ROWS_COLS_COUNT - 1; col >= 0; col--)
            {
                if ((currentNumber & mask) != 0) 
                {
                    if (row < ROWS_COLS_COUNT) 
                    {
                        grid[row, col] = 'T';
                    }
                    else
                    {
                        if (grid[row - ROWS_COLS_COUNT, col] == default(char))
                            grid[row - ROWS_COLS_COUNT, col] = 'B';
                        else
                            grid[row - ROWS_COLS_COUNT, col] = default(char);
                    }
                }
                //else
                //    grid[row, col] = ' ';
                mask <<= 1;
            }
        }
    }

    private static void PlayMatch(ref int topScore, ref int bottomScore)
    {
        for (int row = 0; row < ROWS_COLS_COUNT; row++)
        {
            for (int col = 0; col < ROWS_COLS_COUNT; col++)
            {
                if (grid[row, col] != default(char)) 
                {
                    char currentPlayer = grid[row, col];
                    if (currentPlayer == 'T')
                    {
                        int currentRow = row;
                        while(currentRow + 1 < ROWS_COLS_COUNT
                            && grid[currentRow + 1, col] == default(char))
                        {
                            currentRow++;
                        }

                        if (currentRow == ROWS_COLS_COUNT - 1)
                            topScore++;
                    }
                    else if (currentPlayer == 'B')
                    {
                        int currentRow = row;
                        while (currentRow - 1 >= 0
                            && grid[currentRow - 1, col] == default(char))
                        {
                            currentRow--;
                        }

                        if (currentRow == 0)
                            bottomScore++;
                    }
                }
            }
        }
    }

    private static void PrintGrid()
    {
        for (int row = 0; row < ROWS_COLS_COUNT; row++)
        {
            for (int col = 0; col < ROWS_COLS_COUNT; col++)
            {
                if (grid[row, col] == default(char))
                    Console.Write('0' + " ");
                else
                    Console.Write(grid[row, col] + " ");
            }
            Console.WriteLine();
        }
    }
}
