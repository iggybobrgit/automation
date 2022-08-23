using Final.AdditionalMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.PageObjects
{
    public class ProductDetailPage
    {
        private static IWebDriver _driver;
        private static string _productFrame = "//iframe[contains(@id, 'fancybox')]";
        private static string _successIcon = "//i[@class='icon-ok']";
        public ProductDetailPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement addToWishlistButton => _driver.FindElement(By.Id("wishlist_button"));
        public IWebElement productFrame => _driver.FindElement(By.XPath(_productFrame));
        public IWebElement productName => _driver.FindElement(By.XPath("//h1[contains(@itemprop,'name')]"));
        public IWebElement addToCartButton => _driver.FindElement(By.Id("add_to_cart"));
        public IWebElement successIcon => _driver.FindElement(By.XPath(_successIcon));

        public bool IsLoaded()
        {
            return (Waiter.WaitElement(_driver, By.XPath(_productFrame)));
        }

        public bool ProductSuccessfullyAddedToCart()
        {
            return (Waiter.WaitElement(_driver, By.XPath(_successIcon)));
        }

        public string GetProductName()
        {
            return productName.Text;
        }
    }
}