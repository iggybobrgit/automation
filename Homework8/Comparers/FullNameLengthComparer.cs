using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Homework8.Comparers
{
    class FullNameLengthComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            int xLength = x.FirstName.Length + x.LastName.Length;
            int yLenght = y.FirstName.Length + y.LastName.Length;

            if (xLength > yLenght)
            {
                return 1;
            }
            else if (xLength == yLenght)
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
