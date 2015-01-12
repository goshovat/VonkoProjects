using System;
using System.Collections.Generic;

class AllSubsetsOfStrings
{
    static string[] set = { "test", "rock", "fun" };
    static int numberOfIterations;
    static int maximumLenSubset;
    static List<string> currentSubset;

    static void Main()
    {
        currentSubset = new List<string>();
        numberOfIterations = set.Length;
        maximumLenSubset = numberOfIterations;
        int currentIndex = 0;

        GetAllSubsets(currentIndex);
    }

    //this is the recursive method that will generate the subsets
    static void GetAllSubsets(int currentIndex)
    {
        PrintCombinations();

        if (currentIndex == maximumLenSubset)
            return;

        for (int i = currentIndex; i < numberOfIterations; i++)
        {
            currentSubset.Add(set[i]);
            GetAllSubsets(i + 1);
            currentSubset.RemoveAt(currentSubset.Count - 1);
        }
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
