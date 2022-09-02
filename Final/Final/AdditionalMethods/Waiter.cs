using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Final.AdditionalMethods
{
    public class Waiter
    {
        static public bool WaitElement(IWebDriver driver, By path)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                return (wait.Until(driver => driver.FindElement(path).Displayed));
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}