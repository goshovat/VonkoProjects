using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TheyAreGreen
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        char[] letters = new char[count];

        for (int i = 0; i < count; i++)
        {
            letters[i] = Console.ReadLine()[0];
        }

        int combinations = 0;
        Array.Sort(letters);

        do
        {
            if (!RepetitionsFound(letters))
            {
                combinations++;
            }
        }
        while (NextPermutations(letters));

        Console.WriteLine(combinations);
    }

    private static bool RepetitionsFound(char[] letters)
    {
        for (int i = 0; i < letters.Length - 1; i++)
        {
            if (letters[i] == letters[i + 1])
                return true;
        }
        return false;
    }

    private static bool NextPermutations(char[] letters)
    {
        for (int i = letters.Length - 2; i >= 0; i--)
        {
            if (letters[i] < letters[i + 1])
            {
                int indexToSwap = letters.Length - 1;
                while (letters[i] >= letters[indexToSwap])
                    indexToSwap--;

                char temp = letters[i];
                letters[i] = letters[indexToSwap];
                letters[indexToSwap] = temp;

                Array.Reverse(letters, i + 1, letters.Length - i - 1);

                return true;
            }
        }

        return false;
    }
}
