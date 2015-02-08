using System;
using System.Text;

class ParseTags
{
    static void Main()
    {
        string text = "<lowcase>We</lowcase> <upcase>gosHo</upcase> are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        string result = ChangeCasing(text);
        Console.WriteLine("The formatted text is:\n{0}", result);
    }

    static string ChangeCasing(string text)
    {
        if (text == null)
            throw new ApplicationException("You have given text with null value");

        StringBuilder strBuild = new StringBuilder();
        int len = text.Length;
        bool inOpeningTag = false;
        bool inClosingTag = false;
        string currentTag = "";

        for (int i = 0; i < len; i++)
        {
            //find when we go in oppening tag
            if (text[i] == '<')
            {
                //any tag must be at least 3 chars - <, > and a letter
                if (i < len - 2)
                {
                    if (text[i + 1] == '/')
                    {
                        inClosingTag = true;
                        currentTag = ExtractTag(ref i, text);
                    }
                    else
                    {
                        //if we will open another tag, but the previous is not closed apparently there is a problem. 
                        //our program does not support nested tags
                        if (currentTag != "")
                            throw new ApplicationException(String.Format(
                                "Unclosed tag! Check the text at index {0}", i));

                        inOpeningTag = true;
                        currentTag = ExtractTag(ref i, text);
                    }
                }
                else
                    throw new ApplicationException(String.Format(
                        "Not a valid tag! Check the original text on index {0}", i));
            }
            else if (text[i] == '>')
            {
                if (!inOpeningTag && !inClosingTag)
                    throw new ApplicationException(String.Format(
                        "Error! A tag is not correctly opened. Check the text at index {0}", i));

                inOpeningTag = false;
                if (inClosingTag)
                {
                    inClosingTag = false;
                    currentTag = "";
                }
            }
            else if (text[i] != '>' && text[i] != '<'
                && !inClosingTag && !inOpeningTag)
            {
                //we are in normal text
                if (currentTag == "lowcase")
                {
                    strBuild.Append(text[i].ToString().ToLower());
                }
                else if (currentTag == "upcase")
                {
                    strBuild.Append(text[i].ToString().ToUpper());
                }
                else
                {
                    strBuild.Append(text[i]);
                }
            }
        }

        if (currentTag != "" && !inOpeningTag && !inClosingTag)
            throw new ApplicationException(string.Format("Unclosed tag! Problem at index {0}", len - 1));
        if (inOpeningTag)
            throw new ApplicationException(string.Format("Still in oppening tag! Problem at index {0}", len - 1));
        if (inClosingTag)
            throw new ApplicationException(string.Format("Still in closing tag!Problem at index {0}", len - 1));

        return strBuild.ToString();
    }

    //this method will extract the tags and move the index
    static string ExtractTag(ref int i, string text)
    {
        StringBuilder tag = new StringBuilder();

        while (text[i] == '<' || text[i] == '/')
        {
            i++;
        }
        while (i < text.Length && text[i] != '>')
        {
            tag.Append(text[i]);
            i++;
        }
        i--;
        return tag.ToString();
    }
}
