using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace Task80
{
    public class YandexMainPage : BasePage
    {
        private readonly By _enterButton = By.XPath("//div[@class = 'desk-notif-card__login-new-item-title']");     
        private readonly By _settingButton = By.XPath("//a[@class= 'home-link usermenu-link__control home-link_black_yes']");
        private readonly By _exitButton = By.XPath("//a[@data-statlog='mail.login.usermenu.exit']");
   

        public YandexMainPage(IWebDriver webdriver)
        {
            _webDriver = webdriver;
        }


        public AuthorizationPage OpenSignInMenu()
        {
            _webDriver.FindElement(_enterButton).Click();
            return new AuthorizationPage(_webDriver);
        }

       
        public YandexMainPage Logout()
        {
            _webDriver.FindElement(_settingButton).Click();
            ExplicitWaiter.WaitElement(_webDriver, _exitButton);
            _webDriver.FindElement(_exitButton).Click();
            return new YandexMainPage(_webDriver);
        }
    }
}