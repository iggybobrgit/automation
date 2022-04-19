using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using HabrPageObjectModel;


namespace AuthBananaPageTest
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        public  void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "https://habr.com/ru/all";
            driver.Manage().Window.Maximize();
        }


        [TestMethod]
        public void TestMainPageTitle ()
        {
            SetUp();
            Assert.AreEqual("Все публикации подряд / Хабр", driver.Title);
            driver.Close();
        }


        [TestMethod]
        public void PositiveLogin()
        {
            SetUp();
            var mainPage = new HabrMainPageObject(driver);
            var auth = mainPage.OpenSignInMenu();
            auth.Login("iggybobr@gmail.com", "99659965");
            Assert.AreEqual("Моя лента", mainPage.GetLoggedInSign());
            driver.Close();
        }

        [TestMethod]
        public void LoginWithoutPassword()
        {
            SetUp();
            var mainPage = new HabrMainPageObject(driver);
            var auth = mainPage.OpenSignInMenu();
            auth.Login("iggybobr@gmail.com", "");
            Assert.AreEqual("Введите пароль",auth.GetNoPasswordMessage());
            driver.Close();
        }

        [TestMethod]
        public void LoginWithoutEmail()
        {
            SetUp();
            var mainPage = new HabrMainPageObject(driver);
            var auth = mainPage.OpenSignInMenu();
            auth.Login("", "1234");
            Assert.AreEqual("Введите корректный e-mail", auth.GetNoEmailMessage());
            driver.Close();
        }

        [TestMethod]
        public void LoginWithoutCredentials()
        {
            SetUp();
            var mainPage = new HabrMainPageObject(driver);
            var auth = mainPage.OpenSignInMenu();
            auth.Login("", "");
            Assert.AreEqual("Введите корректный e-mail", auth.GetNoEmailMessage());
            Assert.AreEqual("Введите пароль", auth.GetNoPasswordMessage());
            driver.Close();
        }

        [TestMethod]
        public void LogOut()
        {
            SetUp();
            var mainPage = new HabrMainPageObject(driver);
            var auth = mainPage.OpenSignInMenu();
            auth.Login("iggybobr@gmail.com", "99659965");
            mainPage.LogOut();
            Assert.AreNotEqual("Моя лента", mainPage.GetLoggedInSign());
            driver.Close();
        }

    }
}
