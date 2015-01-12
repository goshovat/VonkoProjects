using System;

class PrintSequence
{
    static void Main()
    {
        int startNumber = 2;
        for (int i = startNumber; i < startNumber + 10; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
            else
            {
                Console.WriteLine(-i);
            }
        }
    }
}


