using System;

class EnglishDigit
{
    static void Main()
    {
        Console.WriteLine("Enter one integer to see the English name of it's last digit: ");
        int number = int.Parse(Console.ReadLine());

        Console.WriteLine("The English name of the last digit is: \n\r{0}", GetNameOfLastDigit(number));
    }

    static string GetNameOfLastDigit(int number)
    {
        string name = "";
        string numberInDigits = number.ToString();
        int len = numberInDigits.Length;
        int indexOflastDigit = len - 1;

        int lastDigit = int.Parse(numberInDigits[indexOflastDigit].ToString());
        string[] namesArray = { "Zero", "One", "Two", "three", "Four", "Five", 
                                  "Six", "Seven", "Eight", "Nine"};

        name = namesArray[lastDigit];
        return name;
    }
}
