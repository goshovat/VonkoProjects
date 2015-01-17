using System;

class BiggestOfThreeNumbers
{
    static void Main()
    {
        //far from the simplest solution, but using only if statements aligns with the topic of the homework
        Console.WriteLine("Enter three real numbers:");
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

        Console.WriteLine("The biggest number is: {0}", biggest);
    }
}

