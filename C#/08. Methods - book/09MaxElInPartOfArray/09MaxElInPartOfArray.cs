using System;

class MaxElInPartOfArray
{
    static void Main()
    {
        Test1();
        Test2();
        Test3();
    }

    static int FindMaxElement(int startIndex, int endIndex, int[] myArray)
    {
        //cover the cases if the array contains 0 or 1 elements
        if (myArray.Length == 0)
        {
            Console.WriteLine("The array does not contain any elements");
            return int.MinValue;
        }
        else if (myArray.Length == 1)
        {
            Console.WriteLine("The array contains only one element");
            return int.MinValue;
        }

        int len = endIndex - startIndex + 1;

        int[] partialArray = new int[len];

        for (int i = 0; i < partialArray.Length; i++)
        {
            partialArray[i] = myArray[i + startIndex];
        }

        Array.Sort(partialArray);

        int maxElement = partialArray[len - 1];

        return maxElement;
    }

    //testing methods
    static void Test1()
    {
        int[] myArray = { 2, 5, 6, 9, 99, 100, 1, 0 };

        int startIndex = 2;
        int endIndex = 7;

        int result = FindMaxElement(startIndex, endIndex, myArray);

        if (result != int.MinValue)
        {
            Console.WriteLine("The max element between indexes {0} and {1} is:\n\r{2}",
                                startIndex, endIndex, result);
        }
        Console.WriteLine();
    }

    static void Test2()
    {
        int[] myArray = {5, 6, 9, 8, 10};

        int startIndex = 2;
        int endIndex = 2;

        int result = FindMaxElement(startIndex, endIndex, myArray);

        if (result != int.MinValue)
        {
            Console.WriteLine("The max element between indexes {0} and {1} is:\n\r{2}",
                                startIndex, endIndex, result);
        }
        Console.WriteLine();
    }

    static void Test3()
    {
        int[] myArray = new int[0];

        int startIndex = 0;
        int endIndex = 0;

        int result = FindMaxElement(startIndex, endIndex, myArray);

        if (result != int.MinValue)
        {
            Console.WriteLine("The max element between indexes {0} and {1} is:\n\r{2}",
                                startIndex, endIndex, result);
        }
        Console.WriteLine();
    }
}

