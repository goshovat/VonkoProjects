using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Library
    {
        private string libraryName;
        private List<Book> listOfBooks = new List<Book>();

        //two constructors for the class
        public Library()
            :this("unknown")
        {
        }

        public Library(string name)
        {
            this.libraryName = name;
        }

        //property for the library name that will be get and set
        public string LibraryName
        {
            get { return this.libraryName; }
            set { this.libraryName = value; }
        }

        //method to add book to the library
        public void AddBook(Book book)
        {
            this.listOfBooks.Add(book);
        }

        //this method will remove all copies of this book in the library
        public void RemoveBook(Book book)
        {
            if (!this.listOfBooks.Contains(book))
                throw new ApplicationException(string.Format("Error! The book {0} is not in the library!"));

            while (this.listOfBooks.Contains(book))
                listOfBooks.Remove(book);
        }

        //this will return a lsit with the books from this author
        public List<Book> SearchBookByAuthor(string author)
        {
            List<Book> booksByAuthor = new List<Book>();

            foreach (Book book in this.listOfBooks)
            {
                if (book.Author == author)
                    booksByAuthor.Add(book);
            }

            return booksByAuthor;
        }

        //this method will print info about ONE book ONLY from the library
        public void PrintBookInfo(Book book)
        {
            if (listOfBooks.Contains(book))
            {
                Console.WriteLine("The name of the book is: {0}", book.Title);
                Console.WriteLine("The author of the book is: {0}", book.Author);
                Console.WriteLine("The publisher of the book is: {0}", book.Publisher);
                Console.WriteLine("The year of publishing of the book is: {0}", book.YearPublished);
                Console.WriteLine("The ISBN of the book is: {0}\n", book.ISBN);
            }
        }

        //this method will print info about all books in the library
        public void PrintInfoAllBooks()
        {
            Console.WriteLine("Information about all the books in the library:\n");
            foreach (Book book in this.listOfBooks)
            {
                this.PrintBookInfo(book);
            }
        }
    }
}
