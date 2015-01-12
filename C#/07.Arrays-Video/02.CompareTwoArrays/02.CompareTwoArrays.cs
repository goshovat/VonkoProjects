using System;

class CompareTwoArrays
{
    static void Main()
    {
        Console.WriteLine("Enter the length of the two arrays:");
        int len = int.Parse(Console.ReadLine());

        int[] myArray1 = new int[len];
        int[] myArray2 = new int[len];
        bool areEqual = true;

        for (int i = 0; i < len; i++)
        {
            Console.WriteLine("Enter element No {0} of the first array: ", i);
            myArray1[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter element No {0} of the second array: ", i);
            myArray2[i] = int.Parse(Console.ReadLine());

            if (myArray1[i] != myArray2[i])
            {
                areEqual = false;
                break;
            }
        }

        Console.WriteLine("Are the arrays equal? {}", areEqual);
    }
}

