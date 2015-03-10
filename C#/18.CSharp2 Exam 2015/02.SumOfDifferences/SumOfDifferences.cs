using System;
using System.Numerics;

class SumOfDifferences
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        BigInteger[] numbers = new BigInteger[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        BigInteger sum = 0;
        int index = 1;

        while (true)
        {
            if (index >= numbers.Length)
                break;

            BigInteger currentNumber = numbers[index];
            BigInteger prevNumber = numbers[index - 1];

            BigInteger diff = Math.Abs((long)currentNumber - (long)prevNumber);

            if (diff % 2 == 0)
                index += 2;
            else
            {
                index += 1;
                sum += diff;
            }
        }

        Console.WriteLine(sum);
    }
}
