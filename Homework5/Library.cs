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
      
        public static void PrintLibrary(Library[] books)
        {
            foreach (Library book in books)
            {
                Console.WriteLine("Book name is {0}, amount of the pages is {1}, unique library id is {2}", book.BookName, book.BookPages, book.BookID);
            }
        }
    }
}
