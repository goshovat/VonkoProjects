using System;
using System.Text;

class Brackets
{
    private static StringBuilder unformattedText = new StringBuilder();
    private static StringBuilder formattedText = new StringBuilder();

    static void Main()
    {
        int initialLines = int.Parse(Console.ReadLine());
        string tabulationPattern = Console.ReadLine();

        for (int row = 0; row < initialLines; row++)
        {
            string currentInput = Console.ReadLine();

            //very important, remove the completely empty lines
            if (currentInput.Trim() != "")
            {
                unformattedText.Append(currentInput);
            }
            unformattedText.Append('\n');
        }

        int tabulations = 0;
        char lastChar = default(char);

        for (int i = 0; i < unformattedText.Length; i++)
        {
            if (unformattedText[i] == '\n')
            {
                if (i > 0 && unformattedText[i - 1] != '\n'
                    && unformattedText[i - 1] != '}'
                    && unformattedText[i - 1] != '{'
                    && i < unformattedText.Length - 1
                    && FindNextChar(i) != '{'
                    && FindNextChar(i) != '}')
                {
                    formattedText.Append('\n');
                    AppendTabulation(tabulations, tabulationPattern);
                }
            }
            else if (unformattedText[i] == ' ')
            {
                if (i > 0 && i < unformattedText.Length - 1 &&
                    unformattedText[i - 1] != ' ' && unformattedText[i - 1] != '\n')
                {
                    formattedText.Append(' ');
                }
            }
            else
            {
                if (unformattedText[i] == '{')
                {
                    formattedText.Append('\n');
                    AppendTabulation(tabulations, tabulationPattern);
                    tabulations++;
                }
                else if (unformattedText[i] == '}')
                {
                    tabulations--;

                    formattedText.Append('\n');
                    AppendTabulation(tabulations, tabulationPattern);
                }
                else
                {
                    if (lastChar == '{' || lastChar == '}')
                    {
                        formattedText.Append('\n');
                        AppendTabulation(tabulations, tabulationPattern);
                    }
                }

                formattedText.Append(unformattedText[i]);

                lastChar = unformattedText[i];
            }
        }

        Console.WriteLine(formattedText.ToString().Trim());
    }

    private static char FindNextChar(int i)
    {
        while(i < unformattedText.Length 
            && (unformattedText[i] == ' ' ||
            unformattedText[i] == '\n'))
        {
            i++;
        }

        if (i < unformattedText.Length)
            return unformattedText[i];
        else
            return default(char);
    }

    private static void AppendTabulation(int tabulations, string tabulationPattern)
    {
        for (int i = 0; i < tabulations; i++)
            formattedText.Append(tabulationPattern);
    }
}
