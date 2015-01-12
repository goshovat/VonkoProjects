using System;
using System.IO;
using System.Text;

class ExtractXMLContent
{
    static void Main()
    {
        string filePathName = @"..\..\SomeText.xml";

        try
        {
            string[] extractedWords = GetXMLContent(filePathName);
            Console.WriteLine("The words from the xml file are:");
            
            foreach (string word in extractedWords)
                Console.WriteLine(word);
        }
        catch (FileNotFoundException fileNotFoundExc)
        {
            Console.WriteLine("Error! The source file " + filePathName + " was not found. Details:\n{0}", fileNotFoundExc.StackTrace);
        }
        catch (ApplicationException applExc)
        {
            Console.WriteLine("Error occured during working with the file. Details:\n{0}", applExc.Message);
        }
        catch (IOException ioExc)
        {
            Console.WriteLine("Error occured during operations with the files. Details:\n{0}", ioExc.StackTrace);
        }
        catch (Exception e)
        {
            Console.WriteLine("Something fucked up happened! Details:\n{0}", e.StackTrace);
        }
    }

    private static string[] GetXMLContent(string filePathName)
    {
        if (filePathName == null)
            throw new ApplicationException("You have given path name with null value.");
        if (filePathName == "")
            throw new ApplicationException("You have given path name with empty value.");

        string fileContent = File.ReadAllText(filePathName);
        fileContent = fileContent.Replace("\r\n", " ");
        int len = fileContent.Length;

        StringBuilder stringBuild = new StringBuilder();

        bool inOpeningTag = false;
        bool inCLosingTag = false;
        bool inXMLTag = false;
        string currentTag = "";

        for (int i = 0; i < len; i++)
        {
            if (fileContent[i] == '<')
            {
                if (i < len - 2)
                {
                    if (fileContent[i + 1] == '/')
                    {
                        inCLosingTag = true;
                        currentTag = ExtractTag(fileContent, ref i);
                        stringBuild.Append(' ');
                    }
                    //xml cversion of the file
                    else if (fileContent[i + 1] == '?')
                    {
                        inXMLTag = true;
                        currentTag = ExtractTag(fileContent, ref i);
                    }
                    else
                    {
                        inOpeningTag = true;
                        currentTag = ExtractTag(fileContent, ref i);
                        stringBuild.Append(' ');
                    }
                }
                else
                {
                    throw new ApplicationException(string.Format("Invalid XML tag. Problem at index {0}", i));
                }
            }
            else if (fileContent[i] == '>')
            {
                if (!inOpeningTag && !inCLosingTag && !inXMLTag)
                    throw new ApplicationException(string.Format("A tag is not correctly opened. Problem at index {0}", i));

                inOpeningTag = false;

                if (inCLosingTag)
                {
                    inCLosingTag = false;
                    currentTag = "";
                }
                else if (inXMLTag)
                {
                    inXMLTag = false;
                    currentTag = "";
                }
            }
            else if (fileContent[i] != '<' && fileContent[i] != '>' && fileContent[i] != '/' &&
                fileContent[i] != '?' && !inOpeningTag && !inCLosingTag)
            {
                stringBuild.Append(fileContent[i]);
            }
        }

        if (currentTag != "" && !inOpeningTag && !inCLosingTag)
            throw new ApplicationException("A tag was not closed at the end of the text");
        if (inOpeningTag)
            throw new ApplicationException("At the end of the text we are still in oppening tag.");
        if (inCLosingTag)
            throw new ApplicationException("At the end of the text we are still in closing tag");

        return stringBuild.ToString().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    }

    private static string ExtractTag(string fileContent, ref int i)
    {
        while (fileContent[i] == '<' || fileContent[i] == '/'
            || fileContent[i] == '?')
            i++;

        StringBuilder currentTag = new StringBuilder();

        for (; i < fileContent.Length; i++)
        {
            if (fileContent[i] != ' ' && fileContent[i] != '>')
                currentTag.Append(fileContent[i]);

            else
                break;
        }

        while (fileContent[i] != '>')
            i++;

        i--;

        return currentTag.ToString();
    }
}
