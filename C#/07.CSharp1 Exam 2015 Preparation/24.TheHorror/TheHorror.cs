using System;

class TheHorror
{
    static void Main()
    {
        string input = Console.ReadLine();
        int currentNumber = 0;

        int numberDigits = 0;
        long sum = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (i % 2 == 0 &&
                int.TryParse(input[i].ToString(), out currentNumber))
            {
                sum += currentNumber;
                numberDigits++;
            }
        }

        Console.WriteLine(numberDigits + " " + sum);
    }
}
