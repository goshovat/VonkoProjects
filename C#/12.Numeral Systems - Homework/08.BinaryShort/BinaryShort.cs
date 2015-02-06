using System;
using System.Collections.Generic;

class BinaryShort
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a signed number type short: ");
        short shortNumber = short.Parse(Console.ReadLine());

        string result = ConvertShortToBinary(shortNumber);
        Console.WriteLine("The result is: {0}", result);
    }

    //this method calculates binary representation of a signed short number
    static string ConvertShortToBinary(short shortNumber)
    {
        List<byte> binaryList = new List<byte>();
        if (shortNumber < 0)
        {
            binaryList.Add(1);

            //this is the number, that needs to be added to the min value of sort so to get our negative given number
            short remainder = (short)(short.MaxValue + shortNumber + 1);
            binaryList = GetBinaryOfInt(binaryList, remainder);
        }
        else
        {
            binaryList.Add(0);
            binaryList = GetBinaryOfInt(binaryList, shortNumber);
        }
        string result = string.Join("", binaryList);
        return result;
    }

    //this method calculates the binary representation of a positive integer
    static List<byte> GetBinaryOfInt(List<byte> binaryList, short positiveInteger)
    {
        for (int i = 0; i < 15; i++)
        {
            if (positiveInteger != 0)
            {
                byte currentBit = (byte)(positiveInteger % 2);
                binaryList.Insert(1, currentBit);
                positiveInteger /= 2;
            }
            else
            {
                binaryList.Insert(1, 0);
            }
        }
        return binaryList;
    }
}
