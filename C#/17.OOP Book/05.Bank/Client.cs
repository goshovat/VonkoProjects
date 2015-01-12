using System;

namespace Bank
{
    public abstract class Client
    {
        protected string name;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}
