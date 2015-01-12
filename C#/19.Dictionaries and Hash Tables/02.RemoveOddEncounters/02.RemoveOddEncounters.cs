using System;
using System.Collections.Generic;

namespace RemoveOddEncounters
{
    class RemoveOddEncounters
    {
        static void Main()
        {
            List<int> sequennce = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6 };

            Dictionary<int, int> encounters = GetEncounters(sequennce);

            RemoveNumbers(sequennce, encounters);

            Console.WriteLine("The new sequence is:\n{0}", 
                string.Join(",", sequennce));
        }

        private static Dictionary<int, int> GetEncounters(List<int> sequennce)
        {
            Dictionary<int, int> encounters = new Dictionary<int, int>();

            for (int i = 0; i < sequennce.Count; i++)
            {
                if (encounters.ContainsKey(sequennce[i]))
                    encounters[sequennce[i]]++;
                else
                    encounters[sequennce[i]] = 1;
            }

             return encounters;
        }

        private static void RemoveNumbers(List<int> sequennce, Dictionary<int, int> encounters)
        {
            foreach (KeyValuePair<int, int> keyValuePair in encounters)
            {
                if (keyValuePair.Value % 2 != 0)
                {
                    while (sequennce.Contains(keyValuePair.Key))
                        sequennce.Remove(keyValuePair.Key);
                }
            }
        }
    }
}
