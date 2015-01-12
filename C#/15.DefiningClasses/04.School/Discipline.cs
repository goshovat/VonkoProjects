using System;
using System.Collections.Generic;

namespace School
{
    public class Discipline
    {
        private string name;
        private uint numberOfLessons;
        private uint numberOfExercises;

        //the constructors
        public Discipline()
            :this("Unknown")
        {

        }

        public Discipline(string name)
            :this(name, 0, 0)
        {

        }

        public Discipline(string name, uint numberOfLessons, uint numberOfExercises)
        {
            this.name = name;
            this.numberOfLessons = numberOfLessons;
            this.numberOfExercises = numberOfExercises;
        }

        //the props
        public string Name
        {
            get { return this.name; }
        }

        public int NumberOfLessons
        {
            get { return (int)this.numberOfLessons; }
        }

        public int NumberOfExercises
        {
            get { return (int)this.numberOfExercises; }
        }

        //some methods
        public void AddLesson()
        {
            this.numberOfLessons++;
        }

        public void RemoveLesson()
        {
            if (this.numberOfLessons > 0)
                this.numberOfLessons--;
            else
                throw new ApplicationException(string.Format("Error! Cannot remove a lesson from the discipline {0}, because the number of lessons is zero!",
                    this.name));
        }

        public void AddExercise()
        {
            this.numberOfExercises++;
        }

        public void RemoveExercise()
        {
            if (this.numberOfExercises > 0)
                this.numberOfExercises--;
            else
                throw new ApplicationException(string.Format("Error! Cannot remove an exercise from the discipline {0}, because the number of exercises is zero!",
                    this.name));
        }

        public void ShowInfo()
        {
            Console.WriteLine("The name of the discipline is: {0}", this.name);
            Console.WriteLine("The number of lessons of the discipline are: {0}", this.numberOfLessons);
            Console.WriteLine("The number of exercises of the discipline are: {0}", this.numberOfExercises);
            Console.WriteLine(new string('-', 50));
            Console.WriteLine();
        }
    }
}
