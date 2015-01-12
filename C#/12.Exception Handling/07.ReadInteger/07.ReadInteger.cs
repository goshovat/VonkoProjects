using System;

class ReadInteger
{
    static void Main()
    {
        Console.WriteLine("Write a random integer: ");
        string numberString = Console.ReadLine();

        try
        {
            double result = SquareOfConsoleNum(numberString);
            Console.WriteLine("The result is: {0}", result);
        }
        catch (FormatException fmtExc)
        {
            Console.WriteLine("Invalid number!");
        }

        Console.WriteLine("Good bye, bitch!");
    } 

    //this is the method that reads a number from console and returns it's square root
    static double SquareOfConsoleNum(string numberString)
    {
        double result = Math.Sqrt(int.Parse(numberString));

        return result;
    }
}
