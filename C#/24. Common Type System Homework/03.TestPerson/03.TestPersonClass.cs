namespace TestPerson
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Person;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreatePersonWithAge()
        {
            string personName = "Vonko";
            int personAge = 34;
            Person person = new Person(personName, personAge);

            if (person.ToString() !=
                string.Format("Person -> Name: {0}, Age: {1}", personName, personAge))
                throw new ApplicationException("ToString() for person with age is not working correctly");
        }

        [TestMethod]
        public void CreatePersonWithoutAge()
        {
            string personName = "Vonko";
            Person person = new Person(personName);

            if (person.ToString() !=
                string.Format("Person -> Name: {0}, Age: {1}", personName, "Not Specified"))
                throw new ApplicationException("ToString() for person without age is not working correctly");
        }
    }
}
