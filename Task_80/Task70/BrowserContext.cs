using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task80
{
    public class BrowserContext
    {
        private static IWebDriver driver;
        public static IWebDriver BrowserSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://yandex.com");
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(7);
            MakeScreenshot.TakeScreenshot(driver);
            return driver;
        }

        public static void BrowserExit()
        {            
            driver.Quit();
        }
    }
}
