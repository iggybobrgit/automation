using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Task50_subtask_9
{
    class Grid
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public int Age { get; set; }
        public string StartDate { get; set; }
        public int Salary { get; set; }

        public Grid(List<string> args)
        {
            Name = args[0];
            Position = args[1];
            Office = args[2];
            Age = int.Parse(args[3]);
            StartDate = args[4];
            Salary = int.Parse(Regex.Replace(args[5], @"\D+", ""));
        }
    }
}