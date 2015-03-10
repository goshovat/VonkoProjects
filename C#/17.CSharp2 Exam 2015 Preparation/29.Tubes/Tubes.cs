using System;

class Tubes
{
    static void Main()
    {
        int initialTubesCount = int.Parse(Console.ReadLine());
        int tubesNeeded = int.Parse(Console.ReadLine());

        int[] initialTubes = new int[initialTubesCount];

        for (int i = 0; i < initialTubesCount; i++)
        {
            initialTubes[i] = int.Parse(Console.ReadLine());
        }

        long maxSize = -1;
        long currentSize = 0;

        //find the max possible size

        Array.Sort(initialTubes);

        long left = 1;
        long right = initialTubes[initialTubes.Length - 1];

        while (left <= right)
        {
            currentSize = (right - left) / 2 + left;
            long tubesMade = 0;

            for (int i = initialTubes.Length - 1; i >= 0; i--)
            {
                long currentCount = initialTubes[i] / currentSize;

                if (currentCount == 0)
                    break;

                tubesMade += currentCount;

                if (tubesMade >= tubesNeeded)
                {
                    maxSize = currentSize;
                    left = currentSize + 1;
                    break;
                }
            }

            if (tubesMade < tubesNeeded)
            {
                right = currentSize - 1;
            }
        }

        Console.WriteLine(maxSize);
    }
}
