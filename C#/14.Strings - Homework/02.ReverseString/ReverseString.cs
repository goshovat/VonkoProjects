using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        string originalString = "sample";
        string reversedString = ReverseStr(originalString);
        Console.WriteLine("Original string: {0}\nReversed string: {1}", originalString, reversedString);

    }

    static string ReverseStr(string originalString)
    {
        int len = originalString.Length;
        StringBuilder strBuild = new StringBuilder(len);

        for (int i = len - 1; i >= 0; i--)
        {
            strBuild.Append(originalString[i]);
        }
        return strBuild.ToString();
    }
}
