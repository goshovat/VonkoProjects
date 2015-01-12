using System;

class BiggestCommonDenominatorEuclidAlg
{
    static void Main()
    {
        double n = 0;
        double m = 0;
        Console.WriteLine("Enter a positivie doubleeger n: ");
        bool parseN = double.TryParse(Console.ReadLine(), out n);
        Console.WriteLine("Enter a positivie doubleeger m: ");
        bool parseM = double.TryParse(Console.ReadLine(), out m);

        if (parseN && parseM)
        {
            while (n > 0 && m > 0)
            {
                if (n > m)
                {
                    n -= m;
                }
                else
                {
                    m -= n;
                }
            }

            double gcd = Math.Max(n, m);
            Console.WriteLine("The greatest common denominator of the two numbers is {0}", gcd);
        }
        else
        {
            Console.WriteLine("Enter valid numbers!");
        }
    }
}

