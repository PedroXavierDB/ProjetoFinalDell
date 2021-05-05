using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject.PageObjects
{
    public class SelectedItemPO : TemplatePO
    {
        private By byAddBtnXPath;
        private By byCloseAddBarBtn;

        public SelectedItemPO(IWebDriver driver) : base(driver)
        {
            byCloseAddBarBtn = By.Id("bp_off_bottom_panel");
            byAddBtnXPath = By.XPath("/html/body/div[2]/div[4]/div[3]/div/div[2]/div/div[1]/div[1]/div[2]/form/div[8]/div/button");
        }

        public void AddTheItemToTheCart()
        {
            IWebElement addToCartBtn = _driver.FindElement(byAddBtnXPath);
            IWebElement closeAddBarBtn = _driver.FindElement(byCloseAddBarBtn);
            closeAddBarBtn.Click();
            addToCartBtn.Submit();
        }
    }
}
