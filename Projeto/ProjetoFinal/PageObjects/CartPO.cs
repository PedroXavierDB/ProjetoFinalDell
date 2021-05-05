using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.PageObjects
{
    public class CartPO : TemplatePO
    {
        private By _byCheckoutSumaryBtn => By.CssSelector("#center_column > p.cart_navigation.clearfix > a.button.btn.btn-default.standard-checkout.button-medium");
        private By _byCheckoutAddressBtn => By.Name("processAddress");
        private By _byCheckbox => By.Id("uniform-cgv");
        private By _byCheckoutShippingBtn => By.Name("processCarrier");
        private By _byPaymentMethod => By.ClassName("bankwire");
        private By _byConfirmOrderBtn => By.CssSelector("#cart_navigation > button");

        public CartPO(IWebDriver driver) : base(driver)
        {
        }

        public void ToClickOnCheckoutSumaryBtn()
        {
            IWebElement proceedToCheckoutBtn = _driver.FindElement(_byCheckoutSumaryBtn);
            proceedToCheckoutBtn.Click();
        }

        public void ToClickOnCheckoutAddressBtn()
        {
            IWebElement proceedToCheckoutBtn = _driver.FindElement(_byCheckoutAddressBtn);
            proceedToCheckoutBtn.Click();
        }

        public void ToClickOnCheckoutShippingBtn()
        {
            IWebElement proceedToCheckoutBtn = _driver.FindElement(_byCheckoutShippingBtn);
            proceedToCheckoutBtn.Click();
        }

        public void ToMarkCheckbox()
        {
            IWebElement checkbox = _driver.FindElement(_byCheckbox);
            checkbox.Click();
        }

        public void ToSelectAPaymentMethod()
        {
            IWebElement paymentMethod = _driver.FindElement(_byPaymentMethod);
            paymentMethod.Click();
        }

        public void ToConfirmOrder()
        {
            IWebElement confirmOrder = _driver.FindElement(_byConfirmOrderBtn);
            confirmOrder.Click();
        }
    }
}
