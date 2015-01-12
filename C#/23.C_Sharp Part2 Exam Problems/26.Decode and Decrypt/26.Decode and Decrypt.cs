namespace Decode_and_Decrypt
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    class Decode_and_Decrypt
    {
        private static Dictionary<char, int> letterCodes = new Dictionary<char, int>
        {
            {'A', 0}, {'B', 1}, {'C', 2}, {'D', 3}, {'E', 4}, {'F', 5},	{'G', 6}, {'H', 7},	{'I', 8}, {'J', 9},	
            {'K', 10}, {'L', 11}, {'M', 12}, {'N', 13}, {'O', 14},	{'P', 15}, {'Q', 16}, {'R', 17}, {'S',18}, 
            {'T', 19}, {'U', 20}, {'V', 21},  {'W', 22}, {'X', 23},	{'Y',24}, {'Z', 25}
        };
        private const char BASE_LETTER = 'A';

        static void Main()
        {
            string input = Console.ReadLine();
            int cypherLen = ExtractCypherLen(ref input);
            string decodedMessage = Decode(input);

            string encriptedMessage = decodedMessage.Substring(0, decodedMessage.Length - cypherLen);
            string cypher = decodedMessage.Substring(encriptedMessage.Length, cypherLen);

            string decriptedMessage = Decript(encriptedMessage, cypher);
            Console.WriteLine(decriptedMessage);
        }

        private static int ExtractCypherLen(ref string input)
        {
            int cypherLen = 0;
            StringBuilder numberBuffer = new StringBuilder();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(input[i]))
                {
                    numberBuffer.Insert(0, input[i]);
                }
                else
                {
                    cypherLen = int.Parse(numberBuffer.ToString());
                    numberBuffer.Clear();
                    input = input.Substring(0, i + 1);
                    break;
                }
            }
            return cypherLen;
        }

        private static string Decode(string input)
        {
            StringBuilder decodedMsg = new StringBuilder();
            StringBuilder numberBuffer = new StringBuilder();
            bool insideLoop = false;
            for (int i = 0; i < input.Length; i++)
            {
                if (!insideLoop && !char.IsDigit(input[i]))
                {
                    decodedMsg.Append(input[i]);
                }
                
                if (char.IsDigit(input[i]))
                {
                    insideLoop = true;
                    numberBuffer.Append(input[i]);
                }
                
                if (insideLoop && !char.IsDigit(input[i]))
                {
                    int loop = int.Parse(numberBuffer.ToString());
                    numberBuffer.Clear();
                    for (int j = 0; j < loop; j++)
                    {
                        decodedMsg.Append(input[i]);
                    }
                    insideLoop = false;
                }
            }
            return decodedMsg.ToString();
        }

        private static string Decript(string encriptedMessage, string cypher)
        {
            StringBuilder messageBuilder = new StringBuilder(encriptedMessage);
            int longer = Math.Max(encriptedMessage.Length, cypher.Length);

            for (int index = 0; index < longer; index++)
            {
                int indexEncripted = index % encriptedMessage.Length;
                int indexCypher = index % cypher.Length;

                int encriptedCode = messageBuilder[indexEncripted] - BASE_LETTER;
                int cypherCode = cypher[indexCypher] - BASE_LETTER;

                messageBuilder[indexEncripted] = (char)(BASE_LETTER + (encriptedCode ^ cypherCode));
            }
            return messageBuilder.ToString();
        }
    }
}
