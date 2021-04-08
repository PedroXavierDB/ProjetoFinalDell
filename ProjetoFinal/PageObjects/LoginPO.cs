using OpenQA.Selenium;

namespace ProjetoFinal.PageObjects
{
    public class LoginPO : TemplatePO
    {
        private By _bySignInEmailField => By.Id("email_create");
        private By _bySignInBtn => By.Id("SubmitCreate");
        private By _byLoginEmailField => By.Id("email");
        private By _byLoginPasswordField => By.Id("passwd");
        private By _byLoginBtn => By.Id("SubmitLogin");
        private By _byForgotPasswordBtn => By.CssSelector("#login_form > div > p.lost_password.form-group > a");

        public LoginPO(IWebDriver driver) : base(driver)
        {

        }

        public void ToFillSignInEmailField(string email)
        {
            IWebElement signInEmailField = _driver.FindElement(_bySignInEmailField);
            signInEmailField.SendKeys(email);
        }

        public void ToClickSignInBtn()
        {
            IWebElement signInBtn = _driver.FindElement(_bySignInBtn);
            signInBtn.Click();
        }

        public void ToFillLoginEmailAndPasswordFields(string email, string password)
        {
            IWebElement loginEmailField = _driver.FindElement(_byLoginEmailField);
            loginEmailField.SendKeys(email);

            IWebElement loginPasswordField = _driver.FindElement(_byLoginPasswordField);
            loginPasswordField.SendKeys(password);
        }

        public void ToClickLoginBtn()
        {
            IWebElement loginBtn = _driver.FindElement(_byLoginBtn);
            loginBtn.Click();
        }

        public void ToClickForgotPasswordBtn()
        {
            IWebElement forgotPasswordBtn = _driver.FindElement(_byForgotPasswordBtn);
            forgotPasswordBtn.Click();
        }
    }
}
