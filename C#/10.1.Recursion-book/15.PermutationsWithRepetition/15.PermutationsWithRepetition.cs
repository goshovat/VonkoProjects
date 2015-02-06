using System;
using System.Collections.Generic;

class PermutationWithRepetitions
{
    private static HashSet<string> allPermsCheck = new HashSet<string>();
    private static List<string> allPermutations = new List<string>();

    static void Main()
    {
        //int[] permutationsArray = new int[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5};

        int[] permutationsArray = new int[] { 1, 2, 2, 3};

        Array.Sort(permutationsArray);
        Permutate(permutationsArray, 0, permutationsArray.Length);

        foreach (string item in allPermutations)
        {
            Console.WriteLine(item);
        }
    }

    //this is the recursive method that will create the permutations
    static void Permutate(int[] permutationsArray, int start, int last)
    {
        CheckForRepetition(permutationsArray);

        int oldValue = 0;

        if (start < last)
        {
            for (int i = last - 2; i >= start; i--)
            {
                for (int j = i + 1; j < last; j++)
                {
                    if (permutationsArray[i] != permutationsArray[j])
                    {
                        oldValue = permutationsArray[i];
                        permutationsArray[i] = permutationsArray[j];
                        permutationsArray[j] = oldValue;

                        Permutate(permutationsArray, i + 1, last);
                    }
                }

                oldValue = permutationsArray[i];

                for (int k = i; k < last - 1; )
                {
                    permutationsArray[k] = permutationsArray[++k];
                }

                permutationsArray[last - 1] = oldValue;
            }
        }
    }

    static void CheckForRepetition(int[] permutationsArray)
    {
        string currentPerm = string.Join(" ", permutationsArray);

        if (!allPermsCheck.Contains(currentPerm))
        {
            allPermsCheck.Add(currentPerm);
            allPermutations.Add(currentPerm);
        }
    }
}
