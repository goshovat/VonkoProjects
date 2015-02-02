using System;

class DrunkenNumbers
{
    static void Main()
    {
        int mitkoBeers = 0;
        int vladkoBeers = 0;
        int rounds = int.Parse(Console.ReadLine());
        
        for (int round = 0; round < rounds; round++)
        {
            string drunkenNumber = Console.ReadLine();
            int startIndex = 0;
            for (int i = 0; i < drunkenNumber.Length; i++)
            {
                if (char.IsDigit(drunkenNumber[i]) &&
                    drunkenNumber[i] != '0')
                {
                    startIndex = i;
                    break;
                }
            }

            drunkenNumber = drunkenNumber.Substring(startIndex);
            int middle = drunkenNumber.Length / 2;
            int temp = 0;

            for (int i = 0; i < middle; i++)
            {
                if (int.TryParse(drunkenNumber[i].ToString(), out temp)) 
                {
                   mitkoBeers += temp;
                }
            }
            for (int i = middle; i < drunkenNumber.Length; i++)
            {
                if (int.TryParse(drunkenNumber[i].ToString(), out temp))
                {
                    vladkoBeers += temp;
                }
            }

            if (drunkenNumber.Length % 2 != 0)
            {
                if (int.TryParse(drunkenNumber[middle].ToString(), out temp))
                {
                    mitkoBeers += temp;
                }
            }
        }

        if (vladkoBeers > mitkoBeers)
        {
            Console.WriteLine("V {0}", vladkoBeers - mitkoBeers);
        }
        else if (mitkoBeers > vladkoBeers)
        {
            Console.WriteLine("M {0}", mitkoBeers - vladkoBeers);
        }
        else
        {
            Console.WriteLine("No {0}", mitkoBeers + vladkoBeers);
        }
    }
}
