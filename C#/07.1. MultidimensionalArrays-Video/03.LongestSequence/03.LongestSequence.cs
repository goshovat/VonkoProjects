using System;

class LongestSequence
{
    static string[,] testMatrix = {
                             {"ha", "ha", "g", "f"},
                             {"fo", "ha", "hi", "xx"},
                             {"xxx", "ho", "ha", "xx"},
                         };

    static string[,] testMatrix1 = {
                                    {"s", "qq", "s"},
                                    {"pp", "pp", "s"},
                                    {"pp", "qq", "s"},
                                };


    static void Main()
    {   
        int bestLen = 0;
        string bestString = "";

        for (int rows = 0; rows < testMatrix.GetLength(0); rows++)
        {
            for (int cols = 0; cols < testMatrix.GetLength(1); cols++)
            {
                int storeRow = rows;
                int storeCol = cols;

                //check horizontally
                int currentLen = 1;

                while (cols + 1 < testMatrix.GetLength(1) &&
                    testMatrix[rows, cols] == testMatrix[rows, cols + 1])
                {
                    currentLen++;
                    cols++;
                }

                if (currentLen > bestLen)
                {
                    bestLen = currentLen;
                    bestString = testMatrix[storeRow, storeCol];
                }

                //check vertically
                rows = storeRow;
                cols = storeCol;

                currentLen = 1;

                while (rows + 1 < testMatrix.GetLength(0) &&
                    testMatrix[rows, cols] == testMatrix[rows + 1, cols])
                {
                    currentLen++;
                    rows++;
                }

                if (currentLen > bestLen)
                {
                    bestLen = currentLen;
                    bestString = testMatrix[storeRow, storeCol];
                }

                //check diagonally
                rows = storeRow;
                cols = storeCol;

                currentLen = 1;

                while (rows + 1 < testMatrix.GetLength(0) && cols + 1 < testMatrix.GetLength(1)
                    && testMatrix[rows, cols] == testMatrix[rows + 1, cols + 1])
                {
                    currentLen++;
                    cols++;
                    rows++;
                }

                if (currentLen > bestLen)
                {
                    bestLen = currentLen;
                    bestString = testMatrix[storeRow, storeCol];
                }

                rows = storeRow;
                cols = storeCol;
            }
        }

        PrintResult(bestLen, bestString);
    }

    //tis method will print the result
    private static void PrintResult(int bestLen, string bestString)
    {
        for (int i = 0; i < bestLen; i++)
        {
            Console.Write(bestString + " ");
        }
        Console.WriteLine();
    }   
}

