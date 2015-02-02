using System;

class FormulaBit
{
    private const int ROWS_COLS_COUNT = 8;
    private static int[,] grid = new int[ROWS_COLS_COUNT, ROWS_COLS_COUNT];

    static void Main()
    {
        FillGrid();

        //PrintGrid();

        int row = 0;
        int col = ROWS_COLS_COUNT - 1;

        string direction = "south";
        string lastDirection = "south";

        int numberTurns = 0;
        int trackLength = 0;

        if (grid[row, col] == 1)
        {
            Console.WriteLine("No {0}", trackLength);
        }
        else
        {
            trackLength++;
            bool IsFinished = false;

            while (!IsFinished)
            {
                if (row == ROWS_COLS_COUNT - 1 && col == 0)
                {
                    Console.WriteLine("{0} {1}", trackLength, numberTurns);
                    break;
                }

                switch (direction)
                {
                    case "south":
                        if (row + 1 < ROWS_COLS_COUNT && grid[row + 1, col] == 0)
                        {
                            row++;
                            trackLength++;
                        }
                        else if (col - 1 >= 0 && grid[row, col - 1] == 0)
                        {
                            direction = "west";
                            trackLength++;
                            numberTurns++;
                            col--;
                        }
                        else
                        {
                            Console.WriteLine("No {0}", trackLength);
                            IsFinished = true;
                        }
                        break;
                    case "west":
                        if (col - 1 >= 0 && grid[row, col - 1] == 0)
                        {
                            col--;
                            trackLength++;
                        }
                        else if (lastDirection == "south" &&
                            row - 1 >= 0 && grid[row - 1, col] == 0)
                        {
                            direction = "north";
                            lastDirection = "north";
                            trackLength++;
                            numberTurns++;
                            row--;
                        }
                        else if (lastDirection == "north" &&
                            row + 1 < ROWS_COLS_COUNT && grid[row + 1, col] == 0)
                        {
                            direction = "south";
                            lastDirection = "south";
                            trackLength++;
                            numberTurns++;
                            row++;
                        }
                        else
                        {
                            Console.WriteLine("No {0}", trackLength);
                            IsFinished = true;
                        }
                        break;
                    case "north":
                        if (row - 1 >= 0 && grid[row - 1, col] == 0)
                        {
                            row--;
                            trackLength++;
                        }
                        else if (col - 1 >= 0 && grid[row, col - 1] == 0)
                        {
                            direction = "west";
                            trackLength++;
                            numberTurns++;
                            col--;
                        }
                        else
                        {
                            Console.WriteLine("No {0}", trackLength);
                            IsFinished = true;
                        }
                        break;
                }
            }
        }
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

