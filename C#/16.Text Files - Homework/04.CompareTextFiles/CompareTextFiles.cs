using System;
using System.IO;
using System.Text;

class CompareTextFiles
{
    static void Main()
    {
        string pathFile1 = @"..\..\Text1.txt";
        string[] word1s = File.ReadAllLines(pathFile1, 
            Encoding.GetEncoding(1251));

        string pathFile2 = @"..\..\Text2.txt";
        string[] words2 = File.ReadAllLines(pathFile2,
            Encoding.GetEncoding(1251));

        if (word1s.Length != words2.Length)
            return;

        int sameLines = 0;
        int differentLines = 0;

        for (int i = 0; i < word1s.Length; i++)
        {
            if (word1s[i] != words2[i])
            {
                differentLines++;
            }
            else
            {
                sameLines++;
            }
        }

        Console.WriteLine("Same Lines:{0} Different Lines:{1}", sameLines, differentLines);
    }
}

