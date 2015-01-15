using System;

class PrimeNumberCheck
{
    static void Main()
    {
        Console.WriteLine("Write the number:");
        int number = int.Parse(Console.ReadLine());

        bool isPrime = true;

        if (number <= 1)
        {
            isPrime = false;
        }
        else
        {
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
        }

        Console.WriteLine("The number is prime: {0}", isPrime);
    }
}