using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace Task50_Subtask5
{
    public class Multiselect
    {
        private IWebDriver _driver;

        private readonly By multiselectList = By.XPath("//select[@id='multi-select']");

        public Multiselect(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl("https://demo.seleniumeasy.com/basic-select-dropdown-demo.html");
        }
        public List<string> GetAllOptions()
        {
            _driver.FindElement(multiselectList);
            IWebElement multiElement = _driver.FindElement(multiselectList);
            SelectElement selectList = new SelectElement(multiElement);
            IList<IWebElement> options = selectList.Options;

            var allOptionsInList = options.Select(s => s.Text).ToList();

            return allOptionsInList;
        }

        public VerifyMultiSelection Verify(List<string> allOptions)
        {
            var random = new Random();
            var optionsToSelect = allOptions.OrderBy(s => random.Next()).Take(3).OrderBy(i => i).ToList();
            SelectElement city = new SelectElement(_driver.FindElement(multiselectList));
            city.SelectByText(optionsToSelect[0]);
            city.SelectByText(optionsToSelect[1]);
            city.SelectByText(optionsToSelect[2]);

            var selectedOptions = city.AllSelectedOptions.Select(s => s.Text).ToList();

            return new VerifyMultiSelection(_driver, optionsToSelect, selectedOptions);
        }
    }
}