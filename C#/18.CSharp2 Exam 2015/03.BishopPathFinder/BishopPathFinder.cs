using System;
using System.Linq;
using System.Numerics;
using System.Collections.Generic;

class Move
{
    public string Direction {get; set;}
    public int Count { get; set; }

    public Move(string direction, int count)
    {
        this.Direction = direction;
        this.Count = count;
    }
}

class BishopPathFinder
{
    static void Main()
    {
        int[] dims = Console.ReadLine().Split()
            .Select(int.Parse).ToArray();

        int height = dims[0];
        int width = dims[1];

        //fill the field
        int[,] field = new int[height, width]; 
        int cellBelow = 0;

        for (int row = height - 1; row >= 0; row--)
        {
            for (int col = 0; col < width; col++)
            {
                field[row, col] = cellBelow;
                cellBelow += 3;
            }
            cellBelow = field[row, 0] + 3;
        }

        //read the moves
        int movesCount = int.Parse(Console.ReadLine());
        List<Move> moves = new List<Move>();

        for (int i = 0; i < movesCount; i++)
        {
            string[] curMove = Console.ReadLine().Split();
            moves.Add(new Move(curMove[0], int.Parse(curMove[1])));
        }

        BigInteger sum = 0;
        int curRow = height - 1;
        int curCol = 0;
        int rowChange = 0;
        int colChange = 0;

        for (int i = 0; i < moves.Count; i++)
        {
            //if (hasFinished)
            //    break;

            Move curMove = moves[i];
            string direction = curMove.Direction;
            int count = curMove.Count - 1;

            switch (direction)
            {
                case "UR":
                case "RU":
                    rowChange = -1; colChange = 1;
                    break;
                case "RD": 
                case "DR":
                    rowChange = 1; colChange = 1; 
                    break;
                case "LU":
                case "UL":
                    rowChange = -1; colChange = -1; 
                    break;
                case "DL":
                case "LD":
                    rowChange = 1; colChange = -1; 
                    break;
            }

            for (int j = 0; j < count; j++)
            {
                if (curRow + rowChange >= 0 && curRow + rowChange < height 
                    && curCol + colChange >= 0 && curCol + colChange < width)
                {
                    curRow += rowChange;
                    curCol += colChange;               
                }
                else
                {
                    break;
                }

                sum += field[curRow, curCol];
                field[curRow, curCol] = 0;
            }
        }

        Console.WriteLine(sum);
    }
}
