using Allure.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using static Final.AdditionalMethods.BrowserFactory;

namespace Final.AdditionalMethods
{
    public class BaseTest
    {
        public static void ScreenshotFail()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString() == "Failed")
            {
                AllureLifecycle.Instance.AddAttachment(
                    TestContext.CurrentContext.Test.MethodName + " screenshot" + DateTime.Now + ".png", "image/png",
                    Screenshots.Take(_driver));
            }

        }
    }
}
