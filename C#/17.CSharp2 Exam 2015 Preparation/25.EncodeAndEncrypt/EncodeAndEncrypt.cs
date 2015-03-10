using System;
using System.Text;

class EncodeAndEncrypt
{
    private const char BASE_LETTER = 'A';

    static void Main()
    {
        string message = Console.ReadLine();
        string cypher = Console.ReadLine();

        string encryptedMsg = Encrypt(message, cypher);

        string encodedMsg = Encode(encryptedMsg, cypher);
        Console.WriteLine(encodedMsg + cypher.Length);
    }

    private static string Encrypt(string message, string cypher)
    {
        int maxLen = Math.Max(message.Length, cypher.Length);
        StringBuilder encryptedMsg = new StringBuilder(message);

        for (int i = 0; i < maxLen; i++)
        {
            char currentMsgSymbol = encryptedMsg[i % message.Length];
            char currentCypherSymbol = cypher[i % cypher.Length];

            int resultCode = ((currentMsgSymbol - BASE_LETTER) ^
                (currentCypherSymbol - BASE_LETTER)) + BASE_LETTER;
            char resultSymbol = (char)resultCode;

            encryptedMsg[i % encryptedMsg.Length] = resultSymbol;
        }
        return encryptedMsg.ToString();
    }

    private static string Encode(string encryptedMsg, string cypher)
    {
        StringBuilder encodedMsg = new StringBuilder();
        string textToEncode = encryptedMsg + cypher;
        char lastChar = textToEncode[0];
        int currentCount = 1;

        for (int i = 1; i < textToEncode.Length; i++)
        {
            if (textToEncode[i] == lastChar)
            {
                currentCount++;
            }
            else
            {
                if (currentCount > 2)
                {
                    encodedMsg.Append(currentCount);
                    encodedMsg.Append(lastChar);
                }
                else
                {
                    for (int j = 0; j < currentCount; j++)
                        encodedMsg.Append(lastChar);
                }
                lastChar = textToEncode[i];
                currentCount = 1;
            }      
        }

        if (currentCount > 2)
        {
            encodedMsg.Append(currentCount);
            encodedMsg.Append(lastChar);
        }
        else
        {
            for (int j = 0; j < currentCount; j++)
                encodedMsg.Append(lastChar);
        }

        return encodedMsg.ToString();
    }
}
