using System;
using System.Linq;

class _3DLines
{
    static void Main()
    {
        int[] dims = Console.ReadLine().Split()
            .Select(int.Parse).ToArray();

        int width = dims[0];
        int height = dims[1];
        int depth = dims[2];

        char[,, ]cuboid = new char[width, height, depth];

        for (int row = 0; row < height; row++)
        {
            string[] layers = Console.ReadLine().Split(
                new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int layer = 0; layer < depth; layer++)
            {
                string curLayer = layers[layer];

                for (int col = 0; col < width; col++)
                {
                    cuboid[col, row, layer] = curLayer[col];
                }
            }
        }

        int longestSize = -1;
        int longestCount = 0;

        for (int row = 0; row < height; row++)
        {
            for (int layer = 0; layer < depth; layer++)
            {
                for (int col = 0; col < width; col++)
                {
                    char currentCube = cuboid[col, row, layer];
                    int currentSize = 1;

                    //check right
                    int tempCol = col + 1;
                    while (tempCol < width && cuboid[tempCol, row, layer] == currentCube)
                    {
                        currentSize++;
                        tempCol++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check up
                    currentSize = 1;
                    int tempRow = row + 1;
                    while (tempRow < height && cuboid[col, tempRow, layer] == currentCube)
                    {
                        currentSize++;
                        tempRow++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check back
                    currentSize = 1;
                    int tempLayer = layer + 1;
                    while (tempLayer < depth && cuboid[col, row, tempLayer] == currentCube)
                    {
                        currentSize++;
                        tempLayer++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check up-right
                    currentSize = 1;
                    tempCol = col + 1;
                    tempRow = row + 1;
                    while (tempCol < width && tempRow < height && cuboid[tempCol, tempRow, layer] == currentCube)
                    {
                        currentSize++;
                        tempCol++;
                        tempRow++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check up-left
                    currentSize = 1;
                    tempCol = col - 1;
                    tempRow = row + 1;
                    while (tempCol >= 0 && tempRow < height && cuboid[tempCol, tempRow, layer] == currentCube)
                    {
                        currentSize++;
                        tempCol--;
                        tempRow++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check up-back
                    currentSize = 1;
                    tempRow = row + 1;
                    tempLayer = layer + 1;
                    while (tempRow < height && tempLayer < depth && cuboid[col, tempRow, tempLayer] == currentCube)
                    {
                        currentSize++;
                        tempRow++;
                        tempLayer++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check up-forward
                    currentSize = 1;
                    tempRow = row + 1;
                    tempLayer = layer - 1;
                    while (tempRow < height && tempLayer >=0 && cuboid[col, tempRow, tempLayer] == currentCube)
                    {
                        currentSize++;
                        tempRow++;
                        tempLayer--;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check back-right
                    currentSize = 1;
                    tempCol = col + 1;
                    tempLayer = layer + 1;
                    while (tempCol < width && tempLayer < depth && cuboid[tempCol, row, tempLayer] == currentCube)
                    {
                        currentSize++;
                        tempCol++;
                        tempLayer++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check back-left
                    currentSize = 1;
                    tempCol = col - 1;
                    tempLayer = layer + 1;
                    while (tempCol >=0 && tempLayer < depth && cuboid[tempCol, row, tempLayer] == currentCube)
                    {
                        currentSize++;
                        tempCol--;
                        tempLayer++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check up-back-right
                    currentSize = 1;
                    tempCol = col + 1;
                    tempRow = row + 1;
                    tempLayer = layer + 1;
                    while (tempCol < width && tempRow < height && tempLayer < depth 
                        && cuboid[tempCol, tempRow, tempLayer] == currentCube)
                    {
                        currentSize++;
                        tempCol++;
                        tempRow++;
                        tempLayer++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check up-back-left
                    currentSize = 1;
                    tempCol = col - 1;
                    tempRow = row + 1;
                    tempLayer = layer + 1;
                    while (tempCol >= 0 && tempRow < height && tempLayer < depth
                        && cuboid[tempCol, tempRow, tempLayer] == currentCube)
                    {
                        currentSize++;
                        tempCol--;
                        tempRow++;
                        tempLayer++;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check up-right-forwad
                    currentSize = 1;
                    tempCol = col + 1;
                    tempRow = row + 1;
                    tempLayer = layer - 1;
                    while (tempCol < width && tempRow < height && tempLayer >= 0
                        && cuboid[tempCol, tempRow, tempLayer] == currentCube)
                    {
                        currentSize++;
                        tempCol++;
                        tempRow++;
                        tempLayer--;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }

                    //check up-left-forwad
                    currentSize = 1;
                    tempCol = col - 1;
                    tempRow = row + 1;
                    tempLayer = layer - 1;
                    while (tempCol >= 0 && tempRow < height && tempLayer >= 0
                        && cuboid[tempCol, tempRow, tempLayer] == currentCube)
                    {
                        currentSize++;
                        tempCol--;
                        tempRow++;
                        tempLayer--;
                    }
                    if (currentSize > 1 && currentSize > longestSize)
                    {
                        longestSize = currentSize;
                        longestCount = 1;
                    }
                    else if (currentSize > 1 && currentSize == longestSize)
                    {
                        longestCount++;
                    }
                }
            }
        }

        if (longestSize == -1)
            Console.WriteLine(longestSize);
        else
            Console.WriteLine(longestSize + " " + longestCount);
    }
}

