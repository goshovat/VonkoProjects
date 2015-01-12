using System;
using System.Collections.Generic;

namespace SchoolModel
{
    public class Human
    {
        protected string name;

        public Human()
            :this("Unknown")
        {
        }

        public Human(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }
    }
}
