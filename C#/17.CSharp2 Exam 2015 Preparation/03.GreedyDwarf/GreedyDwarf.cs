using System;
using System.Collections.Generic;
using System.Linq;

class GreedyDwarf
{
    static void Main()
    {
        string[] valleyInput = Console.ReadLine().Split(',');
        int[] valleyPrototype = valleyInput.Select(el => int.Parse(el)).ToArray();
        int patternLen = int.Parse(Console.ReadLine());

        List<int[]> patterns = new List<int[]>();
        for (int i = 0; i < patternLen; i++)
        {
            string[] currentPatternString = Console.ReadLine().Split(',');
            int[] currentPattern = currentPatternString.Select(el => int.Parse(el)).ToArray();
            patterns.Add(currentPattern);
        }

        int maxCoins = int.MinValue;

        if (valleyPrototype.Length > 0)
        {
            int[] valley = new int[valleyPrototype.Length];

            for (int pattern = 0; pattern < patternLen; pattern++)
            {
                int[] currentPattern = patterns[pattern];
                int patternIndex = 0;
                int valleyIndex = 0;

                Array.Copy(valleyPrototype, valley, valley.Length);
                int currentCoins = valley[valleyIndex];
                valley[valleyIndex] = -2000;
           
                while (true)
                {
                    valleyIndex += currentPattern[patternIndex];

                    if (valleyIndex < 0 || valleyIndex >= valley.Length
                        || valley[valleyIndex] == -2000)
                    {
                        if (currentCoins > maxCoins)
                        {
                            maxCoins = currentCoins;
                        }
                        break;
                    }

                    currentCoins += valley[valleyIndex];
                    valley[valleyIndex] = -2000;

                    patternIndex++;
                    if (patternIndex >= currentPattern.Length)
                        patternIndex = 0;
                }
            }
        }

        Console.WriteLine(maxCoins);
    }
}

