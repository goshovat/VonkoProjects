using System;

namespace DefineStudentClass
{
    public class Student
    {
        static int studentsCreated;

        //initialize the fields of the student class
        private string firstName;
        private string middleName;
        private string familyName;
        private int grade;
        private Universities university;
        private Specialities speciality;
        private string email;
        private string phoneNumber;

        //create constructors
        public Student()
            :this(null, null, null)
        {
            
        }

        public Student(string firstName, string middleName, string lastName)
            :this (firstName, middleName, lastName, null, null)
        {

        }

        public Student(string firstName, string middleName, string lastName,
            string email, string phoneNumber)
            :this (firstName, middleName, lastName, 0, 0, 0, email, phoneNumber)
        {

        }

        public Student(Universities university, Specialities speciality, int grade)
            :this(null, null, null, university, speciality, 0,
            null, null)
        {

        }

        public Student(string firstName, string middleName, string familyName,
            Universities university, Specialities speciality, int grade, string email, string phoneNumber)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.familyName = familyName;
            this.university = university;
            this.speciality = speciality;
            this.grade = grade;
            this.email = email;
            this.phoneNumber = phoneNumber;
           
            studentsCreated++;
        }

        //define properties of the class
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            set { this.middleName = value; }
        }

        public string FamilyName
        {
            get { return this.familyName; }
            set { this.familyName = value; }
        }

        public Universities University
        {
            get { return this.university; }
            set { this.university = value; }
        }

        public Specialities Speciality
        {
            get { return this.speciality; }
            set { this.speciality = value; }
        }

        public int Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        //define the static property giving acess to the created students
        public static int StudentsCreated
        {
            get { return Student.studentsCreated; }
        }

        //instance methods of the class
        public void PrintInfo()
        {
            Console.WriteLine("The student's names are: {0} {1} {2}", 
                this.firstName, this.middleName, this.familyName);

            Console.WriteLine("The student is {0} grade in {1} university, speciality {2}", 
                this.grade, this.university, this.speciality);

            Console.WriteLine("The student's phone number is: {0}", this.phoneNumber);

            Console.WriteLine("The student's email is: {0}", this.email);

            Console.WriteLine();
        }
    }
}
