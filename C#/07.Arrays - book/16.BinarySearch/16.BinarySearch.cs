using System;

class BinarySearch
{
    static void Main()
    {
        int[] myArr = { 1, 2, 3, 8, 677, 678, 902, 1040 };
        int arrLen = myArr.Length;

        int numberToSearch = 677;
        int middlePoint = 0;
        int lowEnd = 0;
        int highEnd = arrLen - 1;
        int index = int.MinValue;

        while (lowEnd <= highEnd)
        {
            middlePoint = lowEnd + (highEnd - lowEnd) / 2;

            if (myArr[middlePoint] == numberToSearch)
            {
                index = middlePoint;
                break;
            }
            else if (myArr[middlePoint] > numberToSearch)
            {
                highEnd = middlePoint -1;
            }
            else if (myArr[middlePoint] < numberToSearch)
            {
                lowEnd = middlePoint + 1;
            }
        }


        if (index == int.MinValue)
        {
            index = -1;
        }

        Console.WriteLine("The index of the number we search is: {0}", index);
        Console.WriteLine();
    }
}

