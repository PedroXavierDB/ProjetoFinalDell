using UnitTestProject.Fixtures;
using UnitTestProject.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace UnitTestProject.Testes
{
    [Collection("GoogleChrome")]
    public class SelectedItem
    {
        private IWebDriver _driver;

        public SelectedItem(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void ShouldAddOneItemToTheCart()
        {
            //Arrange
            HomePagePO homePage = new HomePagePO(_driver);
            SearchResultPO searchResult = new SearchResultPO(_driver);
            SelectedItemPO selectedItem = new SelectedItemPO(_driver);
            homePage.GoTo();
            searchResult.SearchAnItemByTheSearchBox("Batman");
            searchResult.AddToCartAnItemByName("product_form_94");

            //Act
            selectedItem.AddTheItemToTheCart();
            System.Threading.Thread.Sleep(8000);
            selectedItem.GoToCheckoutPage();
     
            //Assert
        }

    }
}
