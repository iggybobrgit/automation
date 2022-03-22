using System;
using System.Collections.Generic;
using System.Text;

namespace Homework8
{
    class QAAutomationEmployee : Employee , IWritingCode
    {
        public void CodeWriting(int ID, string FirstName, string LastName)
        {
            Console.WriteLine("{0} {1} {2}", ID, FirstName, LastName);
        }
    }
}

