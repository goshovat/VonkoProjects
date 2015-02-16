using System;
using System.Linq;

class JoroTheRabbit
{
    static void Main()
    {
        string input = Console.ReadLine();

        int[] numbers = input.Split(new char[] { ' ', ',' },
            StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n)).ToArray();

        int maxSteps = 0;

        for (int step = 1; step <= numbers.Length; step++)
        {
            for (int startPosition = 0; startPosition < numbers.Length; startPosition++)
            {
                //check starting from each position
                int currentSteps = 0;
                int lastNumber = int.MinValue;
                int position = startPosition;

                //check how many steps can make with this pace from this position
                while (numbers[position] > lastNumber)
                {
                    currentSteps++;
                    lastNumber = numbers[position];
                    position = position + step;
                    if (position >= numbers.Length)
                    {
                        position = position - numbers.Length;
                    }
                }

                if (currentSteps > maxSteps)
                    maxSteps = currentSteps;
            }
        }
        Console.WriteLine(maxSteps);
    }
}
