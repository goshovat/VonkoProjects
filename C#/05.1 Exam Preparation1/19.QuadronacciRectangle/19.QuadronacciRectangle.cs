using System;
using System.Numerics;

class QuadronacciRectangle
{
    static void Main()
    {
        BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger secondNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdNumber = BigInteger.Parse(Console.ReadLine());
        BigInteger fourthNumber = BigInteger.Parse(Console.ReadLine());
        int rows = int.Parse(Console.ReadLine());
        int columns = int.Parse(Console.ReadLine());

        Console.Write(firstNumber + " " + secondNumber + " " + thirdNumber +
            " " +fourthNumber + " ");

        BigInteger currentNumber = 0;

        for (int i = 0; i < rows; i++)
        {
            int currentCols = 0;

            if (i == 0)
            {
                currentCols = 4;
            }

            for (int j = currentCols; j< columns; j++)
            {
                currentNumber = firstNumber + secondNumber + thirdNumber + fourthNumber;              
                firstNumber = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = fourthNumber;
                fourthNumber = currentNumber;

                Console.Write(currentNumber + " ");
            }
            Console.WriteLine();
        }
    }
}

