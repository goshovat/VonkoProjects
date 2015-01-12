namespace Humans
{
    using System;

    public abstract class Human
    {
        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}
