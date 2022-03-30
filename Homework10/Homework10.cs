using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework10
{
    class Homework10
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog()
            {
                AvailableBooks = new List<Book>()
            };

            var authorList = new List<Author>()
            {
                new Author("James", "Patterson", new DateTime(1900, 1, 1)),
                new Author("David", "Roberts", new DateTime(1901, 1, 2)),
                new Author("Lee", "Coben", new DateTime(1902, 1, 3)),
                new Author("Clive", "Fluke", new DateTime(1903, 1, 4)),
                new Author("Fern", "Beaton", new DateTime(1904, 1, 5)),
                new Author("Collen", "Hoover", new DateTime(1905, 1, 6)),
                new Author("Aaron", "Brown", new DateTime(1906, 1, 7))
            };

            catalog.AvailableBooks.Add(new Book("Ulysses", new DateTime(1910, 2, 1), 534254, new List<Author>() { authorList[0], authorList[3] }));
            catalog.AvailableBooks.Add(new Book("The Godfather", new DateTime(2000, 01, 25), 09834, new List<Author>() { authorList[1] }));
            catalog.AvailableBooks.Add(new Book("Anna Karenina", new DateTime(2003, 01, 25), 234908, new List<Author>() { authorList[2] }));
            catalog.AvailableBooks.Add(new Book("Harry Potter", new DateTime(2010, 04, 25), 986453, new List<Author>() { authorList[4] }));
            catalog.AvailableBooks.Add(new Book("War and Peace", new DateTime(2014, 04, 1), 523, new List<Author>() { authorList[5], authorList[2] }));
            catalog.AvailableBooks.Add(new Book("Lord of the Rings", new DateTime(2000, 01, 25), 4348, new List<Author>() { authorList[2] }));


            var test = catalog.GetBookNames(catalog.AvailableBooks);
            foreach (var element in test)
            {
                Console.WriteLine($"{element.BookName}");         
            }

            var test1 = catalog.GetAuthorsByBirthday(authorList);
            foreach (var element in test1)
            {
                Console.WriteLine($"{element.FirstName} {element.LastName}, DOB - {element.DOB.ToShortDateString()}");
            }


            var test2 = catalog.GetCobenLeeBooks(catalog.AvailableBooks);

            foreach (var element in test2)
            {
                Console.WriteLine($"{element.BookName} {element.BookID}");
            }


            var test3 = catalog.GetListOfBookWAvailableAuthor(catalog.AvailableBooks);

            foreach (var element in test3)
            {
                Console.WriteLine($"{element.FirstName} {element.LastName}, DOB - {element.DOB.ToShortDateString()}");
            }

        }
    }
 }
