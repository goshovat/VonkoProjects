using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

class BunnyFactory
{
    static void Main()
    {
        List<int> cages = new List<int>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input.Trim() == "END")
                break;

            cages.Add(int.Parse(input));
        }

        int i = 1;
        while (true)
        {
            //1.
            if (cages.Count < i)
                break;

            //2
            BigInteger sum = 0;
            for (int j = 0; j < i; j++)
            {
                sum += cages[j];
            }

            //3
            if (cages.Count - i < sum)
                break;

            //4
            BigInteger sum2 = 0;
            BigInteger product = 1;
            for (int j = i; j < i + sum; j++)
            {
                sum2 += cages[j];
                product *= cages[j];
            }

            //5
            StringBuilder newCages = new StringBuilder();
            newCages.Append(sum2.ToString());
            newCages.Append(product.ToString());

            for (int j = i + (int)sum; j < cages.Count; j++)
                newCages.Append(cages[j]);

            //6
            cages = new List<int>();
            for (int j = 0; j < newCages.Length; j++)
            {
                if (newCages[j] != '0' && newCages[j] != '1')
                    cages.Add((int)(newCages[j] - '0'));
            }
            i++;
        }

        //print the result
        Console.WriteLine(string.Join(" ", cages));
    }
}
