using OpenQA.Selenium;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Task80
{
    public static class SS
    {
        public static void TakeScreenshot(IWebDriver driver)
        {
            string path = Directory.GetCurrentDirectory();
            const string prName = "Test";
            var index = path.IndexOf(prName);
            var scrPath = path.Substring(0, index);

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@$"{scrPath}/Screenshots/" + @DateTime.Now.ToString("yyyy-MM-dd_HH-mm-fff") + @".png", ScreenshotImageFormat.Png);
        }
        }
    }

