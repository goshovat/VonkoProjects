using System;

class FillTheMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //first matrix
        int[,] matrix = new int[n, n];
        int number = 1;

        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = number;
                number++;
            }
        }
        PrintMatrix(matrix);

        //second matrix
        number = 1;

        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = number;
                    number++;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--)
                {
                    matrix[row, col] = number;
                    number++;
                }
            }
        };
        PrintMatrix(matrix);

        //third matrix
        number = 1;
        //first half
        for (int rows = n - 1; rows >= 0; rows--)
        {
            int storedRow = rows;
            int cols = 0;

            for (int diag = 0; diag < n - storedRow; diag++)
            {
                if (rows < n && cols < n)
                {
                    matrix[rows, cols] = number;
                    number++;

                    rows++;
                    cols++;
                }
            }
            rows = storedRow;
        }

        //second part
        for (int cols = 1; cols < n; cols++)
        {
            int storedCol = cols;
            int rows = 0;

            for (int diag = 0; diag < n - storedCol; diag++)
            {
                if (rows < n && cols < n)
                {
                    matrix[rows, cols] = number;
                    number++;

                    rows++;
                    cols++;
                }
            }
            cols = storedCol;
        }
        PrintMatrix(matrix);

        //fourth matrix
        matrix = new int[n, n];
        number = 1;
        string direction = "down";
        int rs = 0;
        int cls = 0;

        for (int i = 0; i < matrix.Length; i++)
        {
            matrix[rs, cls] = number;
            number++;

            switch (direction)
            {
                case "down":
                    if (rs + 1 < n && matrix[rs + 1, cls] == 0)
                    {
                        rs++;
                    }
                    else
                    {
                        cls++;
                        direction = "right";
                    }
                    break;

                case "right":
                    if (cls + 1 < n && matrix[rs, cls + 1] == 0)
                    {
                        cls++;
                    }
                    else
                    {
                        rs--;
                        direction = "up";
                    }
                    break;

                case "up":
                    if (rs - 1 >= 0 && matrix[rs - 1, cls] == 0)
                    {
                        rs--;
                    }
                    else
                    {
                        cls--;
                        direction = "left";
                    }
                    break;

                case "left":
                    if (cls - 1 >= 0 && matrix[rs, cls - 1] == 0)
                    {
                        cls--;
                    }
                    else
                    {
                        rs++;
                        direction = "down";
                    }
                    break;
            }
        }
        PrintMatrix(matrix);
    }

    //this method can print a matrix any time
    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col].ToString().PadLeft(3, ' '));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
