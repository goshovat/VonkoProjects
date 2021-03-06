﻿using System;

class ReplaceTags
{
    static void Main()
    {
        string text = "<p>Please visit <a href=\"http://academy.telerik.com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        string editedText = ReplaceATags(text);
        Console.WriteLine(editedText);
    }

    static string ReplaceATags(string text)
    {
        if (text == null)
            throw new ApplicationException("The value of the text is null");

        text = text.Replace("<a href=\"", "[URL =");
        text = text.Replace("\">", "]");
        text = text.Replace("</a>", "[/URL]");

        return text;
    }
}
