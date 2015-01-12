using System;

class IsNumberPrime_solution_2
{
    static void Main()
    {
        Console.WriteLine("Write the number n:");
        string input = Console.ReadLine();
        int n = Convert.ToInt32(input);

        bool isPrime = ((n % 2 != 0) && (n % 3 != 0) && (n % 5 != 0) && (n % 7 != 0));
        bool isOneDigitPrime = ((n == 2) || (n == 3) || (n == 5) || (n == 7));

        bool result = isPrime || isOneDigitPrime;
        Console.WriteLine("The number is prime: " + result);
    }
}

