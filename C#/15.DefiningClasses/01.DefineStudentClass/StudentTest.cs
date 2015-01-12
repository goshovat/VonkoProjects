using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefineStudentClass
{
    public static class StudentTest
    {
        private static List<Student> studentsList = new List<Student>();

        //the constructor of this class will create a few students on the first accessing of the class
        static StudentTest()
        {
            CreateStudents();
        }

        //these methods will perform the tests
        private static void CreateStudents()
        {
            Student vonko = new Student("Vonko", "Hristov", "Mihov");
            StudentTest.studentsList.Add(vonko);

            Student unnamed = new Student();
            StudentTest.studentsList.Add(unnamed);

            Student goshko = new Student(Universities.TUSofia, Specialities.ComputerScience, 0);
            StudentTest.studentsList.Add(goshko);

            Student sashko = new Student("Aleksandar", "Dimitrov", "Hristov", Universities.VINSA,
                Specialities.Managment, 3, "sashkoTeKlati@abv.bg", "+359884512421");
            StudentTest.studentsList.Add(sashko);
        }

        public static List<Student> StudentsList 
        {
            get { return StudentTest.studentsList; }
        }

        //this method will print all the info of all students given to him
        public static void PrintStudentsInfo()
        {
            foreach (Student student in StudentTest.studentsList)
            {
                student.PrintInfo();
            }
        }
    }
}
