namespace _3DStars
{
    using System;
    using System.Collections.Generic;

    public class _3DStars
    {
        static char[, ,] cube;

        static void Main()
        {
            SortedDictionary<char, int> starsByColor = new
                SortedDictionary<char, int>();

            string[] sizes = Console.ReadLine().Split();
            int width = int.Parse(sizes[0]);
            int height = int.Parse(sizes[1]);
            int depth = int.Parse(sizes[2]);
            cube = new char[width, height, depth];

            for (int row = 0; row < height; row++)
            {
                string currentRow = Console.ReadLine();
                string[] layers = currentRow.Split();

                for (int layer = 0; layer < depth; layer++)
                {
                    string currentLayer = layers[layer];
                    for (int col = 0; col < width; col++)
                    {
                        cube[col, row, layer] = currentLayer[col];
                    }
                }
            }

            int totalNumberStars = FindNumberOfStars(starsByColor);
            Console.WriteLine(totalNumberStars);
            PrintStarsByColor(starsByColor);
        }

        private static int FindNumberOfStars(SortedDictionary<char, int> starsByColor)
        {
            int width = cube.GetLength(0);
            int height = cube.GetLength(1);
            int depth = cube.GetLength(2);

            int totalNumberStars = 0;

            for (int row = 1; row < height - 1; row++)
            {
                for (int layer = 1; layer < depth - 1; layer++)
                {

                    for (int col = 1; col < width - 1; col++)
                    {
                        char currentCube = cube[col, row, layer];
                        //check the star above
                        if (cube[col, row + 1, layer] == currentCube)
                        {
                            //check below
                            if (cube[col, row - 1, layer] == currentCube)
                            {
                                //check on the left
                                if (col > 0 && cube[col - 1, row, layer] == currentCube)
                                {
                                    //check on the right
                                    if (cube[col + 1, row, layer] == currentCube)
                                    {
                                        //check on the front
                                        if (cube[col, row, layer + 1] == currentCube)
                                        {
                                            if (cube[col, row, layer - 1] == currentCube)
                                            {
                                                totalNumberStars++;

                                                if (!starsByColor.ContainsKey(currentCube))
                                                    starsByColor.Add(currentCube, 1);
                                                else
                                                    starsByColor[currentCube]++;
                                            }
                                        }
                                    }
                                }   
                            }
                        }
                    }
                }
            }

            return totalNumberStars;
        }

        private static void PrintStarsByColor(SortedDictionary<char, int> starsByColor)
        {
            foreach (var pair in starsByColor)
            {
                Console.WriteLine("{0} {1}", pair.Key, pair.Value);
            }
        }
    }
}
