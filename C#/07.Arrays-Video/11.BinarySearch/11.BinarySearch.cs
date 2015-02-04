using System;

class BinarySearch
{
    static int[] testArray = { -99, -1, 1, 2, 3, 4, 6, 8, 90, 110, 990 };

    static void Main()
    {
        int elementToFind = 990;

        int lowEnd = 0;
        int highEnd = testArray.Length - 1;
        int middle = (lowEnd + highEnd) / 2;

        int index = BinarySear(elementToFind, lowEnd, highEnd);
        Console.WriteLine("The index of the element is: {0}", index);
    }

    static int BinarySear(int elementToFind, int lowEnd, int highEnd)
    {
        if (lowEnd > highEnd)
        {
            return -1;
        }
        else
        {
            int middle = (lowEnd + highEnd) / 2;

            if (elementToFind < testArray[middle])
            {
                return BinarySear(elementToFind, lowEnd, middle - 1);
            }
            else if (elementToFind > testArray[middle])
            {
                return BinarySear(elementToFind, lowEnd + 1, highEnd);
            }
            else
            {
                return middle;
            }
        }
    }
}

