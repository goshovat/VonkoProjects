namespace _3DSlides
{
    using System;
    using System.IO;

    class _3DSlides
    {
        private static string[, ,] cube;
        private static int width, height, depth;
        private static int ballCol, ballRow, ballDepth;
        private static void Main()
        {
            GetInput();

            DropBall();
        }

        private static void GetInput()
        {
            //StreamReader reader = new StreamReader("input1.txt");
            string[] cubeSizes = Console.ReadLine().Split();
            width = int.Parse(cubeSizes[0]);
            height = int.Parse(cubeSizes[1]);
            depth = int.Parse(cubeSizes[2]);

            cube = new string[width, height, depth];

            for (int row = 0; row < height; row++)
            {
                string[] currentRow = Console.ReadLine().Split(
                    new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                for (int layer = 0; layer < depth; layer++)
                {
                    string currentLayer = currentRow[layer].Trim();
                    string[] cells = currentLayer.Split(
                        new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int col = 0; col < width; col++)
                    {
                        cube[col, row, layer] = cells[col];
                    }
                }
            }
            string[] startPositions = Console.ReadLine().Split();

            ballCol = int.Parse(startPositions[0]);
            ballRow = 0;
            ballDepth = int.Parse(startPositions[1]);
        }

        private static void DropBall()
        {
            while (true)
            {
                string currentCell = cube[ballCol, ballRow, ballDepth];
                string[] cellEntities = currentCell.Split(
                    new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = cellEntities[0];
                switch (command)
                {
                    case "E":
                        if (ballRow == height - 1)
                        {
                            LeaveCube("Yes", ballCol, ballRow, ballDepth);
                            return;
                        }
                        ballRow++;
                        break;

                    case "B":
                        LeaveCube("No", ballCol, ballRow, ballDepth);
                        return;

                    case "T":
                        int newBallCol = int.Parse(cellEntities[1]);
                        if (newBallCol < 0 || newBallCol >= width)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            return;
                        }
                        int newBallDepth = int.Parse(cellEntities[2]);
                        if (newBallDepth < 0 || newBallDepth >= depth)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            return;
                        }
                        ballCol = newBallCol;
                        ballDepth = newBallDepth;
                        break;

                    case "S":
                        ProcessSlide(cellEntities[1]);
                        break;
                }
            }
        }

        private static void ProcessSlide(string directions)
        {
            if (ballRow == height - 1)
            {
                LeaveCube("Yes", ballCol, ballRow, ballDepth);
                Environment.Exit(0);
            }
           
                switch (directions)
                {
                    case "L":
                        if (ballCol == 0)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            Environment.Exit(0);
                        }
                        ballCol--;
                        break;
                    case "R":
                        if (ballCol == width - 1)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            Environment.Exit(0);
                        }
                        ballCol++;
                        break;
                    case "F":
                        if (ballDepth == 0)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            Environment.Exit(0);
                        }
                        ballDepth--;
                        break;
                    case "B":
                        if (ballDepth == depth - 1)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            Environment.Exit(0);
                        }
                        ballDepth++;
                        break;
                    case "FL":
                        if (ballDepth == 0 || ballCol == 0)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            Environment.Exit(0);
                        }
                        ballDepth--;
                        ballCol--;
                        break;

                    case "FR":
                        if (ballDepth == 0 || ballCol == width - 1)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            Environment.Exit(0);
                        }
                        ballDepth--;
                        ballCol++;
                        break;

                    case "BL":
                        if (ballDepth == depth - 1 || ballCol == 0)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            Environment.Exit(0);
                        }
                        ballDepth++;
                        ballCol--;
                        break;

                    case "BR":
                        if (ballDepth == depth - 1 || ballCol == width - 1)
                        {
                            LeaveCube("No", ballCol, ballRow, ballDepth);
                            Environment.Exit(0);
                        }
                        ballDepth++;
                        ballCol++;
                        break;

            }
            ballRow++;
        }

        private static void LeaveCube(string message, int ballCol, int ballRow, int ballDepth)
        {
            Console.WriteLine(message);
            Console.WriteLine("{0} {1} {2}", ballCol, ballRow, ballDepth);
        }
    }
}
