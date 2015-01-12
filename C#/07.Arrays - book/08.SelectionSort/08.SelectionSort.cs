using System;

class SelectionSort
{
    static void Main()
    {
        //Initialize the array
        Console.WriteLine("Enter the length of the array: ");
        int arrLen = int.Parse(Console.ReadLine());
        int[] myArr = new int[arrLen];

        //set the values of the array
        for (int i = 0; i < arrLen; i++)
        {
            Console.WriteLine("Enter element No {0} of the array: ", i);
            myArr[i] = int.Parse(Console.ReadLine());
        }

        //now sort the numbers

        int minIndex, temp;

        for (int i = 0; i < arrLen - 1; i++)
        {
            minIndex = i;

            for (int j = i + 1; j < arrLen; j++)
            {
                if (myArr[j] < myArr[minIndex])
                {
                    minIndex = j;
                }
            }

            temp = myArr[i];
            myArr[i] = myArr[minIndex];
            myArr[minIndex] = temp;
        }

        //print the sorted array
        Console.WriteLine("The sorted array is: ");

        for (int i = 0; i < arrLen; i++)
        {
            Console.Write(myArr[i] + " ");
        }
    }
}

