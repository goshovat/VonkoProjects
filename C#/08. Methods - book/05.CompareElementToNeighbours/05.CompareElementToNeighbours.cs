using System;

class CompareElementToNeighbours
{
    static void Main()
    {
        Test1();

        Test2();

        Test3();

        Test4();

        Test5();

        Test6();

        Test7();
    }

    //our method
    static string CompareElement(int index, int[] myArray)
    {
        string result = "The element is neither bigger nor smaller than it's neighbours";

        if (myArray.Length == 0 || myArray.Length == 1)
        {
            result = "There are no other elements to compare with";
            return result;
        }

        if (index == 0)
        {
            if (myArray[index] > myArray[index + 1])
            {
                result = "The element is bigger than it's only neighbour";
            }
            else if (myArray[index] < myArray[index + 1])
            {
                result = "The element is smaller than it's only neighbour";
            }
         }
        else if (index == myArray.Length - 1)
        {
            if (myArray[index] > myArray[index - 1])
            {
                result = "The element is bigger than it's only neighbour";
            }
            else if (myArray[index] < myArray[index - 1])
            {
                result = "The element is smaller than it's only neighbour";
            }
        }
        else
        {
            if (myArray[index] > myArray[index + 1] && myArray[index] > myArray[index - 1])
            {
                result = "The element is bigger than it's two neighbours";
            }
            else if (myArray[index] < myArray[index + 1] && myArray[index] < myArray[index - 1])
            {
                result = "The element is smaller than it's two neighnours";
            }
        }

        return result;
    }

    //the test methods
    static void Test1()
    {
        int[] myArray = new int[0];
        int index = 1;

        Console.WriteLine("Array: {0}, Position of the element: {1}\n\r Result: {2}", string.Join(",", myArray), index, CompareElement(index, myArray));
        Console.WriteLine();
    }

    static void Test2()
    {
        int[] myArray = {2};
        int index = 1;

        Console.WriteLine("Array: {0}, Position of the element: {1}\n\r Result: {2}", string.Join(",", myArray), index, CompareElement(index, myArray));
        Console.WriteLine();
    }

    static void Test3()
    {
        int[] myArray = {1, 2 ,-2};
        int index = 1;

        Console.WriteLine("Array: {0}, Position of the element: {1}\n\r Result: {2}", string.Join(",", myArray), index, CompareElement(index, myArray));
        Console.WriteLine();
    }

    static void Test4()
    {
        int[] myArray = { 5, 2, 9, 10, 4, 11};
        int index = 1;

        Console.WriteLine("Array: {0}, Position of the element: {1}\n\r Result: {2}", string.Join(",", myArray), index, CompareElement(index, myArray));
        Console.WriteLine();
    }

    static void Test5()
    {
        int[] myArray = { 5, 2, 9, 10, 4, 11 };
        int index = 0;

        Console.WriteLine("Array: {0}, Position of the element: {1}\n\r Result: {2}", string.Join(",", myArray), index, CompareElement(index, myArray));
        Console.WriteLine();
    }

    static void Test6()
    {
        int[] myArray = { 5, 2, 9, 10, 42, 11 };
        int index = 5;

        Console.WriteLine("Array: {0}, Position of the element: {1}\n\r Result: {2}", string.Join(",", myArray), index, CompareElement(index, myArray));
        Console.WriteLine();
    }

    static void Test7()
    {
        int[] myArray = { 1, 2, 9, 10, 42, 11 };
        int index = 2;

        Console.WriteLine("Array: {0}, Position of the element: {1}\n\r Result: {2}", string.Join(",", myArray), index, CompareElement(index, myArray));
        Console.WriteLine();
    }
}
