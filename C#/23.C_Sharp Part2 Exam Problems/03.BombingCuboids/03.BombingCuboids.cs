namespace BombingCuboids
{
    using System;
    using System.Collections.Generic;

    class BombingCuboids
    {
        static char[, ,] cube;
        static LinkedList<Bomb> bombs = new LinkedList<Bomb>();
        static SortedDictionary<char, int> colorsDestroyed =
            new SortedDictionary<char, int>();

        static void Main()
        {
            string cubeSizesInput = Console.ReadLine();
            string[] cubeSizes = cubeSizesInput.Split(' ');

            int width = int.Parse(cubeSizes[0]);
            int height = int.Parse(cubeSizes[1]);
            int depth = int.Parse(cubeSizes[2]);
            cube = new char[width, height, depth];

            GetCubeCells(width, height, depth);

            int numberBombs = int.Parse(Console.ReadLine());
            GetBombs(numberBombs);

            foreach (Bomb bomb in bombs)
            {
                DetonateBomb(bomb);
                MoveDownPieces(bomb);
            }

            int totalDestroyedCubes = CalculateTotalDestroyedCubes();

            PrintResult(totalDestroyedCubes);
        }

        private static void GetCubeCells(int width, int height, int depth)
        {
            for (int row = 0; row < height; row++)
            {
                string line = Console.ReadLine();

                int layer = 0;
                int col = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ')
                    {
                        cube[col, row, layer] = line[i];
                        col++;
                    }
                    else
                    {
                        col = 0;
                        layer++;
                    }
                }
            }
        }

        private static void GetBombs(int numberBombs)
        {
            for (int i = 0; i < numberBombs; i++)
            {
                string bombInput = Console.ReadLine();
                string[] bombEntities = bombInput.Split(' ');
                int widht = int.Parse(bombEntities[0]);
                int height = int.Parse(bombEntities[1]);
                int depth = int.Parse(bombEntities[2]);
                int power = int.Parse(bombEntities[3]);

                Bomb currentBomb = new Bomb(widht, height, depth, power);
                bombs.AddLast(currentBomb);
            }
        }

        private static void DetonateBomb(Bomb bomb)
        {
            //calculate the max possible area of blast and check only within this area
            int startDepth = Math.Max(bomb.Layer - bomb.Power, 0);
            int endDepth = Math.Min(bomb.Layer + bomb.Power + 1, cube.GetLength(2));
            int startHeight = Math.Max(bomb.Row - bomb.Power, 0);
            int endHeight = Math.Min(bomb.Row + bomb.Power + 1, cube.GetLength(1));
            int startWidth = Math.Max(bomb.Col - bomb.Power, 0);
            int endWidth = Math.Min(bomb.Col + bomb.Power + 1, cube.GetLength(0));

            for (int layer = startDepth; layer < endDepth; layer++)
            {
                for (int col = startWidth; col < endWidth; col++)
                {
                    for (int row = startHeight; row < endHeight; row++)
                    {
                        //when we hit empty cell going up, there can be NO more full cells above it
                        if (cube[col, row, layer] == ' ')
                            break;

                        if (ThreeDimensionDistance(col, row, layer, bomb) <= (double)bomb.Power)
                        {
                            if (!colorsDestroyed.ContainsKey(cube[col, row, layer]))
                            {
                                colorsDestroyed[cube[col, row, layer]] = 1;
                            }
                            else
                            {
                                colorsDestroyed[cube[col, row, layer]]++;
                            }
                            cube[col, row, layer] = ' ';
                        }
                    }
                }
            }
        }

        private static double ThreeDimensionDistance(int col, int row, int layer, Bomb bomb)
        {
            return Math.Sqrt(
                (col - bomb.Col) * (col - bomb.Col) +
                (row - bomb.Row) * (row - bomb.Row) +
                (layer - bomb.Layer) * (layer - bomb.Layer)
                );
        }

        private static void MoveDownPieces(Bomb bomb)
        {
            //calculate the max possible area of blast and check only within this area
            int startDepth = Math.Max(bomb.Layer - bomb.Power, 0);
            int endDepth = Math.Min(bomb.Layer + bomb.Power + 1, cube.GetLength(2));
            int startWidth = Math.Max(bomb.Col - bomb.Power, 0);
            int endWidth = Math.Min(bomb.Col + bomb.Power + 1, cube.GetLength(0));

            //here we will iterate through every pillar in the cube
            for (int layer = startDepth; layer < endDepth; layer++)
            {
                for (int col = startWidth; col < endWidth; col++)
                {
                    //start going up the pillar
                    int seenEmpty = 0;
                    for (int row = 0; row < cube.GetLength(1); row++)
                    {
                        if (cube[col, row, layer] == ' ')
                        {
                            seenEmpty++;
                        }
                        else
                        {
                            if (seenEmpty > 0)
                            {
                                cube[col, row - seenEmpty, layer] = cube[col, row, layer];
                                cube[col, row, layer] = ' ';
                            }
                        }
                    }
                }
            }
        }

        private static int CalculateTotalDestroyedCubes()
        {
            int totalDestroyedCubes = 0;
            foreach (KeyValuePair<char, int> pair in colorsDestroyed)
            {
                totalDestroyedCubes += pair.Value;
            }
            return totalDestroyedCubes;
        }


        private static void PrintResult(int totalDestroyedCubes)
        {
            Console.WriteLine(totalDestroyedCubes);
            foreach (KeyValuePair<char, int> pair in colorsDestroyed)
            {
                Console.WriteLine("{0} {1}", pair.Key, pair.Value);
            }
        }

    }
}
