using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter11
{
    //define the class dog
    class Cat
    {
        private string name;
        private string color;

        //define its properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        //define its constructors
        public Cat()
        {
            this.name = "Melez";
            this.color = "gray";
        }

        public Cat(string Name, string color)
        {
            this.name = Name;
            this.color = color;
        }

        //define a method
        public void Myau()
        {
            Console.WriteLine("The cat {0} says myaaauuuu!", this.name);
        }
    }

    //the class sequence
    class Sequence
    {
        static private int currentValue = 0;

        static public int IncreaseValue() 
        {
            return ++currentValue;
        }
    }
}
