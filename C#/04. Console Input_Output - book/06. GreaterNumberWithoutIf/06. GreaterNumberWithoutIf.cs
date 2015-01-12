using System;

class GreaterNumberWithoutIf
{
    static void Main()
    {
        Console.WriteLine("Enter two numbers to check which one is bigger:");
        string firstNumber = Console.ReadLine();
        double firstNumberDouble;
        bool parseFirstNumber = double.TryParse(firstNumber, out firstNumberDouble);
        Console.WriteLine();

        string secondNumber = Console.ReadLine();
        double secondNumberDouble;
        bool parseSecondNumber = double.TryParse(secondNumber, out secondNumberDouble);

        if ((parseFirstNumber == true) && (parseSecondNumber == true))
        {
            double biggerNumber = ((firstNumberDouble + secondNumberDouble) + 
                Math.Abs(firstNumberDouble - secondNumberDouble)) / 2;

            Console.WriteLine("The bigger number is: {0}", biggerNumber);
        }
    }
}

