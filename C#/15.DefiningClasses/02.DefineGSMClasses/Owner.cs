using System;

namespace GSM
{
    public class Owner
    {
        private string name;

        //constructors
        public Owner()
            :this("Unnamed")
        {
        }

        public Owner(string name) 
        {
            this.name = name;
        }

        //property
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
