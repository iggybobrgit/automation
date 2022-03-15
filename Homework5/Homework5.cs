using System;

namespace Homework5
{
    class Homework5
    {
        static void Main(string[] args)
        {

            Library book1 = new Library ("Anna Karenina", 213, "f23rf3");
            Library book2 = new Library ("Harry Potter", 590, "h5454h3");
            Library book3 = new Library ("Lord of the Rings", 1450, "jr67kj");
            Library book4 = new Library ("War and Peace", 1900, "tqy54wh");
            Library book5 = new Library ("The Godfather", 315, "y45h4");

            Library[] books = { book1, book2, book3, book4, book5 };

           foreach (var book in books)
            {
                book.PrintBookInfo();
            }
        }
    }

}