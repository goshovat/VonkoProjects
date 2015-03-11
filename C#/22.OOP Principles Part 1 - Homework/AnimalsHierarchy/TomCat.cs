namespace AnimalsHierarchy
{
    using System;

    public class Tomcat : Cat
    {
        public Tomcat(int age, string name, string sex)
            : base(age, name, sex)
        {
            if (sex == "female")
                throw new ArgumentException("Sex of tomcat can be only male.");
        }

        public override string MakeSound()
        {
            return string.Format("Myaaaa, where is the pussy, says {0}", base.Name);
        }

        public override string ToString()
        {
            return string.Format("Tomcat {0}.", base.Name);
        }
    }
}
