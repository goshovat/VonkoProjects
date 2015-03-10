using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class VariableLengthCoding
{
    private static Dictionary<int, char> table = new Dictionary<int, char>();

    static void Main()
    {
        int[] encodedBytes = Console.ReadLine().Trim().Split(
            new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(n => int.Parse(n)).ToArray();

        int tableRows = int.Parse(Console.ReadLine());

        for (int i = 0; i < tableRows; i++)
        {
            string tableInput = Console.ReadLine().TrimEnd();
            char symbol = tableInput[0];
            int number = int.Parse(tableInput.Substring(1));
            table.Add(number, symbol);
        }

        StringBuilder encodedText = new StringBuilder();

        foreach(byte number in encodedBytes) 
        {
            string result = Convert.ToString(number, 2);
            encodedText.Append(result.PadLeft(8, '0'));
        }

        string[] encodedEntities = encodedText.ToString().Split(
            new char[] { '0' }, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder finalResult = new StringBuilder();
        foreach (string fragment in encodedEntities)
        {
            int count = fragment.Length;

            if (table.ContainsKey(count))
                finalResult.Append(table[count]);
            
        }

        Console.WriteLine(finalResult.ToString());
    }
}

