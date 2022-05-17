using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace YandexPOM
{
    public static class ExplicitWaiter
    {
        public static void WaitElement(IWebDriver webDriver, By locator, int seconds = 10)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch(WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Cannot find specific location: {locator}", ex);
            }

        }
    }
}