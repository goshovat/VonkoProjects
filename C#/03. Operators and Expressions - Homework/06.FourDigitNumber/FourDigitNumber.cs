using System;

class FourDigitNumberSolution2
{
    static void Main()
    {
        Console.WriteLine("Write a number consisting of four digits:");
        int number = int.Parse(Console.ReadLine());

        /*Getting the fourth digit*/
        int fourthDigit = number % 10;

        /*Getting the third digit*/
        int thirdDigit = (number / 10) % 10;

        /*Getting the second digit*/
        int secondDigit = (number / 100) % 10;

        /*Getting the first digit*/
        int firstDigit = (number / 1000) % 10;

        /*Calculate the arithmetic sum of the digits*/
        int sum = firstDigit + secondDigit + thirdDigit + fourthDigit;
        Console.WriteLine("The sum of the digits is: " + sum);
        Console.WriteLine();

        /*Print the digits in reversed order*/
        string reversed = "" + fourthDigit + thirdDigit + secondDigit + firstDigit;
        Console.WriteLine("The digits in reversed order are: " + reversed);
        Console.WriteLine();

        /*Put the last digit in position 1*/
        string fourthOnFirstPos = "" + fourthDigit + firstDigit + secondDigit + thirdDigit;
        Console.WriteLine("The number with the fourth digit moved in fornt is: " + fourthOnFirstPos);
        Console.WriteLine();

        /*Exchange the secondDigit and thirdDigit digit*/
        string secondThirdExc = "" + firstDigit + thirdDigit + secondDigit + fourthDigit;
        Console.WriteLine("The number with the second and third digits exchanged is: " + secondThirdExc);
    }
}
