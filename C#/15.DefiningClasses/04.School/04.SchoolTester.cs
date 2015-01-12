using System;

namespace School
{
    class SchoolTester
    {
        static void Main()
        {
            School gangstaSchool = new School("Gangsta School");

            //create some disciplines
            Discipline sexEducation, maths, literature, programming;
            CreateDisciplines(out sexEducation, out maths, out literature, out programming);

            //create some teachers and add them disciplines
            Teacher sexyMilf, theOldCunt;
            CreateTeachers(out sexyMilf, out theOldCunt);
            AddDisciplines(sexEducation, maths, literature, programming, sexyMilf, theOldCunt);

            //create some students
            Student vonko, goshko, stoyan, mimeto;
            CreateStudents(out vonko, out goshko, out stoyan, out mimeto);

            //create klasses and add them students
            Klass a717, a715;
            CreateKlasses(out a717, out a715);
            AddStudents(vonko, goshko, stoyan, mimeto, a717, a715);

            //add them to the school
            HireTeachers(gangstaSchool, sexyMilf, theOldCunt);
            AddKlasses(gangstaSchool, a717, a715);

            //show the klasses and teachers in the school
            gangstaSchool.ShowKlasses();
            gangstaSchool.ShowTeachers();

            //pick up a teacher and print its disciplines
            sexyMilf.ShowDisciplines();
            theOldCunt.ShowDisciplines();

            try
            {
                //remove a discipline, add a discipline and print again
                sexyMilf.RemoveDiscipline(sexEducation); //she misbehaved with a student during the exercises
                theOldCunt.AddDiscipline(sexEducation);

                sexyMilf.ShowDisciplines();
                theOldCunt.ShowDisciplines();

                //pickup a discipline print information about it
                sexEducation.ShowInfo();
                //change then number of lessons and exercises, print info again
                //for (int i = 0; i < 50; i++ ) - test the exception when try to remove lesson when the lessons are zero
                sexEducation.RemoveLesson();

                sexEducation.AddExercise();
                sexEducation.ShowInfo();

                //pickup a klass and write its students
                a717.ShowStudents();
                //expell one student, add another and write them again
                a717.RemoveStudent(vonko);
                vonko.Number = 0;

                //test functionality when try to remove a student who is not in the class
                //Student conko = new Student("Conko Conev", 13);
                //a717.RemoveStudent(conko);

                a717.ShowStudents();
                //give information about the expelled student
                vonko.ShowInfo();
            }
            catch (ApplicationException applExc)
            {
                Console.WriteLine(applExc.Message);
                Console.WriteLine(applExc.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        //the static methods of the class used for the tests
        private static void CreateDisciplines(out Discipline sexEducation, out Discipline maths, out Discipline literature, out Discipline programming)
        {
            sexEducation = new Discipline("Sex Education", 15, 55);
            maths = new Discipline("Maths", 20, 40);
            literature = new Discipline("Literature", 40, 40);
            programming = new Discipline("Programming", 20, 60);
        }

        private static void CreateTeachers(out Teacher sexyMilf, out Teacher theOldCunt)
        {
            sexyMilf = new Teacher("Penka Tutkova");
            theOldCunt = new Teacher("Stamatka Durkova");
        }

        private static void AddDisciplines(Discipline sexEducation, Discipline maths, Discipline literature, Discipline programming, Teacher sexyMilf, Teacher theOldCunt)
        {
            sexyMilf.AddDiscipline(sexEducation);
            sexyMilf.AddDiscipline(literature);
            theOldCunt.AddDiscipline(maths);
            theOldCunt.AddDiscipline(programming);
        }

        private static void CreateStudents(out Student vonko, out Student goshko, out Student stoyan, out Student mimeto)
        {
            vonko = new Student("Vonko Mihov", 13);
            goshko = new Student("Goshko Radev", 5);
            stoyan = new Student("Stoyan Barakov", 8);
            mimeto = new Student("Mimeto Todorova", 10);
        }

        private static void CreateKlasses(out Klass a717, out Klass a715)
        {
            a717 = new Klass("A717");
            a715 = new Klass("A715");
        }

        private static void AddStudents(Student vonko, Student goshko, Student stoyan, Student mimeto, Klass a717, Klass a715)
        {
            a717.AddNewStudent(vonko);
            a717.AddNewStudent(goshko);
            a715.AddNewStudent(stoyan);
            a715.AddNewStudent(mimeto);
        }

        private static void HireTeachers(School gangstaSchool, Teacher sexyMilf, Teacher theOldCunt)
        {
            gangstaSchool.HireTeacher(sexyMilf);
            gangstaSchool.HireTeacher(theOldCunt);
        }

        private static void AddKlasses(School gangstaSchool, Klass a717, Klass a715)
        {
            gangstaSchool.AddKlass(a717);
            gangstaSchool.AddKlass(a715);
        }
    }
}
