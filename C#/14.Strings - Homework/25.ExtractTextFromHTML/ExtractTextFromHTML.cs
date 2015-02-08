using System.Text;
using System;

class ExtractTextFromHTML
{
    static void Main()
    {
        string text = "<html>\n<head><title>News</title></head>\n<body><p><a href=\"http://academy.telerik.com\">Telerik\nAcademy</a>aims to provide free real-world practical\ntraining for young people who want to turn into\nskillful .NET software engineers.</p></body>\n</html>";

        string editedText = RemoveTags(text);
        Console.WriteLine("The original text is:\n\n{0}\n", text);
        Console.WriteLine("The text without the tags is:\n\n{0}", editedText);
    }

    static string RemoveTags(string text)
    {
        if (text == null)
            throw new ApplicationException("You have given text with null value");

        int len = text.Length;
        StringBuilder strBuild = new StringBuilder();

        bool inOpeningTag = false;
        bool inClosingTag = false;
        string currentTag = "";

        for (int i = 0; i < len; i++)
        {
            if (text[i] == '<')
            {
                if (i < len - 2)
                {
                    if (text[i + 1] == '/')
                    {
                        inClosingTag = true;
                        currentTag = ExtractTag(ref i, text);

                        if (strBuild.Length > 0 && strBuild[strBuild.Length - 1] != ' '
                            && strBuild[strBuild.Length - 1] != '\n')
                            strBuild.Append(' ');
                    }
                    else
                    {
                        inOpeningTag = true;
                        currentTag = ExtractTag(ref i, text);

                        if (currentTag == "title")
                            strBuild.Append("Title: ");
                        else if (currentTag == "body")
                            strBuild.Append("Body:\n");
                    }
                }
                else
                {
                    throw new ApplicationException(
                        String.Format("Not a valid tag! Check the original text on index {0}", i));
                }
            }
            else if (text[i] == '>')
            {
                if (!inClosingTag && !inOpeningTag)
                    throw new ApplicationException(
                        String.Format("A tag is not correctly opened. Check at index {0}", i));

                inOpeningTag = false;

                if (inClosingTag)
                {
                    if (currentTag == "title")
                    {
                        strBuild.Append('\n');
                        strBuild.Append('\n');
                    } 

                    if (currentTag == "body")
                        strBuild.Append('\n');

                    inClosingTag = false;
                    currentTag = "";
                }
            }
            else if (text[i] != '>' && text[i] != '<'
                && !inOpeningTag && !inClosingTag)
            {
                if (text[i] != '\n')
                {
                    strBuild.Append(text[i]);
                }
                else if (text[i] == '\n' && strBuild.Length > 0
                    && strBuild[strBuild.Length - 1] != ' ' && strBuild[strBuild.Length - 1] != '\n')
                {
                    strBuild.Append(' ');
                }
            }
        }

        if (!inOpeningTag && !inClosingTag && currentTag != "")
            throw new ApplicationException(string.Format("Unclosed tag! Problem at index {0}", len - 1));
        if (inOpeningTag)
            throw new ApplicationException(string.Format("Still in openning tag! Problem at index {0}", len - 1));
        if (inClosingTag)
            throw new ApplicationException(string.Format("Still in closing tag! Problem at index {0}", len - 1));

        return strBuild.ToString();
    }

    private static string ExtractTag(ref int i, string text)
    {
        StringBuilder tagName = new StringBuilder();
        while (text[i] == '<' || text[i] == '/')
            i++;

        for (; i < text.Length; i++)
        {
            if (text[i] != '>')
                tagName.Append(text[i]);
            else
                break;
        }
        i--;
        return tagName.ToString();
    }
}
