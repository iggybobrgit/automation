using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using OpenQA.Selenium.Firefox;
using static Final.AdditionalMethods.BaseOptions;
using OpenQA.Selenium.Remote;
using Allure.Commons;
using Final.PageObjects;
using NUnit.Framework;
using System.Configuration;

namespace Final.AdditionalMethods
{
    public class BaseOptions
    {
        public static IWebDriver _driver;
        private static string _sauceUserName;
        private static string _sauceAccessKey;
        private static Dictionary<string, object> _sauceOptions;
        public static void BrowserSetup(string environment)
        {

            var env = (Environments)Enum.Parse(typeof(Environments), environment, true);

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

                case Environments.SauceLabMozilla:
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

                case Environments.SauceLabChrome:
                    _sauceUserName = Environment.GetEnvironmentVariable("igorbobrov");
                    _sauceAccessKey = Environment.GetEnvironmentVariable("ed2c19f2-9c04-413a-8de6-74b5b3aa5e40");
                    _sauceOptions = new Dictionary<string, object>
                    {
                        ["username"] = _sauceUserName,
                        ["accessKey"] = _sauceAccessKey,
                    };
                    _sauceOptions.Add("name", "Mozillaon8.1");
                    var browserOptions1 = new ChromeOptions()
                    {
                        BrowserVersion = "latest",
                        PlatformName = "Windows 8.1"
                    };

                    browserOptions1.AddAdditionalOption("sauce:options", _sauceOptions);
                    _driver = new RemoteWebDriver(new Uri("https://igorbobrov:ed2c19f2-9c04-413a-8de6-74b5b3aa5e40@ondemand.saucelabs.com/wd/hub"), browserOptions1.ToCapabilities(), TimeSpan.FromSeconds(30));
                    _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
                    break;

                case Environments.SelenoidChrome:
                    var driverOptions = new ChromeOptions();
                    _driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), driverOptions);
                    _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
                    break;

                case Environments.SelenoidMozilla:
                    var driverOptions1 = new FirefoxOptions();
                    _driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4444/wd/hub"), driverOptions1);
                    _driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
                    break;

            }

        }

        public static void BrowserExit()
        {
            _driver.Quit();
        }

        public static void ScreenshotFail()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString() == "Failed")
            {
                AllureLifecycle.Instance.AddAttachment(
                    TestContext.CurrentContext.Test.MethodName + " screenshot" + DateTime.Now + ".png", "image/png",
                    Screenshots.Take(_driver));
            }
            
        }

    }
}