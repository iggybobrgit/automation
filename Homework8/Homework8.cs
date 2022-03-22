using System;
using System.Collections.Generic;
using Homework8.Comparers;


namespace Homework8
{
    class Homework8
    {
        static void Main(string[] args)
        {
            Office office = new Office()
            {
                Employees = new List<Employee>()
            };
            office.Employees.Add(new BAEmployee() {ID = 1, FirstName = "Mary", LastName = "Smith" });
            office.Employees.Add(new DevEmployee() { ID =2, FirstName = "Alex", LastName = "Parker"});
            office.Employees.Add(new DevTeamLead() { ID = 3, FirstName = "Robert", LastName = "Downey"});
            office.Employees.Add(new PMEployee() {ID = 4,  FirstName = "Natasha", LastName = "Romanoff"});
            office.Employees.Add(new QAAutomationEmployee() { ID = 5, FirstName = "Bruce", LastName = "Benner"});
            office.Employees.Add(new QAAutomationTeamLead() { ID = 6, FirstName = "Steeve", LastName = "Rogers"});
            office.Employees.Add(new QAEmployee() { ID = 7, FirstName = "Elena", LastName = "Belova"});
            office.Employees.Add(new QATeamLead() { ID = 8, FirstName = "Arnim", LastName = "Zola" });

            
            office.Employees.Sort(new FirstNameComparer());
            Console.WriteLine("List of employees order by first name:");
            foreach (var emp in office.Employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}, ID - {emp.ID}");
                
            }

            office.Employees.Sort(new IDComparer());
            Console.WriteLine("List of employees order by ID:");
            foreach (var emp in office.Employees)
            {
                Console.WriteLine($"ID - {emp.ID}, {emp.FirstName} {emp.LastName}");
            }

            office.Employees.Sort(new FullNameLengthComparer());
            Console.WriteLine("List of employees order by full name lenght:");
            foreach (var emp in office.Employees)
            {
                Console.WriteLine($"ID - {emp.ID}, {emp.FirstName} {emp.LastName}");
            }


            office.Employees.Sort(new TaskAssignComparer());
            Console.WriteLine("List of employees order by ability to assign tasks (emplyees who can assign tasks also order by last name):");
            foreach (var emp in office.Employees)
            {
                Console.WriteLine($"ID - {emp.ID}, {emp.FirstName} {emp.LastName}");
            }
        }
    }
}
