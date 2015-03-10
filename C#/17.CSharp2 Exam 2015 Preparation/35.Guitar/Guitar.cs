using System;
using System.Linq;

class Guitar
{
    static void Main()
    {
        int[] intervals = Console.ReadLine().Split(',')
            .Select(n => int.Parse(n)).ToArray();

        int initialVolume = int.Parse(Console.ReadLine());
        int maxVolume = int.Parse(Console.ReadLine());

        bool[,] table = new bool[intervals.Length + 1, maxVolume + 1];
        table[0, initialVolume] = true;

        for (int round = 1; round <= intervals.Length; round++)
        {
            //check the prev row
            for (int col = 0; col < maxVolume + 1; col++)
            {
                if (table[round - 1, col]) 
                {
                    if (col - intervals[round - 1] >= 0)
                        table[round, col - intervals[round - 1]] = true;
                    if (col + intervals[round-1] <= maxVolume)
                        table[round, col + intervals[round - 1]] = true;
                 }
            }
        }

        for (int i = maxVolume; i >= 0; i--)
        {
            if (table[intervals.Length, i])
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine(-1);
    }
}
