using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

class PHPVariables
{
    private static HashSet<string> variablesFound
        = new HashSet<string>();

    static void Main()
    {
        string inputStart = Console.ReadLine().Trim();

        bool isInSingleString = false;
        bool isInDoubleString = false;
        bool isInMultiLineComment = false;
        bool isEscaped = false;

        if (inputStart == "<?php")
        {
            string line = Console.ReadLine().Trim();

            while (line != "?>")
            {
                StringBuilder currentEntity = new StringBuilder();
                bool isInOneLineComment = false;

                for (int i = 0; i < line.Length; i++)
                {
                    if (i < line.Length && !isEscaped &&
                        !isInOneLineComment &&
                            !isInMultiLineComment)
                    {
                        if (line[i] == '$')
                        {
                            int offset = ExtractVariableName(line, i);
                            i += offset;
                        }
                        else if (line[i] == '"')
                        {
                            if (!isInSingleString && !isInDoubleString)
                                isInDoubleString = true;
                            else if (isInDoubleString)
                                isInDoubleString = false;
                        }
                        else if (line[i] == '\'')
                        {
                            if (!isInSingleString && !isInDoubleString)
                                isInSingleString = true;
                            else if (isInSingleString)
                                isInSingleString = false;
                        }
                        else if (line[i] == '\\' &&
                            (isInSingleString || isInDoubleString))
                        {
                            isEscaped = true;
                        }
                    }
                    else if (isEscaped && !isInOneLineComment &&
                          !isInMultiLineComment &&
                        (isInSingleString || isInDoubleString))
                    {
                        isEscaped = false;
                    }

                    if (!isEscaped && !isInSingleString
                            && !isInDoubleString)
                    {
                        if (i < line.Length && line[i] != ' ')
                            currentEntity.Append(line[i]);
                        else
                            currentEntity = new StringBuilder();
                    }

                    if (currentEntity.ToString() == "//" ||
                        currentEntity.ToString() == "#")
                    {
                        isInOneLineComment = true;
                        currentEntity = new StringBuilder();
                    }
                    else if (currentEntity.ToString() == "/*")
                    {
                        isInMultiLineComment = true;
                        currentEntity = new StringBuilder();
                    }
                    else if (currentEntity.ToString() == "*/" && isInMultiLineComment)
                    {
                        isInMultiLineComment = false;
                        currentEntity = new StringBuilder();
                    }
                }
                //end iterating the current line

                if (currentEntity.ToString() == "//")
                {
                    isInOneLineComment = true;
                    currentEntity = new StringBuilder();
                }
                else if (currentEntity.ToString() == "/*")
                {
                    isInMultiLineComment = true;
                    currentEntity = new StringBuilder();
                }
                else if (currentEntity.ToString() == "*/"
                    && isInMultiLineComment)
                {
                    isInMultiLineComment = false;
                    currentEntity = new StringBuilder();
                }

                line = Console.ReadLine().Trim();
            }

            //print the final result
            Console.WriteLine(variablesFound.Count);
            var sortedVars = variablesFound.OrderBy(
                s => s, StringComparer.Ordinal);

            foreach (var variable in sortedVars)
                Console.WriteLine(variable);
        }
    }

    private static int ExtractVariableName(string line, int i)
    {
        int index = i;

        while (index < line.Length &&
            line[index] == '$')
            index++;

        StringBuilder tag = new StringBuilder();

        while (index < line.Length &&
            (char.IsLetter(line[index])
            || char.IsDigit(line[index])
            || line[index] == '_'))
        {
            tag.Append(line[index]);
            index++;
        }

        variablesFound.Add(tag.ToString().Trim());

        return index - i - 1;
    }
}
