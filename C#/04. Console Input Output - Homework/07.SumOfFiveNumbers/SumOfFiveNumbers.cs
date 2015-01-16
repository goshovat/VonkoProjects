using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        string numbers = Console.ReadLine();
        string[] numbersArray = numbers.Split(new char[] {' '},
            StringSplitOptions.RemoveEmptyEntries);
        double sum = 0;

        foreach (string numberStr in numbersArray)
        {
            double currentNumber = double.Parse(numberStr);
            sum += currentNumber;
        }

        Console.WriteLine("The sum is: {0}", sum);
    }
}

