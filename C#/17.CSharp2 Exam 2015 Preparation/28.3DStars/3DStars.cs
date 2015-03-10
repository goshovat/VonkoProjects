using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static char[, ,] cube;

    static void Main()
    {
        int[] dimensions = Console.ReadLine().Split()
            .Select(int.Parse).ToArray();

        int width = dimensions[0];
        int height = dimensions[1];
        int depth = dimensions[2];

        SortedDictionary<char, int> stars = new SortedDictionary<char, int>();
        int sum = 0;

        cube = new char[width, height, depth];

        for (int row = 0; row < height; row++)
        {
            string[] layers = Console.ReadLine().Split();

            for (int layer = 0; layer < depth; layer++)
            {
                string currentLayer = layers[layer];

                for (int col = 0; col < width; col++)
                {
                    cube[col, row, layer] = currentLayer[col];
                }
            }
        }

        //find the stars
        for (int row = 1; row < height - 1; row++)
        {
            for (int layer = 1; layer < depth - 1; layer++)
            {
                for (int col = 1; col < width - 1; col++)
                {
                    char currentColor = cube[col, row, layer];

                    if (cube[col - 1, row, layer] == currentColor)
                    {
                        if (cube[col + 1, row, layer] == currentColor)
                        {
                            if (cube[col, row, layer - 1] == currentColor)
                            {
                                if (cube[col, row, layer + 1] == currentColor) 
                                {
                                    if (cube[col, row - 1, layer] == currentColor)
                                    {
                                        if (cube[col, row + 1, layer] == currentColor)
                                        {
                                            if (stars.ContainsKey(currentColor))
                                                stars[currentColor]++;
                                            else
                                                stars.Add(currentColor, 1);

                                            sum++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        Console.WriteLine(sum);

        foreach (KeyValuePair<char, int> pair in stars)
        {
            Console.WriteLine("{0} {1}", pair.Key, pair.Value);
        }
    }
}
