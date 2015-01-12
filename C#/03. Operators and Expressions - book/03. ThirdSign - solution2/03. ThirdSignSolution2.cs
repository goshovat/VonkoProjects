using System;


class ThirdSignSolution2
{
    static void Main()
    {
        string strInput = Console.ReadLine();
        int stringToInt = Convert.ToInt32(strInput);
        int divided100 = Math.Abs(stringToInt / 100);
        int divided10 = divided100 % 10;
        if (divided10 == 7)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}

