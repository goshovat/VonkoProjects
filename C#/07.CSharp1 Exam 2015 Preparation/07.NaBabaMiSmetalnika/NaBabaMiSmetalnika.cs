using System;
using System.Numerics;

class NaBabaMiSmetalnika
{
    private static uint[] numbers;
    private const int MOST_LEFT_BIT = 0;
    private static int mostRightBit;

    static void Main()
    {
        int cols = int.Parse(Console.ReadLine());
        int rows = 8;
        mostRightBit = cols - 1;
        numbers = new uint[rows];
        for (int i = 0; i < rows; i++)
        {
            numbers[i] = uint.Parse(Console.ReadLine());
        }

        string command = Console.ReadLine();
        while (command != "stop")
        {
            int rowPos = 0;
            int colPos = 0;
            if (command == "left" || command == "right")
            {
                rowPos = int.Parse(Console.ReadLine());
                colPos = int.Parse(Console.ReadLine());
            }

            //probably the problem is here
            if (colPos < 0)
                colPos = 0;
            else if (colPos > mostRightBit)
                colPos = mostRightBit;

            switch (command)
            {
                case "left":
                    MoveLeft(rowPos, colPos);
                    break;
                case "right":
                    MoveRight(rowPos, colPos);
                    break;
                case "reset":
                    Reset();
                    break;
            }
            command = Console.ReadLine();
        }

        BigInteger finaltResult = CalculateResult();
        Console.WriteLine(finaltResult);
    }

    private static void MoveLeft(int rowPos, int colPos)
    {
        uint currentNumber = numbers[rowPos];

        for (int bit = 0; bit <= colPos; bit++)
        {
            //this will move the first bit 1 to position bit if position bit is free
            int tempBit = bit;

            if (BitIsZero(tempBit, currentNumber))
            {
                tempBit++;
                //find the most-left bit one that will be moved to left
                while (tempBit <= colPos && BitIsZero(tempBit, currentNumber))
                {
                    tempBit++;
                }

                //only if we found bit one we will move it to right
                if (tempBit <= colPos && !BitIsZero(tempBit, currentNumber))
                {
                    uint mask = 1;
                    for (int i = mostRightBit; i > tempBit; i--)
                    {
                        mask = mask << 1;
                    }
                    //null the bit at position where we move away the 1
                    currentNumber = currentNumber & (~mask);
                    mask = 1;
                    for (int i = mostRightBit; i > bit; i--)
                    {
                        mask = mask << 1;
                        //if (BitIsZero(i))
                        //    break;
                    }
                    currentNumber = currentNumber | (mask);
                }
            }
        }
        numbers[rowPos] = currentNumber;
    }

    private static void MoveRight(int rowPos, int colPos)
    {
        uint currentNumber = numbers[rowPos];

        for (int bit = mostRightBit; bit > colPos; bit--)
        {
            //this will move the first bit 1 to position bit if position bit is free
            int tempBit = bit;

            if (BitIsZero(tempBit, currentNumber))
            {
                tempBit--;
                //find the most-right bit one that will be moved to right
                while (tempBit >= colPos && BitIsZero(tempBit, currentNumber))
                {
                    tempBit--;
                }

                //only if we found bit one we will move it to right
                if (tempBit >= colPos && !BitIsZero(tempBit, currentNumber))
                {
                    uint mask = 1;
                    for (int i = mostRightBit; i > tempBit; i--)
                    {
                        mask = mask << 1;
                    }
                    //null the bit at position where we move away the 1
                    currentNumber = currentNumber & (~mask);
                    mask = 1;
                    for (int i = mostRightBit; i > bit; i--)
                    {
                        mask = mask << 1;
                        //if (BitIsZero(i))
                        //    break;
                    }
                    currentNumber = currentNumber | (mask);
                }
            }
        }

        numbers[rowPos] = currentNumber;
    }

    private static void Reset()
    {
        for (int row = 0; row < numbers.Length; row++)
        {
            MoveLeft(row, mostRightBit);
        }
    }

    private static bool BitIsZero(int bit, uint currentNumber)
    {
        int mask = 1;
        for (int i = mostRightBit; i > bit; i--)
        {
            mask = mask << 1;
        }
        if ((mask & currentNumber) != 0)
            return false;
        else 
            return true;
    }

    private static BigInteger CalculateResult()
    {
        BigInteger result = 0;
        //first get the sum of all numbers 
        for (int number = 0; number < numbers.Length; number++)
        {
            result += numbers[number];
        }

        //check how many columns are free
        int freeColumns = 0;
        int mask = 1;
        for (int col = 0; col <= mostRightBit; col++)
        {
            bool isColumnFree = true;
            
            for (int number = 0; number < numbers.Length; number++)
            {
                if ((numbers[number] & mask) != 0)
                {
                    isColumnFree = false;
                    break;
                }
            }
            mask <<= 1;

            if (isColumnFree)
                freeColumns++;
        }
        result *= freeColumns;
        return result;
    }
}
