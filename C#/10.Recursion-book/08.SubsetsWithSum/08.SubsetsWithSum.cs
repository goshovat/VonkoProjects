using System;
using System.Collections.Generic;

class SubsetsWithSum
{
    static int[] set;
    static List<int> currentSubset;
    static int numberOfIterations;
    static int totalIndexes;
    static int givenSum;

    static void Main()
    {
        set = new int[] { 2, 3, 1, -1 };
        numberOfIterations = set.Length;
        totalIndexes = numberOfIterations;

        currentSubset = new List<int>();

        givenSum = 4;

        FindSubsetsOfSum(0);
    }

    //this is the recursive method that will find the subsets
    static void FindSubsetsOfSum(int subset)
    {
        if (NoRepetitions() && CorrectSum() && IsIncreasingSequence())
            PrintSubset();

        if (subset == totalIndexes)
            return;

        for (int i = 0; i < numberOfIterations; i++)
        {
            currentSubset.Add(set[i]);
            FindSubsetsOfSum(subset + 1);
            currentSubset.RemoveAt(currentSubset.Count - 1);
        }
    }

    //this method will check for every subset is the sum is the desired one
    static bool CorrectSum()
    {
        int currentSum = 0;

        for (int i = 0; i < currentSubset.Count; i++)
        {
            currentSum += currentSubset[i];
        }

        return currentSum == givenSum;
    }


    //this method will check if there are no decreasing elements in the current combination
    static bool IsIncreasingSequence()
    {
        for (int i = 0; i < currentSubset.Count - 1; i++)
        {
            if (Array.IndexOf(set, currentSubset[i]) > Array.IndexOf(set, currentSubset[i + 1]))
            {
                return false;
            }
        }

        return true;
    }

    //this method will check if some of the numbers is picked more than once
    static bool NoRepetitions()
    {
        for (int i = 0; i < currentSubset.Count - 1; i++)
        {
            for (int j = i + 1; j < currentSubset.Count; j++)
            {
                if (currentSubset[i] == currentSubset[j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    //this method will print the subset with the given sum
    static void PrintSubset()
    {
        for (int i = 0; i < currentSubset.Count; i++)
        {
            Console.Write(currentSubset[i] + " ");
        }
        Console.WriteLine();
    }
}
