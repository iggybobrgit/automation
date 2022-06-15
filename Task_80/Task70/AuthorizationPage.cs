using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Task80
{
    public class AuthorizationPage : BasePage
    {
        private readonly By _idField = By.XPath("//input[@id='passp-field-login']");
        private readonly By _confirmButton = By.XPath("//button[@type='submit']");
        private readonly By _passField = By.XPath("//input[@id='passp-field-passwd']");

        public AuthorizationPage(IWebDriver webdriver)
        {
            _webDriver = webdriver;
        }

        public AuthorizationPage EnterLogin(string login)
        {
            _webDriver.FindElement(_idField).SendKeys(login);
            ClickConfirmButton();
            return new AuthorizationPage(_webDriver);
        }

        public void ClickConfirmButton()
        {
            _webDriver.FindElement(_confirmButton).Click();
        }

        public YandexMainPage EnterPassword(string password)
        {
            _webDriver.FindElement(_passField).SendKeys(password);
            ClickConfirmButton();
            return new YandexMainPage(_webDriver);
        }


    }
}