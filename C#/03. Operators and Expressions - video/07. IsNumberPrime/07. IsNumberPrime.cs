using System;

class IsNumberPrime
{
    static void Main()
    {
        Console.WriteLine("Write the number n:");
        string input = Console.ReadLine();
        int n = Convert.ToInt32(input);

        bool isPrime = true;

        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                isPrime = false;
                break;
            }
        }

        Console.WriteLine("The number is prime: {0}",isPrime);
    }
}

