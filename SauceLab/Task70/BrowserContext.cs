using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task80
{
    public class BrowserContext
    {
        protected static IWebDriver driver;
        private static string _sauceUserName;
        private static string _sauceAccessKey;
        private static Dictionary<string, object> _sauceOptions;
        public static void BrowserSetup()
        {
            {
                    _sauceUserName = Environment.GetEnvironmentVariable("igorbobrov");
                    _sauceAccessKey = Environment.GetEnvironmentVariable("ed2c19f2-9c04-413a-8de6-74b5b3aa5e40");
                    _sauceOptions = new Dictionary<string, object>
                    {
                        ["username"] = _sauceUserName,
                        ["accessKey"] = _sauceAccessKey,
                        ["name"] = "TestMozillaon8.1"
                    };

                var browserOptions = new FirefoxOptions
                {
                    BrowserVersion = "latest",
                    PlatformName = "Windows 8.1"
                };

                browserOptions.AddAdditionalOption("sauce:options", _sauceOptions);
                    driver = new RemoteWebDriver(new Uri("https://igorbobrov:ed2c19f2-9c04-413a-8de6-74b5b3aa5e40@ondemand.saucelabs.com/wd/hub"), browserOptions.ToCapabilities(),
                    TimeSpan.FromSeconds(30));
                    driver.Navigate().GoToUrl("https://yandex.by");
                    driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(7);          
            }
        }

        public static void BrowserExit()
        {
            driver.Quit();
        }
    }
}
