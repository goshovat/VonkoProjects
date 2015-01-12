using System;

class ReverseMatrix
{
    static void Main()
    {
        Console.WriteLine("Write the size of the matrix: ");
        int size = int.Parse(Console.ReadLine());
        int[,] matrix = new int[size, size];

        //call the method to fill the original matrix
        FillOriginalMatri(matrix, size);

        Console.WriteLine("The original matrix is: ");
        PrintMatrix(matrix);

        //now reverse the matrix
        int[,] reversedMatrix = new int[size, size];

        for (int rows = 0; rows < size; rows++)
        {
            for (int cols = 0; cols < size; cols++)
            {
                reversedMatrix[rows, cols] = matrix[size - cols - 1, rows];
            }
        }

        //print the reversed matrix
        Console.WriteLine("The new matrix is: ");
        PrintMatrix(reversedMatrix);
    }

    //define a method to fill our first matrix
    static void FillOriginalMatri(int[,] matrix, int size)
    {
        int row = size - 1;
        int col = size - 1;
        int storeCol = 0;
        int tempSize = size;
        int turns = 0;
        int number = 1;

        while (turns < size * size)
        {
            row = tempSize - 1;
            storeCol = col;

            while (col < size && row >= 0)
            {
                matrix[row, col] = number;
                number++;
                turns++;

                row--;
                col++;
            }
            col = storeCol - 1;

            if (col < 0)
            {
                col = 0;
                tempSize--;
            }
        }
    }

    //define a method to print the matrix
    static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }
}

