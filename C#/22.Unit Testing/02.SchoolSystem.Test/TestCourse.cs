namespace SchoolSystem.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestCourse
    {
        private Course course;
        private School school;

        [TestMethod]
        [TestInitialize]
        public void InitializeCourse()
        {
            school = new School("SoftUniversity");
            course = new Course("C# baby");
        }

        [TestMethod]
        public void AddTwentyNineStudents()
        {
            for (int i = 0; i < 29; i++)
            {
                Student newStudent = new Student("student" + i, 
                    school, Student.MIN_NUMBER_RANGE + i);
                course.AddStudent(newStudent);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddStudentAlreadyInsideCourse()
        {
            Student firstCourseStudent = new Student("Cvetan", school, 
                Student.MIN_NUMBER_RANGE + 20);

            course.AddStudent(firstCourseStudent);
            //here expect the exception
            course.AddStudent(firstCourseStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AddMoreThanTwentyNineStudents()
        {
            for (int i = 0; i < 30; i++)
            {
                Student newStudent = new Student("student" + i, school, 
                    Student.MIN_NUMBER_RANGE + i);
                course.AddStudent(newStudent);
            }
        }

        [TestMethod]
        public void RemoveStudent()
        {
            Student firstCourseStudent = new Student("Cvetan", school, 
                Student.MIN_NUMBER_RANGE + 20);

            course.AddStudent(firstCourseStudent);
            course.RemoveStudent(firstCourseStudent);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void RemoveStudentWhoIsNotInside()
        {
            Student newStudent = new Student("Pepi Sexa", school, 
                Student.MIN_NUMBER_RANGE + 10);

            course.RemoveStudent(newStudent);
        }
    }
}
