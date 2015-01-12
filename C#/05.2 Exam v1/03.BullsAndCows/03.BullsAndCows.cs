using System;
using System.Collections.Generic;

class BullsAndCows
{
    static void Main()
    {
        //get the input
        string secretNumber = Console.ReadLine();
        int givenBulls = int.Parse(Console.ReadLine());
        int givenCows = int.Parse(Console.ReadLine());

        bool solutionFound = false;

       //check all possible four-digit numbers
        for (int i = 1111; i <= 9999; i++)
        {
            char[] currentNumberChar = i.ToString().ToCharArray();

            if (currentNumberChar[0] >= '0' && currentNumberChar[1] > '0'
                && currentNumberChar[2] > '0' && currentNumberChar[3] > '0')
            {
                char[] secretNumberChar = secretNumber.ToCharArray();
                int bulls = 0;
                int cows = 0;

                //check for bulls and mark the unavailable
                for (int j = 0; j < 4; j++)
                {
                    if (currentNumberChar[j] == secretNumberChar[j])
                    {
                        bulls++;
                        currentNumberChar[j] = '#';
                        secretNumberChar[j] = '*';
                    }
                }

                //check for cows and mark them unavailable
                for (int m = 0; m < 4; m++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (currentNumberChar[m] == secretNumberChar[k])
                        {
                            cows++;
                            currentNumberChar[m] = '#';
                            secretNumberChar[k] = '*';
                        }
                    }
                }

                if (bulls == givenBulls && cows == givenCows)
                {
                    solutionFound = true;
                    Console.Write(i + " ");
                }
            }
        }

        if (!solutionFound)
        {
            Console.WriteLine("No");
        }
    }
}
