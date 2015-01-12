//this class will test the functionality of the library class
using System;
using System.Collections.Generic;

namespace Library
{
    class LibraryTester
    {
        static void Main()
        {
            try
            {
                Library vonkoLibrary = new Library("vonkoLibrary");

                AddBooks(vonkoLibrary);

                //print info about all the books in the library
                vonkoLibrary.PrintInfoAllBooks();

                //delete all books that author is StevenKing
                DeleteBooksByAuthor(vonkoLibrary, "Steven King");
                Console.WriteLine("After the Steven King's books have been removed:\n");

                //after steven kings books have been deleted, print again info
                vonkoLibrary.PrintInfoAllBooks();
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

        //this method will add books for the tests
        private static void AddBooks(Library vonkoLibrary)
        {
            Book kamaSutraBook = new Book("Kama Stutra", "Unknown Sex Addicts");
            vonkoLibrary.AddBook(kamaSutraBook);
            Book theSwiftDeathBook = new Book("Swift Death", "Steven King", "Bard", 1999, 8112414);
            vonkoLibrary.AddBook(theSwiftDeathBook);
            Book vonkoChronicles = new Book("Vonko's Chronicles", "Vonko Mihov", "Hermes", 2014, 2125121);
            vonkoLibrary.AddBook(vonkoChronicles);
            Book theSilenceOfLambs = new Book("Silence of the Lambs", "Steven King", "Bard", 2001, 2412241);
            vonkoLibrary.AddBook(theSilenceOfLambs);
        }

        //this method will delete all books in the given library written by the given author
        private static void DeleteBooksByAuthor(Library vonkoLibrary, string p)
        {
            List<Book> authorBooks = vonkoLibrary.SearchBookByAuthor("Steven King");

            for (int i = 0; i < authorBooks.Count; i++)
            {
                vonkoLibrary.RemoveBook(authorBooks[i]);

                //after the referenc is removed from authorBooks and from the library the garbage collector will delete the object
                authorBooks[i] = null;
            }
        }
    }
}
