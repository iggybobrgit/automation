using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task80
{
    public class BasePage
    {
        protected IWebDriver _webDriver;

        private readonly By _userName = By.XPath("//div[@class='desk-notif-card__domik-user usermenu-link i-bem']");
        private readonly By _loggedoutSign = By.XPath("//div[@class = 'desk-notif-card__login-new-items']/descendant::div[2]");


        public string GetLoggedInSign()
        {
            ExplicitWaiter.WaitElement(_webDriver, _userName);
            return _webDriver.FindElement(_userName).Text;
        }
        public string GetLoggedOutSign()
        {
            ExplicitWaiter.WaitElement(_webDriver, _loggedoutSign);
            return _webDriver.FindElement(_loggedoutSign).Text;
        }



    }
}
