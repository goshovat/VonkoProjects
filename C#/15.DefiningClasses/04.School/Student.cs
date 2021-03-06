﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        private string name;
        private int number;

        //the constructors
        public Student()
            :this("Unnamed", 0)
        {
        }

        public Student(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        //the properties
        public string Name
        {
            get { return this.name; }
        }

        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        //the methods
        public void ShowInfo()
        {
            Console.WriteLine("The name of the student is: {0}", this.name);
            Console.WriteLine("The number of the student is: {0}", this.number);
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
