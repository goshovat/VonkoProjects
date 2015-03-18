using StudentGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupByGroupNumber
{
    class GroupByGroupNumber
    {
        static void Main()
        {
            List<Student> students = new List<Student>() 
            {
                new Student("Ivan", "Penchev", 42412, "+3598815124", "pencho@gmail.com", 3),
                new Student("Mitko", "Genchev", 42413, "+3598815124", "pencho@gmail.com", 2),
                new Student("Stamen", "Penchev", 42414, "+35981244", "pencho@gmail.com", 1),
                new Student("Tsvetko", "Ivanov", 42415, "+3598815124", "pencho@gmail.com", 4),
                new Student("Genadi", "Penchev", 42416, "+359881511251", "pencho@gmail.com", 2),
                new Student("Evgeni", "Penov", 42417, "+359881512131", "pencho@gmail.com", 2),
                new Student("Misho", "Genov", 42418, "+3598815124", "pencho@gmail.com", 3),
                new Student("Vonko", "Penchev", 42419, "+3598815124", "pencho@gmail.com", 2),
                new Student("Conko", "Todorov", 424110, "+3598815124", "pencho@gmail.com", 2),
                new Student("Ronko", "Penchev", 424111, "+3598815124", "pencho@gmail.com", 3),
            };

            var groupedStudents = from student in students
                                    group student by student.GroupNumber into gr
                                    select gr;

            foreach (IGrouping<byte, Student> studentGroup in extractedStudents)
            {
                Console.WriteLine(studentGroup.Key);

                foreach (Student student in studentGroup)
                {
                    Console.WriteLine(student);
                }
                Console.WriteLine(new string('*', 23));
            }                           
        }
    }
}
