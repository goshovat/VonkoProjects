namespace FirstBeforeLast
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class FindStudentsMain
    {
        static void Main()
        {
            Student[] students = new Student[] 
            {
                new Student("Ivan", "Mihov", 23),
                new Student("Georgi", "Radev", 19),
                new Student("Cvetan", "Arabadjiev", 23),
                new Student("Stamat", "Perperikonov", 24),
                new Student("Prokopii", "Zismailov", 22)
            };

            //using lamda expression
            var result = students.
                Where(s => s.FirstName.CompareTo(s.LastName) < 0)
                .Select(s => s);
                             
            foreach(Student student in result)
                Console.WriteLine(student);

            Console.WriteLine();
            //using LINQ query
            var result1 = from student in students
                          where student.FirstName.CompareTo(student.LastName) < 0
                          select student;

            foreach(Student student in result1)
                Console.WriteLine(student);
        }
    }
}
