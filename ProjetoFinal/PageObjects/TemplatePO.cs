﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.PageObjects
{
    public class TemplatePO
    {
        protected IWebDriver _driver;
        private By _bySignInBtn => By.ClassName("login");

        public TemplatePO(IWebDriver driver)
        {
            _driver = driver;
        }

        public void GoToLoginPage()
        {
            IWebElement signInBtn = _driver.FindElement(_bySignInBtn);
            signInBtn.Click();
        }
    }
}