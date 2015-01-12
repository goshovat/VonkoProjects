using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecodeAndDecrypt
{
    class Program
    {
        const char BaseLetter = 'A';

        static void Main(string[] args)
        {
            string encodedencriptedMessage = Console.ReadLine();

            int cypherLength = GetMessageCypherLength(encodedencriptedMessage);
            int cypherLengthNumberSubstringLength = cypherLength.ToString().Length;

            string encodedencriptedMessageAndCypher = encodedencriptedMessage.Substring(0, encodedencriptedMessage.Length - cypherLengthNumberSubstringLength);

            string encriptedMessageAndCypher = Decode(encodedencriptedMessageAndCypher);

            string cypher = encriptedMessageAndCypher.Substring(encriptedMessageAndCypher.Length - cypherLength);
            string encriptedMessage = encriptedMessageAndCypher.Substring(0, encriptedMessageAndCypher.Length - cypherLength);

            string message = Decrypt(encriptedMessage, cypher);

            Console.WriteLine(message);
        }

        static int GetMessageCypherLength(string encodedencriptedMessage)
        {
            int lengthSubstringStartIndex = -1;
            for (int index = encodedencriptedMessage.Length - 1; index > 0; index--)
            {
                char currentSymbol = encodedencriptedMessage[index];
                if (!Char.IsDigit(currentSymbol))
                {
                    lengthSubstringStartIndex = index + 1;
                    break;
                }
            }

            string lengthSubstring = encodedencriptedMessage.Substring(lengthSubstringStartIndex);
            int cypherLength = int.Parse(lengthSubstring);

            return cypherLength;
        }

        static string Decode(string encodedText)
        {
            StringBuilder decodedTextBuilder = new StringBuilder();

            int index = 0;
            int currentNumber = 0;
            while (index < encodedText.Length)
            {
                if (Char.IsDigit(encodedText[index]))
                {
                    currentNumber = encodedText[index] - '0' + (currentNumber * 10);
                }
                else
                {
                    char currentSymbol = encodedText[index];
                    if (currentNumber > 0)
                    {
                        decodedTextBuilder.Append(new string(currentSymbol, currentNumber));
                        currentNumber = 0;
                    }
                    else
                    {
                        decodedTextBuilder.Append(currentSymbol);
                    }
                }

                index++;
            }

            return decodedTextBuilder.ToString();
        }

        static string Decrypt(string encriptedMessage, string cypher)
        {
            StringBuilder messageBuilder = new StringBuilder(encriptedMessage);

            int longer = Math.Max(encriptedMessage.Length, cypher.Length);

            for (int index = 0; index < longer; index++)
            {
                int indexInencriptedMessage = index % encriptedMessage.Length;
                int indexInCypher = index % cypher.Length;

                int charInencriptedMessageOffset = messageBuilder[indexInencriptedMessage] - BaseLetter;
                int charInCypherOffset = cypher[indexInCypher] - BaseLetter;

                messageBuilder[indexInencriptedMessage] = (char)(BaseLetter + (charInencriptedMessageOffset ^ charInCypherOffset));
            }

            return messageBuilder.ToString();
        }
    }
}
