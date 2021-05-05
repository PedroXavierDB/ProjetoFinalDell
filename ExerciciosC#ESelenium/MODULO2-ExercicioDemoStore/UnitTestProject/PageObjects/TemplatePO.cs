using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace UnitTestProject.PageObjects
{
    public class TemplatePO
    {
        protected IWebDriver _driver;
        private By bySearchBoxId;
        private By bySearchBtnClassName;
        private By byCartDropBoxBtnId;
        private By byCartDropBoxCheckoutBtnXPath;

        public TemplatePO(IWebDriver driver)
        {
            _driver = driver;
            bySearchBoxId = By.Id("search_input");
            bySearchBtnClassName = By.ClassName("ty-search-magnifier");
            byCartDropBoxBtnId = By.Id("sw_dropdown_8");
            byCartDropBoxCheckoutBtnXPath = By.XPath("/html/body/div[2]/div[4]/div[2]/div/div[1]/div[3]/div/div[2]/div/div/div[2]/div/div[2]/div[2]/a");
        }

        private void WriteInTheSearchBox(string value)
        {
            IWebElement searchBox = _driver.FindElement(bySearchBoxId);
            searchBox.SendKeys(value);
        }

        private void ClickInTheSearchBtn()
        {
            IWebElement searchBtn = _driver.FindElement(bySearchBtnClassName);
            searchBtn.Submit();
        }

        public void SearchAnItemByTheSearchBox(string value)
        {
            WriteInTheSearchBox(value);
            ClickInTheSearchBtn();
        }

        public void GoToCheckoutPage()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IWebElement cartDropBoxBtn = wait
                .Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions
                .ElementToBeClickable(byCartDropBoxBtnId));

            cartDropBoxBtn.Click();

            
            IWebElement cartDropBoxCheckoutBtn = wait
                .Until(SeleniumExtras.WaitHelpers
                .ExpectedConditions
                .ElementExists(byCartDropBoxCheckoutBtnXPath));

            cartDropBoxCheckoutBtn.Click();
        }
    }
}
