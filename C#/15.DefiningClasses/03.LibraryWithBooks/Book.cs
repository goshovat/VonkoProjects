using System;
using System.Collections.Generic;

namespace Library
{
    public class Book
    {
        private string title;
        private string author;
        private string publisher;
        private int yearPublished;
        private ulong isbn;

        //constructors for the class
        public Book()
            :this("Unknown", "Unknown")
        {
        }

        public Book(string title, string author)
            :this(title, author, "Unknown", 0, 0)
        {
        }

        public Book(string title, string author, string publisher,
            int yearPublished, ulong ISBN)
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.yearPublished = yearPublished;
            this.isbn = ISBN;
        }

        //properties of the book class
        //the properties are only read only because we cannot change the author or title of already published book
        public string Title
        {
            get { return this.title; }
        }

        public string Author
        {
            get { return this.author; }
        }

        public string Publisher
        {
            get { return this.publisher; }
        }

        public int YearPublished
        {
            get { return this.yearPublished; }
        }

        public ulong ISBN
        {
            get { return this.isbn; }
        }
    }
}
