using System;
using System.Numerics;

class AngryFemaleGPS
{
    static void Main()
    {
        string number = Console.ReadLine().Trim('-');
        long evenSum = 0;
        long oddSum = 0;

        for (int i = 0; i < number.Length; i++)
        {
            int currentNumber = int.Parse(number[i].ToString());

            if (currentNumber % 2 == 0)
                evenSum += currentNumber;
            else
                oddSum += currentNumber;
        }

        if (evenSum > oddSum)
            Console.WriteLine("right {0}", evenSum);
        else if (oddSum > evenSum)
            Console.WriteLine("left {0}", oddSum);
        else
            Console.WriteLine("straight {0}", evenSum);
    }
}
