using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8
{
    class PMEployee : Employee, IAssigneTask
    {
        public void AssigneTask(int ID, string FirstName, string LastName)
        {
            Console.WriteLine("{0} {1} {2}", ID, FirstName, LastName) ;
        }
    }
}

