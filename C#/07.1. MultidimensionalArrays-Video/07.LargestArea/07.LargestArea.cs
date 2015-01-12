using System;

class LargestArea
{
    static int[,] testMatrix = {
                          {1,3,2,3,3,3},
                          {3,3,3,2,4,3},
                          {4,3,1,3,3,3},
                          {4,3,1,3,3,1},
                          {4,3,3,3,1,1},
                         };

    static void Main()
    {
        int currentLen = 1;
        int bestLen = 1;
        int bestRow = 0;
        int bestCol = 0;

        //start the search
        for (int row = 0, height = testMatrix.GetLength(0); row < height; row++)
        {
            for (int col = 0, width = testMatrix.GetLength(1); col < width; col++)
            {
                int[,] workingMatrix = (int[,])testMatrix.Clone();
                int count = 1;
                int currentElement = workingMatrix[row, col];

                currentLen = CheckArea(row, col, count);

                if (currentLen > bestLen) 
                {
                    bestLen = currentLen;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        Console.WriteLine("The longest area consists of: {0} elements", bestLen);
        //Console.WriteLine(bestRow);
        //Console.WriteLine(bestCol);
    }

    private static int CheckArea(int row, int col, int count)
    {
        int currentNumber = testMatrix[row, col];

        int height = testMatrix.GetLength(0);
        int width = testMatrix.GetLength(1);

        int maskNumber = 9;

        while (maskNumber == currentNumber)
        {
            maskNumber--;
        }

        testMatrix[row, col] = maskNumber; 

        int resultUp = 0;
        int resultRight = 0;
        int resultDown = 0;
        int resultLeft = 0;
        int result = count;

        //check up
        if (row > 0 && testMatrix[row - 1, col] == currentNumber)
        {
            resultUp = CheckArea(row - 1, col, 1);
        }

        //check right
        if (col + 1 < width && testMatrix[row, col + 1] == currentNumber)
        {
            resultRight = CheckArea(row, col + 1, 1);
        }

        //check down
        if (row + 1 < height && testMatrix[row + 1, col] == currentNumber)
        {
            resultDown = CheckArea(row + 1, col, 1);
        }

        //check left
        if (col > 0 && testMatrix[row, col - 1] == currentNumber)
        {
            resultLeft = CheckArea(row, col - 1, 1);
        }

        result += resultUp + resultRight + resultDown + resultLeft;

        return result;
    }
}

