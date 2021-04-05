using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.PageObjects
{
    public class RegistrationPO : TemplatePO
    {
        private By _byPersonalFirstNameField => By.Id("customer_firstname");
        private By _byPersonalLastNameField => By.Id("customer_lastname");
        private By _byPersonalPasswordField => By.Id("passwd");
        private By _byAddressFirstNameField => By.Id("firstname");
        private By _byAddressLastNameField => By.Id("lastname");
        private By _byAddressAddressField => By.Id("address1");
        private By _byAddressCityField => By.Id("city");
        private By _byAddressStateDropDown => By.Id("id_state");
        private By _byAddressZipField => By.Id("postcode");
        private By _byAddressCountryDropDown => By.Id("id_country");
        private By _byAddressMobilePhoneField => By.Id("phone_mobile");
        private By _byRegisterBtn => By.Id("submitAccount");

        public RegistrationPO(IWebDriver driver) : base(driver)
        {

        }

        public void ToFillPersonalPart(string firstName, string lastName, string password)
        {
            IWebElement personalFirstNameField = _driver.FindElement(_byPersonalFirstNameField);
            personalFirstNameField.SendKeys(firstName);

            IWebElement personalLastNameField = _driver.FindElement(_byPersonalLastNameField);
            personalLastNameField.SendKeys(lastName);

            IWebElement personalPasswordField = _driver.FindElement(_byPersonalPasswordField);
            personalPasswordField.SendKeys(password);
        }

        private void ToSelectAStateFromDropDown(string state)
        {
            IWebElement addressStateDropDown = _driver.FindElement(_byAddressStateDropDown);
            SelectElement selectElement = new SelectElement(addressStateDropDown);
            selectElement.SelectByText(state);
        }

        private void ToSelectACountryFromDropDown(string country)
        {
            IWebElement addressCountryDropDown = _driver.FindElement(_byAddressCountryDropDown);
            SelectElement selectElement = new SelectElement(addressCountryDropDown);
            selectElement.SelectByText(country);
        }

        public void ToFillAddressPart(string firstName, string lastName, string address,
            string city, string state, string country, string zip, string mobilePhone)
        {
            IWebElement addressFirstNameField = _driver.FindElement(_byAddressFirstNameField);
            addressFirstNameField.SendKeys(firstName);

            IWebElement addressLastNameField = _driver.FindElement(_byAddressLastNameField);
            addressLastNameField.SendKeys(lastName);

            IWebElement addressAddressField = _driver.FindElement(_byAddressAddressField);
            addressAddressField.SendKeys(address);

            IWebElement addressCityField = _driver.FindElement(_byAddressCityField);
            addressCityField.SendKeys(city);

            IWebElement addressZipField = _driver.FindElement(_byAddressZipField);
            addressZipField.SendKeys(zip);

            IWebElement addressMobilePhoneField = _driver.FindElement(_byAddressMobilePhoneField);
            addressMobilePhoneField.SendKeys(mobilePhone);

            ToSelectAStateFromDropDown(state);
            ToSelectACountryFromDropDown(country);
        }

        public void ToClickRegisterBtn()
        {
            IWebElement registerBtn = _driver.FindElement(_byRegisterBtn);
            registerBtn.Click();
        }
    }
}
