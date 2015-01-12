using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Students
{
    class Students
    {
        static void Main()
        {
            string filePath = "..\\..\\students.txt";

            try
            {
                SortedDictionary<string, List<KeyValuePair<string, string>>> students =
                     ArrangeStudents(filePath);
                PrintStudents(students);
            }
            //expect some of the IO Exceptions
            catch (IOException ioExc)
            {
                Console.WriteLine(ioExc.Message);
                Console.WriteLine(ioExc.StackTrace);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private static SortedDictionary<string, List<KeyValuePair<string, string>>>
            ArrangeStudents(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            SortedDictionary<string, List<KeyValuePair<string, string>>> students =
                new SortedDictionary<string, List<KeyValuePair<string, string>>>();

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        break;

                    string[] lineEntities = line.Split('|');
                    string names = lineEntities[0].Trim();
                    string[] nameEntities = names.Split(' ');
                    string firstName = nameEntities[0].Trim();
                    string lastName = nameEntities[1].Trim();
                    string speciality = lineEntities[1].Trim();

                    List<KeyValuePair<string, string>> group =
                        new List<KeyValuePair<string, string>>();
                    if (!students.TryGetValue(speciality, out group))
                    {
                        students[speciality] = new List<KeyValuePair<string, string>>();
                    }
                    students[speciality].Add(
                        new KeyValuePair<string, string>(firstName, lastName));
                }
            }

            return students;
        }

        private static void PrintStudents(
            SortedDictionary<string, List<KeyValuePair<string, string>>> students)
        {
            foreach (string speciality in students.Keys)
            {
                SortStudents(students[speciality]);
                Console.Write(speciality + ": ");
                for (int i = 0; i < students[speciality].Count; i++)
                {
                    KeyValuePair<string, string> student = students[speciality][i];
                    Console.Write(student.Key + " " + student.Value);
                    if (i != students[speciality].Count - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void SortStudents(
            List<KeyValuePair<string, string>> students)
        {
            bool hasSwapped = true;
            while (hasSwapped)
            {
                hasSwapped = false;
                for (int i = 0; i < students.Count - 1; i++)
                {
                    KeyValuePair<string, string> student = students[i];
                    KeyValuePair<string, string> nextStudent = students[i + 1];

                    //first compare the families
                    if (student.Value.CompareTo(nextStudent.Value) > 0)
                        Exchange(i, i + 1, students);
                    //if the families are the same compare given names
                    else if (student.Value.Equals(nextStudent.Value))
                        if (student.Key.CompareTo(nextStudent.Key) > 0)
                            Exchange(i, i + 1, students); ;
                }
            }
        }

        private static void Exchange(int index1, int index2,
            List<KeyValuePair<string, string>> students)
        {
            KeyValuePair<string, string> tempStudent = students[index1];
            students[index1] = students[index2];
            students[index2] = tempStudent;
        }
    }
}
