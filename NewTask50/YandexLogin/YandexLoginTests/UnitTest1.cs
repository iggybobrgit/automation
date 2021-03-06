using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using YandexPOM;
using SeleniumExtras.WaitHelpers;


namespace YandexLoginTests
{
    public class Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://yandex.com");
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(7);

        }

        [TestCase("iggybobr", "Panasonik99659965")]
        [TestCase("iggybobr1", "Panasonik99659965")]
        public void YandexMailLogin(string login, string password)
        {
        
            var mainPage = new YandexMailMainPage(driver);
            var signinMenu = mainPage.OpenSignInMenu();
            signinMenu.EnterLogin(login);
            signinMenu.EnterPassword(password);
            Assert.AreEqual(login, mainPage.GetLoggedInSign());

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}