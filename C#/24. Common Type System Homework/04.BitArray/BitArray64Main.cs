namespace BitArray64
{
    using System;

    class BitArray64Main
    {
        static void Main()
        {
            BitArray64 bitArray1 = new BitArray64(54);
            Console.WriteLine(bitArray1);
            Console.WriteLine(bitArray1[3]);
            bitArray1[3] = 1;
            Console.WriteLine(bitArray1);
            bitArray1[4] = 0;
            Console.WriteLine(bitArray1);

            bool areEqual = (new BitArray64(34)).Equals(new BitArray64(34)) 
                ? true : false;
            Console.WriteLine(areEqual);

            Console.WriteLine(new BitArray64(34) != new BitArray64(34));
        }
    }
}
