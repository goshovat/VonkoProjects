using System;

class NFactdividedByKFact
{
    static void Main()
    {
        Console.WriteLine("Enter N and K (bothe to be bigger than 1): ");
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        if (n > 1 && k > 1)
        {
            if (k > n)
            {
                int temp = n;
                n = k;
                k = temp;
            }

            int nFactorial = 1;
            int kFactorial = 1;
            int result = 1;

            for (int i = 1; i <= n; i++)
            {
                nFactorial *= i;
            }
            for (int i = 1; i <= k; i++)
            {
                kFactorial *= i;  
            }

            result = nFactorial / kFactorial;
            Console.WriteLine("Result :{0}",result);
        }
        else
        {
            Console.WriteLine("Enter valid numbers!");
        }
    }
}

