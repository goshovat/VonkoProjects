namespace SchoolSystem
{
    using System;

    class SchoolSystemMain
    {
        static void Main()
        {
            School theSchool = School.Instance;
            Student vonko = new Student("Vonko Mihov", 23);
            Student goshko = new Student("Gosko Radev", 24);
            Student stamat = new Student("Stamat Petrov", 34);

            Teacher mathTeacher = new Teacher("Iskra Pecova");
            Teacher sexyMilf = new Teacher("Mariia Iskrova");

            Discipline maths = new Discipline("Maths", 34, 43);
            Discipline physics = new Discipline("Physics", 24, 32);

            mathTeacher.AddDiscipline(maths);
            Console.WriteLine(mathTeacher.ShowDisciplines());
            sexyMilf.AddDiscipline(physics);
            Console.WriteLine(sexyMilf.ShowDisciplines());

            Clas nineE = new Clas("9 E");
            theSchool.AddClas(nineE);
            string classes = theSchool.ShowClases();
            Console.WriteLine(classes);

            nineE.AddStudent(vonko);
            nineE.AddStudent(goshko);
            nineE.AddStudent(stamat);

            nineE.AddTeacher(mathTeacher);
            nineE.AddTeacher(sexyMilf);

            Console.WriteLine(nineE.ShowStudents());
            Console.WriteLine(nineE.ShowTeachers());

            nineE.ExpellStudent(vonko);
            vonko.OptionalComment = "Vonko was an extremely bad student.";
            Console.WriteLine(vonko.OptionalComment);
            nineE.RemoveTeacher(sexyMilf);

            Console.WriteLine(nineE.ShowStudents());
            Console.WriteLine(nineE.ShowTeachers());
        }
    }
}
