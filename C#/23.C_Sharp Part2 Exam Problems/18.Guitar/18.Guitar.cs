namespace Guitar
{
    using System;

    class Guitar
    {
        private static string[] volumeChanges;
        private static int maxVolume;
        private static int[,] table;

        private static void Main()
        {
            volumeChanges = Console.ReadLine().Split(
                new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int currentVolume = int.Parse(Console.ReadLine());
            maxVolume = int.Parse(Console.ReadLine());

            //the horizontal are the volume changes, on the vertical are the songs
            table = new int[volumeChanges.Length + 1, maxVolume + 1];
            table[0, currentVolume] = 1;

            int result = FindMaxVolume(currentVolume);
            Console.WriteLine(result);
        }

        private static int FindMaxVolume(int initialVolume)
        {
            int currentVolume = initialVolume;
            int result = -1;

            for (int row = 1; row < table.GetLength(0); row++)
            {
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    if (table[row - 1, col] == 1)
                    {
                        currentVolume = col;
                        FillRow(currentVolume, row);
                    }
                }
            }

            //find the biggest value on the last row
            for (int col = table.GetLength(1) - 1; col >= 0; col--)
            {
                if (table[table.GetLength(0) - 1, col] == 1)
                {
                    return col;
                }
            }
            return result;
        }

        private static void FillRow(int currentVolume, int row)
        {
            int interval = int.Parse(volumeChanges[row -1]);

            if (currentVolume - interval >= 0)
                table[row, currentVolume - interval] = 1;
            if (currentVolume + interval <= maxVolume)
                table[row, currentVolume + interval] = 1;
        }
    }
}
