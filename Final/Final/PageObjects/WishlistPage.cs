using Final.AdditionalMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.PageObjects
{
    public class WishlistPage
    {
        private static IWebDriver _driver;
        private string _wishlistTable = "//table[@class='table table-bordered']";
        private string _wishlistViewButton = "//a[contains(@onclick, 'WishlistManage')]";
        private string _wishlistProductNameLable = "s_title";
        private string _wishlistUrl = "http://automationpractice.com/index.php?fc=module&module=blockwishlist&controller=mywishlist";
        public WishlistPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement wishlistTable => _driver.FindElement(By.XPath(_wishlistTable));
        public IWebElement wishlistNameField => _driver.FindElement(By.Id("name"));
        public IWebElement wishlistSaveButton => _driver.FindElement(By.Id("submitWishlist"));
        public IWebElement wishlistViewButton => _driver.FindElement(By.XPath(_wishlistViewButton));
        public IWebElement wishlistProductNameLable => _driver.FindElement(By.Id(_wishlistProductNameLable));

        public bool IsLoaded()
        {
            return (Waiter.WaitElement(_driver, By.XPath(_wishlistTable)));
        }

        public void NavigateToWishlist()
        {
            _driver.Navigate().GoToUrl(_wishlistUrl);
        }

        public void AddNewWishlist(string name)
        {
            wishlistNameField.SendKeys(name);
            wishlistSaveButton.Click();
        }

        public bool VerifyProductInWishlist(string productName)
        {
            wishlistViewButton.Click();
            Waiter.WaitElement(_driver, By.XPath(_wishlistProductNameLable));
            return wishlistProductNameLable.Text.Contains(productName);
        }

    }
}
