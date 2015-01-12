namespace Student
{
    using System;

    class StudentMain
    {
        static void Main()
        {
            //create some student and test Equals and operators == and !=
            Student vonko = new Student("Ivan", "Hristov", "Mihov", 
                Universities.TechnicalUniversity, Faculties.IT, Specialities.ComputerScience);
            Student goshko = new Student("Georgi", "Stanislavov", "Radev");
            Student goshkoCopy = new Student("Georgi", "Stanislavov", "Radev");
            Console.WriteLine(goshko.Equals(goshkoCopy));
            Console.WriteLine(goshko == goshkoCopy);

            goshko.Phone = "00359887555386";
            vonko.Email = "vonko@gmail.com";
            vonko.SSN = 453;

            Student nullStudent = null;

            Console.WriteLine(vonko);
            Console.WriteLine(goshko);
            Console.WriteLine(vonko.Equals(nullStudent));

            Console.WriteLine(nullStudent == null);
            Console.WriteLine(vonko != nullStudent);

            //test IClonable
            Student vonkoCloning = vonko.Clone() as Student;
            vonko.University = Universities.UNSS;
            Console.WriteLine(vonkoCloning.University);

            //test IComparable
            Student vonko2 = new Student("Ivan", "Hristov", "Zazkov");
            Student vonko3 = new Student("Ivan", "Hristov", "Zazkov");
            vonko2.SSN = 23;
            vonko3.SSN = 556;
            Console.WriteLine(vonko2.CompareTo(vonko3));

        }
    }
}
