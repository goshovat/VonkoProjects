using System;
using System.Numerics;

class LeastMajorityMultiple
{
    static void Main()
    {
        int[] numbers = new int[5];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int numberToCheck = 1;
        long leastMajorite = numberToCheck;
        bool leastMajoriteFound = false;
        while(!leastMajoriteFound)
        {
            int currentCount = 0;

            for (int j = 0; j < 5; j++)
            {
                if (numberToCheck % numbers[j] == 0)
                {
                    currentCount++;
                }

                if (currentCount == 3)
                {
                    leastMajorite = numberToCheck;
                    leastMajoriteFound = true;
                    break;
                }
            }
            numberToCheck++;
        }

        Console.WriteLine(leastMajorite);
    }
}
