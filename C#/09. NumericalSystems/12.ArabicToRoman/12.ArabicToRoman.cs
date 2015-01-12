using System;

class ArabicToRoman
{
    static void Main()
    {
        Console.WriteLine("Enter a positive integer to see it in Roman numerical system: ");
        uint arabicNumber = uint.Parse(Console.ReadLine());

        string romanNumber = ConvertToRoman(arabicNumber);

        Console.WriteLine("The roman number is: {0}", romanNumber);
    }

    //this method will convert the arabic number to roman and return the string
    static string ConvertToRoman(uint arabicNumber)
    {
        if (arabicNumber > 3999)
            return "Cannot be converted to Roman number";

        uint thousands = arabicNumber / 1000;
        uint hundreds = (arabicNumber / 100) % 10;
        uint tens = (arabicNumber / 10) % 10;
        uint units = arabicNumber % 10;

        string thousandsString = GetRomanDigits(thousands * 1000);
        string hundredsString = GetRomanDigits(hundreds * 100);
        string tensString = GetRomanDigits(tens * 10);
        string unitsString = GetRomanDigits(units);

        string romanNumber = thousandsString + hundredsString + tensString + unitsString;

        return romanNumber;
    }

    static string GetRomanDigits(uint arabicDigit)
    {
        if (arabicDigit == 0)
            return "";

        string[,] romanDigits = { 
                                {"I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX"},
                                {"X", "XX", "X", "XL", "L", "LX", "LXX", "LXXX", "XC"},
                                {"C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM"},
                                {"M", "MM", "MMM", "", "", "", "", "", ""}
                              };

        uint row = 0;
        uint col = arabicDigit - 1;

        if (arabicDigit % 1000 == 0)
        {
            row = 3;
            col = arabicDigit / 1000 - 1;
        }
        else if (arabicDigit % 100 == 0)
        {
            row = 2;
            col = arabicDigit / 100 - 1;
        }
        else if (arabicDigit % 10 == 0)
        {
            row = 1;
            col = arabicDigit / 10- 1;
        }

        string romanValue = romanDigits[row, col];

        return romanValue;
    }
}

