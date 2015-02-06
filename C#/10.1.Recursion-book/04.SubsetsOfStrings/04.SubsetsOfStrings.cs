using System;
using System.Collections.Generic;

class SubsetOfStrings
{
    static int numberOfLoops;
    static int numberOfIterations;
    static string[] combinations;

    static string[] set = { "test", "rock", "fun" };

    static void Main()
    {
        Console.WriteLine("Enter the number of loops(n):");
        numberOfLoops = int.Parse(Console.ReadLine());
        numberOfIterations = set.Length;
        combinations = new string[numberOfLoops];

        int currentLoop = 0;

        GetSubstrings(currentLoop);
    }

    //this is the recursive method that will generate the combinations
    static void GetSubstrings(int currentLoop)
    {
        if (currentLoop == numberOfLoops)
        {
            if (IsIncreasingSequence())
                PrintCombinations();

            return;
        }

        for (int i = 0; i < numberOfIterations; i++)
        {
            combinations[currentLoop] = set[i];
            GetSubstrings(currentLoop + 1);
        }
    }

    //this method will check if there are no decreasing elements in the current combination
    static bool IsIncreasingSequence()
    {
        for (int i = 0; i < combinations.Length - 1; i++)
        {
            if (Array.IndexOf(set, combinations[i]) >= Array.IndexOf(set, combinations[i + 1]))
            {
                return false;
            }
        }

        return true;
    }

    //this method will print the current combination
    static void PrintCombinations()
    {
        for (int i = 0; i < combinations.Length; i++)
        {
            Console.Write(combinations[i] + " ");
        }
        Console.WriteLine();
    }
}

