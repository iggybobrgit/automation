using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace YandexPOM
{
    public class YandexMailMainPage
    {
        private IWebDriver _webDriver;

        private readonly By _enterButton = By.XPath("//div[@class = 'desk-notif-card__login-new-item-title']");
        private readonly By _userName = By.XPath("//span[contains(text(), 'ggybobr')]");

        public YandexMailMainPage(IWebDriver webdriver)
        {
            _webDriver = webdriver;
        }


        public AuthorizationPage OpenSignInMenu()
        {
            _webDriver.FindElement(_enterButton).Click();
            return new AuthorizationPage(_webDriver);
        }

        public string GetLoggedInSign()
        {
            ExplicitWaiter.WaitElement(_webDriver, _userName);
            return _webDriver.FindElement(_userName).Text;

        }
    }
}
