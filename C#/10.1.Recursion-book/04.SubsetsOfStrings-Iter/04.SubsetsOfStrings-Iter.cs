using System;
using System.Collections.Generic;

class SubsetOfStrings
{
    static int numberOfLoops;
    static int numberOfIterations;
    static string[] combinations;

    static string[] set = { "test", "rock", "fun", "gun" };

    static void Main()
    {
        Console.WriteLine("Enter the number of loops(n):");
        numberOfLoops = int.Parse(Console.ReadLine());
        numberOfIterations = set.Length;
        combinations = new string[numberOfLoops];

        InitiateCombinations();
        GetSubstrings();
    }

    //this iterative method will get the combinations
    static void GetSubstrings()
    {
        while (true)
        {
            if (IsIncreasingSequence())
                PrintCombinations();

            int currentLoop = numberOfLoops - 1;

            int index = Array.IndexOf(set, combinations[currentLoop]) + 1;

            if (index < numberOfIterations)
                combinations[currentLoop] = set[index];

            while (index >= numberOfIterations)
            {
                combinations[currentLoop] = set[0];
                currentLoop--;

                if (currentLoop < 0)
                {
                    return;
                }

                index = Array.IndexOf(set, combinations[currentLoop]) + 1;

                if (index < numberOfIterations)
                    combinations[currentLoop] = set[index];
            }
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

      //this method will make the array of combinations initially with 1s
    private static void InitiateCombinations()
    {
        for (int i = 0; i < combinations.Length; i++)
        {
            combinations[i] = set[0];
        }
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

