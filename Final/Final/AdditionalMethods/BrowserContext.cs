using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Firefox;
using static Final.AdditionalMethods.BrowserContext;
using OpenQA.Selenium.Remote;

namespace Final.AdditionalMethods
{
    public class BrowserContext
    {
        protected static IWebDriver _driver;
        private static string _sauceUserName;
        private static string _sauceAccessKey;
        private static Dictionary<string, object> _sauceOptions;
        public static void BrowserSetup(Environments env)
        {

            switch (env)
            {
                case Environments.LocalChrome:
                    _driver = new ChromeDriver();
                    _driver.Manage().Window.Maximize();
                    _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
                    break;

                case Environments.LocalFireFox:
                    _driver = new FirefoxDriver();
                    _driver.Manage().Window.Maximize();
                    _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
                    break;

                case Environments.SauceLab:
                    _sauceUserName = Environment.GetEnvironmentVariable("igorbobrov");
                    _sauceAccessKey = Environment.GetEnvironmentVariable("ed2c19f2-9c04-413a-8de6-74b5b3aa5e40");
                    _sauceOptions = new Dictionary<string, object>
                    {
                        ["username"] = _sauceUserName,
                        ["accessKey"] = _sauceAccessKey,
                    };
                    _sauceOptions.Add("name", "Mozillaon8.1");
                    var browserOptions = new FirefoxOptions
                    {
                        BrowserVersion = "latest",
                        PlatformName = "Windows 8.1"
                    };

                    browserOptions.AddAdditionalOption("sauce:options", _sauceOptions);
                    _driver = new RemoteWebDriver(new Uri("https://igorbobrov:ed2c19f2-9c04-413a-8de6-74b5b3aa5e40@ondemand.saucelabs.com/wd/hub"), browserOptions.ToCapabilities(), TimeSpan.FromSeconds(30));
                    _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
                    break;

                case Environments.Selenoid:
                    var driverOptions = new ChromeOptions();
                    _driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), driverOptions);
                    _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
                    break;
            }

            

        }

        public static void BrowserExit()
        {
            _driver.Quit();
        }

        public enum Environments
        {
            LocalChrome,
            LocalFireFox,
            SauceLab,
            Selenoid
        }
    }
}