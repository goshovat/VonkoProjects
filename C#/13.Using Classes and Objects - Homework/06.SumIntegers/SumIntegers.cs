using System;

class SumIntegers
{
    static void Main()
    {
        string numbers = "43 68 9 23 318";
        string[] numbersArray = numbers.Split(' ');
        int sum = 0;

        for (int i = 0; i < numbersArray.Length; i++)
        {
            sum += int.Parse(numbersArray[i]);
        }

        Console.WriteLine("The sum is: {0}", sum);
    }
}
