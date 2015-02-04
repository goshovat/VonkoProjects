using System;

class SelectionSort
{
    static void Main()
    {
        int[] myArray = { 5, -7, 8, 10, 11, 0, -3, 99, 22 };

        for (int i = 0; i < myArray.Length; i++)
        {
            int minIndex = i;

            for (int j = i; j < myArray.Length; j++)
            {
                if (myArray[j] < myArray[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                int temp = myArray[i];
                myArray[i] = myArray[minIndex];
                myArray[minIndex] = temp;
            }
        }

        //print the sorted array
        for (int i = 0; i < myArray.Length; i++)
        {
            Console.Write(myArray[i] + " ");
        }
    }
}
