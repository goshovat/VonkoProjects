namespace AnimalsHierarchy
{
    using System;

    public class Frog : Animal
    {      
        public Frog(int age, string name, string sex)
            : base(age, name, sex) { }

        public override string MakeSound()
        {
            return string.Format("{0} says: Queeek, queek, baby!",
                base.Name);
        }

        public override string ToString()
        {
            return string.Format("Frog {0}.", base.Name);
        }
    }
}
