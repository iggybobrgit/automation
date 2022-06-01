using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task80
{
    public static class SS
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\igorbobrov\Documents\ss(" + @DateTime.Now.ToString("yyyy-MM-dd_HH-mm-fff") + @").png", ScreenshotImageFormat.Png);
        }
        }
    }

