using System;

class SieveOfEratosthenes
{
    static void Main()
    {
        int limit = 10000000;
        bool[] primeOrNot = new bool[limit];

        //initially assume all numbers are prime
        for (int i = 0; i < limit; i++)
        {
            primeOrNot[i] = true;
        }

        //now find the numbers which are not prime
        //0, 1 and 2 are prime numbers
        for (int i = 2; i < limit; i++)
        {
            if (primeOrNot[i])
            {
                for (int p = 2; p * i < limit; p++)
                {
                    primeOrNot[p * i] = false;
                }
            }
        }

        //print the result
        for (int index = 0; index < limit; index++)
        {
            if (primeOrNot[index])
            {
                Console.WriteLine(index);
            }
        }
    }
}
