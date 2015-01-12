using System;
using System.Text;

class ExtractSentences
{
    static void Main()
    {
        Console.WriteLine("The program will print all the senteces containing the given word:");

        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
        string givenWord = "in";

        try
        {
            ExtractSentencs(text, givenWord);
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

    static void ExtractSentencs(string text, string givenWord)
    {
        char[] sentenceSeparators = {'.', '!', '?'};
        char[] wordSeparators = {' ', '-', '*', '\\', '/'};

        if (text == null)
            throw new ApplicationException("The value of the text you have given is null.");

        if (givenWord == null)
            throw new ApplicationException("The value of the word you have given is null.");

        string[] sentences = text.Split(sentenceSeparators);

        foreach (string sentece in sentences) 
        {
            string[] wordsInSentence = sentece.Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in wordsInSentence)
            {
                if (word.Equals(givenWord))
                {
                    Console.WriteLine(sentece.Trim());
                    break;
                }
            }
        }
    }
}
