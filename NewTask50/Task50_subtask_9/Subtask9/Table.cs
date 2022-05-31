using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task50_subtask_9
{
   public class Table
    {
        static IWebDriver _driver;
        static WebDriverWait _wait;

        private readonly By tableRowTr = By.CssSelector("tbody tr");
        private readonly By tableRowTd = By.CssSelector("tbody td");
        private readonly By nextButtonId = By.Id("example_next");
        private readonly By numberOfEntries = By.Name("example_length");
        List<List<string>> grid = new List<List<string>>();
        private readonly By numberOfTablePages = By.XPath("//div[@id='example_paginate']/span/a");

        private int _Age;
        private int _Salary;


        public Table(IWebDriver driver, WebDriverWait wait, int Age, int Salary)
        {
            _driver = driver;
            _wait = wait;
            _Age = Age;
            _Salary = Salary;
        }

        public int CustomTableHandle()
        {
            IWebElement nextButton = _driver.FindElement(nextButtonId);
            int numberOfPages = _driver.FindElements(numberOfTablePages).Count;

            for (int i = 0; i < numberOfPages; i++)
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(nextButtonId));
                var tableRow = _driver.FindElements(tableRowTr).Select(x => x.FindElements(tableRowTd).Select(x => x)).ToList();
                grid.AddRange(tableRow.Select(x => x.Select(x => x.Text).ToList()));
                _driver.FindElement(nextButtonId).Click();
            }

            var result = grid.Select(x => new Grid(x)).Where(x => x.Age > _Age & x.Salary <= _Salary).ToList();

            return result.Count;
        }

        public void SetNumberOfEntriesToTen()
        {
            SelectElement oSelect = new SelectElement(_driver.FindElement(numberOfEntries));
            string entriesNumber = oSelect.SelectedOption.Text;

            if (entriesNumber != "10")
            {
                oSelect.SelectByText("10");
            }
        }
    }
}