using System;
using System.Collections.Generic;
using System.Linq;


namespace Homework9
{
    class Homework9
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

            var firstnameOrder = office.Employees.OrderBy(x => x.FirstName);
            Console.WriteLine("List of employees order by first name:");
            foreach (var emp in firstnameOrder)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}, ID - {emp.ID}");
            }

            var idOrder = office.Employees.OrderBy(x => x.ID);
            Console.WriteLine("List of employees order by ID:");
            foreach (var emp in idOrder)
            {
                Console.WriteLine($"ID - {emp.ID}, {emp.FirstName} {emp.LastName}");
            }

            var fullnamelenghtOrder = office.Employees.OrderBy(x => x.FirstName.Length + x.LastName.Length);
            Console.WriteLine("List of employees order by full name lenght:");
            foreach (var emp in fullnamelenghtOrder)
            {
                Console.WriteLine($"ID - {emp.ID}, {emp.FirstName} {emp.LastName}");
            }

            var taskassignOrder = office.Employees.OrderBy(x => !(x is IAssigneTask)).ThenBy(x=> x.LastName);
            Console.WriteLine("List of employees order by ability to assign tasks and last name");
            foreach (var emp in taskassignOrder)
            {
                Console.WriteLine($"ID - {emp.ID}, {emp.FirstName} {emp.LastName}");
            }
        }
    }
}
