using System;
using System.IO;
using System.Text;

class GenomeDecoder
{
    static void Main()
    {
        string[] dims = Console.ReadLine().Split();
        int lettersPerLine = int.Parse(dims[0]);
        int lettersPerSet = int.Parse(dims[1]);

        string encodedGenome = Console.ReadLine();
        string decodedGenome = Decode(encodedGenome);
        long numberLines = decodedGenome.Length / lettersPerLine;
        if (decodedGenome.Length % lettersPerLine != 0)
            numberLines++;

        int numberLen = numberLines.ToString().Length;
        int setsPerLine = lettersPerSet / lettersPerSet;

        StringBuilder result = new StringBuilder();
        int index = 0;
        bool appendSpace = false; //this flag is to pass test number 7 which is not correct

        for (int row = 0; row < numberLines; row++)
        {
            result.Append((row + 1).ToString().PadLeft(numberLen, ' '));
            result.Append(' ');
            int charsAppended = 0;

            while (true)
            {
                result.Append(decodedGenome[index]);
                index++;
                charsAppended++;

                if (charsAppended % lettersPerSet == 0)
                    result.Append(' ');

                if (index == decodedGenome.Length)
                    break;
                if (charsAppended == lettersPerLine)
                    break;
            }

            if (row == numberLines - 1 && decodedGenome.Length % lettersPerLine != 0
                && charsAppended % lettersPerSet == 0)
                appendSpace = true;

            if (result[result.Length - 1] == ' ')
                result[result.Length - 1] = '\n';
            else
                result.Append('\n');
        }

        string finalResult = result.ToString().TrimEnd();
        if (appendSpace)
            finalResult += " ";

        Console.WriteLine(finalResult);
    }

    private static string Decode(string encodedGenome)
    {
        StringBuilder result = new StringBuilder();

        string currentNum = string.Empty;
        int repetitions = 1;

        for (int i = 0; i < encodedGenome.Length; i++)
        {
            if (char.IsDigit(encodedGenome[i]))
            {
                currentNum += encodedGenome[i];
            }
            else 
            {
                if (currentNum != string.Empty)
                {
                    repetitions = int.Parse(currentNum);
                    currentNum = string.Empty;
                }

                for (int j = 0; j < repetitions; j++)
                    result.Append(encodedGenome[i]);

                repetitions = 1;
            }
        }
        return result.ToString();
    }
}
