namespace Laser
{
    using System;

    class Laser
    {
        static bool[,,] burnedCubes;

        static void Main()
        {
            string[] cubeSizes = Console.ReadLine().Split();
            int cubeWidth = int.Parse(cubeSizes[0]);
            int cubeHeight = int.Parse(cubeSizes[1]);
            int cubeDepth = int.Parse(cubeSizes[2]);

            string[] startPositions = Console.ReadLine().Split();
            int startW = int.Parse(startPositions[0]);
            int startH = int.Parse(startPositions[1]);
            int startD = int.Parse(startPositions[2]);

            string[] directions = Console.ReadLine().Split();
            int dirW = int.Parse(directions[0]);
            int dirH = int.Parse(directions[1]);
            int dirD = int.Parse(directions[2]);

            burnedCubes = new bool[cubeWidth, cubeHeight, cubeDepth];

            BurnEdges(cubeWidth, cubeHeight, cubeDepth);

            int currentW = startW - 1;
            int currentH = startH - 1;
            int currentD = startD - 1;

            while (true)
            {
                burnedCubes[currentW, currentH, currentD] = true;
                //check if need to change direction
                if (currentW == 0 || currentW == cubeWidth - 1)
                    dirW *= -1;
                if (currentH == 0 || currentH == cubeHeight - 1)
                    dirH *= -1;
                if (currentD == 0 || currentD == cubeDepth - 1)
                    dirD *= -1;

                int nextW = currentW + dirW;
                int nextH = currentH + dirH;
                int nextD = currentD + dirD;
                
                if (burnedCubes[nextW, nextH, nextD])
                {
                    Console.WriteLine("{0} {1} {2}", currentW + 1, currentH + 1, currentD + 1);
                    break;
                }
                else
                {
                    currentW = nextW;
                    currentH = nextH;
                    currentD = nextD;
                }
            }
        }

        private static void BurnEdges(int cubeWidth, int cubeHeight, int cubeDepth)
        {
            //burn the horizontal edges on the front and back walls
            for (int col = 0; col < cubeWidth; col++)
            {
                //burn the front-down edge
                burnedCubes[col, 0, 0] = true;
                //burn the front-up edge
                burnedCubes[col, cubeHeight - 1, 0] = true;
                //burn the back-down edge
                burnedCubes[col, 0, cubeDepth - 1] = true;
                //burn the back-up edge
                burnedCubes[col, cubeHeight - 1, cubeDepth - 1] = true;
            }
            //burn the horizontal edges on the sides
            for (int depth = 0; depth < cubeDepth; depth++)
            {
                //burn the left-down edge
                burnedCubes[0, 0, depth] = true;
                //burn the left-up edge
                burnedCubes[0, cubeHeight - 1, depth] = true;
                //burn the right-down edge
                burnedCubes[cubeWidth - 1, 0, depth] = true;
                //burn the right-up edge
                burnedCubes[cubeWidth - 1, cubeHeight - 1, depth] = true;
            }
            //burn the vertical edges
            for (int height = 0; height < cubeHeight; height++)
            {
                //burn the front-left pillar
                burnedCubes[0, height, 0] = true;
                //burn the back-left pillar
                burnedCubes[0, height, cubeDepth - 1] = true;
                //burn the front-right pillar
                burnedCubes[cubeWidth - 1, height, 0] = true;
                //burn the back-right pillar
                burnedCubes[cubeWidth - 1, height, cubeDepth - 1] = true;
            }
        }
    }
}
