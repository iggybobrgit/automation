using System;
using System.Collections.Generic;
using System.Text;

namespace Homework9
{
    class DevTeamLead : Employee, IAssigneTask, ICodeReview, IWritingCode
    {
        public void AssigneTask(int ID, string FirstName, string LastName)
        {
            Console.WriteLine("{0} {1} {2}", ID, FirstName, LastName);
        }
        public void CodeReview(int ID, string FirstName, string LastName)
        {
            Console.WriteLine("{0} {1} {2}", ID, FirstName, LastName );
        }
        public void CodeWriting(int ID, string FirstName, string LastName)
        {
            Console.WriteLine("{0} {1} {2}", ID, FirstName, LastName);
        }
    }
}



