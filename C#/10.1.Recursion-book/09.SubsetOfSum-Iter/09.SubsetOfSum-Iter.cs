using System;
using System.Collections.Generic;

class SubsetOfSum_Iter
{
    static int[] set;
    static List<int> combination;
    static int numberOfIterations;
    static int givenSum;
    static int numberOfCombinations;

    static void Main()
    {
        set = new int[] { 2, 3, 1, -1 };
        numberOfIterations = set.Length;

        givenSum = 4;

        numberOfCombinations = (int)Math.Pow(2, (double)set.Length);

        for (int currentCombination = 0; currentCombination < numberOfCombinations; currentCombination++)
        {
            combination = new List<int>();

            //with this algorithm we will get all the possible combinations
            for (int currentBit = 0; currentBit < set.Length; currentBit++)
            {
                if ((1 << currentBit & currentCombination) != 0)
                {
                    combination.Add(set[currentBit]);
                }
            }
            
            //now check if the current combination satisfy our requirements
            if (NoRepetitions() && CorrectSum() && IsIncreasingSequence())
                PrintSubset();
        }
    }

    //this method will check for every subset is the sum is the desired one
    static bool CorrectSum()
    {
        int currentSum = 0;

        for (int i = 0; i < combination.Count; i++)
        {
            currentSum += combination[i];
        }

        return currentSum == givenSum;
    }


    //this method will check if there are no decreasing elements in the current combination
    static bool IsIncreasingSequence()
    {
        for (int i = 0; i < combination.Count - 1; i++)
        {
            if (Array.IndexOf(set, combination[i]) > Array.IndexOf(set, combination[i + 1]))
            {
                return false;
            }
        }

        return true;
    }

    //this method will check if some of the numbers is picked more than once
    static bool NoRepetitions()
    {
        for (int i = 0; i < combination.Count - 1; i++)
        {
            for (int j = i + 1; j < combination.Count; j++)
            {
                if (combination[i] == combination[j])
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
        for (int i = 0; i < combination.Count; i++)
        {
            Console.Write(combination[i] + " ");
        }
        Console.WriteLine();
    }
}
