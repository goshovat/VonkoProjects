using System;
using System.Collections.Generic;

class Patterns
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[,] matrix = new int[count, count];

        for (int i = 0; i < count; i++)
        {
            string[] lineNumbers = Console.ReadLine().Split();

            for (int j = 0; j < count; j++)
            {
                matrix[i, j] = int.Parse(lineNumbers[j]);
            }
        }

        bool patternFound = false;
        long maxSum = 0;
        List<int[]> moves = new List<int[]> { new int[] { 0, 1 }, new int[] { 1, 0 } };

        for (int row = 0; row < count - 2; row++)
        {
            for (int col = 0; col < count - 4; col++)
            {
                long currentSum = 0;
                int patternCount = 1;
                int currentMove = 0;
                int lastValue = matrix[row, col];
                currentSum += (long)lastValue;

                int nextRow = row + moves[currentMove][0];
                int nextCol = col + moves[currentMove][1];

                while (matrix[nextRow, nextCol] == lastValue + 1)
                {
                    patternCount++;
                    lastValue = matrix[nextRow, nextCol];
                    currentSum += (long)lastValue;
                   
                    if (patternCount == 3)
                        currentMove = 1;
                    else if (patternCount == 5)
                        currentMove = 0;
                    else if (patternCount == 7)
                    {
                        if (currentSum > maxSum)
                            maxSum = currentSum;

                        patternFound = true;
                        break;
                    }

                    nextRow = nextRow + moves[currentMove][0];
                    nextCol = nextCol + moves[currentMove][1];
                }
            }
        }

        if (patternFound)
        {
            Console.WriteLine("YES {0}", maxSum);
        }
        else
        {
            long diagonalSum = 0;
            int row = 0; int col = 0;
            while (row < count && col < count)
            {
                diagonalSum += (long)matrix[row, col];
                row++;
                col++;
            }

            Console.WriteLine("NO {0}", diagonalSum);
        }
    }
}

