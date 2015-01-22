using System;

class RandomizeNumbers1toN
{
    static void Main()
    {
        Console.WriteLine("Enter the total count:");
        int n = int.Parse(Console.ReadLine());
        int[] numbers = new int[n];

        for (int i = 0; i < n; i++)
        {
            numbers[i] = i + 1;
        }

        Shuffle(numbers);
        Print(numbers);
    }

    public static void Shuffle(int[] numbers)
    {
        Random randomGenerator = new Random();
        int n = numbers.Length;
        while (n > 1)
        {
            n--;
            int currentIndex = randomGenerator.Next(n + 1);
            int value = numbers[currentIndex];
            numbers[currentIndex] = numbers[n];
            numbers[n] = value;
        }
    }

    public static void Print(int[] numbers)
    {
        Console.WriteLine("The randomized numbers:");
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
