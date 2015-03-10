using System;
using System.Collections.Generic;

class Zerg
{
    private const int SYSTEM_BASE = 15;
    private static Dictionary<string, ulong> zergDigits = new Dictionary<string, ulong>() 
        {
          {"Rawr", 0}, {"Rrrr",1}, {"Hsst",2}, {"Ssst",3}, {"Grrr",4}, {"Rarr",5}, {"Mrrr",6}, {"Psst",7}, 
          {"Uaah",8}, {"Uaha",9}, {"Zzzz",10}, {"Bauu",11}, {"Djav",12}, {"Myau",13}, {"Gruh",14} 
        };

    static void Main()
    {
        string input = Console.ReadLine();
        string currentZergNum = "";
        List<ulong> zergNumbersDec = new List<ulong>();
        ulong result = 0;
        ulong power = 1;

        for (int i = 0; i < input.Length; i++)
        {
            currentZergNum += input[i];

            if (zergDigits.ContainsKey(currentZergNum))
            {
                zergNumbersDec.Add(zergDigits[currentZergNum]);
                currentZergNum = "";
            }

        }

        for (int i = 0; i < zergNumbersDec.Count; i++)
        {
            for (int pow = 0; pow < zergNumbersDec.Count - 1 - i; pow++)
            {
                power *= SYSTEM_BASE;
            }

            result += zergNumbersDec[i] * power;
            power = 1;
        }

        Console.WriteLine(result);
    }
}
