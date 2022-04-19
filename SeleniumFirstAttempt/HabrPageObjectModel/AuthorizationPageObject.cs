using OpenQA.Selenium;


namespace HabrPageObjectModel
{
    public class AuthorizationPageObject
    {
        private IWebDriver _webdriver;
        private readonly By _submitButton = By.XPath("//button[@type = 'submit']");
        private readonly By _emailField = By.XPath("//input[@id= 'email_field']");
        private readonly By _passField = By.XPath("//input[@id= 'password_field']");
        private readonly By _noPassText = By.XPath("//input[@type = 'password']/following-sibling::div[@class = 's-error']");
        private readonly By _noEmailText = By.XPath("//input[@type = 'email']/following-sibling::div[@class = 's-error']");

        public AuthorizationPageObject(IWebDriver webdriver)
        {
            _webdriver = webdriver;
        }

        public HabrMainPageObject Login (string login, string password)
        {
            Waiter.WaitElement(_webdriver, _emailField);
            _webdriver.FindElement(_emailField).SendKeys(login);
            _webdriver.FindElement(_passField).SendKeys(password);
            _webdriver.FindElement(_submitButton).Click();
            return new HabrMainPageObject(_webdriver);
        }
      

        public string GetNoPasswordMessage()
        {
            Waiter.WaitElement( _webdriver, _noPassText);
            return _webdriver.FindElement(_noPassText).Text;
        }


        public string GetNoEmailMessage()
        {
            Waiter.WaitElement(_webdriver, _noEmailText);
            return _webdriver.FindElement(_noEmailText).Text;
        }

    }
}
