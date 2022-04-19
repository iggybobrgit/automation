using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Homework8.Comparers
{
    class TaskAssignComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            {
                if (x is IAssigneTask & !(y is IAssigneTask))
                {
                    return -1;
                }
                else if (x is IAssigneTask & y is IAssigneTask)
                {
                    if (x.LastName[0] > y.LastName[0])
                    {
                        return 1;
                    }
                    else if (x.LastName[0] == y.LastName[0])
                    {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return 1;
                }

            }
        }
    }
}
