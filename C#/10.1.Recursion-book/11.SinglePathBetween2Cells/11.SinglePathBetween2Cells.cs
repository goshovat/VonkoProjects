using System;

class AllPathsBetween2Cells
{
    //static char[,] labyrinth = {
    //                               {' ', '*', '*', '*', '*', '*', '*'},
    //                               {' ', ' ', ' ', ' ', ' ', ' ', '*'},
    //                               {' ', '*', ' ', '*', '*', ' ', '*'},
    //                               {' ', ' ', ' ', ' ', ' ', ' ', '*'}
    //                           };

    static char[,] labyrinth = {
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',}
                               };

    static int height;
    static int width;

    static char[] directions;

    static int startRow;
    static int startCol;
    static int endRow;
    static int endCol;
    static int steps;

    static void Main()
    {
        height = labyrinth.GetLength(0);
        width = labyrinth.GetLength(1);
        directions = new char[width * height];

        startRow = 0;
        startCol = 0;
        endRow = height - 1;
        endCol = width - 1;
        steps = 0;

        FindPaths(startRow, startCol, 'S');
    }

    //this is the recursive method that will find the paths
    static void FindPaths(int row, int col, char direction)
    {
        //check if try to step out of the labirynth
        if (row < 0 || col < 0 || row >= height || col >= width)
            return;

        directions[steps] = direction;
        steps++;

        if (row == endRow && col == endCol)
        {
            PrintPath(1, steps - 1);
            steps--;
            return;
        }

        if (labyrinth[row, col] == ' ')
        {
            labyrinth[row, col] = 'v';

            FindPaths(row - 1, col, 'U');
            FindPaths(row, col + 1, 'R');
            FindPaths(row + 1, col, 'D');
            FindPaths(row, col - 1, 'L');
        }

        steps--;
    }

    //this method will print the path when exit is found
    static void PrintPath(int start, int end)
    {
        Console.Write("Exit found! Directions: ");
        for (int i = start; i <= end; i++)
        {
            Console.Write(directions[i] + " ");
        }
        Console.WriteLine();
    }
}
