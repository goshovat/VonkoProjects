using System;
using System.Text;

class SeriesOfLetters
{
    static void Main()
    {
        string text = "aaaaabbbbbcdddeeeedssaa";

        if (text == "")
        {
            Console.WriteLine("Error! You have given empty string.");
            return;
        }

        StringBuilder result = new StringBuilder();
        char prevLetter = text[0];
        result.Append(prevLetter);

        for (int i = 1; i < text.Length; i++)
        {
            if (text[i] != prevLetter)
            {
                prevLetter = text[i];
                result.Append(prevLetter);
            }
        }

        Console.WriteLine("The formatted text is:\n{0}", result.ToString());
    }
}
