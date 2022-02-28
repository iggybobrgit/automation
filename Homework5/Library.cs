using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5
{
    class Library
    {
         string bookName;
         int bookPages;
         string bookID;


        public Library (string bookname, int bookpages, string bookid)
        {
            bookName = bookname;
            bookPages = bookpages;
            bookID = bookid;
        }

        public string GetBookName()
        {
            return bookName;
        }

        public int  GetBookPages()
        {
            return bookPages;
        }

        public string GetBookID()
        {
            return bookID;
        }
    }
}
