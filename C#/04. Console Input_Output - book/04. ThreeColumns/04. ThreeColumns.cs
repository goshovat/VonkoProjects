using System;

class ThreeColumns
{
    static void Main()
    {
        Console.WriteLine("Enter three numbers.\n" 
            + "The first one must be whole number, the second to be positive double \n"
            + " and the third to be negative double.");

        string firstNumber = Console.ReadLine();
        int firstNumberInt;
        bool firstNumberParse = int.TryParse(firstNumber, out firstNumberInt);
        Console.WriteLine();

        string secondNumber = Console.ReadLine();
        double secondNumberDouble;
        bool secondNumberParse = double.TryParse(secondNumber, out secondNumberDouble);
        Console.WriteLine();

        string thirdNumber = Console.ReadLine();
        double thirdNumberDouble;
        bool thirdNumberParse = double.TryParse(thirdNumber, out thirdNumberDouble);
        Console.WriteLine();

        if ((firstNumberParse == true) && (secondNumberParse == true) && (thirdNumberParse == true))
        {
            Console.Write("{0, -10 :X}", firstNumberInt);
            Console.Write("{0, -10 :X}", firstNumberInt);
            Console.WriteLine("{0, -10:X}", firstNumberInt);

            Console.Write("{0, -10 :F2}", secondNumberDouble);
            Console.Write("{0, -10 :F2}", secondNumberDouble);
            Console.WriteLine("{0, -10 :F2}", secondNumberDouble);

            Console.Write("{0, -10 :F2}", thirdNumberDouble);
            Console.Write("{0, -10 :F2}", thirdNumberDouble);
            Console.WriteLine("{0, -10 :F2}", thirdNumberDouble);
        }
        else
        {
            Console.WriteLine("Enter valid numbers!");
        }
    }
}

