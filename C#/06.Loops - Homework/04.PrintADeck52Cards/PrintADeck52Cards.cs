using System;

class PrintADeck52Cards
{
    static void Main()
    {
        string card = "";
        string color = "";

        for (int i = 2; i <= 14; i++)
        {
            if (i <= 10)
            {
                card = i.ToString();
            }
            else if (i == 11) 
            {
                card = "J";
            }
            else if (i == 12) 
            {
                card = "D";
            }
            else if (i == 13) 
            {
                card = "K";
            }
            else if (i == 14) 
            {
                card = "A";
            }

            for (int j = 1; j <= 4; j++)
            {    
                switch (j)
                {
                    case 1:
                        color = "spades";
                        break;
                    case 2:
                        color = "clubs";
                        break;
                    case 3:
                        color = "hearts";
                        break;
                    case 4:
                        color = "diamonds";
                        break;
                }

                Console.Write("{0} of {1}", card, color);
                if (j != 4)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }
    }
}
