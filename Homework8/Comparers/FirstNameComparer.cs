using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Homework8.Comparers
{
    class FirstNameComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
           if (x.FirstName[0] > y.FirstName[0])
            {
                return 1;
            }
            else if (x.FirstName[0] == y.FirstName[0])
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
