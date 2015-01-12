namespace AnimalsHierarchy
{
    using System;

    class Dog : Animal
    {
        public Dog(int age, string name, string sex)
            : base(age, name, sex) { }

        public override string MakeSound()
        {
            return string.Format("{0} says: Djaff djaff, baby!",
                base.Name);
        }

        public override string ToString()
        {
            return string.Format("Dog {0}.", base.Name);
        }
    }
}
