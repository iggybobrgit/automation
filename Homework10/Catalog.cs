using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework10
{
    class Catalog
    {
        public List<Book> AvailableBooks { get; set; }
        public List<Book> GetBookNames(List<Book> books)
        {
            Console.WriteLine("List of books ordered by book name:");
            var bookNames = books.OrderBy(x => x.BookName).ToList();
            return bookNames;
        }
        public List<Author> GetAuthorsByBirthday(List<Author> authors)
        {
            Console.WriteLine("List of all authors ordered by DOB:");
            var names = authors.OrderBy(x => x.DOB).ToList();
            return names;
        }
        public List<Book> GetBooksByAuthorPrintedAfter2001(List<Book> books)
        {
            Console.WriteLine("Enter author's firstname:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter author's lastname:");
            string lastName = Console.ReadLine();
            Console.WriteLine("List of books wrote by {0} {1} after 01/01/2001", firstName, lastName);
            var names = books.Where(x => x.Authors.Any(a =>a.FirstName == firstName && a.LastName == lastName)).Where(x => x.PrintDate > new DateTime(2001, 01, 01)).ToList();
            return names;
        }
        public List<Author> GetBooksOfAvailableAuthors(List<Book> books)
        {
            Console.WriteLine("List of books wrote by authors from catalog");
            var names = books.SelectMany(x => x.Authors).Distinct().ToList();
            return names;
        }
    }
}
