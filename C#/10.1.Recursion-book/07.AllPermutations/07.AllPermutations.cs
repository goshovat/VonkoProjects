using System;

class AllPermutations
{
    static int number;
    static int[] permutationsArray;

    static void Main()
    {
        Console.WriteLine("Enter the number n: ");
        number = int.Parse(Console.ReadLine());
        permutationsArray = new int[number];

        InitiatePermutations();

        Permutate(0);
    }

    //this method will generate the permutations
    static void Permutate(int index)
    {
        if (index == permutationsArray.Length)
        {
            PrintPermutation();
        }

        for (int i = index; i < number; i++)
        {
            Exchange(index, i);
            Permutate(index + 1);
            Exchange(index, i);
        }
    }

    //this method exchanges two numbers in the array
    static void Exchange(int index1, int index2)
    {
        int temp = permutationsArray[index1];
        permutationsArray[index1] = permutationsArray[index2];
        permutationsArray[index2] = temp;
    }

    //this method will initially set up the numbers
    static void InitiatePermutations()
    {
        for (int i = 0; i < permutationsArray.Length; i++)
        {
            permutationsArray[i] = i + 1;
        }
    }

    //this method will print the current permutation
    static void PrintPermutation()
    {
        for (int i = 0; i < permutationsArray.Length; i++)
        {
            Console.Write(permutationsArray[i] + " ");
        }
        Console.WriteLine();
    }
}
