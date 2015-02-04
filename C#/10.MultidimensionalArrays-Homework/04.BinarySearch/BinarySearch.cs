using System;

class BinarySearch
{
    //It is not interesting to use the .NET sort functionality, preferred to practice Quick Sort :)
    static void Main()
    {
        Console.WriteLine("Enter an integer K: ");
        int k = int.Parse(Console.ReadLine());

        int[] testArray = { 99, 8, -8, 16, 543, 2, 41, 0, 1 };
        int middle = testArray.Length / 2;
        int leftEnd = 0;
        int rightEnd = testArray.Length - 1;

        QuickSort(testArray, leftEnd, rightEnd);

        if (k < testArray[0])
        {
            Console.WriteLine("There is no such number!");
            return;
        }

        int elementToFind = k;
        int indexToFind = -1;

        while (indexToFind < 0)
        {
            indexToFind = Array.BinarySearch(testArray, elementToFind);
            elementToFind--;
        }
        Console.WriteLine("The desired number is: {0}", testArray[indexToFind]);
    }

    static void QuickSort(int[] testArray, int leftEnd, int rightEnd)
    {
        int index = Partition(testArray, leftEnd, rightEnd);

        if (index - 1 > leftEnd)
        {
            QuickSort(testArray, leftEnd, index - 1);
        }
        if (index < rightEnd)
        {
            QuickSort(testArray, index, rightEnd);
        }
    }

    private static int Partition(int[] testArray, int leftEnd, int rightEnd)
    {
        int pivot = testArray[(leftEnd + rightEnd) / 2];
        int i = leftEnd;
        int j = rightEnd;

        while (i <= j)
        {
            while (testArray[i] < pivot)
            {
                i++;
            }
            while (testArray[j] > pivot)
            {
                j--;
            }

            if (i <= j)
            {
                int temp = testArray[i];
                testArray[i] = testArray[j];
                testArray[j] = temp;

                i++;
                j--;
            }
        }
        return i;
    }
}
