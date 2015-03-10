using System;
using System.Collections.Generic;
using System.Linq;

class AcademyTask
{
    static void Main()
    {
        string pleasantnessAsString = Console.ReadLine();
        int variety = int.Parse(Console.ReadLine());
        string[] pleasantnessParts = pleasantnessAsString.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        int[] pleasantness = pleasantnessParts.Select(x => int.Parse(x)).ToArray();
        Console.WriteLine(minNumber(pleasantness, variety));
    }

    static int minNumber(int[] pleasantness, int variety)
    {
        int res = pleasantness.Length;
        for (int i = 0; i < pleasantness.Length; i++)
        {
            for (int j = i + 1; j < pleasantness.Length; j++)
            {
                int diff = Math.Abs(pleasantness[i] - pleasantness[j]);
                if (diff < variety)
                {
                    continue;
                }
                int distance = (i + 3) / 2; //distance to i
                distance += (j - i + 1) / 2; //distance between i and j
                res = Math.Min(res, distance);
            }
        }
        return res;
    } 
}
