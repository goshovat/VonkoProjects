namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : Human
    {
        private HashSet<Discipline> disciplines;

        public Teacher(string name)
        {
            this.disciplines = new HashSet<Discipline>();
            base.Name = name;
        }

        #region Disciplines
        public void AddDiscipline(Discipline discipline)
        {
            if (this.disciplines.Contains(discipline))
                throw new ArgumentException("Cannot add a discipline, because the teacher is already teaching it.");

            this.disciplines.Add(discipline);
        }
        public void RemoveDiscipline(Discipline discipline)
        {
            if (!this.disciplines.Contains(discipline))
                throw new ArgumentException("Cannot remove a discipline that the teacher is not teaching.");

            this.disciplines.Remove(discipline);
        }
        public string ShowDisciplines()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Disciplines tacught by teacher {0}:", base.Name));
            foreach (Discipline discipline in this.disciplines)
                result.Append(discipline);

            return result.ToString();
        }
        #endregion

        public override string ToString()
        {
            return string.Format("Teacher: {0}", base.Name);
        }
    }
}
