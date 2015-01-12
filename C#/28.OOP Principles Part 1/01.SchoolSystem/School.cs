namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class School
    {
        private static School instance;
        private HashSet<Clas> classes;

        private School() 
        {
            this.classes = new HashSet<Clas>();
        }

        public static School Instance
        {
            get
            {
                if (School.instance == null)
                    School.instance = new School();

                return School.instance;
            }
        }

        #region Class
        public void AddClas(Clas clas)
        {
            if (this.classes.Contains(clas))
                throw new ArgumentException("Cannot add a class that is already in the school.");

            this.classes.Add(clas);
        }
        public void RemoveClas(Clas clas)
        {
            if (!this.classes.Contains(clas))
                throw new ArgumentException("Cannot remove a class that is not in the school.");

            this.classes.Remove(clas);
        }
        public string ShowClases()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Classes in {0}: ", this.ToString()));
            foreach (Clas clas in this.classes)
                result.Append(clas.ToString() + ' ');

            return result.ToString();
        }
        #endregion

        public override string ToString()
        {
            return "The Vonko School";
        }
    }
}
