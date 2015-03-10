using System;
using System.Collections.Generic;
using System.Linq;


class _3DMaxWalk
{
    private static int width;
    private static int height;
    private static int depth;
    private static short[, ,] cuboid;
    private static bool[, ,] visited;

    static void Main()
    {
        ReadCuboid();
        long sum = CalculateSum();
        Console.WriteLine(sum);  
    }

    private static long CalculateSum()
    {
        int w = width / 2;
        int h = height / 2;
        int d = depth / 2;
        bool finished = false;
        long sum = cuboid[w, h, d];
        visited = new bool[width, height, depth];

        while (!finished)
        {
            visited[w, h, d] = true;

            int newW, newH, newD, maxCount;
            GetNextPosition(w, h, d, out newW,
                out newH, out newD, out maxCount);

            if (visited[newW, newH, newD] || maxCount > 1)
            {
                // We fall into a loop (went into already visited position)
                finished = true;
            }
            else
            {
                sum = sum + cuboid[newW, newH, newD];
                w = newW;
                h = newH;
                d = newD;
            }
        }
        return sum;
    }

    private static void GetNextPosition(
        int w, int h, int d, out int newW, out int newH, out int newD, out int maxCount)
    {
        short maxValue = short.MinValue;
        newW = 0;
        newH = 0;
        newD = 0;
        maxCount = 0;

        short oldCurPosValue = cuboid[w, h, d];
        cuboid[w, h, d] = short.MinValue;

        //check left/right
        for (int newxW = 0; newxW < width; newxW++)
        {
            short value = cuboid[newxW, h, d];
            if (value == maxValue)
            {
                maxCount++;
            }
            if (value > maxValue)
            {
                maxValue = value;
                newW = newxW;
                newH = h;
                newD = d;
                maxCount = 1;
            }
        }

        //check up down
        for (int nextH = 0; nextH < height; nextH++)
        {
            short value = cuboid[w, nextH, d];
            if (value == maxValue)
            {
                maxCount++;
            }
            if (value > maxValue)
            {
                maxValue = value;
                newW = w;
                newH = nextH;
                newD = d;
                maxCount = 1;
            }
        }

        //check front/back
        for (int nextD = 0; nextD < depth; nextD++)
        {
            short value = cuboid[w, h, nextD];
            if (value == maxValue)
            {
                maxCount++;
            }
            if (value > maxValue)
            {
                maxValue = value;
                newW = w;
                newH = h;
                newD = nextD;
                maxCount = 1;
            }
        }

        cuboid[w, h, d] = oldCurPosValue;
    }

    private static void ReadCuboid()
    {
        int[] dims = Console.ReadLine().Split()
            .Select(int.Parse).ToArray();

        width = dims[0];
        height = dims[1];
        depth = dims[2];

        cuboid = new short[width, height, depth];
        bool[, ,] visited = new bool[width, height, depth];

        for (int row = 0; row < height; row++)
        {
            string[] layers = Console.ReadLine().Split(
                new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            for (int layer = 0; layer < depth; layer++)
            {
                short[] columns = layers[layer].Trim().Split()
                    .Select(short.Parse).ToArray();

                for (int col = 0; col < width; col++)
                {
                    cuboid[col, row, layer] = columns[col];
                }
            }
        }
    }
}
