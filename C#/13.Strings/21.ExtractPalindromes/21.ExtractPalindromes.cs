using System;
using System.Collections.Generic;

class ExtractPalindromes
{
    static void Main()
    {
        string text = "Telerik Academy aims to provide exe free real-world practical abba training for young people who want to turn into skillful .NET lamal software engineers.";

        try
        {
            List<string> palindromes = GetPalindromes(text);
            Console.WriteLine("The palindromes in the text are:");
            foreach (string word in palindromes)
            {
                Console.WriteLine(word);
            }
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error! Details:\n{0}", applExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution! Details:\n{0}", e.StackTrace);
        }
    }

    //this method will find the palindromes in the text
    static List<string> GetPalindromes(string text)
    {
        if (text == null)
            throw new ApplicationException("You have given text with null value.");

        List<string> palindromes = new List<string>();

        char[] separators = {' ', ',', '.', '!', '?', '-', '/', '\\'};
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (IsPalindrome(word))
                palindromes.Add(word);
        }

        return palindromes;
    }

    //this method will check every separate word in the sentence if it is palindrome
    private static bool IsPalindrome(string word)
    {
        if (word == "")
            throw new ApplicationException("You have given empty word.");

        int len = word.Length;

        for (int i = 0; i < len / 2; i++)
        {
            if (word[i] != word[len - 1 - i])
                return false;
        }

        return true;
    }
}
