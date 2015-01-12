using System;

class SquareWithMaxSum
{
    static void Main()
    {
        //int[,] testMatrix = {
        //                     {1, 3, 5, 6, 7, 8},
        //                     {4, 5, 70, 8, 9, 10},
        //                     {11, 12, 13, 14, 15, 18},
        //                     {16, 17, 18, 19, 20, 19}
        //                 };

        int[,] testMatrix = {
                             {0, 0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0, 0},
                             {0, 0, 0, 0, 0, 0},
                         };

        int maxSum = 0;
        int maxRow = -1;
        int maxCol = -1;

        //find the biggest square
        for (int row = 0; row < testMatrix.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < testMatrix.GetLength(1) - 2; col++)
            {
                int currentMaxSum = 0;

                currentMaxSum = testMatrix[row, col] + testMatrix[row, col + 1] + testMatrix[row, col + 2] +
                                testMatrix[row + 1, col] + testMatrix[row + 1, col + 1] + testMatrix[row + 1, col + 2] +
                                testMatrix[row + 2, col] + testMatrix[row + 2, col + 1] + testMatrix[row + 2, col + 2];

                if (currentMaxSum > maxSum)
                {
                    maxSum = currentMaxSum;
                    maxRow = row;
                    maxCol = col;
                }
            }
        }

        if (maxRow != -1 && maxCol != -1)
        {
            //print the result
            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int col = maxCol; col < maxCol + 3; col++)
                {
                    Console.Write(testMatrix[row, col].ToString().PadLeft(4, ' '));
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("All sums are zero!");
        }
    }
}

