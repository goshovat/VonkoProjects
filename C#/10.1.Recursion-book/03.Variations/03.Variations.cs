using System;
using System.Collections.Generic;

class Variations
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

        GetVariations(currentLoop);
    }

    //this is the recursive method that will generate the combinations
    static void GetVariations(int currentLoop)
    {
        if (currentLoop == numberOfLoops)
        {
            PrintCombinations();
            return;
        }

        for (int i = 1; i <= numberOfIterations; i++)
        {
            combinations[currentLoop] = i;
            GetVariations(currentLoop + 1);
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

