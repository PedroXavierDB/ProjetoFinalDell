﻿using MODULO2_ExercicioDemoStore.Fixtures;
using MODULO2_ExercicioDemoStore.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MODULO2_ExercicioDemoStore.Testes
{
    [Collection("GoogleChrome")]
    public class SearchResult
    {
        private IWebDriver _driver;

        public SearchResult(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void ShouldAddAnItemToTheCart()
        {
            //Arrange
            HomePagePO homePage = new HomePagePO(_driver);
            SearchResultPO searchResult = new SearchResultPO(_driver);
            homePage.GoTo();
            searchResult.SearchAnItemByTheSearchBox("Batman");

            //Act
            searchResult.AddToCartAnItemByName("product_form_94");

            //Assert
            Assert.Contains("Batman", _driver.PageSource);
        }
    }


}
