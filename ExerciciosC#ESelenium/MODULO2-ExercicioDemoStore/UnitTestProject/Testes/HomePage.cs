using UnitTestProject.Fixtures;
using UnitTestProject.PageObjects;
using OpenQA.Selenium;
using Xunit;

namespace UnitTestProject.Testes
{
    [Collection("GoogleChrome")]
    public class HomePage
    {
        private IWebDriver _driver;

        public HomePage(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void ShouldCheckThatPageIsHomePage()
        {
            var homePage = new HomePagePO(_driver);

            homePage.GoTo();

            Assert.Contains("Mon", _driver.PageSource);
        }

        [Fact]
        public void ShouldSearchByTheSearchBox()
        {
            //Arrange
            var homePage = new HomePagePO(_driver);
            homePage.GoTo();

            //Act
            homePage.SearchAnItemByTheSearchBox("Batman");

            //Assert
            Assert.Contains("Batman", _driver.PageSource);
        }
    }
}
