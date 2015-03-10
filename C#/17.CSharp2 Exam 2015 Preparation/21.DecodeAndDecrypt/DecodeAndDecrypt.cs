using System;
using System.Collections.Generic;
using System.Text;

class DecodeAndDecrypt
{
    private const char BASE_LETTER = 'A';

    static void Main()
    {
        string input= Console.ReadLine();

        int cyperLen = ExtractCypherLen(input);
        int cypherLenStr = cyperLen.ToString().Length;
        string msgAndCYpher = input.Substring
            (0, input.Length - cypherLenStr);

        string decodedMsgAndCypher = Decode(msgAndCYpher);

        string decodedMsg = decodedMsgAndCypher.Substring(
            0, decodedMsgAndCypher.Length - cyperLen);
        string cypher = decodedMsgAndCypher.Substring(
            decodedMsgAndCypher.Length - cyperLen, cyperLen);

        
        string decryptedMsg = Decrypt(decodedMsg, cypher);
        Console.WriteLine(decryptedMsg);
    }

    private static int ExtractCypherLen(string input)
    {
        StringBuilder cypherLen = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (char.IsDigit(input[i]))
                cypherLen.Insert(0, input[i]);
            else
                break;
        }
        return int.Parse(cypherLen.ToString());
    }

    private static string Decode(string encodedMsg)
    {
        StringBuilder decodedMsg = new StringBuilder();
        string currentDigit = "";

        for (int i = 0; i < encodedMsg.Length; i++)
        {
            if (char.IsDigit(encodedMsg[i]))
            {
                currentDigit += encodedMsg[i];
            }
            else
            {
                if (currentDigit != "")
                {
                    int digit = int.Parse(currentDigit);

                    if (digit > 2)
                    {
                        for (int symbol = 0; symbol < digit; symbol++)
                            decodedMsg.Append(encodedMsg[i]);
                    }
                    else
                    {
                        decodedMsg.Append(currentDigit);
                        decodedMsg.Append(encodedMsg[i]);
                    }

                    currentDigit = "";
                }
                else
                {
                    decodedMsg.Append(encodedMsg[i]);
                }
            }
        }

        return decodedMsg.ToString();
    }

    private static string Decrypt(string decodedMsg, string cypher)
    {
        StringBuilder decryptedMsg = new StringBuilder(decodedMsg);
        int longer = Math.Max(decodedMsg.Length, cypher.Length);

        for (int i = 0; i < longer; i++)
        {
            int msgIndex = i % decryptedMsg.Length;
            int cypherIndex = i % cypher.Length;

            char msgChar = decryptedMsg[msgIndex];
            char cyperhChar = cypher[cypherIndex];

            int msgCode = msgChar - BASE_LETTER;
            int cypherCode = cyperhChar - BASE_LETTER;
            int resultCode = (msgCode ^ cypherCode) + BASE_LETTER;

            decryptedMsg[msgIndex] = (char)resultCode;
        }

        return decryptedMsg.ToString();
    }
}
