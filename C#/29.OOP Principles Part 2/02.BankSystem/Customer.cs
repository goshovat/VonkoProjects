namespace BankSystem
{
    using System;

    public abstract class Customer
    {
        public string Name { get; private set; }

        protected Customer(string name)
        {
            this.Name = name;
        }
    }
}
