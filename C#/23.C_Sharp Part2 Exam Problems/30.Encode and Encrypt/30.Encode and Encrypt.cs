namespace Encode_and_Encrypt
{
    using System;
    using System.Text;

    class Encode_and_Encrypt
    {
        private const int CHAR_A = 'A';

        static void Main()
        {
            string message = Console.ReadLine();
            string cypher = Console.ReadLine();

            string cypherMessage = Encrypt(message, cypher);
            string encodedEncriptMsg = Encode(cypherMessage + cypher);

            Console.WriteLine(encodedEncriptMsg + cypher.Length);
        }

        private static string Encrypt(string message, string cypher)
        {
            int longer = Math.Max(message.Length, cypher.Length);
            StringBuilder encryptedMsg = new StringBuilder(message);
            for (int i = 0; i < longer; i++)
            {
                int msgIndex = i % message.Length;
                int msgCode = encryptedMsg[msgIndex] - CHAR_A;

                int cypherIndex = i % cypher.Length;
                int cypherCode = cypher[cypherIndex] - CHAR_A;

                encryptedMsg[msgIndex] = (char)((msgCode ^ cypherCode) + CHAR_A);
            }
            return encryptedMsg.ToString();
        }

        private static string Encode(string concatMessage)
        {
            StringBuilder encodedMsg = new StringBuilder();
            StringBuilder numberBuffer = new StringBuilder();
            int curentCharCount = 1;
            char curentChar = default(char);
            for (int i = 0; i < concatMessage.Length; i++)
            {
                if (concatMessage[i] == curentChar)
                {
                    curentCharCount++;
                }
                else if (concatMessage[i] != curentChar)
                {
                    if (curentCharCount != 2 && curentCharCount != 1)
                    {
                        encodedMsg.Append(curentCharCount);
                        encodedMsg.Append(curentChar);
                    }
                    else if (curentCharCount == 2)
                    {
                        for (int j = 0; j < 2; j++)
                            encodedMsg.Append(curentChar);
                    }
                    else if (curentCharCount == 1 && i != 0)
                    {
                        encodedMsg.Append(curentChar);
                    }
                    curentCharCount = 1;
                    curentChar = concatMessage[i];
                }
            }
            if (curentCharCount == 1)
            {
                encodedMsg.Append(curentChar);
            }
            else if (curentCharCount == 2)
            {
                for (int j = 0; j < 2; j++)
                    encodedMsg.Append(curentChar);
            }
            else
            {
                encodedMsg.Append(curentCharCount);
                encodedMsg.Append(curentChar);
            }

            return encodedMsg.ToString();
        }
    }
}
