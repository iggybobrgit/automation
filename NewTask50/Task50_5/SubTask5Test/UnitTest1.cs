using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;


namespace Task50_Subtask5
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckSelectedOptions()
        {
            var multiselect = new Multiselect(_driver);
            List<string> GetAllOptionsInMultiSelectDropdown = multiselect.GetAllOptions();
            VerifyMultiSelection verifyMultiSelection = multiselect.Verify(GetAllOptionsInMultiSelectDropdown);
            Assert.IsTrue(verifyMultiSelection.IsEqual());
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}