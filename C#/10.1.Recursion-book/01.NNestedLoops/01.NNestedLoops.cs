using System;

class NNestedLoops
{
    static int[] loopsArray;
    static int numberOfLoops;

    static void Main()
    {
        numberOfLoops = 4;

        loopsArray = new int[numberOfLoops];

        InitiateArray();

        NestedLoops(0);
    }

    //this is the recursive method that will imitate the nested loops
    static void NestedLoops(int currentLoop)
    {
        if (currentLoop == numberOfLoops)
        {
            Print(loopsArray);
            return;
        }

        //the irritation of every loop is from 1 to numberOfLoops
        for (int i = 1; i <= numberOfLoops; i++)
        {
            loopsArray[currentLoop] = i;
            NestedLoops(currentLoop + 1);
        }
    }

    //this method will initially set the array values to 1
    static void InitiateArray()
    {
        for (int i = 0; i < loopsArray.Length; i++)
        {
            loopsArray[i] = 1;
        }
    }

    //this method will print our array any time
    static void Print(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}

