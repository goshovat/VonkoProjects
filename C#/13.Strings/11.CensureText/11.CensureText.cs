using System;
using System.Text;

class CensureText
{
    static void Main()
    {
        try
        {
            string text = "Microsoft announced its next generation C# compiler today. It uses advanced parser and special optimizer for the Microsoft CLR.";
            string[] wordsToCensure = { "C#", "CLR", "Microsoft" };

            string censuredText = ReplaceWords(text, wordsToCensure);

            Console.WriteLine("The censured text is:\n{0}", censuredText);
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error! Details:\n{0}", applExc.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\n{0}", e.Message);
        }
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
