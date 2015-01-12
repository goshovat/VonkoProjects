using System;

class FourDigitNumberSolution2
{
    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Write a number consisting of four digits:");
        string input = Console.ReadLine();
        int inputInt = Convert.ToInt32(input);

        /*Getting the fourth digit*/
        int fourthNumber = inputInt % 10;
        string fourthtDigit = fourthNumber.ToString();
        
        /*Getting the third digit*/
        int thirdNumber = (inputInt / 10) % 10;
        string thirdDigit = thirdNumber.ToString();

        /*Getting the second digit*/
        int secondNumber = (inputInt / 100) % 10;
        string secondDigit = secondNumber.ToString();

        /*Getting the first digit*/
        int firstNumber = (inputInt / 1000) % 10;
        string firstDigit = firstNumber.ToString();

        /*Calculate the arithmetic sum of the digits*/
        int sum = firstNumber + secondNumber + thirdNumber + fourthNumber;
        Console.WriteLine("The sum of the digits is: " +sum);
        Console.WriteLine();

        /*Print the digits in reversed order*/
        string reversed = fourthtDigit + thirdDigit + secondDigit + firstDigit;
        Console.WriteLine("The digits in reversed order are: " + reversed);
        Console.WriteLine();

        /*Put the last digit in position 1*/
        string fourthOnFirstPos = fourthtDigit + firstDigit + secondDigit + thirdDigit;
        Console.WriteLine("The number with the fourth digit moved in fornt is: " + fourthOnFirstPos);
        Console.WriteLine();
        
        /*Exchange the secondDigit and thirdDigit digit*/
        string secondThirdExc = firstDigit + thirdDigit + secondDigit + fourthtDigit;
        Console.WriteLine("The number with the second and third digits exchanged is: " + secondThirdExc);
    }
}

