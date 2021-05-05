using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MODULO2_ExercicioDemoStore.PageObjects
{
    public class TemplatePO
    {
        protected IWebDriver _driver;
        private By bySearchBoxId;
        private By bySearchBtnCssSelector;
        private By byCartDropBoxBtnId;
        private By byCartDropBoxCheckoutBtnXPath;

        public TemplatePO(IWebDriver driver)
        {
            _driver = driver;
            bySearchBoxId = By.Id("search_input");
            //bySearchBtnClassName = By.ClassName("ty-search-magnifier");
            bySearchBtnCssSelector = By.CssSelector("form.cm-processed-form > button");
            byCartDropBoxBtnId = By.Id("sw_dropdown_8");
            byCartDropBoxCheckoutBtnXPath = By.CssSelector("div.cm-cart-buttons.ty-cart-content__buttons.buttons-container.full-cart > div.ty-float-right > a");
        }

        private void WriteInTheSearchBox(string value)
        {
            IWebElement searchBox = _driver.FindElement(bySearchBoxId);
            searchBox.SendKeys(value);
        }

        private void ClickInTheSearchBtn()
        {
            IWebElement searchBtn = _driver.FindElement(bySearchBtnCssSelector);
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
