using StudentGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractStudentsByEmail
{
    class ExtractStudentsByEmail
    {
        static void Main()
        {
            List<Student> students = new List<Student>() 
            {
                new Student("Ivan", "Penchev", 42412, "028815124", "pencho@gmail.com", 3),
                new Student("Mitko", "Genchev", 42413, "028815124", "pencho@abv.bg", 2),
                new Student("Stamen", "Penchev", 42414, "05681244", "pencho@gmail.com", 1),
                new Student("Tsvetko", "Ivanov", 42415, "0568815124", "pencho@abv.bg", 4),
                new Student("Genadi", "Penchev", 42416, "056881511251", "pencho@gmail.com", 2),
                new Student("Evgeni", "Penov", 42417, "052881512131", "pencho@gmail.com", 2),
                new Student("Misho", "Genov", 42418, "028815124", "pencho@gmail.com", 3),
                new Student("Vonko", "Penchev", 42419, "028815124", "pencho@abv.bg", 2),
                new Student("Conko", "Todorov", 424110, "028815124", "pencho@gmail.com", 2),
                new Student("Ronko", "Penchev", 424111, "028815124", "pencho@abv.bg", 3),
            };

            var sortedStudents = students.Where(s => s.Email.EndsWith("@abv.bg"));

            foreach (Student student in sortedStudents)
                Console.WriteLine(student);
        }
    }
}
