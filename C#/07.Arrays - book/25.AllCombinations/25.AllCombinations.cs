using System;

class AllVariations
{
    static bool Next(int[] array, int n)
    {
        int index = array.Length - 1;

        while (index >= 0)
        {
            array[index]++;

            //int current = array[index];

            if (array[index] > n)
            {
                if (index > 0)
                {
                    array[index] = array[index - 1] + 1;
                }
                else
                {
                    array[index] = 1; 
                }

                index--;
            }
            else
            {
                return true;
            }
        }

        if (index == -1)
        {
            return false;
        }

        return true;
    }

    static void Main()
    {
        Console.WriteLine("Write the number N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Write the number K: ");
        int k = int.Parse(Console.ReadLine());

        int[] array = new int[k];

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = 1;
        }

        while (Next(array, n))
        {
            if (AreThereRepetitions(array) == false)
            {
                PrintArray(array);
            }
        }
    }

    static bool AreThereRepetitions(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j]) 
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static void PrintArray(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}

