using System;

class ArrayOf20Ints
{
    static void Main()
    {
        int[] myArray = new int[20];

        for (int i = 0; i < 20; i++)
        {
            myArray[i] = i * 5;
            Console.WriteLine("Element on position {0} is: {1}", i, myArray[i]);
        }
    }
}

