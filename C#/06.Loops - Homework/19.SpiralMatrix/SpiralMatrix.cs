using System;

class SpiralMatrix
{
    static void Main()
    {
        Console.WriteLine("Enter a positive integer N: ");
        int n = int.Parse(Console.ReadLine());

        if (n < 20)
        {
            int[,] matrix = new int[n, n];

            int row = 0;
            int col = 0;
            int direction = 0;
            int totalSteps = n * n;

            //first fill the matrix
            for (int totalStep = 1; totalStep <= totalSteps; totalStep++)
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

            //print the matrix
            for (int curRow = 0; curRow < n; curRow++)
            {
                for (int curCol = 0; curCol < n; curCol++)
                {
                    Console.Write(matrix[curRow, curCol].ToString().PadLeft(3));
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
