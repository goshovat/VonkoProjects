using System;

class SumOfNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter number 1:");
        decimal number1 = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter number 2:");
        decimal number2 = decimal.Parse(Console.ReadLine());
        Console.WriteLine("Enter number 3:");
        decimal number3 = decimal.Parse(Console.ReadLine());

        decimal sum = number1 + number2 + number3;
        Console.WriteLine("Sum: {0}", sum);
    }
}
