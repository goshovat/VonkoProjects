using System;
using System.Text;

class ConsoleJustification
{
    static void Main()
    {
        int initialLines = int.Parse(Console.ReadLine());
        int symbolsPerLine = int.Parse(Console.ReadLine());

        StringBuilder originalText = new StringBuilder();
        for (int i = 0; i < initialLines; i++)
        {
            originalText.Append(Console.ReadLine());
            originalText.Append(' ');
        }

        string[] unformattedText = originalText.ToString().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

        StringBuilder formattedText = new StringBuilder();
        int remainingSymbols = symbolsPerLine;
        int addedWordsForLine = 0;

        for (int word = 0; word < unformattedText.Length; word++)
        {
            if (unformattedText[word].Length <= remainingSymbols)
            {
                formattedText.Append(unformattedText[word]);
                addedWordsForLine++;
                remainingSymbols -= (unformattedText[word].Length);

                if (remainingSymbols > 0)
                {
                    formattedText.Append(' ');
                    remainingSymbols--;
                }
                else
                {
                    if (formattedText[formattedText.Length - 1] == ' ')
                    {
                        formattedText[formattedText.Length - 1] = '\n';
                        remainingSymbols++;
                    }
                    else
                        formattedText.Append('\n');

                    if (addedWordsForLine > 1 && remainingSymbols > 0)
                    {
                        int startIndex = formattedText.Length - 1 + remainingSymbols - symbolsPerLine;
                        AddWhiteSpaces(startIndex, formattedText, remainingSymbols);
                    }

                    remainingSymbols = symbolsPerLine;
                    addedWordsForLine = 0;
                }
            }
            else
            {
                if (formattedText[formattedText.Length - 1] == ' ')
                {
                    formattedText[formattedText.Length - 1] = '\n';
                    remainingSymbols++;
                }
                else
                    formattedText.Append('\n');

                if (addedWordsForLine > 1 && remainingSymbols > 0)
                {
                    int startIndex = formattedText.Length - 1 + remainingSymbols - symbolsPerLine;
                    AddWhiteSpaces(startIndex, formattedText, remainingSymbols);
                }

                word--;
                remainingSymbols = symbolsPerLine;
                addedWordsForLine = 0;
            }
        }

        if (addedWordsForLine > 1 && remainingSymbols > 0)
        {
            if (formattedText[formattedText.Length - 1] == ' ')
            {
                formattedText[formattedText.Length - 1] = '\n';
                remainingSymbols++;
            }
            else
                formattedText.Append('\n');

            int startIndex = formattedText.Length - 1 + remainingSymbols - symbolsPerLine;
            AddWhiteSpaces(startIndex, formattedText, remainingSymbols);
        }
        Console.WriteLine(formattedText.ToString().Trim());
    }

    private static void AddWhiteSpaces(int startIndex, StringBuilder formattedText, 
        int remainingSymbols)
    {
        int index = startIndex;

        if (formattedText[index] == '\n')
            index++;

        while (remainingSymbols > 0)
        {
            if (formattedText[index] == ' ' 
                && formattedText[index - 1] != ' ')
            {
                formattedText.Insert(index + 1, ' ');
                remainingSymbols--;
            }
            index++;

            if (formattedText[index] == '\n')
                index = startIndex;
        }
    }
}

