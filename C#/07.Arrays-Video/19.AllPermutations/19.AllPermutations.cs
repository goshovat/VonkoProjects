using System;

class AllPermutations
{
    static void Main()
    {
        int numbers = int.Parse(Console.ReadLine());

        int[] numbersArray = new int[numbers];

        //create the original array of the numbers
        for (int i = 1; i <= numbers; i++)
        {
            numbersArray[i - 1] = i; 
        }

        int current = 0;

        Permutate(numbersArray, current);
    }

    private static void Permutate(int[] numbersArray, int current)
    {
        if (current == numbersArray.Length - 1)
        {
            Console.WriteLine(string.Join(",", numbersArray));
        }
        else
        {
            for (int i = current; i < numbersArray.Length; i++)
            {
                Swap(numbersArray, i, current);
                Permutate(numbersArray, current + 1);
                Swap(numbersArray, i, current);
            }
        }
    }

    private static void Swap(int[] numbersArray, int i, int current)
    {
        int temp = numbersArray[i];
        numbersArray[i] = numbersArray[current];
        numbersArray[current] = temp;
    }

}
