using System;

class NumbersDividableBy5
{
    static void Main()
    {
        Console.WriteLine("Enter two whole numbers: ");
        string firstNumber = Console.ReadLine();
        int firstNumberInt;
        bool parseFirstNumber = int.TryParse(firstNumber, out firstNumberInt);
        Console.WriteLine();

        string secondNumber = Console.ReadLine();
        int secondNumberInt;
        bool parseSecondNumber = int.TryParse(secondNumber, out secondNumberInt);
        Console.WriteLine();

        if ((parseFirstNumber == true) && (parseSecondNumber == true))
        {
            int lesserNumber = ((firstNumberInt + secondNumberInt) - Math.Abs(firstNumberInt - secondNumberInt)) / 2;
            int biggerNumber = ((firstNumberInt + secondNumberInt) + Math.Abs(firstNumberInt - secondNumberInt)) / 2;
            int counter = 0;

            for (int i = lesserNumber; i <= biggerNumber; i++)
            {
                if (i % 5 == 0)
                {
                    counter++;
                }
            }

            Console.WriteLine("In between {0} numbers can be divided by 5.", counter);
            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Please enter valid numbers!");
        }
    }
}

