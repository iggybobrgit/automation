using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task50_Subtask5
{
    public class VerifyMultiSelection
    {
        private IWebDriver _driver;
        private List<string> _optionsToSelect;
        private List<string> _selectedOptions;

        public VerifyMultiSelection(IWebDriver driver, List<string> optionsToSelect, List<string> selectedOptions)
        {
            _driver = driver;
            _optionsToSelect = optionsToSelect;
            _selectedOptions = selectedOptions;
        }

        public bool IsEqual()
        {
            return _optionsToSelect.SequenceEqual(_selectedOptions);
        }
    }
}
