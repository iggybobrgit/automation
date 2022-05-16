using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Selenium_Task20
{
    public class Elements
    {
        private IWebDriver driver;
     
        public void FindElements()
        {
            var xpathElement = driver.FindElement(By.XPath("//div[@class = 'desk-notif-card__login-new-item-title']"));
            var idElement = driver.FindElement(By.Id("passp-field-login"));
            var nameElement = driver.FindElement(By.Name("text"));
            var tagElement = driver.FindElement(By.TagName("h1"));
            var classNameElement = driver.FindElement(By.ClassName("b-time-banner__place"));
            var cssElement = driver.FindElement(By.CssSelector("div.home-arrow__search-wrapper"));
            var linkTextElement = driver.FindElement(By.LinkText("About"));
            var partiallinkTextElement = driver.FindElement(By.PartialLinkText("Установите быстрый"));

        }
    }
}