using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.PageObjects
{
    public class CartPage
    {
        private static IWebDriver _driver;
        private string _productName = "//td/p[@class='product-name']";
        public CartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement productDescription => _driver.FindElement(By.XPath(_productName));

        public List<string> GetAllProductNames()
        {
            return _driver.FindElements(By.XPath(_productName)).Select(x => x.Text).ToList();
        }
    }
}