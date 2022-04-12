using System;
using System.Collections.Generic;
using System.Text;

namespace Homework10
{
    class Author
    {
        public Author (string firstname, string lastname, DateTime dob)
        {
            FirstName = firstname;
            LastName = lastname;
            DOB = dob;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
}
