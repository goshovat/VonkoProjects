using System;

class HexToDecimal
{
    static void Main()
    {
        string numberInHex = "FFEEDD";

        double result = ConvertToDecimal(numberInHex);

        Console.WriteLine("The number in decimal is: {0}", result);
    }

    static double ConvertToDecimal(string numberInHex)
    {
        double result = 0;

        char[] hexInArray = numberInHex.ToCharArray();

        Array.Reverse(hexInArray);

        string[] hexSymbols = { "A", "B", "C", "D", "E", "F" };

        //we will use these variabe to check if the current symbol is a digit;
        int temp = 0;

        for (int i = 0; i < hexInArray.Length; i++)
        {
            if (!int.TryParse(hexInArray[i].ToString(), out temp))
            {
                temp = Array.IndexOf(hexSymbols, hexInArray[i].ToString()) + 10;
            }

            result += Math.Pow(16.0, (double)i) * temp;
        }

        return result;
    }
}
