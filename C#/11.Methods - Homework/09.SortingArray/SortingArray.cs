using System;

class SortingArray
{
    static void Main()
    {
        int[] testArray ={1,4, -2, 0, -6, 5, -3, 1};

        CustomSortDesc(testArray);
        Console.WriteLine("Array sorted descending:");
        Console.WriteLine(string.Join(", ", testArray));

        Array.Reverse(testArray);

        Console.WriteLine("Array sorted ascending:");
        Console.WriteLine(string.Join(", ", testArray));
    }

    private static int FindMaxElement(int[] array, int index)
    {
        if (index >= array.Length || index < 0)
            throw new ArgumentException("Invalid index passed to the method.");

        int maxElement = array[index];
        for (int i = index + 1; i < array.Length; i++)
        {
            if (array[i] > maxElement)
                maxElement = array[i];
        }
        return maxElement;
    }

    private static void CustomSortDesc(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int currentBiggest = FindMaxElement(array, i);
            int temp = array[i];
            int biggestIndex = Array.IndexOf(array, currentBiggest, i);
            array[biggestIndex] = temp;
            array[i] = currentBiggest;
        }
    }
}

