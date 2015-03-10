using System;
using System.Text;

class MovingLetters
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        //in this array we store on which letter we are in each word
        int[] indexes = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            indexes[i] = input[i].Length - 1;
        }

        bool someLetterRemain = true;
        StringBuilder extractedLetters = new StringBuilder();

        while (someLetterRemain)
        {
            someLetterRemain = false;

            for (int i = 0; i < input.Length; i++)
            {
                if (indexes[i] >= 0)
                {
                    extractedLetters.Append(input[i][indexes[i]]);
                    indexes[i]--;
                    someLetterRemain = true;
                }
            }
        }

        //Console.WriteLine(extractedLetters);

        for (int i = 0; i < extractedLetters.Length; i++)
        {
            int letterMoves = char.ToUpper(extractedLetters[i]) - 'A' + 1;
            int newPosition = (i + letterMoves) % (extractedLetters.Length);
            char letter = extractedLetters[i];
            extractedLetters.Remove(i, 1);

            extractedLetters.Insert(newPosition, letter);
        }

        Console.WriteLine(extractedLetters);
    }
}
