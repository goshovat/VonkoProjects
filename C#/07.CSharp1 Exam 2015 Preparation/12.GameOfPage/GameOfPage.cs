using System;
using System.Collections.Generic;

class GameOfPage
{
    private static int[,] tray = new int[16, 16];
    private const int ROWS_COUNT = 16;
    private const int COLS_COUNT = 16;

    static void Main()
    {
        for (int rows = 0; rows < ROWS_COUNT; rows++)
        {
            string input = Console.ReadLine();

            for (int cols = 0; cols < COLS_COUNT; cols++)
            {
                tray[rows, cols] = int.Parse(input[cols].ToString());
            }
        }

        decimal bill = 0;
        List<string> finalResults = new List<string>();
        while (true)
        {
            string command = Console.ReadLine();

            if (command != "paypal")
            {
                int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());

                string result = CheckPosition(row, col);

                if (command == "what is") 
                { 
                    switch(result)
                    {
                        case "cookie":
                            finalResults.Add("cookie");
                            break;
                        case "brokenCookie":
                            finalResults.Add("broken cookie");
                            break;
                        case "crumb":
                            finalResults.Add("cookie crumb");
                            break;
                        case "nothing":
                            finalResults.Add("smile");
                            break;
                    }
                }
                else if (command == "buy")
                {
                    switch (result)
                    {
                        case "cookie":
                            bill += (decimal)1.79;
                            //remove the cookie from the tray
                            Buy(row, col);
                            break;
                        case "brokenCookie":
                        case "crumb":
                            finalResults.Add("page");
                            break;
                        case "nothing":
                            finalResults.Add("smile");
                            break;
                    }
                }
            }
            else
            {
                finalResults.Add(string.Format("{0:N2}", bill));
                break;
            }
        }

        foreach(string result in finalResults)
            Console.WriteLine(result);
    }

    private static void Buy(int row, int col)
    {
        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                tray[i, j] = 0;
            }
        }
    }

    private static string CheckPosition(int row, int col)
    {
        int piecesFound = 0;
        if (row >= 0 && row < tray.GetLength(0)
            && col >= 0 && col < tray.GetLength(1)
            && tray[row, col] == 0)
            return "nothing";

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
               if (i >= 0 && i < tray.GetLength(0)
                    && j >= 0 && j < tray.GetLength(1) && tray[i, j] == 1)
               {
                   piecesFound++;
               }
            }
        }

        if (piecesFound == 9)
            return "cookie";
        else if (piecesFound > 1)
            return "brokenCookie";
        else if (piecesFound == 1)
            return "crumb";
        else
            return "nothing";
    }
}

