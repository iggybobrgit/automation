using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Task50_Subtask8
{
    public class Tests
    {

        static IWebDriver _webDriver = new ChromeDriver();
      
        WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(60));

        private readonly By downloadButton = By.Id("cricle-btn");
        private readonly By percentageProgress = By.ClassName("percenttext");


        [SetUp]
        public void Setup()
        {

            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://demo.seleniumeasy.com/bootstrap-download-progress-demo.html");
        }

        [Test]
        public void Test1()
        {
            _webDriver.FindElement(downloadButton).Click();
            var percentStatus = _webDriver.FindElement(percentageProgress);
            wait.Until(ExpectedConditions.TextToBePresentInElement(percentStatus, "50"));
            _webDriver.Navigate().Refresh();
            wait.Until(ExpectedConditions.ElementIsVisible(percentageProgress));
            var zeroValue = _webDriver.FindElement(percentageProgress).Text;
            Assert.AreEqual("0%", zeroValue);
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}