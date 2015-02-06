using System;
using System.Collections.Generic;

class RepetativeCombinations
{
    static int numberOfLoops;
    static int numberOfIterations;
    static int[] combinations;

    static void Main()
    {
        Console.WriteLine("Enter the number of loops(n):");
        numberOfLoops = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the number of iterations(k):");
        numberOfIterations = int.Parse(Console.ReadLine());
        combinations = new int[numberOfLoops];

        int currentLoop = 0;

        GetCombinations(currentLoop);
    }

    //this is the recursive method that will generate the combinations
    static void GetCombinations(int currentLoop)
    {
        if (currentLoop == numberOfLoops)
        {
            if (IsIncreasingSequence())
            {
                PrintCombinations();
            }

            return;
        }

        for (int i = 1; i <= numberOfIterations; i++)
        {
            combinations[currentLoop] = i;
            GetCombinations(currentLoop + 1);
        }
    }

    //this method will check if there are no decreasing elements in the current combination
    static bool IsIncreasingSequence()
    {
        for (int i = 0; i < combinations.Length - 1; i++)
        {
            if (combinations[i] > combinations[i + 1])
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

