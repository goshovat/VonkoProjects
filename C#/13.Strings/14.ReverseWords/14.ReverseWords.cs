using System;
using System.Collections.Generic;
using System.Text;

class ReverseWords
{
    static void Main()
    {
        string sentence = "C# is not C++, and PHP, is not Delphi.";

        try
        {
            string reversedWordsSentence = RevWords(sentence);
            Console.WriteLine("The original sentence is:\n{0}", sentence);
            Console.WriteLine("The sentence with words reverse is:\n{0}", reversedWordsSentence);
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

    static string RevWords(string sentence)
    {
        if (sentence == null)
            throw new ApplicationException("The value of the sentence you have given is null.");

        sentence = sentence.Trim();

        StringBuilder strBuild = new StringBuilder();

        char[] separators = { ';', ',', ' ', '-', '.', '?', '!'};
        string[] wordsArray = sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        //now we will save how many words we have before any sign 
        List<char> signsList = new List<char>();
        List<int> signsPositionsList = new List<int>();

        for (int i = 0; i < separators.Length; i++)
        {
            if (separators[i] != '.' && separators[i] != '!' && separators[i] != '?' && separators[i] != ' ')
            {
                int indexCurSep = sentence.IndexOf(separators[i]);

                while (indexCurSep != -1)
                {
                    signsList.Add(separators[i]);

                    string currentSubstring = sentence.Substring(0, indexCurSep);
                    int indexWhiteSpace = currentSubstring.IndexOf(' ');
                    int whiteSpaces = 0;

                    while (indexWhiteSpace != -1)
                    {
                        whiteSpaces++;
                        indexWhiteSpace = currentSubstring.IndexOf(' ', indexWhiteSpace + 1);
                    }

                    //the whitespaces between n words are n-1
                    signsPositionsList.Add(whiteSpaces + 1);

                    indexCurSep = sentence.IndexOf(separators[i], indexCurSep + 1);
                }
            }
        }

        int wordsAppended = 0;
        int currentSign = 0;

        for (int i = wordsArray.Length - 1; i >= 0; i--)
        {
            string word = wordsArray[i];
            strBuild.Append(word);
            wordsAppended++;

            if (currentSign < signsList.Count && signsPositionsList[currentSign] == wordsAppended)
            {
                strBuild.Append(signsList[currentSign]);
                currentSign++;
            }

            strBuild.Append(' ');
        }

        //now append the final sign of the sentence
        string newSentence = strBuild.ToString().Trim() + sentence[sentence.Length - 1];

        return newSentence;
    }
}
