using System;
using System.Collections.Generic;
using System.Text;

namespace Homework10
{
    class Book
    {
        public Book (string bookname, DateTime printdate, int bookid, List<Author> authors)
        {
            BookName = bookname;
            PrintDate = printdate;
            BookID = bookid;
            Authors = authors;
        }
        public string BookName { get; set; }
        public DateTime PrintDate { get; set; }
        public int BookID { get; set; }
        public List <Author> Authors  { get; set; }
    }
}
