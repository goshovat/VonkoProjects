using System;

class SquareMatrixes
{
    static void Main()
    {
        //initialize the matrix
        Console.WriteLine("Enter the size of the matrix: ");
        int size = int.Parse(Console.ReadLine());

        ////prepare and print the first matrix      
        //int[,] matrix = new int[size, size];
        //int k = 1;

        //for (int col = 0; col < size; col++)
        //{
        //    for (int row = 0; row < size; row++)
        //    {
        //        matrix[row, col] = k;
        //        k++;
        //    }
        //}

        //Console.WriteLine();
        //Console.WriteLine(new string(' ', 10));
        //Console.WriteLine("The first matrix is: ");

        //for (int row = 0; row < size; row++)
        //{
        //    for (int col = 0; col < size; col++)
        //    {
        //        Console.Write((matrix[row, col] + "").PadLeft(4));
        //    }
        //    Console.WriteLine();
        //}

        ////prepare and print the second matrix
        //int[,] matrix1 = new int[size, size];
        //k = 1;

        //for (int col = 0; col < size; col++)
        //{
        //    if (col % 2 == 0)
        //    {
        //        for (int row = 0; row < size; row++)
        //        {
        //            matrix1[row, col] = k;
        //            k++;
        //        }
        //    }
        //    else
        //    {
        //        for (int row = size - 1; row >= 0; row--)
        //        {
        //            matrix1[row, col] = k;
        //            k++;
        //        }
        //    }
        //}


        //Console.WriteLine();
        //Console.WriteLine(new string(' ', 10));
        //Console.WriteLine("The second matrix is: ");

        //for (int row = 0; row < size; row++)
        //{
        //    for (int col = 0; col < size; col++)
        //    {
        //        Console.Write((matrix1[row, col] + "").PadLeft(4));
        //    }
        //    Console.WriteLine();
        //}

        //prepare and print the third matrix
        int[,] matrix2 = new int[size, size];
        int k = 1;

        for (int diag = 0; diag <= 2 * size - 1; diag++)
        {
            int row = size - 1 - diag;
            if (row < 0)
            {
                row = 0;
            }
            int col = 0;

            if (diag >= size)
            {
                col = diag - size + 1;
            }

            while (row < size && col < size)
            {
                matrix2[row, col] = k;
                k++;
                row++;
                col++;
            }
        }

        Console.WriteLine();
        Console.WriteLine(new string(' ', 10));
        Console.WriteLine("The third matrix is: ");

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Console.Write((matrix2[row, col] + "").PadLeft(4));
            }
            Console.WriteLine();
        }

        //prepare and print the fourth matrix
        int[,] matrix3 = new int[size, size];
        k = 1;
        string direction = "down";
        int rows = 0;
        int cols = 0;

        for (int i = 0; i < size * size; i++)
        {
            matrix3[rows, cols] = k;
            k++;

            switch (direction)
            {
                case "down":                    
                    if (rows + 1 <= size - 1 && matrix3[rows +1, cols] == 0)
                    {
                        rows++;
                    }
                    else
                    {
                        direction = "right";
                        cols++;
                    }
                    break;

                case "right":
                    if (cols + 1 <= size - 1 && matrix3[rows, cols + 1] == 0)
                    {
                        cols++;
                    }
                    else
                    {
                        direction = "up";
                        rows--;
                    }
                    break;

                case "up":
                    if (rows - 1 >= 0 && matrix3[rows - 1, cols] == 0)
                    {
                        rows--;
                    }
                    else
                    {
                        direction = "left";
                        cols--;
                    }
                    break;

                case "left":
                    if (cols - 1 >= 0 && matrix3[rows, cols - 1] == 0)
                    {
                        cols--;
                    }
                    else
                    {
                        direction = "down";
                        rows++;
                    }
                    break;
            }
        }

        Console.WriteLine();
        Console.WriteLine(new string(' ', 10));
        Console.WriteLine("The fourth matrix is: ");

        for (int row = 0; row < size; row++)
        {
            for (int col = 0; col < size; col++)
            {
                Console.Write((matrix3[row, col] + "").PadLeft(4));
            }
            Console.WriteLine();
        }
    }
}
