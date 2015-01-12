using System;
using System.Collections.Generic;

namespace EncountersOfNumber
{
    class EncountersOfNumber
    {
        static void Main()
        {
            int[] sequennce = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            Dictionary<int, int> encounters = new Dictionary<int, int>();

            //count the encounters
            for (int i = 0; i < sequennce.Length; i++)
            {
                if (encounters.ContainsKey(sequennce[i]))
                    encounters[sequennce[i]]++;
                else
                    encounters[sequennce[i]] = 1;
            }

            //print the result
            foreach(KeyValuePair<int, int> pair in encounters)
                Console.WriteLine("Number {0} -> {1} times", pair.Key, pair.Value);
        }
    }
}
