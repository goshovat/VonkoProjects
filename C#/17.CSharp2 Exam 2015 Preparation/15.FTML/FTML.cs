using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Tag
{
    public string TagName { get; set; }
    public int StartIndex { get; set; }

    public Tag(string name, int startIndex)
    {
        this.TagName = name;
        this.StartIndex = startIndex;
    }
}

class FTML
{
    static void Main()
    {
        int numberLines = int.Parse(Console.ReadLine());
        StringBuilder resultText = new StringBuilder();
        Stack<Tag> tags = new Stack<Tag>();
        Tag currentTag = null;
        int openedDelTags = 0;

        for (int row = 0; row < numberLines; row++)
        {
            string currentLine = Console.ReadLine();

            for (int symbol = 0; symbol < currentLine.Length; symbol++)
            {
                char currentSymbol = currentLine[symbol];

                if (currentSymbol == '<')
                {
                    bool isClosingTag = false;
                    if (currentLine[symbol + 1] == '/')
                        isClosingTag = true;

                    string currentTagName = ExtractTags(currentLine, symbol);

                    if (!isClosingTag)
                    {
                        currentTag = new Tag(currentTagName, resultText.Length);
                        if (currentTagName == "del")
                            openedDelTags++;

                        symbol += currentTagName.Length + 1;
                        tags.Push(currentTag);
                    }
                    else
                    {
                        currentTag = tags.Pop();

                        if (currentTag.TagName == "upper")
                            TransformToUpperCase(resultText, currentTag.StartIndex);
                        else if (currentTag.TagName == "lower")
                            TransformToLowerCase(resultText, currentTag.StartIndex);
                        else if (currentTag.TagName == "toggle")
                            ToggleText(resultText, currentTag.StartIndex);
                        else if (currentTag.TagName == "rev")
                            ReverseText(resultText, currentTag.StartIndex);
                        else if (currentTag.TagName == "del")
                            openedDelTags--;

                        symbol += currentTagName.Length + 2;
                    }

                }
                else
                {
                    if (openedDelTags == 0)
                        resultText.Append(currentLine[symbol]);
                }
            }
            resultText.Append('\n');
        }

        Console.WriteLine(resultText.ToString());
    }

    private static string ExtractTags(string currentLine, int symbol)
    {
        while (symbol < currentLine.Length &&
            (currentLine[symbol] == '<' ||
            currentLine[symbol] == '/'))
        {
            symbol++;
        }
        StringBuilder tag = new StringBuilder();

        while (symbol < currentLine.Length &&
              currentLine[symbol] != '>')
        {
            tag.Append(currentLine[symbol]);
            symbol++;
        }
        return tag.ToString();
    }

    private static void TransformToUpperCase(StringBuilder resultText, int startIndex)
    {
        for (int i = startIndex; i < resultText.Length; i++)
        {
            if (char.IsLetter(resultText[i]))
                resultText[i] = char.ToUpper(resultText[i]);
        }
    }

    private static void TransformToLowerCase(StringBuilder resultText, int startIndex)
    {
        for (int i = startIndex; i < resultText.Length; i++)
        {
            if (char.IsLetter(resultText[i]))
                resultText[i] = char.ToLower(resultText[i]);
        }
    }

    private static void ToggleText(StringBuilder resultText, int startIndex)
    {
        for (int i = startIndex; i < resultText.Length; i++)
        {
            if (char.IsLetter(resultText[i]))
            {
                if (char.IsUpper(resultText[i]))
                    resultText[i] = char.ToLower(resultText[i]);
                else
                    resultText[i] = char.ToUpper(resultText[i]);
            }
        }
    }

    private static void ReverseText(StringBuilder resultText, int startIndex)
    {
        for (int i = startIndex; i < startIndex + (resultText.Length - startIndex) / 2; i++)
        {
            char temp = resultText[i];
            int rightIndex = resultText.Length - (i - startIndex) - 1;
            resultText[i] = resultText[rightIndex];
            resultText[rightIndex] = temp;
        }
    }
}
