using System;
using System.Text;

class UnicodeCharacters
{
    static void Main()
    {
        string originalString = "Hi!";

        string result = TransformString(originalString);
        Console.WriteLine("The transofrmed string is:\n{0}", result);
    }

    static string TransformString(string originalString)
    {
        StringBuilder stringBuild = new StringBuilder();

        for (int i = 0; i < originalString.Length; i++)
        {
            stringBuild.Append(String.Format("\\u{0:x4}", (ushort)originalString[i]));
        }
        return stringBuild.ToString();
    }
}
