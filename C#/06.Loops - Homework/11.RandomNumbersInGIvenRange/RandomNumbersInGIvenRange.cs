using System;

class RandomNumbersInGIvenRange
{
    static void Main()
    {
        Console.WriteLine("Enter the total count:");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the min bound:");
        int min = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the max bound:");
        int max = int.Parse(Console.ReadLine());
        Random randomGenerator = new Random();

        for (int i = 0; i < n; i++)
        {
            int currentNumber = randomGenerator.Next(min, max + 1);
            Console.Write(currentNumber + " ");
        }
    }
}
