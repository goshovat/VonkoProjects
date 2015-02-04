using System;

class UpDownGame
{
    static void Main()
    {
        Console.WriteLine("Up and Down Game");
        Console.WriteLine("Try to guess the number(from 1 to 100)");

        Random randomGenerator = new Random();

        int randomNumber = randomGenerator.Next(1, 101);
        int min = 1;
        int max = 100;

        while (true)
        {
            Console.Write("Enter your number between {0} and {1}: ", min, max);
            string input = Console.ReadLine();
            int userNumber = 0;

            bool tryParse = int.TryParse(input, out userNumber);

            if (!tryParse)
            {
                Console.WriteLine("Invalid number!");
                continue;
            }

            if (userNumber < min)
            {
                continue;
            }
            if (userNumber > max)
            {
                continue;
            }

            if (userNumber == randomNumber)
            {
                Console.WriteLine("You won the game");
                break;
            }
            else if (userNumber < randomNumber)
            {
                min = userNumber + 1;
                Console.WriteLine("Up!");
            }
            else if (userNumber > randomNumber)
            {
                max = userNumber - 1;
                Console.WriteLine("Down!");
            }
        }
    }
}

