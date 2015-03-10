using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class Indices
{
    static void Main()
    {
        int count = int.Parse(Console.ReadLine());
        int[] numbers = new int[count];
        string numbersAsStringLine = Console.ReadLine();
        string[] numbersAsStrings = numbersAsStringLine.Split(' ');
        for (int i = 0; i < count; i++)
        {
            numbers[i] = int.Parse(numbersAsStrings[i]);
        }
        bool[] used = new bool[count]; 
        int index = 0;
        int loopStart = -1;
        StringBuilder result = new StringBuilder();

        while (true)
        {
            if (index < 0 || index >= count)
            {
                break;
            }

            if (used[index])
            {
                loopStart = index;
                break;
            }

            result.Append(index);
            result.Append(' ');
            used[index] = true;
            index = numbers[index];
        }

        if (loopStart >= 0)
        {
            int loopIndex = result.ToString().IndexOf((" " + loopStart + " ").ToString());

            if (loopIndex < 0)
                result.Insert(0, '(');
            else
                result[loopIndex] = '(';

            result[result.Length - 1] = ')';
        }
      
        Console.WriteLine(result.ToString().Trim());
    }
}
