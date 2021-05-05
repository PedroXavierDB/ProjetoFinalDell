using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects
{
    public class LoginPO
    {
        private IWebDriver _driver;
        private By byUsernameBoxId;
        private By byPasswordBoxId;
        private By byLoginFormId;
        private By byErrorMessageBoxId;

        public LoginPO(IWebDriver driver)
        {
            _driver = driver;
            byUsernameBoxId = By.Id("username");
            byPasswordBoxId = By.Id("password");
            byLoginFormId = By.Id("login");
            byErrorMessageBoxId = By.Id("flash");
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/login");
        }

        public void WriteLoginData(string username, string password)
        {
            IWebElement usernameBox = _driver.FindElement(byUsernameBoxId);
            IWebElement passwordBox = _driver.FindElement(byPasswordBoxId);

            usernameBox.SendKeys(username);
            passwordBox.SendKeys(password);
        }

        public void ClickLoginBtn()
        {
            IWebElement loginForm = _driver.FindElement(byLoginFormId);
            loginForm.Submit();
        }

        public string GetErrorMessage()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IWebElement errorField = wait.Until(driver => driver.FindElement(byErrorMessageBoxId));

            return errorField.Text;
        }
    }
}
