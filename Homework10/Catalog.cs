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
            var names = books.OrderBy(x => x.BookName).ToList();
            return names;
        }

        public List<Author> GetAuthorsByBirthday(List<Author> authors)
        {
            Console.WriteLine("List of all authors ordered by DOB:");
            var names = authors.OrderBy(x => x.DOB).ToList();
            return names;
        }

        public List<Book> GetCobenLeeBooks(List<Book> books)
        {
            Console.WriteLine("List of books wrote by Coben Lee after 01/01/2001");
            var names = books.Where(x => x.Authors.Any(a =>a.FirstName == "Lee" && a.LastName == "Coben")).Where(x => x.PrintDate > new DateTime(2001, 01, 01)).ToList();
            return names;
        }

        public List<Author> GetListOfBookWAvailableAuthor(List<Book> books)
        {
            Console.WriteLine("List of books wrote by authors from catalog");
            var names = books.SelectMany(x => x.Authors).Distinct().ToList();
            return names;
        }
    }
}
