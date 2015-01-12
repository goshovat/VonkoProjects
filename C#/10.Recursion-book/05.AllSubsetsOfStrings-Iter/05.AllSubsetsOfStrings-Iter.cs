using System;
using System.Collections.Generic;

class AllSubsetsOfStrings_Iter
{
    static string[] set = { "test", "rock", "fun" };
    static int numberOfIterations;
    static int maximumLenSubset;
    static int totalNumberSubsets;
    static List<string> currentSubset = new List<string>();

    static void Main()
    {
        numberOfIterations = set.Length;
        maximumLenSubset = numberOfIterations;
        totalNumberSubsets = (int)Math.Pow(2, (double)numberOfIterations);

        GetAllSubsets();
    }

    //this method will generate our subsets
    static void GetAllSubsets()
    {
        for (int subset = 0; subset < totalNumberSubsets; subset++)
        {
            currentSubset = new List<string>();

            for (int j = 0; j < maximumLenSubset; j++)
            {
                if ((1 << j & subset) != 0)
                {
                    currentSubset.Add(set[j]);
                }
            }

            if (IsIncreasingSequence())
                PrintCombinations();
        }
    }

    //this method will check if there are no decreasing elements in the current combination
    static bool IsIncreasingSequence()
    {
        for (int i = 0; i < currentSubset.Count - 1; i++)
        {
            if (Array.IndexOf(set, currentSubset[i]) >= Array.IndexOf(set, currentSubset[i + 1]))
            {
                return false;
            }
        }

        return true;
    }

    //this method will print the current subset
    static void PrintCombinations()
    {
        for (int i = 0; i < currentSubset.Count; i++)
        {
            Console.Write(currentSubset[i] + " ");
        }
        Console.WriteLine();
    }
}
