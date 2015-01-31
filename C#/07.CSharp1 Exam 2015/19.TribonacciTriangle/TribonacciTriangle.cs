using System;

class TribonacciTriangle
{
    static void Main()
    {
        long firstNumber = int.Parse(Console.ReadLine());
        long secondNumber = int.Parse(Console.ReadLine());
        long thirdNumber = int.Parse(Console.ReadLine());
        int lines = int.Parse(Console.ReadLine());

        int currentIndex = 0;
        long currentNumber = firstNumber;
        for (int row = 1; row <= lines; row++)
        {
            for (int i = 0; i < row; i++)
            {
                if (currentIndex == 0)
                {
                    Console.Write(firstNumber + " ");
                    currentIndex++;
                }
                else if (currentIndex == 1)
                {
                    Console.Write(secondNumber + " ");
                    currentIndex++;
                }
                else if (currentIndex == 2)
                {
                    Console.Write(thirdNumber + " ");
                    currentIndex++;
                }
                else
                {
                    currentNumber = firstNumber + secondNumber + thirdNumber;
                    Console.Write(currentNumber + " ");
                    firstNumber = secondNumber;
                    secondNumber = thirdNumber;
                    thirdNumber = currentNumber;
                }
            }
            Console.WriteLine();
        }
    }
}
