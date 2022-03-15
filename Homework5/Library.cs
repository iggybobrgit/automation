using System;

namespace Homework5
{
    class Library
    {
        public Library (string bookname, int bookpages, string bookid)
        {
            BookName = bookname;
            BookPages = bookpages;
            BookID = bookid;
        }
        public string BookName { get; set; }
        public int BookPages { get; set; }
        public string BookID { get; set; }
      
        public void PrintBookInfo()
        {
            Console.WriteLine("{0} book with ID - {1} has {2} pages", BookName, BookID, BookPages);
        }
    }
}
