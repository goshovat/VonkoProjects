using System;

class PrintAllCards
{
    static void Main()
    {
        string[] signs = new String[] {"2", "3", "4", "5", "6", "7", "8", "9",
                                  "10", "J", "Q", "K", "A"};

        string[] suits = new String[] { "Clubs", "Diamonds", "Hearts", "Spades" };

        for (int i = 0; i < signs.Length; i++)
        {
            for (int j = 0; j < suits.Length; j++)
            {
                Console.Write(signs[i].PadLeft(2) + " " + suits[j] + " ");
            }
            Console.WriteLine();
        }
    }
}

