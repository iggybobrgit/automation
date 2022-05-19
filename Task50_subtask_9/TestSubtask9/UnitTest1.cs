using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Task50_subtask_9;



namespace TestSubtask9
{
    public class Tests
    {
        static IWebDriver _driver = new ChromeDriver();
        WebDriverWait _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));

        [SetUp]
        public void Setup()
        {
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/table-sort-search-demo.html");
        }

        [Test]
        public void Test1()
        {
            Table handleTable = new Table(_driver, _wait, 60, 200000);
            handleTable.SetNumberOfEntriesToTen();
            int resultNumber = handleTable.CustomTableHandle();
            Assert.AreEqual(1, resultNumber);
        }
    }
}