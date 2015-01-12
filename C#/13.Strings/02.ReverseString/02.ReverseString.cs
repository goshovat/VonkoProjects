using System;
using System.Text;

class ReverseString
{
    static void Main()
    {
        string originalString = "introduction";

        try
        {
            string reversedString = ReverseStr(originalString);
            Console.WriteLine("Original string: {0}\nReversed string: {1}", originalString, reversedString);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error occured during program execution. Details:\n{0}", e.Message);
        }       
    }

    static string ReverseStr(string originalString)
    {
        try
        {
            int len = originalString.Length;
            StringBuilder strBuild = new StringBuilder(len);

            for (int i = len - 1; i >= 0; i--)
            {
                strBuild.Append(originalString[i]);
            }

            return strBuild.ToString();
        }
        catch (NullReferenceException nullRefExc)
        {
            Console.WriteLine("Error! You gave a string with null value! Details:\n{0}", nullRefExc.Message);
            return "";
        }       
    }
}
