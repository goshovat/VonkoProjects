using System;
using System.Collections.Generic;

class FloatNumberToBinary2
{
    static void Main()
    {
        float numberInFloat = 99.99f;

        List<byte> result = ConvFloatToBin(numberInFloat);

        PrintResult(result);
    }

    //this method will convert our float to its binary representation
    static List<byte> ConvFloatToBin(float numberInFloat)
    {
        bool negativeNumber = false;

        if (numberInFloat < 0)
        {
            negativeNumber = true;
            numberInFloat *= -1;
        }

        List<byte> resultList = new List<byte>();

        int integerPart = (int)numberInFloat;

        float floatPart = numberInFloat - (float)integerPart;

        List<byte> leftPartMant = ConvertIntToBin(integerPart);
        List<byte> rightPartMant = ConvertFloatToBin(floatPart);

        //now we need to normalize the mantissa
        int exponent = NormalizeMantissa(numberInFloat, 
            ref leftPartMant, ref rightPartMant);

        //fill the mantissa with zeroes to the right or cut if necessary
        if (rightPartMant.Count < 23)
        {
            while (rightPartMant.Count < 23)
            {
                rightPartMant.Add(0);
            }
        }
        else if (rightPartMant.Count > 23)
        {
            rightPartMant.RemoveRange(23, 23);
        }

        //the bits of this neumber will be represented in the exponent part
        int bias = 127 - exponent;

        List<byte> exponentBits = ConvertIntToBin(bias);

        //fill the 8 bits with zeroes if neessary
        while (exponentBits.Count < 8)
        {
            exponentBits.Insert(0, 0);
        }

        //this variable will hold the bit that determines the sign of the whole number
        byte signBit = 0;

        if (negativeNumber)
            signBit = 1;

        resultList.Add(signBit);

        JoinLists(resultList, exponentBits);
        JoinLists(resultList, rightPartMant);

        return resultList;
    }

    //this method will normalize our mantissa and return the exponen
    private static int NormalizeMantissa(float numberInFloat, 
        ref List<byte> leftPartMant, ref List<byte> rightPartMant)
    {
        int exponent = 0;

        if ((int)numberInFloat == 0)
        {
            //in this case the number does not have integer part and we will normalize the mantissa by moving to the left
            bool normalized = false;

            while (!normalized)
            {
                int currentBit = rightPartMant[0];

                if (currentBit == 1)
                {
                    normalized = true;
                }

                exponent++;

                rightPartMant.RemoveAt(0);
            }
        }
        else
        {
            //in this case the number has integer part and we normalize by moving right
            while (leftPartMant.Count != 1)
            {
                byte currentBit = leftPartMant[leftPartMant.Count - 1];

                rightPartMant.Insert(0, currentBit);

                leftPartMant.RemoveAt(leftPartMant.Count - 1);
                exponent++;
            }

            exponent *= -1;
        }

        return exponent;
    }

    //thhis method will add the second list to the first
    static void JoinLists(List<byte> firstList, List<byte> secondList)
    {
        for (int i = 0; i < secondList.Count; i++)
        {
            firstList.Add(secondList[i]);
        }
    }

    //this method converts a positive integer to its binary representation
    static List<byte> ConvertIntToBin(int integerNumber)
    {
        List<byte> result = new List<byte>();

        while (integerNumber != 0)
        {
            byte currentBit = (byte)(integerNumber % 2);
            result.Insert(0, currentBit);
            integerNumber /= 2;
        }

        return result;
    }

    static List<byte> ConvertFloatToBin(float floatPart)
    {
        List<byte> result = new List<byte>();
        int counter = 46;

        while (floatPart != 0 && counter != 0)
        {
            counter--;

            floatPart *= 2;

            if (floatPart < 1)
            {
                result.Add(0);
            }
            else
            {
                result.Add(1);
                floatPart -= 1;
            }
        }

        return result;
    }

    //this method will print the bnary string so that the sign bit, exponent and mantissa will be separated
    static void PrintResult(List<byte> binaryResult)
    {
        for (int i = 0; i < binaryResult.Count; i++)
        {
            Console.Write(binaryResult[i]);
            if (i == 0 || i == 8)
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
    }
}

