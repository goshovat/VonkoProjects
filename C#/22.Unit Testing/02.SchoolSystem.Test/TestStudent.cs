namespace SchoolSystem.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class TestStudent
    {
        private School school;
        private Student firstStudent;
        public const int MIN_NUMBER_RANGE = 10000;
        public const int MAX_NUMBER_RANGE = 99999;

        [TestMethod]
        [TestInitialize]
        public void InstantiateStudent()
        {
            school = new School("Petko Rosen");
            //add 30 students to the school
            firstStudent = new Student("Vonko", school, MIN_NUMBER_RANGE + 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateStudentNumberBelowRange()
        {
            Student wrongNumberStudent = new Student("Pesho", school, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]   
        public void CreateStudentNumberAboveRange()
        {
            Student wrongNumberStudent = new Student("Pesho", school, MAX_NUMBER_RANGE + 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void CreateStudentAlreadyInSchool()
        {
            Student newStudent1 = new Student("student0", school, MIN_NUMBER_RANGE);
            Student newStudent2 = new Student("Dragan", school, MIN_NUMBER_RANGE);
        }
    }
}
