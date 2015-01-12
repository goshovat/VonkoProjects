using System;

class RomanToArabic
{
    static void Main()
    {
        string romanNumber = "MMCDLXXVI";

        int arabicNumber = ConvertToArabic(romanNumber);

        Console.WriteLine("The number in Arabic is: {0}", arabicNumber);
    }

    //this method converts a roman number to arabic
    static int ConvertToArabic(string romanNumber)
    {
        int arabicNumber = 0;
        int len = romanNumber.Length;

        for (int i = 0; i < len - 1; i++)
        {
            if (GetValueOfRomanDigit(romanNumber[i]) >= GetValueOfRomanDigit(romanNumber[i + 1]))
            {
                arabicNumber += GetValueOfRomanDigit(romanNumber[i]);
            }
            else
            {
                arabicNumber -= GetValueOfRomanDigit(romanNumber[i]);
            }
        }

        arabicNumber += GetValueOfRomanDigit(romanNumber[len - 1]);

        return arabicNumber;
    }

    //this method will get the decimal value of every roman digit
    static int GetValueOfRomanDigit(char romanDigit)
    {
        char[] romanDigits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        int[] romanValues = { 1, 5, 10, 50, 100, 500, 1000 };

        int arabicValue = romanValues[Array.IndexOf(romanDigits, romanDigit)];

        return arabicValue;
    }
}
