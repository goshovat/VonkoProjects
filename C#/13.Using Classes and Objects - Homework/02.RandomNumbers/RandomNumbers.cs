using System;

class RandomNumbers
{
    static Random randomGenerator = new Random();

    static void Main()
    {
        int startValue = 100;
        int endValue = 200;

        Console.WriteLine("The random numbers are: ");

        for (int i = 0; i < 10; i++)
        {
            Console.Write(GenerateRandomNumber(startValue, endValue) + " ");
        }
        Console.WriteLine();
    }

    //this method will generate a random number in the interval
    static int GenerateRandomNumber(int startValue, int endValue)
    {
        return randomGenerator.Next(endValue - startValue + 1) + startValue;
    }
}
