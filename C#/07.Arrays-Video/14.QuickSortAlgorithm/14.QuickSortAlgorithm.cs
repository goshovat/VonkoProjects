﻿using System;

class QuickSortAlgorithm
{
    static int[] testArray = { 99, 8, -8, 16, 543, 2, 41, 0, 1 };

    static void Main()
    {
        int left = 0;
        int right = testArray.Length - 1;

        QuickSort(testArray, left, right);

        Console.WriteLine(string.Join(", ", testArray));
    }

    static void QuickSort(int[] array, int left, int right)
    {
        int index = Partition(array, left, right);

        if (left < index - 1)
        {
            QuickSort(array, left, index - 1);
        }
        if (index < right)
        {
            QuickSort(array, index, right);
        }
    }

    private static int Partition(int[] array, int left, int right)
    {
        int pivot = array[(left + right) / 2];

        int i = left;
        int j = right;

        while (i <= j)
        {
            while (array[i] < pivot)
            {
                i++;
            }
            while (array[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                int temp = testArray[i];
                array[i] = testArray[j];
                array[j] = temp;

                i++;
                j--;
            }
        }

        return i;
    }
}

