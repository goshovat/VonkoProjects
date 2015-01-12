using System;
using System.Collections.Generic;

class DecimalToBinary
{
    static void Main()
    {
        Console.WriteLine("Write a decima number to see it's binary representation: ");
        int number = int.Parse(Console.ReadLine());

        List<int> binaryRepresentation = ConvertToBinary(number);

        Console.WriteLine(string.Join("", binaryRepresentation));
    }

    private static List<int> ConvertToBinary(int number)
    {
        //find which is the highest bit with 1
        int endIndex = 0;

        for (int i = 31; i >= 0; i--)
        {
            if (((1 << i) & number) != 0)
            {
                endIndex = i;
                break;
            }
        }

        List<int> binaryRepresentation = new List<int>();

        for (int i = 0; i <= endIndex; i++)
        {
            int currentBit = (1 << i & number) >> i;

            //c# returns the sign bit with the sign, which we don't need in the result
            if (currentBit == -1)
                currentBit = 1;

            binaryRepresentation.Insert(0, currentBit);
        }

        return binaryRepresentation;
    }
}
