namespace BitArray64
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    //The indexing is from right to left
    public class BitArray64 : IEnumerable<int>
    {
        public const int ARRAY_LEN = 64;

        public BitArray64(ulong value)
        {
            this.Value = value;
        }

        public int this[int index] 
        {
            get
            {
                ulong bit = 1;
                ulong number = (bit << index & this.Value) >> index;
                return (int)number;
            }
            set
            {
                if (value != 0 && value != 1)
                    throw new ArgumentException("Invalid value for setting a bit.");

                //first clear the bit at that position
                ulong clearingMask = ~((ulong)1 << index);
                this.Value = this.Value & clearingMask;

                //set the new value
                this.Value = this.Value | ((ulong)value << index);
            }
        }

        public ulong Value { get; private set; }

        public static bool operator == (BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return Object.Equals(bitArray1, bitArray2);
        }
        public static bool operator != (BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return !Object.Equals(bitArray1, bitArray2);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            BitArray64 other = obj as BitArray64;

            if (other == null)
                return false;

            return this.Value.Equals(other.Value);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < ARRAY_LEN; i++)
            {
                yield return this[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = ARRAY_LEN - 1; i >= 0; i--)
                result.Append(this[i]);

            return result.ToString();
        }
    }
}
