using System;
using School;
using System.Collections.Generic;

namespace GenericList
{
    class GenericListTester
    {
        public static void Main()
        {
            try
            {
                TestWithBoolType();

                //now we will test the Generic Class with our class from previous project
                GenericList<Student> students;
                Student stoyan, mimeto, prokopii, vonko, goshko;

                //this method will create the students and add two of them to the list
                CreateAddStudents(out students, out stoyan, out mimeto, out prokopii, out vonko,  out goshko);

                AddMoreStudents(students, stoyan, mimeto);

                Console.WriteLine("The index of {0} is {1}\n", mimeto.Name, students.FindElement(mimeto));

                RemoveAndInsertStudents(students);

                //add a new object at the end          
                AddStudentToTheEnd(students, prokopii);

                Console.WriteLine("The student {0} is at index {1}\n",
                    mimeto.Name, students.FindElement(mimeto));

                //test the exception for searching for a student who is not in the list
                //Student vesko = new Student("Vesko Marinov", 29);
                //Console.WriteLine("The student {0} is at index {1}\n",
                //   vesko.Name, students.FindElement(vesko));

                //test the indexator and the clear function
                int indexToCheck = students.Length - 1;
                Console.WriteLine("The object at index {0} is {1}.", indexToCheck, students[indexToCheck].Name);
                Console.WriteLine();

                students.ClearList();
                Console.WriteLine("After clearing the list, its length is {0}.", students.Length);
            }
            catch (ApplicationException applE)
            {
                Console.WriteLine(applE.Message);
                Console.WriteLine(applE.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        //these methods will consecutevely perform the tests
        private static void TestWithBoolType()
        {
            Console.WriteLine("Test with a bool list of deafult size and adding one element: ");
            GenericList<bool> boolList = new GenericList<bool>();
            boolList.AddElement(true);
            Console.WriteLine(string.Format("The only element different from the default value is: {0}", 
                boolList.ToString()));
            Console.WriteLine();
        }

        private static void CreateStudents(out Student vonko, out Student goshko,
        out Student stoyan, out Student mimeto, out Student prokopii)
        {
            vonko = new Student("Vonko Mihov", 13);
            goshko = new Student("Goshko Radev", 5);
            stoyan = new Student("Stoyan Barakov", 8);
            mimeto = new Student("Mimeto Todorova", 10);
            prokopii = new Student("Prokopii", 15);
        }

        private static void CreateAddStudents(out GenericList<Student> students, out Student stoyan, out Student mimeto, 
            out Student prokopii, out Student vonko, out Student goshko)
        {
            students = new GenericList<Student>(2);

            CreateStudents(out vonko, out goshko, out stoyan, out mimeto, out prokopii);
            students.AddElement(vonko);
            students.AddElement(goshko);
            Console.WriteLine("Initially the length of the list is {0} and the capacity is {1}.", students.Length, students.Capacity);
            Console.WriteLine("The students in the list: ");
            Console.WriteLine(students.ToString());
            Console.WriteLine();
        }

        private static void AddMoreStudents(GenericList<Student> students, Student stoyan, Student mimeto)
        {
            students.AddElement(mimeto);
            students.AddElement(stoyan);
            Console.WriteLine("After adding two more students to the list: ");
            Console.WriteLine(students.ToString());
            Console.WriteLine();
        }

        private static void RemoveAndInsertStudents(GenericList<Student> students)
        {
            int indexToRemove = 1;
            int indexToAdd = 2;
            Student removedStudent = students.RemoveAt(1);
            students.InsertAt(indexToAdd, removedStudent);
            Console.WriteLine("The list of students after removing the element at index {0} and adding it to the index {1}",
                indexToRemove, indexToAdd);
            Console.WriteLine(students.ToString());
            Console.WriteLine();

            List<int> vonkoList = new List<int>();
        }

        private static void AddStudentToTheEnd(GenericList<Student> students, Student prokopii)
        {
            students.AddElement(prokopii);
            Console.WriteLine("After adding one more student, the students in the list: ");
            Console.WriteLine(students.ToString());
            Console.WriteLine();
        }
    }
}
