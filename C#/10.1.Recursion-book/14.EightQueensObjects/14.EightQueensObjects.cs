using System;
using System.Collections.Generic;

class EightQueensObjects
{
    static char[,] field = {
                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                                { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                           };

    private static int numberOfQueens = 8;
    static int foundSolutions = 0;

    static void Main()
    {
        int column = 0;

        for (int row = 0; row < 8; row++)
        {
            //here is created the first queen
            Queen currentQueen = new Queen(column, row, null);
            PutQueens(currentQueen);
        }
    }

    //this recursive method will put every new queen on the field
    static void PutQueens(Queen currentQueen)
    {
        //put the new queen on the field
        field[currentQueen.Row, currentQueen.Column] = 'Q';

        if (currentQueen.Column == numberOfQueens - 1)
        {
            foundSolutions++;
            PrintField();
            field[currentQueen.Row, currentQueen.Column] = ' ';
            return;
        }

        Queen nextQueen;

        for (int rows = 0; rows < field.GetLength(0); rows++)
        {
            bool isChecked = false;
            Queen queenBefore = currentQueen;
            //check if we can put the new queen here
            while (rows != queenBefore.Row &&
                Math.Abs(rows - queenBefore.Row) != Math.Abs(currentQueen.Column + 1 - queenBefore.Column)) //check if the new queen will be attacked diagonally
            {
                isChecked = true;

                if (queenBefore.Parent != null)
                {
                    queenBefore = queenBefore.Parent;
                }
                else
                {
                    break;
                }

                isChecked = false;
            }

            //if the new queen is not threatened by all the queens, we can put it here
            if (queenBefore.Column == 0 && isChecked)
            {
                nextQueen = new Queen(currentQueen.Column + 1, rows, currentQueen);
                PutQueens(nextQueen);
            }
        }

        field[currentQueen.Row, currentQueen.Column] = ' ';
    }

    //this method will print the current solution
    static void PrintField()
    {
        Console.WriteLine(foundSolutions);

        for (int row = 0; row < field.GetLength(0); row++)
        {
            for (int col = 0; col < field.GetLength(1); col++)
            {
                if (field[row, col] == 'Q')
                    Console.Write(field[row, col].ToString().PadLeft(3));
                else
                    Console.Write("*".PadLeft(3));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

