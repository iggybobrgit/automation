using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Selenium_Task20
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _signInButton = By.XPath("//div[@class = 'desk-notif-card__login-new-item-title']");
        private readonly By _loginField = By.XPath("//input[@type = 'text']");
        private readonly By _submitLoginButton =By.XPath("//button[@type='submit']");
        private readonly By _passwordField = By.XPath("//input[@type= 'password']");
        private readonly By _submitPasswordButton = By.XPath("//button[@id = 'passp:sign-in']");
        private readonly By _userLogInFirstLetter = By.XPath("//span[@class = 'username__first-letter']");

        private const string _login = "iggybobr";
        private const string _password = "Panasonik99659965";

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://yandex.com");
        }

        [Test]
        public void PositiveLogin()
        {
         
            Thread.Sleep(10000);
            var signIn = driver.FindElement(_signInButton);
            signIn.Click();

            var loginEnter = driver.FindElement(_loginField);
            loginEnter.SendKeys(_login);

            var submitLoginButton = driver.FindElement(_submitLoginButton);
            submitLoginButton.Click();

            Thread.Sleep(1000);
            var passwordField = driver.FindElement(_passwordField);
            passwordField.SendKeys(_password);

            var submitPassButton = driver.FindElement(_submitPasswordButton);
            submitPassButton.Click();

            Thread.Sleep(1000);
            var firtsLoginLetter = driver.FindElement(_userLogInFirstLetter).Text;
            Assert.AreEqual("i", firtsLoginLetter);

            driver.Quit();

        }
    }
}