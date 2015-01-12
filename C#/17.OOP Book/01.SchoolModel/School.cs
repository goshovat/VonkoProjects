using System;
using System.Collections.Generic;

namespace SchoolModel
{
    class School
    {
        private static School instance;
        private string name;
        private List<Klass> klasses;
        private List<Teacher> teachers;

        //the static constructor that will be called the first time
        //a property or method of the class is called
        static School()
        {
            School.instance = new School();
        }

        //the private constructor that will be called only once by the static cosntructor
        private School()
        {
            this.klasses = new List<Klass>();
            this.teachers = new List<Teacher>();
        }

        //the properties of the class
        public static School Instance
        {
            get { return School.instance; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        //methods for the klasses
        public void AddKlass(Klass klass)
        {
            if (this.klasses.Contains(klass))
                throw new ApplicationException(string.Join("Error! The klass {0} is already in the school!",
                    klass.ID));

            this.klasses.Add(klass);
        }

        public void RemoveKlass(Klass klass)
        {
            if (!this.klasses.Contains(klass))
                throw new ApplicationException(string.Join("Error! The klass {0} is NOT in the school!",
                    klass.ID));

            this.klasses.Remove(klass);
        }

        public void ShowKlasses()
        {
            Console.WriteLine("The klasses in {0} school are: ", this.name);
            foreach (Klass klass in this.klasses)
            {
                Console.WriteLine(klass.ID);
            }
            Console.WriteLine();
        }

        //methods for the teachers
        public void HireTeacher(Teacher teacher)
        {
            if (teachers.Contains(teacher))
                throw new ApplicationException(string.Join("Error! The teacher {0} is already working in the school.",
                    teacher.Name));

            this.teachers.Add(teacher);
        }

        public void FireTeacher(Teacher teacher)
        {
            if (!teachers.Contains(teacher))
                throw new ApplicationException(string.Join("Error! The teacher {0} is NOT working in the school.",
                    teacher.Name));

            this.teachers.Remove(teacher);
        }

        public void ShowTeachers()
        {
            Console.WriteLine("The teachers in {0} school are: ", this.name);
            foreach (Teacher teacher in this.teachers)
            {
                Console.WriteLine(teacher.Name);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}
