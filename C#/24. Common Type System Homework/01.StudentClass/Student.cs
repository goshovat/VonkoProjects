namespace Student
{
    using System;
    using System.Text.RegularExpressions;

    public class Student : ICloneable, IComparable<Student>
    {
        private int ssn;
        private string phone;
        private string email;

        public Student
            (string firstName, string middleName, string lastName, 
            Universities university, Faculties faculty, Specialities speciality)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.University = university;
            this.Faculty = faculty;
            this.Speciality = speciality;
        }

        public Student(string firstName, string middleName, string lastName)
            :this(firstName, middleName, lastName, default(Universities), 
            default(Faculties), default(Specialities))
        {
        }

        public string FirstName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public int SSN 
        {
            get { return this.ssn; }
            set 
            {
                if (value < 0)
                    throw new ArgumentException("The SSN cannot be a negative number.");

                   this.ssn = value;
            }
        }
        public string Address { get; set; }
        public string Phone 
        { 
            get {return this.phone;}
            set
            {
                if (value != null && !Regex.IsMatch(value, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$"))
                    throw new ArgumentException("The phone number is not valid.");

                this.phone = value;
            }
        }
        public string Email 
        {
            get { return this.email; }
            set
            {
                if (value != null && !Regex.IsMatch(value, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    throw new ArgumentException("The email is not valid.");

                this.email = value;
            } 
        }
        public Universities University { get; set; }
        public Faculties Faculty { get; set; }
        public Specialities Speciality { get; set; }

        public static bool operator == (Student student1, Student student2) 
        {
            return Object.Equals(student1, student2);
        }
        public static bool operator != (Student student1, Student student2)
        {
            return !Object.Equals(student1, student2);
        }

        public override bool Equals(object obj)
        {
            Student other = obj as Student;

            if (Object.Equals(other, null))
                return Student.Equals(this, other);

            if (this.FirstName != other.FirstName)
                return false;
            if (this.MiddleName != other.MiddleName)
                return false;
            if (this.LastName != other.LastName)
                return false;
            if (this.SSN != other.SSN)
                return false;
            if (this.Address != other.Address)
                return false;
            if (this.Phone != other.Phone)
                return false;
            if (this.Email != other.Email)
                return false;
            if (this.University != other.University)
                return false;
            if (this.Faculty != other.Faculty)
                return false;
            if (this.Speciality != other.Speciality)
                return false;

            return true;
        }
        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() + this.MiddleName.GetHashCode() + this.LastName.GetHashCode()
                + this.SSN.GetHashCode() + this.Address.GetHashCode() + this.Phone.GetHashCode() + this.Email.GetHashCode()
                + this.University.GetHashCode() + this.Faculty.GetHashCode() + this.Speciality.GetHashCode();
        }
        public object Clone()
        {
            Student result = new Student(this.FirstName, this.MiddleName, this.LastName)
            {
                //enums are value types and strings are immutable so we can copy them like value types
                SSN = this.SSN,
                Address = this.Address,
                Phone = this.Phone,
                Email = this.Email,
                University = this.University,
                Faculty = this.Faculty,
                Speciality = this.Speciality
            };

            return result as Object;
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName != other.FirstName)
                return this.FirstName.CompareTo(other.FirstName);
            if (this.MiddleName != other.MiddleName)
                return this.MiddleName.CompareTo(other.MiddleName);
            if (this.LastName != other.LastName)
                return this.LastName.CompareTo(other.LastName);
            if (this.SSN != other.SSN)
                return this.SSN.CompareTo(other.SSN); //the comparison will be in increasing order because SSN is int

            //the students are equal according to our criteria
            return 0;
        }

        public override string ToString()
        {
            return string.Format("Student -> FirstName: {0}, MiddleName:{1}, LastName: {2}\n", this.FirstName, this.MiddleName, this.LastName) +
                string.Format("SSN: {0}, Address: {1}, Phone: {2}, Email: {3}\n", this.SSN, this.Address, this.Phone, this.Email) +
                string.Format("University: {0}, Faculty: {1}, Speciality: {2}\n", this.University, this.Faculty, this.Speciality);
        }
    }
}
