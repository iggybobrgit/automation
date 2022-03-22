using System;
using System.Collections.Generic;

namespace Homework7
{
    class Homework7
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

            Console.WriteLine("Employess who can assign tasks: ");
            foreach (Employee worker in office.Employees)
            {
                if (worker is IAssigneTask)
                {
                    IAssigneTask task = (IAssigneTask)worker;
                    task.AssigneTask(worker.ID, worker.FirstName, worker.LastName);
                }
             }

            Console.WriteLine("Employess who can make code review: ");
            foreach (Employee worker in office.Employees)
            {
                if (worker is ICodeReview)
                {
                    ICodeReview task = (ICodeReview)worker;
                    task.CodeReview(worker.ID, worker.FirstName, worker.LastName);
                }
            }

            Console.WriteLine("Employess who can write a code: ");
            foreach (Employee worker in office.Employees)
            {
                if (worker is IWritingCode)
                {
                    IWritingCode task = (IWritingCode)worker;
                    task.CodeWriting(worker.ID, worker.FirstName, worker.LastName);
                }
            }

        }
    }
}
