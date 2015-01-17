using System;

class BiggestOfFiveNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers: ");
        double number1 = double.Parse(Console.ReadLine());
        double biggest = number1;

        double number2 = double.Parse(Console.ReadLine());
        if (number2 > biggest)
        {
            biggest = number2;
        }
        double number3 = double.Parse(Console.ReadLine());
        if (number3 > biggest)
        {
            biggest = number3;
        }
        double number4 = double.Parse(Console.ReadLine());
        if (number4 > biggest)
        {
            biggest = number4;
        }
        double number5 = double.Parse(Console.ReadLine());
        if (number5 > biggest)
        {
            biggest = number5;
        }

        Console.WriteLine("The biggest number is: {0}", biggest);
    }
}
