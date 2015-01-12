namespace StudentsOfGIvenAge
{
    using System;
    using System.Linq;
    using FindStudents;

    class Program
    {
        static void Main()
        {
            Student[] students = new Student[] 
            {
                new Student("Ivan", "Mihov", 17),
                new Student("Georgi", "Radev", 19),
                new Student("Cvetan", "Arabadjiev", 23),
                new Student("Stamat", "Perperikonov", 24),
                new Student("Prokopii", "Zismailov", 25)
            };

            //using lambda expression
            var selectedStudents = students
                .Where(s => s.Age < 24 && s.Age > 18)
                .Select(s => new {FirstName = s.FirstName, LastName = s.LastName});

            foreach(var student in selectedStudents)
                Console.WriteLine(student);

            Console.WriteLine();
            //using linq query
            var selectedStudents1 = from student in students
                                    where student.Age > 18 && student.Age < 24
                                    select new { FirstName = student.FirstName, LastName = student.LastName };

            foreach (var student in selectedStudents1)
                Console.WriteLine(student);
        }
    }
}
