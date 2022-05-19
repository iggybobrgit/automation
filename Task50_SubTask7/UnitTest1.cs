using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Task50_SubTask7
{
    public class Tests
    {
        static IWebDriver _webDriver = new ChromeDriver();

        private readonly By getUserButton = By.Id("save");
        private readonly By namePresence = By.Id("loading");

        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

        [SetUp]
        public void Setup()
        {
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://demo.seleniumeasy.com/dynamic-data-loading-demo.html");
        }

        [Test]
        public void Test1()
        {
            _webDriver.FindElement(getUserButton).Click();
            var element = _webDriver.FindElement(namePresence);
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, "First Name"));
            wait.Until(ExpectedConditions.TextToBePresentInElement(element, "Last Name"));

        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}