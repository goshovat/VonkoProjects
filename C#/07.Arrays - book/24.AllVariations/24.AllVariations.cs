using System;

class AllCombinations
{
    private static bool Next(int[] array, int n)
    {
        int index = array.Length - 1;

        while (index >= 0)
        {
            array[index]++;

            if (array[index] > n)
            {
                array[index] = 1;
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
            Print(array);
        }
    }

    private static void Print(int[] array)
    {
        foreach (int number in array)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
