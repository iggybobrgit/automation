using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using Task80;
using SeleniumExtras.WaitHelpers;


namespace YandexLoginTests
{
    public class Tests
    {
       private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = BrowserContext.BrowserSetup();           
        }

        [TestCase("iggybobr", "Panasonik99659965")]        
        public void YandexMailLogin(string login, string password)
        {           
            var mainPage = new YandexMainPage(driver);
            var signinMenu = mainPage.OpenSignInMenu();
            signinMenu.EnterLogin(login);
            signinMenu.EnterPassword(password);
            Assert.AreEqual(login, mainPage.GetLoggedInSign());
        }

        [TestCase("iggybobr", "Panasonik99659965")]
        public void YandexMailLogOut(string login, string password)
        {
            var mainPage = new YandexMainPage(driver);
            var signinMenu = mainPage.OpenSignInMenu();
            signinMenu.EnterLogin(login);
            signinMenu.EnterPassword(password);
            mainPage.Logout();
            Assert.AreEqual("Войти", mainPage.GetLoggedOutSign());      
        }

        [TearDown]
        public void TearDown()
        {
            BrowserContext.BrowserExit();
        }
    }
}