using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.PageObjects;
using ProjetoFinal.TestContext;
using System;
using TechTalk.SpecFlow;

namespace ProjetoFinal.StepDefinitions
{
    [Binding]
    public class UserPurchaseSteps
    {
        private Context _context;
        private HomePO _homePage;
        private SearchPO _searchPage;
        private CartPO _cartPage;

        public UserPurchaseSteps(Context context)
        {
            _context = context;
            _homePage = new HomePO(_context.Driver);
            _searchPage = new SearchPO(_context.Driver);
            _cartPage = new CartPO(_context.Driver);
        }

        [When(@"I add one item to my cart")]
        public void WhenIAddOneItemToMyCart()
        {
            _searchPage.ToAddOneItemToTheCart();
        }

        [When(@"I go to Checkout page by the popup window")]
        public void WhenIGoToCheckoutPageByThePopupWindow()
        {
            _searchPage.ToClickOnCheckoutBtn();
        }

        [When(@"I click on checkout on the Cart page")]
        public void WhenIClickOnCheckoutOnTheCartPage()
        {
            _cartPage.ToClickOnCheckoutSumaryBtn();
        }

        [When(@"I confirm my address")]
        public void WhenIConfirmMyAddress()
        {
            _cartPage.ToClickOnCheckoutAddressBtn();
        }

        [When(@"I complete the paymente")]
        public void WhenICompleteThePaymente()
        {
            _cartPage.ToMarkCheckbox();
            _cartPage.ToClickOnCheckoutShippingBtn();
        }

        [When(@"I select a payment method")]
        public void WhenISelectAPaymentMethod()
        {
            _cartPage.ToSelectAPaymentMethod();
        }

        [When(@"I confirm my purchase")]
        public void WhenIConfirmMyPurchase()
        {
            _cartPage.ToConfirmOrder();
        }

        [Then(@"I will be able to complete my purchase")]
        public void ThenIWillBeAbleToCompleteMyPurchase()
        {
            //System.Threading.Thread.Sleep(TimeSpan.FromSeconds(10));
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), "Your order on My Store is complete.".ToLower());
        }
    }
}
