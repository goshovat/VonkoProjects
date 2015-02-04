using System;

class SevenlandNumbers_ver2_cicles
{
    static void Main()
    {
        string input = Console.ReadLine();
        int number = int.Parse(input);
        byte powerCounter = 0;
        int decimalNumber = 0;

        while (number != 0)
        {
            byte lastNumber = (byte)(number % 10);
            decimalNumber += lastNumber * (int)Math.Pow(7, powerCounter);
            powerCounter++;
            number /= 10;
        }

        decimalNumber++;
        string result = "";

        while (decimalNumber != 0)
        {
            byte lastNumber = (byte)(decimalNumber % 7);
            result = lastNumber + result;
            decimalNumber /= 7;
        }

        Console.WriteLine(result);
    }
}

 