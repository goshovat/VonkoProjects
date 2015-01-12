using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public abstract class Animal
    {
        protected string name;
        protected byte age;
        protected string gender;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                byte ageInByte = 0;
                if (!byte.TryParse(value.ToString(), out ageInByte))
                    throw new ApplicationException(string.Format("Invalid age: {0} for {1}.", 
                        value, this.Name));

                this.age = ageInByte;
            }
        }

        public string Gender
        {
            get 
            {
                return this.gender; 
            }
            set
            {
                if (value != "Male" && value != "Female")
                    throw new ApplicationException(string.Format("Error! Invalid gender '{0}' for {1}.", 
                        value, this.name));

                this.gender = value;
            }
        }

        public virtual string MakeSpecificSound()
        {
            return "I'm a fucking animal!";
        }

        public void PrintInfo()
        {
            Console.WriteLine("My name is: {0}", this.name);
            Console.WriteLine("My age is: {0}", this.age);
            Console.WriteLine("My gender is: {0}", this.gender);
            Console.WriteLine("I like to say: {0}", this.MakeSpecificSound());
            Console.WriteLine(new String('-', 50));
            Console.WriteLine();
        }
    }
}
