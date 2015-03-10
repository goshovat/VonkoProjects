using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BasicLanguage
{
    private static List<string> allCommands = new List<string>();
    private static StringBuilder buffer = new StringBuilder();

    static void Main()
    {
        ReadInput();
        GetAllCommands();
        ExecuteCommands();
        Console.WriteLine(buffer.ToString());
    }

    private static void ReadInput()
    {
        while (true)
        {
            string line = Console.ReadLine();
            buffer.AppendLine(line);
            if (line.Contains("EXIT;"))
            {
                break;
            }
        }
    }

    private static void GetAllCommands()
    {
        string wholeString = buffer.ToString();
        buffer.Clear();

        foreach (char token in wholeString)
        {
            buffer.Append(token);
            if (token == ';')
            {
                allCommands.Add(buffer.ToString());
                buffer.Clear();
            }
        }
        buffer.Clear();
    }

    private static void ExecuteCommands()
    {
        bool hasExecuted = false;
        int commandNumber = 0;

        while (!hasExecuted)
        {
            string[] subCommands = allCommands[commandNumber].Split(
                new char[] {')'}, StringSplitOptions.RemoveEmptyEntries);
            commandNumber++;
            int loopCounter = 1;

            for (int i = 0; i < subCommands.Length; i++)
            {
                string currentSubCommand = subCommands[i].TrimStart();

                if (string.IsNullOrWhiteSpace(currentSubCommand) || currentSubCommand == ";")
                {
                    continue;
                }

                if (currentSubCommand.StartsWith("PRINT"))
                {
                    int start = currentSubCommand.IndexOf('(') + 1;
                    string printContent = currentSubCommand.Substring(start);
                    if (printContent.Length > 0)
                    {
                        for (int j = 0; j < loopCounter; j++)
                        {
                            buffer.Append(printContent);
                        }
                    }
                }
                else if (currentSubCommand.StartsWith("FOR"))
                {
                    int paramsStart = currentSubCommand.IndexOf('(') + 1;
                    string loopParams = currentSubCommand.Substring(paramsStart);
                    if (loopParams.Contains(","))
                    {
                        string[] rawParams = loopParams.Split(',');
                        int a = int.Parse(rawParams[0]);
                        int b = int.Parse(rawParams[1]);
                        loopCounter *= (b - a + 1);
                    }
                    else
                    {
                        int value = int.Parse(loopParams);
                        loopCounter *= value;
                    }
                }
                else if (currentSubCommand.StartsWith("EXIT"))
                {
                    hasExecuted = true;
                    break;
                }
                else
                {
                    throw new ArgumentException("Error! Invalid command.");
                }
            }
        }
    }
}

