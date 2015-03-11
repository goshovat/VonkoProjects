namespace SchoolSystem
{
    using System;

    public class Discipline
    {
        public string Name { get; private set; }
        public int NumberLectures { get; private set; }
        public int NumberExercises { get; private set; }
        public string OptionalComment { get; set; }

        public Discipline(string name, int numberLectures, int numberExercises) 
        {
            if (numberLectures < 0)
                throw new ArgumentException("The number of lectures in a discipline must be positive.");

            if (numberExercises < 0)
                throw new ArgumentException("The number of exercises in a discipline must be positive.");

            this.Name = name;
            this.NumberLectures = numberLectures;
            this.NumberExercises = numberExercises;
        }

        public override string ToString()
        {
            return string.Format("Discipline: {0}; {1} lectures, {2} exercises\r",
                this.Name, this.NumberLectures, this.NumberExercises);
        }
    }
}
