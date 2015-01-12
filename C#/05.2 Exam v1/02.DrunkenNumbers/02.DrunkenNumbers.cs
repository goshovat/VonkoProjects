using System;

class DrunkenNumbers
{
    static void Main()
    {
        int rounds = int.Parse(Console.ReadLine());

        int mitkoBeers = 0;
        int vladkoBeers = 0;

        for (int round = 0; round < rounds; round++)
        {
            //get the number for the current round
            int currentNumber = int.Parse(Console.ReadLine());
            if (currentNumber < 0)
            {
                currentNumber *= -1;
            }

            string currentRoundStr = currentNumber.ToString();

            int middle = currentRoundStr.Length / 2;

            //if the length of the number is even
            if (currentRoundStr.Length % 2 == 0)
            {
                for (int i = 0; i < currentRoundStr.Length; i++)
                {
                    if (i < middle)
                    {
                        mitkoBeers += int.Parse(currentRoundStr[i].ToString());
                    }
                    else
                    {
                        vladkoBeers += int.Parse(currentRoundStr[i].ToString());
                    }
                }
            }
            //if the length of the number is odd
            else 
            {
                for (int i = 0; i < currentRoundStr.Length; i++)
                {
                    if (i < middle)
                    {
                        mitkoBeers += int.Parse(currentRoundStr[i].ToString());
                    }
                    else if (i == middle) 
                    {
                        mitkoBeers += int.Parse(currentRoundStr[i].ToString());
                        vladkoBeers += int.Parse(currentRoundStr[i].ToString());
                    }
                    else if (i > middle)
                    {
                        vladkoBeers += int.Parse(currentRoundStr[i].ToString());
                    }
                }
            }

        }

        //print the final results
        if (mitkoBeers > vladkoBeers)
        {
            Console.WriteLine("M " + (mitkoBeers - vladkoBeers));
        }
        else if (vladkoBeers > mitkoBeers)
        {
            Console.WriteLine("V " + (vladkoBeers - mitkoBeers));
        }
        else if (mitkoBeers == vladkoBeers)
        {
            Console.WriteLine("No " + (mitkoBeers + vladkoBeers));
        }
    }
}

