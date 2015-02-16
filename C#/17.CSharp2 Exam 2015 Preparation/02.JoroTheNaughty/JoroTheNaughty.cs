using System;

public class Jump
{
    public int RowOffset { get; set; }
    public int ColOffset { get; set; }

    public Jump(int rowOffset, int colOffset)
    {
        this.RowOffset = rowOffset;
        this.ColOffset = colOffset;
    }
}

class JoroTheNaughty
{
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        int height = int.Parse(input1[0]);
        int width = int.Parse(input1[1]);
        int jumps = int.Parse(input1[2]);
        string[] input2 = Console.ReadLine().Split();
        int row = int.Parse(input2[0]);
        int col = int.Parse(input2[1]);

        Jump[] jumpsSequence = new Jump[jumps];

        for (int i = 0; i < jumps; i++)
        {
            string[] currentJumpEntities = Console.ReadLine().Split();
            int currentRowOffset = int.Parse(currentJumpEntities[0]);
            int currentColOffset = int.Parse(currentJumpEntities[1]);
            jumpsSequence[i] = new Jump(currentRowOffset, currentColOffset);
        }

        //initialize the field
        int[,] field = new int[height, width];
        int number = 1;
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                field[i, j] = number;
                number++;
            }
        }

        PrintField(field);

        int numberJumps = 0;
        if (row < 0 || row >= height
                || col < 0 || col >= width)
        {
            Console.WriteLine("escaped {0}", numberJumps);
            return;
        }
        int sum = field[row, col];
        field[row, col] = -1;

        int jumpNumber = 0;
        while (true)
        {
            row += jumpsSequence[jumpNumber].RowOffset;
            col += jumpsSequence[jumpNumber].ColOffset;
            numberJumps++;
            jumpNumber++;

            if (jumpNumber >= jumps)
                jumpNumber = 0;

            if (row < 0 || row >= height
                || col < 0 || col >= width)
            {
                Console.WriteLine("escaped {0}", sum);
                break;
            }
            else if (field[row, col] == -1)
            {
                Console.WriteLine("caught {0}", numberJumps);
                break;
            }

            sum += field[row, col];
            field[row, col] = -1;
        }
    }

    private static void PrintField(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
   
    }
}