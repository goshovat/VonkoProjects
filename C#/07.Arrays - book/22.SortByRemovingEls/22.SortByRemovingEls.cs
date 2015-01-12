using System;
using System.Collections.Generic;

class RemainingSortedArray
{
    static bool isSorted(List<int> list)
    {
        bool isSorted = true;

        for (int i = 0; i < list.Count - 1; i++)
        {
            if (list[i] > list[i + 1])
            {
                isSorted = false;
            }
        }

        return isSorted;
    }

    static void PrintList(List<int> list)
    {
        Console.WriteLine("The sorted array is: ");
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        List<int> listOfNumbers = new List<int>() { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
        List<int> result = new List<int>();

        int maxi = (int)Math.Pow(2, listOfNumbers.Count);
        int counter = 0;
        int maxCounter = 0;

        for (int i = 1; i < maxi; i++)
        {
            List<int> sortedList = new List<int>();
            counter = 0;

            for (int j = 0; j < listOfNumbers.Count; j++)
            {
                if ((i >> j & 1) == 1)
                {
                    sortedList.Add(listOfNumbers[j]);
                    counter++;
                }
            }

            if (counter > maxCounter && isSorted(sortedList))
            {
                result = sortedList;
                maxCounter = counter;
            }
        }

        PrintList(result);
    }
}