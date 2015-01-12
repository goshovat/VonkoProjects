namespace SchoolSystem.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestSchool
    {
        private School school;

        [TestMethod]
        [TestInitialize]
        public void InstantiateSchool()
        {
            school = new School("Dimcho Debelyanov");
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void AddStudentAlreadyInSchool()
        {
            Student vonko = new Student("Vonko Mihov", school, Student.MIN_NUMBER_RANGE + 1);
            school.AddStudent(vonko);
        }
    }
}
