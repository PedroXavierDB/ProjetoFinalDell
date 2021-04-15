using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.PageObjects;
using ProjetoFinal.TestContext;
using System;
using TechTalk.SpecFlow;

namespace ProjetoFinal.StepDefinitions
{
    [Binding]
    public class StoreFiltersAndLayoutSteps
    {
        private Context _context;
        private HomePO _homePage;
        private CategorySearchPO _categorySearchPage;

        public StoreFiltersAndLayoutSteps(Context context)
        {
            _context = context;
            _homePage = new HomePO(_context.Driver);
            _categorySearchPage = new CategorySearchPO(_context.Driver);
        }

        [Given(@"That I am a client on the Women Category Search page")]
        public void GivenThatIAmAClientOnTheWomenCategorySearchPage()
        {
            _homePage.ToGoToHomePageByUrl();
            _homePage.ToGoToWomemCategoryPage();
        }
        
        [When(@"I select the category Women")]
        public void WhenISelectTheCategoryWomen()
        {
            _homePage.ToGoToWomemCategoryPage();
        }
        
        [When(@"I select the category Dresses")]
        public void WhenISelectTheCategoryDresses()
        {
            _categorySearchPage.ToClickDressesCategory();
        }
        
        [When(@"I select the size M")]
        public void WhenISelectTheSizeM()
        {
            _categorySearchPage.ToClickSizeM();
        }
        
        [When(@"I select the color White")]
        public void WhenISelectTheColorWhite()
        {
            _categorySearchPage.ToClickColorWhite();
        }
        
        [When(@"I select the composition Polyester")]
        public void WhenISelectTheCompositionPolyester()
        {
            _categorySearchPage.ToClickCompositionPolyester();
        }
        
        [When(@"I select the style Casual")]
        public void WhenISelectTheStyleCasual()
        {
            _categorySearchPage.ToClickStyleCasual();
        }
        
        [When(@"I select the propertie Colorful Dress")]
        public void WhenISelectThePropertieColorfulDress()
        {
            _categorySearchPage.ToClickPropertieColorful();
        }
        
        [When(@"I select the availability In stock")]
        public void WhenISelectTheAvailabilityInStock()
        {
            _categorySearchPage.ToClickAvailabilityInStock();
        }
        
        [When(@"I select the manufacturer Fashion Manufacturer")]
        public void WhenISelectTheManufacturerFashionManufacturer()
        {
            _categorySearchPage.ToClickManufacturerFashion();
        }
        
        [When(@"I select the condition New")]
        public void WhenISelectTheConditionNew()
        {
            _categorySearchPage.ToClickConditionNew();
        }
        
        [Then(@"I will be redirected to the Womem Category Search page")]
        public void ThenIWillBeRedirectedToTheWomemCategorySearchPage()
        {
            StringAssert.Contains(_context.Driver.Url.ToLower(), "id_category=3");
        }
        
        [Then(@"The message ""(.*)"" should be displayed on the Category Search page")]
        public void ThenTheMessageShouldBeDisplayedOnTheCategorySearchPage(string p0)
        {
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), p0.ToLower());
        }
    }
}
