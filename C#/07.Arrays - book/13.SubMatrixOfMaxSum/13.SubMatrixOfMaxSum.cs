using System;

class SubMatrixOfMaxSum
{
    static void Main()
    {
        //initialize the matrix
        Console.WriteLine("Enter the height of the matrix: ");
        int height = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the width of the matrix: ");
        int width = int.Parse(Console.ReadLine());

        if (height < 3 || width < 3)
        {
            Console.WriteLine("Enter a matrix with at least 3 rows and three cols!");

            //restart the program
            Main();
        }

        int[,] matrix = new int[height, width];

        //fill the matrix
        Console.WriteLine("Enter the integers of the matrix: ");

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.WriteLine("Enter element {0}, {1}: ", row, col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }

        //print the matrix so it is easier for testing
        Console.WriteLine();
        Console.WriteLine("The matrix is: ");
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.Write(matrix[row, col] + "  ");
            }
            Console.WriteLine();
        }

        //now find the biggest sum
        int biggestSum = int.MinValue;
        int currentSum = 0;
        int biggestStartRow = 0;
        int biggestStartCol = 0;

        for (int row = 0; row < height-2; row++)
        {
            for (int col = 0; col < width-2; col++)
            {
                currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                            + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                            + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                if (currentSum > biggestSum)
                {
                    biggestSum = currentSum;
                    biggestStartRow = row;
                    biggestStartCol = col;
                }
            }
        }

        //print the biggest sum and the submatrix
        Console.WriteLine();
        Console.WriteLine("The biggest sum is: {0}", biggestSum);

        Console.WriteLine("The submatrix with the biggest sum is: ");

        for (int row = biggestStartRow; row < biggestStartRow + 3; row++)
        {
            for (int col = biggestStartCol; col < biggestStartCol + 3; col++)
            {
                Console.Write(matrix[row, col] + "  ");
            }

            Console.WriteLine();
        }
    }
}
