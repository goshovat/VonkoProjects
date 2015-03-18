namespace Person
{
    using System;

    public class Person
    {
        public Person(string name, int? age = null)
        {
            if (age < 0)
                throw new ApplicationException("The age cannot be negative.");

            this.Name = name;
            this.Age = age;
        }

        public string Name { get; private set; }
        public int? Age { get; private set; }

        public override string ToString()
        {
            return string.Format("Person -> Name: {0}, Age: {1}",
                this.Name, this.Age != null ? this.Age.ToString() : "Not Specified");
        }
    }
}
