using System;
using System.Linq;

class FLoatNumberToBinary
{
    static void Main()
    {
        float floatNumber = 99.99f;

        string hexResult = ConvertFloatToHex(floatNumber);

        string binaryResult = "";

        //convert hex to binary
        for (int i = 0; i < hexResult.Length; i++)
        {
            switch (hexResult[i])
            {
                case '0':
                    binaryResult += "0000";
                    break;
                case '1':
                    binaryResult += "0001";
                    break;
                case '2':
                    binaryResult += "0010";
                    break;
                case '3':
                    binaryResult += "0011";
                    break;
                case '4':
                    binaryResult += "0100";
                    break;
                case '5':
                    binaryResult += "0101";
                    break;
                case '6':
                    binaryResult += "0110";
                    break;
                case '7':
                    binaryResult += "0111";
                    break;
                case '8':
                    binaryResult += "1000";
                    break;
                case '9':
                    binaryResult += "1001";
                    break;
                case 'A':
                    binaryResult += "1010";
                    break;
                case 'a':
                    binaryResult += "1010";
                    break;
                case 'B':
                    binaryResult += "1011";
                    break;
                case 'b':
                    binaryResult += "1011";
                    break;
                case 'C':
                    binaryResult += "1100";
                    break;
                case 'c':
                    binaryResult += "1100";
                    break;
                case 'D':
                    binaryResult += "1101";
                    break;
                case 'd':
                    binaryResult += "1101";
                    break;
                case 'E':
                    binaryResult += "1110";
                    break;
                case 'e':
                    binaryResult += "1110";
                    break;
                case 'F':
                    binaryResult += "1111";
                    break;
                case 'f':
                    binaryResult += "1111";
                    break;
            }
        }

        PrintBinary(binaryResult);
    }

    //this method converts our float to hex, so we can convert it to binary after
    private static string ConvertFloatToHex(float floatNumber)
    {
        byte[] binaryArray = BitConverter.GetBytes(floatNumber);

        Array.Reverse(binaryArray);

        string result = BitConverter.ToString(binaryArray);

        return result;
    }

    //this method will print the bnary string so that the sign bit, exponent and mantissa will be separated
    static void PrintBinary(string binaryResult)
    {
        for (int i = 0; i < binaryResult.Length; i++)
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
