using OpenQA.Selenium;

namespace ProjetoFinal.PageObjects
{
    public class TemplatePO
    {
        protected IWebDriver _driver;
        private By _bySignInBtn => By.ClassName("login");
        private By _bySignOutBtn => By.ClassName("logout");
        private By _byLogoImg => By.ClassName("logo img-responsive");
        private By _bySearchBar => By.Id("search_query_top");

        public TemplatePO(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ToGoToLoginPage()
        {
            IWebElement signInBtn = _driver.FindElement(_bySignInBtn);
            signInBtn.Click();
        }

        public void SignOut()
        {
            IWebElement signOutBtn = _driver.FindElement(_bySignOutBtn);
            signOutBtn.Click();
        }

        public void ToGoToHomeByLogo()
        {
            IWebElement logoImg = _driver.FindElement(_byLogoImg);
            logoImg.Click();
        }

        public void ToSearchByTheSearchBox(string text)
        {
            IWebElement searchBox = _driver.FindElement(_bySearchBar);
            searchBox.SendKeys(text);
            searchBox.Submit();
        }
    }
}
