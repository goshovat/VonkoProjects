using System;

class CoffeeVendingMachine
{
    //in this array will be stored the amount of coins in each tray
    static int n = 5;
    static int[] trayCoinsArray = new int[n];

    //in this array will be stored the value of coins in each tray
    static decimal[] trayValuesArray = { 0.05m, 0.1m, 0.2m, 0.5m, 1m };

    static void Main()
    {
        //fill the number of coins in each tray
        for (int i = 0; i < n; i++)
        {
            trayCoinsArray[i] = int.Parse(Console.ReadLine());
        }

        //calculate the total sum in the machine
        decimal ammountInTrays = CalculateSumInMachine(trayCoinsArray, trayValuesArray);      

        decimal givenSum = decimal.Parse(Console.ReadLine());
        decimal price = decimal.Parse(Console.ReadLine());

        string outputString = "";
        decimal change = givenSum - price;
        decimal outputSum = 0;

        //check the first case
        if (givenSum >= price && change <= ammountInTrays)
        {
            outputString = "Yes";

            while (change > 0)
            {
                for (int i = trayCoinsArray.Length - 1; i >= 0; i--)
                {
                    if (change >= trayValuesArray[i] && trayCoinsArray[i] > 0)
                    {
                        trayCoinsArray[i]--;
                        change -= trayValuesArray[i];
                    }
                }             
            }

            outputSum = CalculateSumInMachine(trayCoinsArray, trayValuesArray);
        }
        // check the second case
        else if (givenSum > price && change > ammountInTrays)
        {
            outputString = "No";
            outputSum = change - ammountInTrays;
        }
        //check the third case
        else if (price > givenSum)
        {
            outputString = "More";

            outputSum = price - givenSum;
        }

        Console.WriteLine("{0} {1:F2}", outputString, outputSum);
    }

    //
    static decimal CalculateSumInMachine(int[] trayCoinsArray, decimal[] trayValuesArray)
    {
        decimal ammountInTrays = 0;
        for (int i = 0; i < trayCoinsArray.Length; i++)
        {
            ammountInTrays += trayCoinsArray[i] * trayValuesArray[i];
        }

        return ammountInTrays;
    }
}

