using System;

namespace SchoolModel
{
    class SchoolModelTest
    {
        static void Main()
        {
            //create THE school
            School gangstaSchool = School.Instance;

            //create students, create class, add students to the class
            Student vonko, mimeto, stoyan, pesho, patkan;
            CreateStudents(out vonko, out mimeto, out stoyan, out pesho, out patkan);
            Klass coolKlass = new Klass("Cool");        
            AddStudentsToKlass(coolKlass, vonko, mimeto, stoyan, pesho, patkan);
            coolKlass.ShowStudents();

            //create teachers, create disciplines, add disciplines to teachers
            Discipline sexEducation, maths;
            CreateDisciplines(out sexEducation, out maths);
            Teacher sexyMilf, oldCunt;
            CreateTeachers(out sexyMilf, out oldCunt);
            AddDisciplinesToTeachers(sexEducation, sexyMilf, maths, oldCunt);
            sexyMilf.ShowDisciplines();
            oldCunt.ShowDisciplines();

            //add the teachers and klass to the school
            gangstaSchool.AddKlass(coolKlass);
            gangstaSchool.HireTeacher(sexyMilf);
            gangstaSchool.HireTeacher(oldCunt);

            try
            {
                //remove one lesson and add one exercies to a discipline
                sexEducation.ShowInfo();
                sexEducation.RemoveLesson();
                sexEducation.AddExercise();

                //one student and a teacher misbehaved during an exercise
                coolKlass.RemoveStudent(vonko);
                gangstaSchool.FireTeacher(sexyMilf);

                coolKlass.ShowStudents();
                gangstaSchool.ShowTeachers();
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
    
        //the methods that will help testing our school system
        private static void CreateStudents(out Student vonko, out Student mimeto, out Student stoyan, out Student pesho, out Student patkan)
        {
            vonko = new Student("Vonko Mihov", 13);
            mimeto = new Student("Mimeto Todorova", 5);
            stoyan = new Student("Stoyan Barakov", 20);
            pesho = new Student("Pesho Jivotnoto", 18);
            patkan = new Student("Patkan Patkanov", 17);
        }

        private static void AddStudentsToKlass(Klass klass, params Student[] students)
        {
            foreach (Student student in students)
            {
                klass.AddNewStudent(student);
            }
        }

        private static void CreateDisciplines(out Discipline sexEducation, out Discipline maths)
        {
            sexEducation = new Discipline("Sex Education", 10, 46);
            maths = new Discipline("Maths", 20, 35);
        }


        private static void CreateTeachers(out Teacher sexyMilf, out Teacher oldCunt)
        {
            sexyMilf = new Teacher("Penka Minkova");
            oldCunt = new Teacher("Tutka Kuchkova");
        }
   
        private static void AddDisciplinesToTeachers(Discipline sexEducation, Teacher sexyMilf, Discipline maths, Teacher oldCunt)
        {
            sexyMilf.AddDiscipline(sexEducation);
            oldCunt.AddDiscipline(maths);
        }
    }
}
