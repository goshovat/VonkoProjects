using System;

class FirstBiggerThanTwoNeighbrs
{
    static void Main()
    {
        Test1();

        Test2();

        Test3();

        Test4();

        Test5();

        Test6();
    }

    //our method
    static int FindElBiggerThanTwoNeigbrs(int[] myArray) 
    {
        int index = -1;

        if (myArray.Length == 0 || myArray.Length == 1 || myArray.Length == 2)
        {
            return index;
        }

        for (int i = 1; i < myArray.Length - 1; i++)
        {
            if (myArray[i] > myArray[i - 1] && myArray[i] > myArray[i + 1])
            {
                index = i;
            }
        }

        return index;
    }

    //the test methods
    static void Test1()
    {
        int[] myArray = new int[0];

        Console.WriteLine("Array: {0}, Position of the desired element: {1}", string.Join(",", myArray), FindElBiggerThanTwoNeigbrs(myArray));
        Console.WriteLine();
    }

    static void Test2()
    {
        int[] myArray = { 2 , 3  };

        Console.WriteLine("Array: {0}, Position of the desired element: {1}", string.Join(",", myArray), FindElBiggerThanTwoNeigbrs(myArray));
        Console.WriteLine();
    }

    static void Test3()
    {
        int[] myArray = { 1, 2, -2 };

        Console.WriteLine("Array: {0}, Position of the desired element: {1}", string.Join(",", myArray), FindElBiggerThanTwoNeigbrs(myArray));
        Console.WriteLine();
    }

    static void Test4()
    {
        int[] myArray = { 5, 10, 9, 10, 49, 11 };

        Console.WriteLine("Array: {0}, Position of the desired element: {1}", string.Join(",", myArray), FindElBiggerThanTwoNeigbrs(myArray));
        Console.WriteLine();
    }

    static void Test5()
    {
        int[] myArray = { 5, 2, 9, 10, 4, 11 };

        Console.WriteLine("Array: {0}, Position of the desired element: {1}", string.Join(",", myArray), FindElBiggerThanTwoNeigbrs(myArray));
        Console.WriteLine();
    }

    static void Test6()
    {
        int[] myArray = { 5, 2, 9, 10, 42, 11 };

        Console.WriteLine("Array: {0}, Position of the desired element: {1}", string.Join(",", myArray), FindElBiggerThanTwoNeigbrs(myArray));
        Console.WriteLine();
    }
}

