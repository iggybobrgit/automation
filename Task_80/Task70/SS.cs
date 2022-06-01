using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task70
{
    public static class SS
    {
        //private static ITakesScreenshot driver;
       // private static DateTime date = DateTime.Now;

        public static void TakeScreenshot(IWebDriver driver)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\igorbobrov\Documents\ss(" + @DateTime.Now.ToString("yyyy-MM-dd_HH-mm-fff") + @").png", ScreenshotImageFormat.Png);
        }
        }
    }

