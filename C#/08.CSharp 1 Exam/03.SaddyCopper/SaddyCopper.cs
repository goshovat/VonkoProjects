using System;
using System.Collections.Generic;
using System.Numerics;

class SaddyCopper
{
    static void Main()
    {
        string number = Console.ReadLine();
        List<long> sums = new List<long>();
        BigInteger product = 1;

        for (int transformation = 1; transformation <= 10; transformation++)
        {
            if (transformation > 1)
            {
                number = product.ToString();
                product = 1;
            }

            int counter = 1;
            while (number.Length > 1)
            {
                if (counter > 100000)
                    throw new ApplicationException("Error");

                number = number.Substring(0, number.Length - 1);
                long currentSum = 0;

                for (int i = 0; i < number.Length; i++)
                {
                    if (i % 2 == 0)
                        currentSum += (int)(number[i] - '0');
                }
                sums.Add(currentSum);

                counter++;
            }

            foreach (long sum in sums)
            {
                product *= sum;
            }
            if (product < 10)
            {
                Console.WriteLine(transformation);
                Console.WriteLine(product);
                return;
            }
            sums = new List<long>();
        }

        Console.WriteLine(product);
    }
}