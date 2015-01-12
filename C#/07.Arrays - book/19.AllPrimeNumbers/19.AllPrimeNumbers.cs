using System;

class AllPrimeNumbers
{
    static void Main()
    {
        long limit = 20000;

        bool[] primeOrNotArr = new bool[limit];

        for (int i = 2; i < limit; i++)
        {
            primeOrNotArr[i] = true;
        }

        for (int i = 2; i < limit; i++)
        {
            if (primeOrNotArr[i])
            {
                for (int p = 2; p * i < limit; p++)
                {
                    primeOrNotArr[p * i] = false;
                }
            }
        }

        Console.WriteLine("All the prime numbers are: ");
        //now print all the prime numbers
        for (int i = 0; i < limit; i++)
        {
            if (primeOrNotArr[i])
            {
                Console.Write(i + " ");
            }
        }
    }
}

