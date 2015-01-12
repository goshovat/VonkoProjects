using System;

class EqualStringElements
{
    static void Main()
    {
        //initialize the matrix
        Console.WriteLine("Enter the height of the matrix: ");
        int height = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the width of the matrix: ");
        int width = int.Parse(Console.ReadLine());

        string[,] matrix = new string[height, width];

        //fill the matrix
        Console.WriteLine("Enter the integers of the matrix: ");

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                Console.WriteLine("Enter element {0}, {1}: ", row, col);
                matrix[row, col] = Console.ReadLine();
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

        //now find the largest sequence
        int currentSequence = 0;
        int largestSequence = 0;
        string mostCommonString = "";

        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                currentSequence = 1;

                //check the horizontal
                while (col + 1 < width && matrix[row, col + 1] == matrix[row, col])
                {
                    currentSequence++;
                    col++;
                }

                if (currentSequence > largestSequence)
                {
                    largestSequence = currentSequence;
                    mostCommonString = matrix[row, col];
                }
                currentSequence = 1;

                //check the vertical

                while (row + 1 < height && matrix[row + 1, col] == matrix[row, col])
                {
                    currentSequence++;
                    row++;
                }

                if (currentSequence > largestSequence)
                {
                    largestSequence = currentSequence;
                    mostCommonString = matrix[row, col];
                }
                currentSequence = 1;

                //check the diagonal

                while (row + 1 < height && col + 1 < width && matrix[row + 1, col + 1] == matrix[row, col])
                {
                    currentSequence++;
                    row++;
                    col++;
                }

                if (currentSequence > largestSequence)
                {
                    largestSequence = currentSequence;
                    mostCommonString = matrix[row, col];
                }
            }
        }

        //print the largest sequece
        Console.WriteLine();
        Console.WriteLine("largest {0} times", largestSequence);
        Console.WriteLine("The largest sequence is: ");

        for (int i = 0; i < largestSequence; i++)
        {
            Console.Write(mostCommonString + " ");
        }

        Console.WriteLine();
    }
}

