using System;
using System.Collections.Generic;

class Dictionary
{
    static void Main()
    {
        string text = ".NET – platform for applications from Microsoft \nCLR – managed execution environment for \n.NET namespace – hierarchical organization of classes";

        List<string> termins = new List<string>();
        List<string> explainations = new List<string>();

        try
        {
            ParseDictionary(text, ref termins, ref explainations);

            Console.WriteLine("Input a word to check its meaning in the dictionary: ");
            string userInput = Console.ReadLine().Trim();

            string meaning = CheckWord(userInput, termins, explainations);
            Console.WriteLine(meaning);
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error! Details:\n{0}", applExc.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error! Details:\n{0}", e.StackTrace);
        }
    }

    private static string CheckWord(string userInput, List<string> termins, List<string> explainations)
    {
        if (userInput == null)
            throw new ApplicationException("The value of the word is null");

        int index = termins.IndexOf(userInput);

        if (index != -1)
        {
            return explainations[index];
        }
        else
        {
            return "The word is not in the dictionary.";
        }
    }

    private static void ParseDictionary(string text, ref List<string> termins, ref List<string> explainations)
    {
        if (text == null)
            throw new ApplicationException("The text you have given is null");
        if (termins == null)
            throw new ApplicationException("The list of termins is not initialized");
        if (explainations == null)
            throw new ApplicationException("The list of explainations is not initialized");

        string[] lines = text.Split('\n');

        char[] separator = { '–' };

        foreach (string line in lines)
        {
            string[] components = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (components.Length != 2)
                throw new ApplicationException("Invalid text!");

            termins.Add(components[0].Trim());
            explainations.Add(components[1].Trim());
        }
    }

}

