using System;

class LargestArea
{
    static char[,] field = {
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',},
                                   {' ',' ',' ','*','*','*',' ',' ',' ',' ',},
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

    static int currentArea;
    static int largestArea;

    static void Main()
    {
        height = field.GetLength(0);
        width = field.GetLength(1);

        FindLargestArea();
    }

    //this method will start looking for a largest area from every cell that is not already visited
    static void FindLargestArea()
    {
        for (int row = 0; row < height; row++)
        {
            for (int col = 0; col < width; col++)
            {
                currentArea = 0;

                if (field[row, col] == ' ')
                    FindAreas(row, col);

                if (currentArea > largestArea)
                    largestArea = currentArea;
            }
        }

        Console.WriteLine("The largest area consists of: {0}", largestArea);
    }

    //this is the recursive method that will find the paths
    static void FindAreas(int row, int col)
    {
        //check if try to step out of the labirynth
        if (row < 0 || col < 0 || row >= height || col >= width)
            return;

        if (field[row, col] == ' ')
        {
            field[row, col] = 'v';
            currentArea++;

            FindAreas(row - 1, col);
            FindAreas(row, col + 1);
            FindAreas(row + 1, col);
            FindAreas(row, col - 1);
        }
    }
}
