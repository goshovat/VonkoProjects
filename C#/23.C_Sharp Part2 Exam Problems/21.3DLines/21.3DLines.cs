namespace _3DLines
{
    using System;

    public class _3DLines
    {
        private static char[, ,] cuboid;
        private static int width;
        private static int height;
        private static int depth;
        private static int maxLen = 1;
        private static int bestNumberLines = 0;

        static void Main()
        {
            string[] sizes = Console.ReadLine().Split();
            width = int.Parse(sizes[0]);
            height = int.Parse(sizes[1]);
            depth = int.Parse(sizes[2]);
            cuboid = new char[width, height, depth];

            GetInput();

            FindMaxLines();

            if (bestNumberLines != 0)
                Console.WriteLine("{0} {1}", maxLen, bestNumberLines);
            else
                Console.WriteLine(-1);
        }

        private static void GetInput()
        {
            for (int row = 0; row < height; row++)
            {
                string[] currentRow = Console.ReadLine().Split(
                    new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries
                    );
                for (int layer = 0; layer < depth; layer++)
                {
                    string currentLayer = currentRow[layer];
                    for (int col = 0; col < width; col++)
                    {
                        cuboid[col, row, layer] = currentLayer[col];
                    }
                }
            }
        }

        private static void FindMaxLines()
        {
            int currentLine = 1;

            for (int row = 0; row < height; row++)
            {
                for (int layer = 0; layer < depth; layer++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        char currentCube = cuboid[col, row, layer];

                        currentLine = CheckLeft(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckFront(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckDown(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckFrontLeft(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckBacktLeft(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckUpLeft(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckDownLeft(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckDownFront(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckDownBack(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckDownFrontLeft(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckDownBackLeft(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckDownFrontRight(col, row, layer);
                        CompareLengths(currentLine);

                        currentLine = CheckDownBackRight(col, row, layer);
                        CompareLengths(currentLine);
                    }
                }
            }
        }

        private static int CheckLeft(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (col - 1 >= 0 && cuboid[col - 1, row, layer] == currentCube)
            {
                col--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckFront(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (layer - 1 >= 0 && cuboid[col, row, layer - 1] == currentCube)
            {
                layer--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckDown(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (row - 1 >= 0 && cuboid[col, row - 1, layer] == currentCube)
            {
                row--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckFrontLeft(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (layer - 1 >= 0 && col - 1 >= 0 &&
                cuboid[col - 1, row, layer - 1] == currentCube)
            {
                layer--;
                col--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckBacktLeft(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (layer + 1 < depth && col - 1 >= 0 &&
                cuboid[col - 1, row, layer + 1] == currentCube)
            {
                layer++;
                col--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckUpLeft(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (row + 1 < height && col - 1 >= 0 &&
                cuboid[col - 1, row + 1, layer] == currentCube)
            {
                row++;
                col--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckDownLeft(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (row - 1 >= 0 && col - 1 >= 0 &&
                cuboid[col - 1, row - 1, layer] == currentCube)
            {
                row--;
                col--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckDownFront(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (row - 1 >= 0 && layer - 1 >= 0 &&
                cuboid[col, row - 1, layer - 1] == currentCube)
            {
                row--;
                layer--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckDownBack(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (row - 1 >= 0 && layer + 1 < depth &&
                cuboid[col, row - 1, layer + 1] == currentCube)
            {
                row--;
                layer++;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckDownFrontLeft(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (row - 1 >= 0 && layer - 1 >= 0 && col - 1 >= 0 &&
                cuboid[col - 1, row - 1, layer - 1] == currentCube)
            {
                row--;
                layer--;
                col--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckDownBackLeft(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (row - 1 >= 0 && layer + 1 < depth && col - 1 >= 0 &&
                cuboid[col - 1, row - 1, layer + 1] == currentCube)
            {
                row--;
                layer++;
                col--;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckDownFrontRight(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (row - 1 >= 0 && layer - 1 >= 0 && col + 1 < width &&
                cuboid[col + 1, row - 1, layer - 1] == currentCube)
            {
                row--;
                layer--;
                col++;
                currentLine++;
            }
            return currentLine;
        }

        private static int CheckDownBackRight(int col, int row, int layer)
        {
            int currentLine =1;
            char currentCube = cuboid[col, row, layer];
            while (row - 1 >= 0 && layer + 1 < depth && col + 1 < width &&
                cuboid[col + 1, row - 1, layer + 1] == currentCube)
            {
                row--;
                layer++;
                col++;
                currentLine++;
            }
            return currentLine; 
        }

        private static void CompareLengths(int currentLine)
        {
            if (currentLine > maxLen)
            {
                maxLen = currentLine;
                bestNumberLines = 1;
            }
            else if (currentLine == maxLen && currentLine != 1)
            {
                bestNumberLines++;
            }
        }
    }
}
