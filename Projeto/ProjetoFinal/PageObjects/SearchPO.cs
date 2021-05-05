using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.PageObjects
{
    public class SearchPO : TemplatePO
    {
        private By _byNumberOfResults => By.ClassName("heading-counter");
        private By _byItemAddBtn => By.CssSelector("#center_column > ul > li:nth-child(2) > div > div.right-block > div.button-container > a.button.ajax_add_to_cart_button.btn.btn-default");
        private By _byProceedToCheckoutBtn => By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a");
        
        public SearchPO(IWebDriver driver) : base(driver)
        {
        }

        public int NumberOfSearchResults()
        {
            IWebElement numberOfResults = _driver.FindElement(_byNumberOfResults);
            String number = numberOfResults.Text;
            return int.Parse(number.Substring(0,1));
        }

        public void ToAddOneItemToTheCart()
        {
            IWebElement item = _driver.FindElement(_byItemAddBtn);
            item.Click();
        }

        public void ToClickOnCheckoutBtn()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement checkoutBtn = wait
                .Until(SeleniumExtras
                .WaitHelpers
                .ExpectedConditions
                .ElementExists(_byProceedToCheckoutBtn));
            checkoutBtn.Click();
        }
    }
}
