namespace AnimalsHierarchy
{
    using System;

    public class Kitten : Cat
    {
        public Kitten(int age, string name, string sex)
            : base(age, name, sex) 
        {
            if (sex == "male")
                throw new ArgumentException("Sex of kitten can be only female.");
        }

        public override string MakeSound()
        {
            return string.Format("Myaaaa, says {0}", base.Name);
        }

        public override string ToString()
        {
            return string.Format("Kitten {0}.", base.Name);
        }
    }
}
