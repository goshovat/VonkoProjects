using System;


class SumFiveNumbers
{
    static void Main()
    {
        //I will make this program using decimal type of numbers
        Console.WriteLine("Enter five numbers and check their sum: ");

        string firsNumber = Console.ReadLine();
        decimal FirstNumberDec;
        bool parseFirstNumber = decimal.TryParse(firsNumber, out FirstNumberDec);
        Console.WriteLine();

        string secondNumber = Console.ReadLine();
        decimal secondNumberDec;
        bool parseSecondNumber = decimal.TryParse(secondNumber, out secondNumberDec);
        Console.WriteLine();

        string thirdNumber = Console.ReadLine();
        decimal thirdNumberDec;
        bool parseThirdNumber = decimal.TryParse(thirdNumber, out thirdNumberDec);
        Console.WriteLine();

        string fourthNumber = Console.ReadLine();
        decimal fourthNumberDec;
        bool parseFourthNumber = decimal.TryParse(fourthNumber, out fourthNumberDec);
        Console.WriteLine();

        string fifthNumber = Console.ReadLine();
        decimal fifthNumberDec;
        bool parseFifthNumber = decimal.TryParse(fifthNumber, out fifthNumberDec);
        Console.WriteLine();

        if (parseFirstNumber == true && parseSecondNumber == true 
            && parseThirdNumber == true && parseFourthNumber == true && parseFifthNumber == true)
        {
            decimal sum = FirstNumberDec + secondNumberDec + thirdNumberDec + fourthNumberDec + fifthNumberDec;
            Console.WriteLine("The sum of the numbers is: {0}", sum);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Please enter proper numbers!");
            Console.WriteLine();
            Main();
        }
    }
}

