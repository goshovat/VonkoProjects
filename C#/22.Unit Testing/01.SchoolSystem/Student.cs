namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private School school;
        private int number;
        public const int MIN_NUMBER_RANGE = 10000;
        public const int MAX_NUMBER_RANGE = 99999;

        public Student(string name, School school, int number) 
        {
            if (number < MIN_NUMBER_RANGE || number > MAX_NUMBER_RANGE)
                throw new ArgumentOutOfRangeException(string.Format(
                    "Error! Cannot create student with number: {0}", number));

            if (school.ContainsNumber(number))
                throw new ApplicationException(string.Format(
                    "The school {0} contains already a student with number {1}", school.Name, number));

            this.Name = name;
            this.school = School;
            this.number = number;

            school.AddStudent(this);
        }

        public int Number 
        {
            get { return this.number; }
        }
        public School School 
        {
            get {return this.school; }  
        }
        public string Name { get; set; }
    }
}
