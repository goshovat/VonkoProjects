using System;

class Sheets
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        //we wiil store if each list is used in array
        bool[] usedOrNotArr = new bool[11];
        double substract = 0;

        //in this case we use the A0 list

        for (int i = 0; i < 11; i++)
        {
            if (n >= Math.Pow(2, 11 - i - 1) && usedOrNotArr[i] == false)
            {
                usedOrNotArr[i] = true;
                substract = Math.Pow(2, 11 - i - 1);
                n -= (int)substract;
            }
        }

        //now print the unused lists
        for (int i = usedOrNotArr.Length - 1; i >= 0; i--)
        {
            if (usedOrNotArr[i] == false)
            {
                Console.WriteLine("A{0}", i);
            }
        }
    }
}

