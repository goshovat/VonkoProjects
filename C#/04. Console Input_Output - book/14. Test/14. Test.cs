using System;

class Fibonacci
{
    static void Main()
    {
        decimal sum = 1;
        decimal oldSum = -1;
        for (decimal i = 2; i < 999999999; i++)
        {

            if (i % 2 == 0)
            {
                sum += (1 / i);
            }
            else
            {
                sum -= (1 / i);
            }

            if (sum - oldSum == 0.001M)
            {
                break;
            }
            else
            {
                oldSum = sum;
            }

        }

        Console.WriteLine("{0}", sum);
    }
}