namespace SortStudents
{
    using System;
    using System.Linq;
    using FindStudents;


    class SortStudents
    {
        static void Main()
        {
            Student[] students = new Student[] 
            {
                new Student("Ivan", "Mihov", 17),
                new Student("Ivan", "Petrov", 17),
                new Student("Georgi", "Radev", 19),
                new Student("Cvetan", "Arabadjiev", 23),
                new Student("Cvetan", "Azisov", 23),
                new Student("Stamat", "Perperikonov", 24),
                new Student("Prokopii", "Zismailov", 25)
            };

            //using extension methods and lambda expression
            var sortedStudents = students
                .OrderBy(s => s.FirstName)
                .ThenBy(s => s.LastName);

            foreach (Student student in sortedStudents)
                Console.WriteLine(student);

            Console.WriteLine();
            //using LINQ query
            var sortedStudents1 = from student in students
                                  orderby student.FirstName, student.LastName
                                  select student;

            foreach (Student student in sortedStudents1)
                Console.WriteLine(student);                   
        }
    }
}
