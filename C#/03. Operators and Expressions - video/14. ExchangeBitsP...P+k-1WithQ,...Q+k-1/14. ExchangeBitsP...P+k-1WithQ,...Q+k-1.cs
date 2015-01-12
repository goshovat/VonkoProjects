using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.ExchangeBitsP._._.P_k_1WithQ_._._.Q_k_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the number n:");
            string inputN = Console.ReadLine();
            uint n = Convert.ToUInt32(inputN);
            Console.WriteLine();

            Console.WriteLine("Enter the starting position of the first sequence(p):");
            string inputP = Console.ReadLine();
            int p = Convert.ToInt32(inputP);
            Console.WriteLine();

            Console.WriteLine("Enter the starting position the second sequence(q):");
            string inputQ = Console.ReadLine();
            int q = Convert.ToInt32(inputQ);
            Console.WriteLine();

            Console.WriteLine("Enter the length of the sequences(k):");
            string inputK = Console.ReadLine();
            int k = Convert.ToInt32(inputK);
            Console.WriteLine();

            string binary = Convert.ToString(n, 2).PadLeft(32, '0');
            Console.WriteLine("The number in binary is: {0}", binary);
            Console.WriteLine();

            uint mask = 1;

            for (int i = 0; i < k; i++)
            {
                mask *= 2;
            }

            mask -= 1;

            string maskBinary = Convert.ToString(mask, 2).PadLeft(32, '0');
            Console.WriteLine("The mask is: {0}",maskBinary);
            Console.WriteLine();

            mask <<= p;
            uint juniorBits = mask & n;
            string juniorBitsStr = Convert.ToString(juniorBits, 2).PadLeft(32, '0');
            Console.WriteLine("The junior bits are: {0}", juniorBitsStr);
            Console.WriteLine();
            //Now I will null the junior bits of the original number
            n &= (~juniorBits);
            juniorBits <<= (q-p);

            mask <<= (q-p);
            uint seniorBits = mask & n;
            string seniorBitsStr = Convert.ToString(seniorBits, 2).PadLeft(32, '0');
            Console.WriteLine("The senior bits are: {0}", seniorBitsStr);
            Console.WriteLine();
            //Now I will null the senior Bits
            n &= (~seniorBits);
            seniorBits >>= (q-p);

            n |= juniorBits;
            n |= seniorBits;

            Console.WriteLine("The new value of n is: {0}", n);
            Console.WriteLine();
            string binary2 = Convert.ToString(n, 2).PadLeft(32, '0');
            Console.WriteLine("The new value of n in binary is: {0}", binary2);
        }
    }
}
