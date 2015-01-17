using System;
using System.Linq;

class NumberAsWords
{
    static void Main()
    {
        Console.WriteLine("Write a number from 0 to 999:");
        string input = Console.ReadLine();
        int number = int.Parse(input);

        input = number.ToString();
        int n2 = (number % 100) % 10;
        int n1 = (number % 100) / 10;
        int n = number / 100;

        string[] ones = new string[] { "", "one", "two", "three", "four", "five", "six",
                                      "seven", "eight", "nine"};
        string[] tens = new string[] {"", "", "twenty", "thirty", "fourty", "fifty", "sixty",
                                      "seventy", "eighty", "ninety"};
        string[] specialNumbers = new string[] {"ten","eleven", "twelve", "thirteen", "fourteen",
                                                "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
        string output = null;
        if (input.Length == 1)
        {
            if (number == 0)
            {
                output = "zero";
            }
            else
            {
                output = ones[n2];
            }
        }
        else if (input.Length == 2)
        {
            if (n1 == 1)
            {
                output = specialNumbers[n2];
            }
            else
            {
                output = tens[n1] + " " + ones[n2];
            }
        }
        else if (input.Length == 3)
        {
            if (n1 == 1)
            {
                output = ones[n] + " hundred and " + specialNumbers[n2];
            }
            else
            {
                if (n1 != 0 || n2 != 0)
                {
                    output = ones[n] + " hundred and " + tens[n1] + " " + ones[n2];
                }
                else
                {
                    output = ones[n] + " hundred ";
                }
            }
        }
        else
        {
            output = "Please enter a number between 0 and 999";
        }

        output = new String(
                    new[] { char.ToUpper(output.First()) }
                    .Concat(output.Skip(1))
                    .ToArray()
                    );

        Console.WriteLine(output);
    }
}


