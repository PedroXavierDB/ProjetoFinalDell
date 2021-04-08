using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.PageObjects
{
    public class ForgotPasswordPO : TemplatePO
    {
        private By _byEmailField => By.Id("email");
        private By _byRetrievePasswordBtn => By.CssSelector("#form_forgotpassword > fieldset > p > button");
        public ForgotPasswordPO(IWebDriver driver) : base(driver)
        {

        }

        public void WriteOnEmailBox(string email)
        {
            IWebElement emailField = _driver.FindElement(_byEmailField);
            emailField.SendKeys(email);
        }

        public void ToClickRetrievePasswordBtn()
        {
            IWebElement retrievePasswordForm = _driver.FindElement(_byRetrievePasswordBtn);
            retrievePasswordForm.Click();
        }
    }
}
