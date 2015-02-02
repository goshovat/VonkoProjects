using System;

class OnesAndZeroes
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        uint mask = 1;

        string[] one = { ".#.", "##.", ".#.", ".#.", "###"};
        string[] zero = { "###", "#.#", "#.#", "#.#", "###" };

        int[] bits = new int[16];
        //take the bits
        for (int i = 0; i < 16; i++)
        {
            if ((mask << (15 - i) & number) != 0)
            {
                bits[i] = 1;
            }
        }

        //print the result
        for (int row = 0; row < 5; row++)
        {
            for (int bit = 0; bit < 16; bit++)
            {
                if (bits[bit] == 1)
                    Console.Write(one[row]);
                else
                    Console.Write(zero[row]);

                if (bit < 15)
                    Console.Write('.');
            }
            Console.WriteLine();
        }
    }
}
