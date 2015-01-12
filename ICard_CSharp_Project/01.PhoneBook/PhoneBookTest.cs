//Provided I haven't used WinForms, I will show a console solution to the problem.

using System;
using System.Collections.Generic;
using System.IO;

namespace PhoneBook
{
    class PhoneBookTest
    {
        const string fileToImport = "..\\..\\import_contacts.txt";
        const string fileToExport = "..\\..\\phone_book.txt";

        static void Main()
        {
            //hardcoded scenario to test the functions of the phone book
            Console.SetWindowSize(120, 50);

            /*Create the only instance of PhoneBook using Singleton Design Pattern.
            assume there will be only one PhoneBook for the application*/
            PhoneBook phoneBook = PhoneBook.Instance;
            
            //create some sample entries
            PersonData person1 = new PersonData("Ivan",
                "Mihov", "0887555386", "Burgas, Demokracia 104");
            PersonData person2 = new PersonData("Georgi",
                "Radev", "0884555368", "Burgas, Br. Miladinovi 90");
            PersonData person3 = new PersonData("Mariana",
               "Miteva", "0878654326", "Sofia, Ovcha Kupel 6");
            PersonData person4 = new PersonData("Stoyan",
               "Georgiev", "0879555378", "Varna, Vladislav Varnenchik 118");

            //test the functionality of the phonebook
            phoneBook.AddEntry(person1);
            phoneBook.AddEntry(person2);
            phoneBook.AddEntry(person3);
            phoneBook.AddEntry(person4);
            Console.WriteLine("After adding the first entries:\n\n{0}\n\n", 
                phoneBook.ToString());

            try
            {
            phoneBook.Import(fileToImport);
            Console.WriteLine("After importing from file:\n\n{0}\n\n",
                phoneBook.ToString());

            Console.WriteLine("Sorted by First Name:\n\n{0}\n\n",
           phoneBook.SortByFirstName());
            Console.WriteLine("Sorted by Address:\n\n{0}\n\n",
                phoneBook.SortByAddress());
          
                phoneBook.UpdateByFirstName("Ivan", new PersonData(
                    "Ivan", "Mihov", "0887555386", "Varna, Mladost 63"
                    ));
                phoneBook.UpdateByLastName("Radev", new PersonData(
                    "Georgi", "Radev", "0878563458", "Burgas, Br. Miladinovi 90"
                    ));
                Console.WriteLine("After changing the address of Ivan and the phone of Georgi:\n\n{0}\n\n",
                    phoneBook.ToString());

                phoneBook.DeleteByLastName("Miteva");
                Console.WriteLine("After deleting Mariana:\n\n{0}\n\n",
                    phoneBook.ToString());

                phoneBook.Export(fileToExport);
            }
            catch (ApplicationException appicationlException)
            {
                Console.WriteLine(appicationlException.Message);
                Console.WriteLine(appicationlException.StackTrace);
            }
            catch (IOException ioException)
            {
                Console.WriteLine(ioException.Message);
                Console.WriteLine(ioException.StackTrace);
            }
            catch (Exception generalException)
            {
                Console.WriteLine(generalException.Message);
                Console.WriteLine(generalException.StackTrace);
            }
        }
    }
}
