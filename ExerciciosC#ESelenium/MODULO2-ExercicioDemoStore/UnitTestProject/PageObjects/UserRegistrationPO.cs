using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.PageObjects
{
    public class UserRegistrationPO : TemplatePO
    {
        private By byUserDropBoxId;
        private By byUserDropBoxRegisterBtnXPath;
        private By byFirstNameBoxId;
        private By byLastNameBoxId;
        private By byPhoneNumberBoxId;
        private By byEmailBoxId;
        private By byPasswordBoxId;
        private By byConfirmPasswordBoxId;
        private By byBirthdayBoxId;
        //private By byRecaptchaId;
        private By byRegisterBtnXPath;
        private By byCloseBarBtnId;

        public UserRegistrationPO(IWebDriver driver) : base(driver)
        {
            byUserDropBoxId = By.Id("sw_dropdown_4");
            byUserDropBoxRegisterBtnXPath = By.XPath("/html/body/div[2]/div[4]/div[1]/div/div/div[3]/div/div[2]/div/div[2]/a[2]");
            byFirstNameBoxId = By.Id("elm_6");
            byLastNameBoxId = By.Id("elm_7");
            byPhoneNumberBoxId = By.Id("elm_9");
            byEmailBoxId = By.Id("email");
            byPasswordBoxId = By.Id("password1");
            byConfirmPasswordBoxId = By.Id("password2");
            byBirthdayBoxId = By.Id("birthday");
            //byRecaptchaId = By.Id("recaptcha-anchor");
            byRegisterBtnXPath = By.XPath("/html/body/div[2]/div[4]/div[3]/div/div[2]/div[1]/div/div/div/form/div[8]/button");
            byCloseBarBtnId = By.Id("bp_off_bottom_panel");
        }

        public void CompleteRegistrationForm(string firstName, string lastName, string phoneNumber,
            string email, string password, string birthday)
        {
            IWebElement firstNameBox = _driver.FindElement(byFirstNameBoxId);
            IWebElement lastNameBox = _driver.FindElement(byLastNameBoxId);
            IWebElement phoneNumberBox = _driver.FindElement(byPhoneNumberBoxId);
            IWebElement emailBox = _driver.FindElement(byEmailBoxId);
            IWebElement passwordBox = _driver.FindElement(byPasswordBoxId);
            IWebElement confirmPasswordBox = _driver.FindElement(byConfirmPasswordBoxId);
            IWebElement birthdayBox = _driver.FindElement(byBirthdayBoxId);
            //IWebElement recaptcha = _driver.FindElement(byRecaptchaId);

            firstNameBox.Clear();
            firstNameBox.SendKeys(firstName);
            lastNameBox.Clear();
            lastNameBox.SendKeys(lastName);
            phoneNumberBox.Clear();
            phoneNumberBox.SendKeys(phoneNumber);
            emailBox.Clear();
            emailBox.SendKeys(email);
            passwordBox.Clear();
            passwordBox.SendKeys(password);
            confirmPasswordBox.Clear();
            confirmPasswordBox.SendKeys(password);
            birthdayBox.Clear();
            birthdayBox.SendKeys(birthday);
            birthdayBox.SendKeys(Keys.Tab);
        }

        public void ClosePopUp()
        {
            IWebElement closeBarBtn = _driver.FindElement(byCloseBarBtnId);
            closeBarBtn.Click();
        }

        public void Register()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IWebElement registerBtn = wait
                .Until(SeleniumExtras
                .WaitHelpers
                .ExpectedConditions
                .ElementToBeClickable(byRegisterBtnXPath));

            registerBtn.Click();
        }

        public void GoToRegistrationPage()
        {
            IWebElement userDropBox = _driver.FindElement(byUserDropBoxId);
            userDropBox.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IWebElement registerBtn = wait
                .Until(SeleniumExtras
                .WaitHelpers
                .ExpectedConditions
                .ElementToBeClickable(byUserDropBoxRegisterBtnXPath));
            registerBtn.Click();
        }
    }
}
