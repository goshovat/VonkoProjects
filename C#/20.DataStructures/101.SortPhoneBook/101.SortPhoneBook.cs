using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SortPhoneBook
{
    class SortPhoneBook
    {
        static void Main()
        {
            string filePath = "..\\..\\phone book.txt";

            try
            {
                SortedDictionary<string, SortedDictionary<string, string>> phoneBook =
                    FillPhoneBook(filePath);
                PrintContacts(phoneBook);
            }
            catch (FileNotFoundException fileNotExc)
            {
                Console.WriteLine("Error! The file {0} was not found.", filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        private static SortedDictionary<string, SortedDictionary<string, string>>
            FillPhoneBook(string filePath)
        {
            SortedDictionary<string, SortedDictionary<string, string>> phoneBook =
                new SortedDictionary<string, SortedDictionary<string, string>>();

            StreamReader reader = new StreamReader(filePath,
                Encoding.GetEncoding("windows-1251"));

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        break;

                    string[] personData = line.Split(new char[] { '|' });
                    string name = personData[0].Trim();
                    string city = personData[1].Trim();
                    string phone = personData[2].Trim();

                    SortedDictionary<string, string> cityData =
                        new SortedDictionary<string, string>();

                    if (!phoneBook.TryGetValue(city, out cityData))
                    {
                        phoneBook[city] = new SortedDictionary<string, string>();
                    }
                    phoneBook[city][name] = phone;

                    line = reader.ReadLine();
                }
            }

            return phoneBook;
        }

        private static void PrintContacts(
            SortedDictionary<string, SortedDictionary<string, string>> phoneBook)
        {
            foreach (string city in phoneBook.Keys)
            {
                Console.WriteLine(city + ": ");
                foreach (string name in phoneBook[city].Keys)
                    Console.WriteLine(name + " " + phoneBook[city][name]);

                Console.WriteLine();
            }
        }
    }
}
