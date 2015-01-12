namespace BankSystem
{
    using System;

    public class Individual : Customer
    {
        public Individual(string name)
            : base(name) { }

        public override string ToString()
        {
            return string.Format("Individual: {0}", base.Name);
        }
    }
}
