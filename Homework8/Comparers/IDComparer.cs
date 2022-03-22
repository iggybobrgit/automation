using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Homework8.Comparers
{
    class IDComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            if (x.ID > y.ID)
            {
                return 1;
            }
            else if (x.ID == y.ID)
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
