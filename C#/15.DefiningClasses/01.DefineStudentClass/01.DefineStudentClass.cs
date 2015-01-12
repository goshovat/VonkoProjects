using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefineStudentClass
{
    class StudentClassMain
    {   
        static void Main()
        {
            Console.WriteLine("Print students' initial info:");
            StudentTest.PrintStudentsInfo();

            ChangeStudentsInfo();

            Console.WriteLine("Print students info after the data is changed:");
            StudentTest.PrintStudentsInfo();

            Console.WriteLine("Students created so far: {0}", Student.StudentsCreated);
        }

        private static void ChangeStudentsInfo()
        {
            StudentTest.StudentsList[0].University = Universities.VVMU;
            StudentTest.StudentsList[0].Speciality = Specialities.Navigation;
            StudentTest.StudentsList[0].Grade = 4;

            StudentTest.StudentsList[2].FirstName = "Georgi";
            StudentTest.StudentsList[2].MiddleName = "Stanislavov";
            StudentTest.StudentsList[2].FamilyName = "Radev";

            StudentTest.StudentsList[3].FamilyName = "Tavarisha";
        }
    }
}
