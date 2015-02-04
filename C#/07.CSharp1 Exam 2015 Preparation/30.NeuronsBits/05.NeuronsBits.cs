using System;

class NeuronsBits
{
    static void Main()
    {
        const uint BITT = (uint)1;

        while (true)
        {
            string inputStr = Console.ReadLine();
            if (inputStr == "-1")
            {
                break;
            }

            uint thisRow = uint.Parse(inputStr);

            uint output = 0;

            bool isInside = false;

            int oneBitSequence = 0;
          
            for (int i = 0; i < 32; ++i)
            {
                uint mask = (BITT << i);

                if ((mask & thisRow) == 0)
                {
                    if (isInside)
                        output |= mask;
                    continue;
                }
                else
                {
                    oneBitSequence++;
                    isInside = !isInside;
                    while (i < 32 && ((thisRow & (BITT << i)) >> i == 1))
                    {
                        i++;
                    }
                    // back off one step,
                    // the for loop will increment the counter anyway
                    i--;
                }
            }

            if (oneBitSequence != 2)
            {
                output = 0;
            }

            Console.WriteLine(output);
        }
    }
}

