using System;

class CountNumberInArray
{
    static void Main()
    {
        //initiate first test
        Test1();

        //initiate second test
        Test2();

        //initiate third test
        Test3();
    }

    static int CountNumber(int number, int[] myArray)
    {
        int encounters = 0;

        for (int i = 0; i < myArray.Length; i++)
        {
            if (number == myArray[i])
            {
                encounters++;
            }
        }

        return encounters;
    }

    //first test method
    static void Test1()
    {
        int[] myArray = { 0, 5, 6, 7, 9, 10 };

        int number = 95;

        int encounters = CountNumber(number, myArray);

        Console.WriteLine("The number {0} is encoountered in the array {1}: \n\r {2} times"
            , number, string.Join(",", myArray), encounters);
    }

    //second test method
    static void Test2()
    {
        int[] myArray = { 4, 4, 4, 4, 4, 4 };

        int number = 4;

        int encounters = CountNumber(number, myArray);

        Console.WriteLine("The number {0} is encoountered in the array {1}: \n\r {2} times"
            , number, string.Join(",", myArray), encounters);
    }

    //third test method
    static void Test3()
    {
        int[] myArray = {1, 3, 6, 3, 9, 8 };

        int number = 3;

        int encounters = CountNumber(number, myArray);

        Console.WriteLine("The number {0} is encoountered in the array {1}: \n\r {2} times"
            , number, string.Join(",", myArray), encounters);
    }
}

