using System;

class PrintLongSequence
{
    static void Main()
    {
        int startNumber = 2;
        for (int i = startNumber; i < startNumber + 1000; i++)
        {
            Console.WriteLine(i);
        }
    }
}

