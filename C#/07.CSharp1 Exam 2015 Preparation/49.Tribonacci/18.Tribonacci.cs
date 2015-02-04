using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger input = int.Parse(Console.ReadLine());

        BigInteger currentMember = 0;

        if (input == 1)
        {
            currentMember = firstNumber;
        }
        else if (input == 2)
        {
            currentMember = secondNumber;
        }
        else if (input == 3)
        {
            currentMember = thirdNumber;
        }
        else
        {
            for (int i = 4; i <= input; i++)
            {
                currentMember = firstNumber + secondNumber + thirdNumber;
                firstNumber = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = currentMember;
            }
        }

        Console.WriteLine(currentMember);
    }
}

