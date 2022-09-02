using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.PageObjects
{
    public class MyAccPage
    {
        private static IWebDriver _driver;
        public MyAccPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement logoutButton => _driver.FindElement(By.XPath("//a[@class='logout']"));
        public IWebElement userInfo => _driver.FindElement(By.ClassName("header_user_info"));
        public IWebElement wishlistButton => _driver.FindElement(By.XPath("//span[normalize-space()='My wishlists']"));

        public void NavigateToWishlistPage()
        {
            wishlistButton.Click();
        }
    }
}