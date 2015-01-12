using System;

class AllPermutations
{
    static void Swap(ref int first, ref int second)
    {
        int temp = first;
        first = second;
        second = temp;
    }

    static void Permute(int[] array, int current)
    {
        if (current == array.Length - 1)
        {
            Print(array);
        }
        else
        {
            for (int i = current; i <= array.Length - 1; i++)
            {
                Swap(ref array[i], ref array[current]);
                Permute(array, current + 1);
                Swap(ref array[i], ref array[current]);
            }
        }

    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] arrayOfNumbers = new int[N];

        //fill the array
        for (int i = 1; i <= N; i++)
        {
            arrayOfNumbers[i - 1] = i;
        }

        Permute(arrayOfNumbers, 0);
    }

    private static void Print(int[] array)
    {
        for (int i = 0; i <= array.Length - 1; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}