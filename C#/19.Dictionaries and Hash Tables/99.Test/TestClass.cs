using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class TestClass
    {
        private string name;

        public TestClass(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}
