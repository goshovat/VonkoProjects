using System;

class NFactandKFactExpression2
{
    static void Main()
    {
        Console.WriteLine("Enter N and K (both to be bigger than 1): ");
        ulong n = ulong.Parse(Console.ReadLine());
        ulong k = ulong.Parse(Console.ReadLine());

        if (n > 1 && k > 1)
        {
            if (k > n)
            {
                ulong temp = n;
                n = k;
                k = temp;
            }

            ulong kToNFactorial = 1;
            ulong kFactorial = 1;
            ulong result = 1;

            for (ulong i = (n-k + 1); i <= n; i++)
            {
                kToNFactorial *= i;
            }

            for (ulong i = 1; i <= k; i++) 
            {
                kFactorial *=i;
            }


            result = kToNFactorial * kFactorial ;
            Console.WriteLine("Result: {0}", result);
        }
        else
        {
            Console.WriteLine("Enter valid numbers!");
        }
    }
}

