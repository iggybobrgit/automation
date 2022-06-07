using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace YandexPOM
{
    public class YandexMailPage
    {
        private IWebDriver _webDriver;

        public YandexMailPage(IWebDriver webdriver)
        {
            _webDriver = webdriver;
        }
    }
}
