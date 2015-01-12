using System;
using System.Collections.Generic;

class BinaryToHex
{
    static void Main()
    {
        string numberInBinary = "001111011011001";

        string result = string.Join("", ConvertBinToHex(numberInBinary));

        Console.WriteLine("The number in hex is: {0}", result);
    }

    //this method solves our problem
    static List<string> ConvertBinToHex(string numberInBinary)
    {
        List<string> result = new List<string>();

        char[] hexSymbols = { 'A', 'B', 'C', 'D', 'E', 'F' };

        while (numberInBinary.Length % 4 != 0)
        {
            numberInBinary = '0' + numberInBinary;
        }

        for (int i = 0; i < numberInBinary.Length; i += 4)
        {
            string currentHalfBite = null;
            string currentSign = null;

            for (int j = i; j < i + 4; j++)
            {
                currentHalfBite += numberInBinary[j].ToString();
            }

            int currentNumber = Convert.ToInt32(currentHalfBite, 2);

            if (currentNumber < 10)
            {
                currentSign = currentNumber.ToString();
            }
            else 
            {
                currentSign = hexSymbols[currentNumber - 10].ToString();
            }

            result.Add(currentSign);
        }

        //remove the leading zeroes from the result if any
        result = RemoveLeadingZeroes(result);

        return result;
    }

    //this method removes the leading zeroes
    static List<string> RemoveLeadingZeroes(List<string> result)
    {
        int k = 0;
        int startIndex = 0;

        List<string> newResult = new List<string>();

        while (result[k] == "0")
        {
            startIndex++;
            k++;
        }

        for (int i = startIndex; i < result.Count; i++)
        {
            newResult.Add(result[i]);
        }
        return result;
    }
}

