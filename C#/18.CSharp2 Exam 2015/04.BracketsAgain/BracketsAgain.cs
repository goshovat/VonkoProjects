using System;
using System.Collections.Generic;
using System.Text;

class BracketsAgain
{
    private static string[] keywords = new string[] 
        {
            "abstract",
            "as",
            "base",
            "break",
            "case",
            "catch",
            "checked",
            "class",
            "const",
            "continue",
            "default",
            "delegate",
            "do",
            "else",
            "enum",
            "event",
            "explicit",
            "extern",
            "false",
            "finally",
            "fixed",
            "for",
            "foreach",
            "goto",
            "if",
            "implicit",
            "in",
            "interface",
            "internal",
            "is",
            "lock",
            "namespace",
            "new",
            "null",
            "operator",
            "out",
            "override",
            "params",
            "private",
            "protected",
            "public",
            "readonly",
            "ref",
            "return",
            "sealed",
            "sizeof",
            "stackalloc",
            "static",
            "struct",
            "switch",
            "this",
            "throw",
            "true",
            "try",
            "typeof",
            "unchecked",
            "unsafe",
            "using",
            "virtual",
            "void",
            "volatile",
            "while"
        };

    static void Main()
    {
        int numberLines = int.Parse(Console.ReadLine());

        List<string> methodCalls = new List<string>();

        int foundMethods = 0;

        for (int i = 0; i < numberLines; i++)
        {
            var currentLine = Console.ReadLine();

            currentLine = currentLine.Trim();
            int indexMethodDeclaration = 0;

            if (currentLine.IndexOf("static") == 0)
            {
                if (methodCalls.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", methodCalls));
                }

                if (foundMethods > 0 && methodCalls.Count == 0)
                {
                    Console.WriteLine("None");
                }

                methodCalls.Clear();

                int indexOfOpenBracket = currentLine.IndexOf("(");
                int indexOfWhiteSpace = indexOfOpenBracket;

                while (!char.IsLetter(currentLine[indexOfWhiteSpace]))
                {
                    indexOfWhiteSpace--;
                }

                int indexOfSpaceBeforeBracket = currentLine.LastIndexOf(" ", indexOfWhiteSpace);
                indexMethodDeclaration = indexOfOpenBracket;
                Console.Write(currentLine.Substring(
                    indexOfSpaceBeforeBracket + 1, indexOfOpenBracket - indexOfSpaceBeforeBracket - 1).Trim());
                Console.Write(" -> ");
                foundMethods++;
            }

            var currentWord = new StringBuilder();

            bool isKeyWord = false;
            string lastKeyWord = string.Empty;

            for (int j = indexMethodDeclaration; j < currentLine.Length; j++)
            {
                if (char.IsLetter(currentLine[j]))
                {
                    currentWord.Append(currentLine[j]);
                    continue;
                }

                if (!char.IsLetter(currentLine[j]) && currentLine.Length > 0)
                {
                    var currentWordString = currentWord.ToString();
                    if (Array.IndexOf(keywords, currentWordString) > -1)
                    {
                        isKeyWord = true;
                        currentWord.Clear();
                        lastKeyWord = currentWordString;
                        continue;
                    }
                    else if (lastKeyWord != "new")
                    {
                        isKeyWord = false;
                    }

                    if (CheckForMethodCall(currentLine, j))
                    {
                        if (isKeyWord)
                        {
                            isKeyWord = false;
                            currentWord.Clear();
                            continue;
                        }

                        isKeyWord = false;
                        methodCalls.Add(currentWordString);
                    }

                    currentWord.Clear();
                }
            }
        }

        if (methodCalls.Count > 0)
        {
            Console.WriteLine(string.Join(", ", methodCalls));
        }

        if (foundMethods > 0 && methodCalls.Count == 0)
        {
            Console.WriteLine("None");
        }
    }

    private static bool CheckForMethodCall(string line, int position)
    {
        for (int i = position; i < line.Length; i++)
        {
            if (line[i] == ' ')
            {
                continue;
            }

            if (line[i] == '(')
            {
                return true;
            }

            break;
        }
        return false;
    }
}