using System;

class StringLength
{
    static void Main()
    {
        Console.WriteLine("Enter a string of maximum 20 symbols:");
        string userInput = Console.ReadLine();

        if (userInput.Length > 20)
        {
            //we imitate exception in order not to throw one outside the main method
            Console.WriteLine("Error! The length of your string is {0}", userInput.Length);
        }
        else
        {
            string formattedString = userInput.PadRight(20, '*');
            Console.WriteLine("The formatted string is:\n{0}", formattedString);
        }
    }
}

