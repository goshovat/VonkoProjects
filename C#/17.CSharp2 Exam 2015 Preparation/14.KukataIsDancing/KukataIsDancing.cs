using System;

class KukataIsDancing
{
    //private static char[, ,] cube = new char[3, 3, 3];
    private static char[,] field = new char[3, 3];

    static void Main()
    {
        //fill the field
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (row == 1 && col == 1) 
                {
                   field[row, col] = 'G';
                }
                else if ((row == 0 && col == 0) ||
                         (row == 0 && col == 2) ||
                         (row == 2 && col == 0) ||
                         (row == 2 && col == 2)) 
                {
                    field[row, col] = 'R';
                }
                else
                {
                    field[row, col] = 'B';
                }
            }
        }

        int dances = int.Parse(Console.ReadLine());
        string[] directions = new string[] { "right", "down", "left", "up" };
        int currentDirection = 2;

        for (int dance = 0; dance < dances; dance++)
        {
            int curRow = 1;
            int curCol = 1;
            string danceMoves = Console.ReadLine();
            char currentColor = field[curRow, curCol];

            for (int move = 0; move < danceMoves.Length; move++)
            {
                char currentMove = danceMoves[move];

                switch (currentMove)
                {
                    case 'W':
                        switch (currentDirection)
                        {
                            case 0:
                                curCol++;
                                if (curCol > 2)
                                    curCol = 0;
                                break;
                            case 1:
                                curRow--;
                                if (curRow < 0)
                                    curRow = 2;
                                break;
                            case 2:
                                curCol--;
                                if (curCol < 0)
                                    curCol = 2;
                                break;
                            case 3:
                                curRow++;
                                if (curRow > 2)
                                    curRow = 0;
                                break;
                        }
                        currentColor = field[curRow, curCol];
                        break;
                    case 'R':
                        currentDirection++;
                        if (currentDirection > 3)
                            currentDirection = 0;
                        break;
                    case 'L':
                        currentDirection--;
                        if (currentDirection < 0)
                            currentDirection = 3;
                        break;
                }
            }

            switch (currentColor)
            {
                case 'G':
                    Console.WriteLine("GREEN");
                    break;
                case 'R':
                    Console.WriteLine("RED");
                    break;
                case 'B':
                    Console.WriteLine("BLUE");
                    break;
            }
        }
    }
}
