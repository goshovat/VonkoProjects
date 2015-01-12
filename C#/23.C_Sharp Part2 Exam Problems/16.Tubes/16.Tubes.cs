namespace Tubes
{
    using System;
    using System.Collections.Generic;

    class Tubes
    {
        static void Main()
        {
            //get the input data
            int initialTubes = int.Parse(Console.ReadLine());
            int allFighters = int.Parse(Console.ReadLine());
            long[] tubesSizes = new long[initialTubes];
            for (int tube = 0; tube < initialTubes; tube++)
            {
                tubesSizes[tube] = int.Parse(Console.ReadLine());
            }

            long maxTubeSize = GetMaxTubeSize(tubesSizes, allFighters);

            Console.WriteLine(maxTubeSize);
        }

        private static long GetMaxTubeSize(long[] tubesSizes, int allFighters)
        {
            Array.Sort(tubesSizes);
            int initialTubes = tubesSizes.Length;
            long tubesMade = 0;
            long maxSize = tubesSizes[initialTubes - 1];

            long left = 1;
            long right = maxSize;
            long maxSizeFound = 0;
            while (true)
            {
                if (left > right)
                {
                    break;
                }
                long currentSize = (right - left) / 2 + left;
                tubesMade = 0;

                for (int i = tubesSizes.Length - 1; i >= 0; i--)
                {
                    long currentTubes = tubesSizes[i] / currentSize;

                    if (currentTubes == 0)
                        break;

                    tubesMade += currentTubes;

                    if (tubesMade >= allFighters)
                    {
                        maxSizeFound = currentSize;
                        left = currentSize + 1;
                    }
                }

                if (tubesMade < allFighters)
                {
                    right = currentSize - 1;
                }
            }

            return maxSizeFound;
        }
    }
}
