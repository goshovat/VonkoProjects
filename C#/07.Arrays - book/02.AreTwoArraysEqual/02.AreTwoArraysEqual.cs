using System;

class AreTwoArraysEqual
{
    static void Main()
    {
        Console.WriteLine("Enter the length of the arrays: ");

        int arrLen = int.Parse(Console.ReadLine());

        //initialize and read the first array

        int[] firstArray = new int[arrLen];

        for (int i = 0; i < arrLen; i++)
        {
            Console.WriteLine("Enter element with index {0} of the first array:", i);
            firstArray[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("------------------------------");
        Console.WriteLine();

        //initialize and read the second array

        int[] secondArray = new int[arrLen];

        for (int i = 0; i < arrLen; i++)
        {
            Console.WriteLine("Enter element with index {0} of the second array:", i);
            secondArray[i] = int.Parse(Console.ReadLine());
        }

        //check if the two arrays are equal

        bool areEqual = true;

        for (int i = 0; i < arrLen; i++)
        {
            if (firstArray[i] != secondArray[i])
            {
                areEqual = false;
            }
        }

        Console.WriteLine("The arrays are equal: {0}", areEqual);
    }
}

