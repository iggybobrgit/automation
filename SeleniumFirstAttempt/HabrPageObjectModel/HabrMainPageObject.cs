using OpenQA.Selenium;


namespace HabrPageObjectModel
{
    public class HabrMainPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _loginInButton = By.XPath("//*[@data-test-id='menu-toggle-guest']");
        private readonly By _enterButton = By.XPath("//*[@class='tm-user-menu__auth-button']");
        private readonly By _signOfLogin = By.XPath("//a[@class = 'tm-main-menu__item']");
        private readonly By _userMenuButton = By.XPath("//div[@data-test-id = 'menu-toggle-user']");
        private readonly By _exitButton = By.XPath("//a[@href = 'https://habr.com/kek/v1/auth/logout2/776873391/?back=/ru/all/']");

        public HabrMainPageObject(IWebDriver webdriver)
        {
            _webDriver = webdriver;
        }



        public AuthorizationPageObject OpenSignInMenu()
        {
            Waiter.WaitElement(_webDriver, _loginInButton);
            _webDriver.FindElement(_loginInButton).Click();
            Waiter.WaitElement(_webDriver, _enterButton);
            _webDriver.FindElement(_enterButton).Click();
            return new AuthorizationPageObject(_webDriver);
        }

        public void OpenUserMenu()
        {
            Waiter.WaitElement(_webDriver, _userMenuButton);
            _webDriver.FindElement(_userMenuButton).Click();

        }

        public void LogOut()
        {
            Waiter.WaitElement(_webDriver, _userMenuButton);
            OpenUserMenu();
            Waiter.WaitElement(_webDriver, _exitButton);
            _webDriver.FindElement(_exitButton).Click();

        }
        
        public string GetLoggedInSign()
        {

            Waiter.WaitElement(_webDriver, _signOfLogin);
            return _webDriver.FindElement(_signOfLogin).Text;
            
        }

    }
}
