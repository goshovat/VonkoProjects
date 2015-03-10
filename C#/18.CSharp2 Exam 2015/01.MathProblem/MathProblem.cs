using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

class MathProblem
{
    private const int BASE = 19;

    private static Dictionary<char, int> digits = new Dictionary<char, int>()
    {
        {'a', 0}, {'b', 1}, {'c', 2}, {'d', 3}, {'e', 4}, {'f', 5}, {'g', 6}, {'h', 7}, {'i', 8}
        , {'j', 9}, {'k', 10}, {'l', 11}, {'m', 12}, {'n', 13}, {'o', 14}, {'p', 15}, {'q', 16}, {'r', 17}, {'s', 18}
    };

    private static char[] digits1 = {'a', 'b', 'c', 'd', 'e', 'f','g', 'h', 'i',
                        'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's'};
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        BigInteger sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            string currentEntity = input[i];

            long partialSum = 0;
            for (int j = 0; j < currentEntity.Length; j++)
            {
                int power = 1;

                for (int k = currentEntity.Length - j - 1; k > 0; k--)
                {
                    power *= BASE;
                }
                partialSum += digits[currentEntity[j]] * power;
            }

            sum += partialSum;
        }

        //Console.WriteLine(sum);
        //find the decimal sum
        BigInteger oldSum = sum;

        if (sum == 0)
        {
            Console.WriteLine("{0} = {1}", 'a', 0);
            return;
        }

        StringBuilder result = new StringBuilder();
        while (sum > 0)
        {
            int remainder = (int)(sum % BASE);
            result.Insert(0, digits1[remainder]);
            sum = sum / BASE;
        }

        Console.WriteLine("{0} = {1}", result.ToString(), oldSum);
    }
}

