using System;
using System.Text;

class ForbiddenWords
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It uses advanced parser and special optimizer for the Microsoft CLR.";
        string[] wordsToCensure = { "PHP", "CLR", "Microsoft" };

        string censuredText = ReplaceWords(text, wordsToCensure);
        Console.WriteLine("The censured text is:\n{0}", censuredText);
    }

    static string ReplaceWords(string text, string[] wordsToCensure)
    {
        if (text == null)
            throw new ApplicationException("The value of the text you have given is null.");
        if (wordsToCensure == null)
            throw new ApplicationException("The value of the text you have given is null.");

        foreach (string word in wordsToCensure)
        {
            StringBuilder currentCensurer = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
                currentCensurer.Append('*');

            text = text.Replace(word, currentCensurer.ToString());
        }
        return text;
    }
}

