using System;

class IsPrime
{
    static void Main()
    {
        Console.WriteLine("Write the number n:");
        string inputN = Console.ReadLine();
        int n = Convert.ToInt32(inputN);

        bool isPrime = true;

        if (n != 2)
        {
            for (int i = 2; i < n-1; i++)
            {           
                if (n % i != 0)
                {
                    isPrime = true;   
                 }
                else
                {
                    isPrime = false;
                    break;
                }

            }
        }
        else
        {
            isPrime = true;
        }

        Console.WriteLine("Is the number prime? {0}", isPrime);
    }
}

