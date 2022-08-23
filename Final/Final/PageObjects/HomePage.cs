using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.PageObjects
{
    public class HomePage
    {
        private static IWebDriver _driver;
        private string _login = "";
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement newUserEmailAddressField => _driver.FindElement(By.Id("email_create"));
        public IWebElement createNewAccountButton => _driver.FindElement(By.Id("SubmitCreate"));
        public IWebElement emailAddressField => _driver.FindElement(By.Id("email"));
        public IWebElement passwordField => _driver.FindElement(By.Id("passwd"));
        public IWebElement signInButton => _driver.FindElement(By.Id("SubmitLogin"));
        public IWebElement cartButton => _driver.FindElement(By.XPath("//a[@title='View my shopping cart']"));
        public IWebElement logOutButton => _driver.FindElement(By.ClassName("logout"));



        public void CreateNewAccount(string emailAddress)
        {
            newUserEmailAddressField.SendKeys(emailAddress);
            createNewAccountButton.Click();
        }

        public void LogIn(string email, string password)
        {
            emailAddressField.SendKeys(email);
            passwordField.SendKeys(password);
            signInButton.Click();
        }

        public void LogOut()
        {
            logOutButton.Click();
        }
    }
}