using System;

class TrailingZeroes
{
    static void Main()
    {
        /*My program is not calculating N!, because then we have to use BigInteger. The idea
        is to calculate the trailing zeroes without straigthforward calculating of factorial*/
        Console.WriteLine("Write a positive integer N: ");
        decimal n = int.Parse(Console.ReadLine());
        int counter = 0;

        for (int i = 1; i <= n; i++)
        {
            if (i % 5 == 0)
            {
                int divider = i;
                while (divider % 5 == 0)
                {
                    counter++;
                    divider /= 5;
                }
            }
        }
        Console.WriteLine("The trailing zeroes at the end of N! are: {0}", counter);
    }
}
