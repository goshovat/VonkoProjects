namespace AnimalsHierarchy
{
    using System;

    public abstract class Animal : ISound
    {
        public int Age { get; private set; }
        public string Name { get; private set; }
        public string Sex { get; private set; }

        protected Animal(int age, string name, string sex)
        {
            if (age < 0)
                throw new ArgumentException("The age cannot be negative.");

            if (sex != "male" && sex != "female")
                throw new ArgumentException("Invalide sex.");

            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public abstract string MakeSound();
    }
}
