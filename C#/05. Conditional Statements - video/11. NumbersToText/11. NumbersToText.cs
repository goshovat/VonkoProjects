using System;

class NumbersToText
{
    static void Main()
    {
        Console.WriteLine("Write a number from 0 to 999:");
        string input = Console.ReadLine();
        int number = 0;

        try
        {
            number = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter a valid number!");
        }

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



        if (input.Length == 1)
        {
            if (number == 0)
            {
                Console.WriteLine("zero");
            }
            else
            {
                Console.WriteLine(ones[n2]);
            }
        }

        else if (input.Length == 2)
        {
            if (n1 == 1)
            {
                Console.WriteLine(specialNumbers[n2]);
            }
            else
            {
                Console.WriteLine(tens[n1] + " " + ones[n2]);
            }
        }

        else if (input.Length == 3)
        {
            if (n1 == 1)
            {
                Console.WriteLine(ones[n] + " hundred and " + specialNumbers[n2]);
            }
            else
            {
                if (n1 != 0 || n2 != 0)
                {
                    Console.WriteLine(ones[n] + " hundred and " + tens[n1] + " " + ones[n2]);
                }
                else
                {
                    Console.WriteLine(ones[n] + " hundred ");
                }
            }
        }

        else
        {
            Console.WriteLine("Please enter a number between 0 and 999");
        }
    }
}

