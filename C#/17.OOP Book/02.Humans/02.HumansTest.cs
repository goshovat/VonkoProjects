using System;
using System.Collections.Generic;

namespace Humans
{
    class HumansTest
    {
        static void Main()
        {
            try
            {
                //create a student vonko and give him mark
                Student vonko = new Student("Vonko", "Mihov");
                Console.WriteLine("The mark of {0} is {1}", vonko.GivenName, vonko.Mark);

                //create workers and assign them worked hours and total earnings
                Worker tomcho, mincho, strahil, stamat, evlogi, cenko;
                CreateWorkersWithEarnings(out tomcho, out mincho, out strahil,
                    out stamat, out evlogi, out cenko);

                //create students and assign them marks
                Student gosho, mimeto, cvetka, stoyanka, penka;
                CreateStudentsWithMarks(out gosho, out mimeto, out cvetka, out penka, out stoyanka);

                //sort the students in increasing order by their marks
                List<Human> students = AddHumansToList((Human)vonko, (Human)gosho,
                    (Human)mimeto, (Human)cvetka, (Human)penka);
                List<Human> sortedStudents = SortStudents(students);
                PrintPersonsInfo(sortedStudents);

                //sort the workers in decreasing order by their Salary
                List<Human> workers = AddHumansToList((Human)tomcho, (Human)mincho, (Human)strahil,
                    (Human)stamat, (Human)evlogi, (Human)cenko);
                List<Human> sortedWorkers = SortWorkers(workers);
                PrintPersonsInfo(sortedWorkers);
            }
            catch (InvalidCastException invalidCast)
            {
                Console.WriteLine(invalidCast.Message);
                Console.WriteLine(invalidCast.StackTrace);
            }
            catch (NullReferenceException nullRef)
            {
                Console.WriteLine(nullRef.Message);
                Console.WriteLine(nullRef.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void CreateWorkersWithEarnings(out Worker tomcho, out Worker mincho, out Worker strahil, out Worker stamat,
            out Worker evlogi, out Worker cenko)
        {
            tomcho = new Worker("Tomcho", "Tomov");
            tomcho.TotalEarnings = 19;
            tomcho.HoursWorked = 3;

            mincho = new Worker("Mincho", "Minkov");
            mincho.TotalEarnings = 25;
            mincho.HoursWorked = 2.5;

            strahil = new Worker("Strahil", "Tsenkov");
            strahil.TotalEarnings = 21;
            strahil.HoursWorked = 6;

            stamat = new Worker("Stamat", "Stamchov");
            stamat.TotalEarnings = 35;
            stamat.HoursWorked = 3.5;

            evlogi = new Worker("Evlogi", "Peichev");
            evlogi.TotalEarnings = 28;
            evlogi.HoursWorked = 1.8;

            cenko = new Worker("Cenko", "Minkov");
            cenko.TotalEarnings = 18;
            cenko.HoursWorked = 2.5;
        }

        private static void CreateStudentsWithMarks(out Student gosho, out Student mimeto,
            out Student cvetka, out Student penka, out Student stoyanka)
        {
            gosho = new Student("Goshko", "Radev");
            gosho.Mark = 5;

            mimeto = new Student("Mariana", "Todorova");
            mimeto.Mark = 6;

            cvetka = new Student("Cvetka", "Brutkova");
            cvetka.Mark = 4;

            penka = new Student("Penka", "Shavrantata");
            penka.Mark = 3;

            stoyanka = new Student("Stoyanka", "Firkata");
            stoyanka.Mark = 6;//makes nice firki
        }

        private static List<Human> AddHumansToList(params Human[] givenHumans)
        {
            List<Human> humans = new List<Human>();

            foreach (Human human in givenHumans)
            {
                humans.Add(human);
            }

            return humans;
        }

        private static List<Human> SortStudents(List<Human> students)
        {
            bool hasSwapped = true;

            while (hasSwapped)
            {
                hasSwapped = false;

                for (int i = 0; i < students.Count - 1; i++)
                {
                    if (students[i].CompareTo(students[i + 1]) > 0)
                    {
                        Swap<Human>(students, i, i+ 1);
                        hasSwapped = true;
                    }
                }
            }

            return students;
        }

        private static List<Human> SortWorkers(List<Human> workers)
        {
            bool hasSwapped = true;

            while (hasSwapped)
            {
                hasSwapped = false;

                for (int i = 0; i < workers.Count - 1; i++)
                {
                    if (workers[i].CompareTo(workers[i + 1]) < 0)
                    {
                        Swap(workers, i, i + 1);
                        hasSwapped = true;
                    }
                }
            }

            return workers;
        }

        private static void Swap<T>(List<T> objects, int index1, int index2)
        {
            T tempObject = objects[index1];
            objects[index1] = objects[index2];
            objects[index2] = tempObject;
        }

        private static void PrintPersonsInfo(List<Human> humans)
        {
            foreach (Human human in humans)
            {
                human.PrintPersonInfo();
            }
            Console.WriteLine();
        }
    }
}
