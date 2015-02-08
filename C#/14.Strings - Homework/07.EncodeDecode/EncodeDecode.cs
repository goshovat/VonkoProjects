using System;
using System.Text;

class EncodeDecode
{
    static void Main()
    {
        string text = "Nakov";
        string cypher = "ab";

        string result = CodeTextWithCypher(text, cypher);
        Console.WriteLine(result);
    }

    static string CodeTextWithCypher(string text, string cypher)
    {
        if (text == null)
            throw new ApplicationException("The value of the text you have given is null.");
        if (text == "")
            throw new ApplicationException("There is no text to encode.");
        if (cypher == null)
            throw new ApplicationException("The value of the cypher you have given is null.");

        bool hasCypher = true;
        if (cypher == "")
            hasCypher = false;

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            ushort currentCharCoded = 0;

            if (hasCypher)
                currentCharCoded = (ushort)(text[i] ^ cypher[i % cypher.Length]);
            else
                currentCharCoded = (ushort)text[i];

            result.Append(String.Format("\\u{0:x4}", currentCharCoded));
        }

        return result.ToString();
    }
}
