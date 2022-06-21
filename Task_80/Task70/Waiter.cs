using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Task80
{
    public static class ExplicitWaiter
    {
        public static void WaitElement(IWebDriver webDriver, By locator, int seconds = 30)
        {
            try
            {
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementIsVisible(locator));
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new NotFoundException($"Cannot find specific location: {locator}", ex);
            }

        }
    }
}