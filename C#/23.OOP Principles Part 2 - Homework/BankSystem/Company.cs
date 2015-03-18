namespace BankSystem
{
    using System;

    public class Company : Customer
    {
        public Company(string name)
            : base(name) { }

        public override string ToString()
        {
            return string.Format("Company: {0}", base.Name);
        }
    }
}
