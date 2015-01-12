using System;

class Sum1plus1N
{
    static void Main()
    {
        decimal sum = 1;
        decimal temp = 0;

        for (int i = 2; Math.Abs(sum - temp) > 0.001m; i++)
        {
            if (i % 2 != 0)
            {
                temp = sum;
                sum -= 1.0m/i;
            }
            else
            {
                temp = sum;
                sum += 1.0m/i;
            }
        }

        Console.WriteLine(sum);

    }
}

