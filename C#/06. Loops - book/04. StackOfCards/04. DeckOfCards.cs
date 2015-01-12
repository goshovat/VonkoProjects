using System;

class DeckOfCards
{
    static void Main()
    {
        Console.WindowWidth = 100;
 
        string[] suits = new String[] { "Clubs", "Diamonds", "Hearts", "Spades" };
        string[] symbols = new String[] {"2", "3", "4", "5", "6", "7", "8", "9", "10",
                                    "J", "D", "K", "A"};

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                Console.Write(symbols[j] + " "+ suits[i] + "; ");
                if (j == 6)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}

