using System;
using System.Collections.Generic;

namespace SchoolModel
{
    public class Teacher : Human
    {
        private List<Discipline> disciplines = new List<Discipline>();

        public Teacher(string name)
            :base(name)
        {
        }

        //methods of the class
        public void AddDiscipline(Discipline discipline)
        {
            if (this.disciplines.Contains(discipline))
                throw new ApplicationException(string.Format("Error! The teacher {0} already teaches the discipline {1}",
                        base.name, discipline.Name));

            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            if (!this.disciplines.Contains(discipline))
                throw new ApplicationException(string.Format("Error! The teacher {0} doesn't teach the discipline {1}",
                       base.name, discipline.Name));

            this.disciplines.Remove(discipline);
        }

        public void ShowDisciplines()
        {
            Console.WriteLine("The disciplines of the teacher {0} are:", this.name);
            foreach (Discipline discipline in this.disciplines)
            {
                Console.WriteLine(discipline.Name);
            }
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}
