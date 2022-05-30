using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Task50_SubTask_6
{
    public class Tests
    {

        private IWebDriver _webDriver;

        private readonly By alertBoxButton =  By.XPath("//button[@onclick='myAlertFunction()']");
        string expectedAlertBoxText = "I am an alert box!";

        private readonly By confirmBoxButton = By.XPath("//button[@onclick='myConfirmFunction()']");
        private readonly By confirmResult = By.Id("confirm-demo");
        string  cancelConfirmText = "You pressed Cancel!";
        string okConfirmText = "You pressed OK!";

        private readonly By javaScriptButton = By.XPath("//button[@onclick='myPromptFunction()']");
        private readonly By javaScripConfirmResult = By.Id("prompt-demo");
        string expectedJavaScriptPromtText = "You have entered 'Hello, Igor' !";

        [SetUp]
        public void Setup()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl("https://demo.seleniumeasy.com/javascript-alert-box-demo.html");
        }

        [Test]
        public void JavaScriptAlertBoxCheck()
        {
            _webDriver.FindElement(alertBoxButton).Click();
            var alert = _webDriver.SwitchTo().Alert();
            Assert.AreEqual(expectedAlertBoxText, alert.Text);
            alert.Accept();
        }

        [Test]
        public void JavaScriptConfirmBoxOk()
        {
            _webDriver.FindElement(confirmBoxButton).Click();
            var alert = _webDriver.SwitchTo().Alert();
            alert.Accept();
            string okText = _webDriver.FindElement(confirmResult).Text;
            Assert.AreEqual(okConfirmText, okText);

        }

        [Test]
        public void JavaScriptConfirmBoxCancel()
        {
            _webDriver.FindElement(confirmBoxButton).Click();
            var alert = _webDriver.SwitchTo().Alert();
            alert.Dismiss();
            string cancelText = _webDriver.FindElement(confirmResult).Text;
            Assert.AreEqual(cancelConfirmText, cancelText);

        }

        [Test]
        public void JavaScriptAlertBoxTest()
        {
            _webDriver.FindElement(javaScriptButton).Click();
            var alert = _webDriver.SwitchTo().Alert();
            alert.SendKeys("Hello, Igor");
            alert.Accept();
            string res = _webDriver.FindElement(javaScripConfirmResult).Text;
            Assert.AreEqual(expectedJavaScriptPromtText, res);

        }


        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }

    }
}