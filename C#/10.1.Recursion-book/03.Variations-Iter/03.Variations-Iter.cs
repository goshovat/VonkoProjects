using System;

class VariationsIter
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

        InitiateCombinations();
        GetCombinations();
    }

    //this iterative method will get the combinations
    static void GetCombinations()
    {
        while (true)
        {
            PrintCombinations();

            int currentLoop = numberOfLoops - 1;

            combinations[currentLoop] = combinations[currentLoop] + 1;

            while (combinations[currentLoop] > numberOfIterations)
            {
                combinations[currentLoop] = 1;
                currentLoop--;

                if (currentLoop < 0)
                {
                    return;
                }

                combinations[currentLoop] = combinations[currentLoop] + 1;
            }
        }
    }

    //this method will make the array of combinations initially with 1s
    private static void InitiateCombinations()
    {
        for (int i = 0; i < combinations.Length; i++)
        {
            combinations[i] = 1;
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
