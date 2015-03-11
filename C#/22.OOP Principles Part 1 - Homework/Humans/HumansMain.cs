namespace Humans
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class HumansMain
    {
        static void Main()
        {
            HashSet<Student> students = new HashSet<Student>
            {
                new Student("Vonko", "Mihov", 3),
                new Student("Stoyan", "Barakov", 4),
                new Student("Mihail", "Petkov", 5),
                new Student("Dimityr", "Mihov", 2),
                new Student("Goshko", "Radev", 4),
                new Student("Chavdar", "Zazkov", 6),
                new Student("Chavdar", "Cecalov", 4),
                new Student("Mariika", "Caceva", 3),
                new Student("Ginka", "Minkova", 2),
                new Student("Petranka", "Evtimova", 5),
            };
            //sort students by grade with lambda expression and LINQ
            Console.WriteLine("Sort students by grade:");
            var sortedStudents1 = students.OrderBy(s => s.Grade);
            foreach(Student student in sortedStudents1)
                Console.WriteLine(student);

            Console.WriteLine();
            var sortedStudents2 = from student in students
                                  orderby student.Grade
                                  select student;
            foreach(Student student in sortedStudents2)
                Console.WriteLine(student);

            Console.WriteLine();
            Console.WriteLine("Sort workers by money per hour:");
            HashSet<Worker> workers = new HashSet<Worker> 
            {
                new Worker("Petran", "Voinov", 2340, 9),
                new Worker("Ramazan", "Jirinovski", 2000, 8),
                new Worker("Guslan", "Arnauzov", 3000, 9),
                new Worker("Yordan", "Donchev", 2500, 10),
                new Worker("Mihail", "Vendilov", 1500, 10),
                new Worker("Serdan", "Cvetkov", 3500, 9),
                new Worker("Ismail", "Denev", 4500, 6),
                new Worker("Serkiz", "Serkizov", 4500, 11),
                new Worker("Yasminka", "Peicheva", 6000, 4),
                new Worker("Mimeto", "Minkova", 2500, 9),
            };

            //sort workers by pay per hour with lambda expression and LINQ
            var sortedWorkers1 = workers.OrderByDescending(w => w.CalculateMoneyPerHour());
            foreach(Worker worker in sortedWorkers1)
                Console.WriteLine(worker);

            Console.WriteLine();
            var sortedWorkers2 = from worker in workers
                                 orderby worker.CalculateMoneyPerHour() descending
                                 select worker;
            foreach(Worker worker in sortedWorkers2)
                Console.WriteLine(worker);

            Console.WriteLine();
            Console.WriteLine("Sort all humans by first name and last name: ");
            //unite and sort by first name and last name
            HashSet<Human> humans = new HashSet<Human>(students);
            HashSet<Human> humanWorkers = new HashSet<Human>(workers);
            humans.UnionWith(humanWorkers);

            var sortedHumans1 = humans.OrderBy(h => h.FirstName).
                ThenBy(h => h.LastName);
            foreach(Human human in sortedHumans1)
                Console.WriteLine(human);

            Console.WriteLine();
            var sortedHumans2 = from human in humans
                                orderby human.FirstName, human.LastName
                                select human;
            foreach(Human human in sortedHumans2)
                Console.WriteLine(human);
        }
    }
}
