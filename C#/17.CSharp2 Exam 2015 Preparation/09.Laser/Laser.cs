using System;

class Laser
{
    private static int[, ,] cube;
    static void Main()
    {
        string[] cubeSizes = Console.ReadLine().Split();
        int width = int.Parse(cubeSizes[0]);
        int height = int.Parse(cubeSizes[1]);
        int depth = int.Parse(cubeSizes[2]);
        cube = new int[width, height, depth];

        string[] startCoordinates = Console.ReadLine().Split();
        int curW = int.Parse(startCoordinates[0]) - 1;
        int curH = int.Parse(startCoordinates[1]) - 1;
        int curD = int.Parse(startCoordinates[2]) - 1;

        string[] laserDirection = Console.ReadLine().Split();
        int dirW = int.Parse(laserDirection[0]);
        int dirH = int.Parse(laserDirection[1]);
        int dirD = int.Parse(laserDirection[2]);

        //burn the initial cubes
        for (int col = 0; col < width; col++)
        {
            cube[col, 0, 0] = 1;
            cube[col, height - 1, 0] = 1;
            cube[col, 0, depth - 1] = 1;
            cube[col, height - 1, depth - 1] = 1;
        }
        for (int row = 0; row < height; row++)
        {
            cube[0, row, 0] = 1;
            cube[width - 1, row, 0] = 1;
            cube[0, row, depth - 1] = 1;
            cube[width - 1, row, depth - 1] = 1;
        }
        for (int layer = 0; layer < depth - 1; layer++)
        {
            cube[0, 0, layer] = 1;
            cube[0, height - 1, layer] = 1;
            cube[width - 1, 0, layer] = 1;
            cube[width - 1, height - 1, layer] = 1;
        }

        //start shooting with laser
        while (true)
        {
            cube[curW, curH, curD] = 1;

            int nextW = curW + dirW;
            int nextH = curH + dirH;
            int nextD = curD + dirD;

            if (cube[nextW, nextH, nextD] == 1)
            {
                Console.WriteLine("{0} {1} {2}", curW+1, curH+1, curD+1);
                break;
            }

            if (nextW == 0 || nextW == width - 1)
                dirW *= -1;
            if (nextH == 0 || nextH == height - 1)
                dirH *= -1;
            if (nextD == 0 || nextD == depth - 1)
                dirD *= -1;

            curW = nextW;
            curH = nextH;
            curD = nextD;
        }
    }
}