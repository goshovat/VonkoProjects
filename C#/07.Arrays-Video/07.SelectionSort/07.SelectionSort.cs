using System;

class SelectionSort
{
    static void Main()
    {
        int[] myArray = { 5, -7, 8, 10, 11, 0, -3, 99, 22 };

        for (int i = 0; i < myArray.Length; i++)
        {
            int minimalIndex = i;
            bool hasSwapped = false;

            for (int j = i + 1; j < myArray.Length; j++)
            {
                if (myArray[j] < myArray[minimalIndex]) 
                {
                    minimalIndex = j;
                    hasSwapped = true;
                }

                //only if the minimum index is change we swap values
                if (hasSwapped)
                {
                    int temp = myArray[i];
                    myArray[i] = myArray[minimalIndex];
                    myArray[minimalIndex] = temp;
                }
            }
        }

        //print the sorted array
        for (int i = 0; i < myArray.Length; i++)
        {
            Console.Write(myArray[i] + " ");
        }
    }
}

