using System;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] myArray = { 5, 2, 9, 10, 4, 11 };

        int indexFirstBigger = FindFirstBiggerThanNeighbours(myArray);
        Console.WriteLine(indexFirstBigger);
    }

    private static int FindFirstBiggerThanNeighbours(int[] myArray)
    {
        for (int i = 0; i < myArray.Length; i++)
        {
            if (LargerThanNeighbours.LargerThanNeighbours.CompareElement(i, myArray) ==
                "The element is bigger than it's two neighbours")
            {
                return i;
            }
        }
        return -1;
    }
}
