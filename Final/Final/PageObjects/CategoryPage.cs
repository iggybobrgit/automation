using Final.AdditionalMethods;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.PageObjects
{
    public class CategoryPage
    {
        private static IWebDriver _driver;
        private string _wishlistSuccess = "//p[@class='fancybox-error']";
        public CategoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement productsTable => _driver.FindElement(By.XPath("//ul[contains(@class,'product_list grid row')]"));
        public IWebElement wishlistButton => _driver.FindElement(By.Id("wishlist_button"));
        public IWebElement closeButton => _driver.FindElement(By.XPath("//span[@class='cross']"));

        public Uri GetCategoryUrl(Enum category)
        {
            switch (category)
            {
                case Categories.Dresses:
                    return new Uri("http://automationpractice.com/index.php?id_category=8&controller=category");
                    break;
                case Categories.TShirts:
                    return new Uri("http://automationpractice.com/index.php?id_category=5&controller=category");
                    break;
                case Categories.Women:
                    return new Uri("http://automationpractice.com/index.php?id_category=3&controller=category");
                    break;
                default: throw new ArgumentException("Invalid category");
            }

        }

        public void NavigateToCategory(Enum category)
        {
            _driver.Navigate().GoToUrl(GetCategoryUrl(category));
        }

        public IEnumerable<IWebElement> GetAllProduct()
        {
            return _driver.FindElements(By.XPath("//ul[contains(@class,'product_list grid row')]/li"));
        }

        public IEnumerable<IWebElement> GettAllLinksToProduct()
        {
            return _driver.FindElements(By.XPath("//ul[contains(@class,'product_list grid row')]/li//a[contains(@class,'product_img_link')]"));
        }

        public bool IsLoaded(string xpath)
        {
            return (Waiter.WaitElement(_driver, By.XPath(xpath)));
        }

        public string AddRandomProductToWishlist(Enum category)
        {
            var productDetail = new ProductDetailPage(_driver);
            var random = new Random();

            NavigateToCategory(category);
            var links = GettAllLinksToProduct();
            links.OrderBy(x => random.Next()).Take(1).First().Click();
            productDetail.IsLoaded();
            _driver.SwitchTo().Frame(productDetail.productFrame);
            var name = productDetail.GetProductName();
            productDetail.addToWishlistButton.Click();
            productDetail.ProductSuccessfullyAddedToCart();

            return name;
        }

        public string AddRandomProductToCart(Enum category)
        {
            var productDetail = new ProductDetailPage(_driver);
            var random = new Random();

            NavigateToCategory(category);
            var links = GettAllLinksToProduct();
            var link = links.OrderBy(x => random.Next(0, links.Count())).First();
            link.Click();
            productDetail.IsLoaded();
            _driver.SwitchTo().Frame(productDetail.productFrame);
            
               
            var name = productDetail.GetProductName();
            productDetail.addToCartButton.Click();

            _driver.SwitchTo().ParentFrame();
            productDetail.ProductSuccessfullyAddedToCart();
            closeButton.Click();

            return name;
        }
    }
}