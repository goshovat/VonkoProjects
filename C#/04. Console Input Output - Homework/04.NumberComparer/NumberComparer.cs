using System;

class NumberComparer
{
    static void Main()
    {
        Console.WriteLine("Input first number:");
        double number1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Input second number:");
        double number2 = double.Parse(Console.ReadLine());
        double biggerNumber = ((number1 + number2) + Math.Abs(number1 - number2)) / 2;
        double lesserNumber = ((number1 + number2) - Math.Abs(number1 - number2)) / 2;

        Console.WriteLine("Lesser number: {0}", lesserNumber);
        Console.WriteLine("Bigger number: {0}", biggerNumber);
    }
}

