using System;

class TripleRotationOfDigits
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int lastNumber = 0;
        string result = "";
        
        for (int i = 0; i < 3; i++)
        {
            if (number > 9)
            {
                lastNumber = number % 10;
                number /= 10;
                result = lastNumber + "" + number;
                number = int.Parse(result);
            }
        }

        Console.WriteLine(number);
    }
}

