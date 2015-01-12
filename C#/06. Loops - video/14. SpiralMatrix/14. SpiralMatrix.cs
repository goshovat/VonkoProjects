using System;

class SpiralMatrix
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a positive integer N: ");
        int n = 0;

        try
        {
            n = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter a valid number!");
            return;
        }

        if (n < 20)
        {           
            int[,] matrix = new int[n, n];

            int row = 0;
            int col = 0;
            int direction = 0;

            for (int totalStep = 1; totalStep <= n * n; totalStep++)
            {
                matrix[row, col] = totalStep;

                switch (direction)
                {
                    //step right
                    case 0:
                        if (col < n - 1 && matrix[row, col + 1] == 0)
                        {
                            col++;
                        }
                        else
                        {
                            direction = (++direction) % 4;
                            row++;
                        }
                        break;
                    //step down
                    case 1:
                        if (row < n - 1 && matrix[row + 1, col] == 0)
                        {
                            row++;
                        }
                        else
                        {
                            direction = (++direction) % 4;
                            col--;
                        }
                        break;
                    //step left
                    case 2:
                        if (col > 0 && matrix[row, col - 1] == 0)
                        {
                            col--;
                        }
                        else
                        {
                            direction = (++direction) % 4;
                            row--;
                        }
                        break;
                    //step up 
                    case 3:
                        if (row > 0 && matrix[row - 1, col] == 0)
                        {
                            row--;
                        }
                        else
                        {
                            direction = (++direction) % 4;
                            col++;
                        }
                        break;
                }
            }

            for (int curRow = 0; curRow < n; curRow++)
            {
                for (int curCol = 0; curCol < n; curCol++)
                {
                    Console.Write(matrix[curRow, j].ToString().PadLeft(3));
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Enter a valid number!");
        }
    }
}

