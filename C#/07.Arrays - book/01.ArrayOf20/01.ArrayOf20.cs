using System;

class ArrayOf20
{
    static void Main()
    {
        int[] myArray = new int[20];

        Console.WriteLine("My array is: ");

        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = i * 5;
            Console.Write(myArray[i] + " ");
        }
    }
}

