using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.AdditionalMethods;

namespace Final.PageObjects
{
    class AddAccPage
    {
        private static IWebDriver _driver;
        private string _accountCreationForm = "account_creation";
        public AddAccPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement titleMrRadioButton => _driver.FindElement(By.Id("id_gender1"));
        public IWebElement titleMrsRadioButton => _driver.FindElement(By.Id("id_gender2"));
        public IWebElement firstNamePersonalField => _driver.FindElement(By.Id("customer_firstname"));
        public IWebElement lastNamePersonalField => _driver.FindElement(By.Id("customer_lastname"));
        public IWebElement emailPersonalField => _driver.FindElement(By.Id("email"));
        public IWebElement passswordField => _driver.FindElement(By.Id("passwd"));
        public IWebElement dayDOBDropdown => _driver.FindElement(By.Id("days"));
        public IWebElement monthDOBDropdown => _driver.FindElement(By.Id("months"));
        public IWebElement yearsDOBDropdown => _driver.FindElement(By.Id("years"));
        public IWebElement newsLetterCheckbox => _driver.FindElement(By.Id("newsletter"));
        public IWebElement specialOffersCheckbox => _driver.FindElement(By.Id("optin"));
        public IWebElement firstNameAddresslField => _driver.FindElement(By.Id("firstname"));
        public IWebElement lastNameAddresslField => _driver.FindElement(By.Id("lastname"));
        public IWebElement companyNameField => _driver.FindElement(By.Id("company"));
        public IWebElement address1Field => _driver.FindElement(By.Id("address1"));
        public IWebElement address2Field => _driver.FindElement(By.Id("address2"));
        public IWebElement cityField => _driver.FindElement(By.Id("city"));
        public IWebElement stateDropdown => _driver.FindElement(By.Id("id_state"));
        public IWebElement zipCodeField => _driver.FindElement(By.Id("postcode"));
        public IWebElement countryDropdown => _driver.FindElement(By.Id("id_country"));
        public IWebElement additionalInformationField => _driver.FindElement(By.Id("other"));
        public IWebElement homePhoneField => _driver.FindElement(By.Id("phone"));
        public IWebElement mobilePhoneField => _driver.FindElement(By.Id("phone_mobile"));
        public IWebElement addressAliasField => _driver.FindElement(By.Id("alias"));
        public IWebElement registerButton => _driver.FindElement(By.Id("submitAccount"));
        public IWebElement accountCreationForm => _driver.FindElement(By.ClassName(_accountCreationForm));

        public void SelectDayDOB(string day)
        {
            var dayDOB = new SelectElement(dayDOBDropdown);
            dayDOB.SelectByText(day);
        }

        public void SelectMonthDOB(string month)
        {
            var dayDOB = new SelectElement(monthDOBDropdown);
            dayDOB.SelectByText(month);
        }

        public void SelectYearhDOB(string year)
        {
            var dayDOB = new SelectElement(yearsDOBDropdown);
            dayDOB.SelectByText(year);
        }

        public void SelectState(string state)
        {
            var dayDOB = new SelectElement(stateDropdown);
            dayDOB.SelectByText(state);
        }

        public void SelectCountry(string country)
        {
            var dayDOB = new SelectElement(countryDropdown);
            dayDOB.SelectByText(country);
        }

        public void AddNewMember(User member)
        {
            if (member.TitleMr != default) { titleMrRadioButton.Click(); }
            if (member.TitleMrs != default) { titleMrsRadioButton.Click(); }

            firstNamePersonalField.SendKeys(member.FirstNamePersonal);
            lastNamePersonalField.SendKeys(member.LastNamePersonal);

            passswordField.SendKeys(member.Password);

            if (member.DayDOB != default) { SelectDayDOB($"{member.DayDOB}  "); }
            if (member.MonthDOB != default) { SelectMonthDOB($"{member.MonthDOB.ToString()} "); }
            if (member.YearDOB != default) { SelectYearhDOB($"{member.YearDOB}  "); }

            if (member.Newsletter != default) { newsLetterCheckbox.Click(); }
            if (member.SpecialOffers != default) { specialOffersCheckbox.Click(); }
            if (member.Company != default) { companyNameField.SendKeys(member.Company); }
            if (member.Address2 != default) { address2Field.SendKeys(member.Address2); }
            if (member.AdditionalInformation != default) { additionalInformationField.SendKeys(member.AdditionalInformation); }
            if (member.HomePhone != default) { homePhoneField.SendKeys(member.HomePhone); }

            if (member.FirstNameAddress != member.FirstNamePersonal)
            {
                firstNameAddresslField.Clear();
                firstNameAddresslField.SendKeys(member.FirstNameAddress);
            }

            if (member.LastNameAddress != member.LastNamePersonal)
            {
                lastNameAddresslField.Clear();
                lastNameAddresslField.SendKeys(member.LastNameAddress);
            }

            address1Field.SendKeys(member.Address1);
            cityField.SendKeys(member.City);
            SelectState(member.State);
            zipCodeField.SendKeys(member.ZipCode);
            mobilePhoneField.SendKeys(member.MobilePhone);

            addressAliasField.Clear();
            addressAliasField.SendKeys(member.AddressAlias);
            registerButton.Click();
        }

        public bool IsLoaded()
        {
            return ((Waiter.WaitElement(_driver, By.ClassName(_accountCreationForm))));
        }
    }
}