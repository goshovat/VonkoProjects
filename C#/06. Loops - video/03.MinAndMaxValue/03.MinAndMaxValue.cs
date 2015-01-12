using System;

class MinAndMaxValue
{
    static void Main()
    {
        Console.Write("Enter how many numbers you will check: ");
        int n = 0;

        try
        {
            n = int.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Enter valid numbers!");
            return;
        }

        int min = int.MaxValue;
        int max = int.MinValue;

        Console.WriteLine("Enter a sequence of integers: ");
        int currentNumber = 0;

        for (int i = 0; i < n; i++)
        {
            try
            {
                currentNumber = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter valid numbers!");
                return;
            }

            if (currentNumber < min)
            {
                min = currentNumber;
            }
            if (currentNumber > max)
            {
                max = currentNumber;
            }
        }

        Console.WriteLine("The min value is {0} and the max value is {1}", min, max);
    }

}
