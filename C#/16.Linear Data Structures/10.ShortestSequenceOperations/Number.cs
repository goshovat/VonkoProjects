using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestSequenceOperations
{
    public class Number
    {
        private int value;
        private Number previоus;

        public Number(int value)
            :this(value, null)
        {

        }

        public Number(int value, Number previous)
        {
            this.value = value;
            this.previоus = previous;
        }

        public int Value
        {
            get { return this.value; }
        }

        public Number Previous
        {
            get { return this.previоus; }
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
