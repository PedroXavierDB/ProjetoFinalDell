using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoFinal.PageObjects;
using ProjetoFinal.TestContext;
using System;
using TechTalk.SpecFlow;

namespace ProjetoFinal.StepDefinitions
{
    [Binding]
    public class StoreSearchBarSteps
    {
        private Context _context;
        private HomePO _homePage;
        private SearchPO _searchPage;

        public StoreSearchBarSteps(Context context)
        {
            _context = context;
            _homePage = new HomePO(_context.Driver);
            _searchPage = new SearchPO(_context.Driver);
        }

        [Given(@"That I am a client on the Home page")]
        public void GivenThatIAmAClientOnTheHomePage()
        {
            _homePage.ToGoToHomePageByUrl();
        }
        
        [When(@"I search by ""(.*)"" in the store")]
        public void WhenISearchByInTheStore(string p0)
        {
            _homePage.ToSearchByTheSearchBox(p0);
        }
        
        [Then(@"I will be redirected to the Search page")]
        public void ThenIWillBeRedirectedToTheSearchPage()
        {
            StringAssert.Contains(_context.Driver.Url.ToLower(), "controller=search".ToLower());
        }
        
        [Then(@"A list of products should be displayed on the Search page")]
        public void ThenAListOfProductsShouldBeDisplayedOnTheSearchPage()
        {
            int numberOfProducts = _searchPage.NumberOfSearchResults();
            Assert.IsTrue( numberOfProducts > 0, "There are no products on page.");
        }
        
        [Then(@"The message ""(.*)"" should be displayed on the Search page")]
        public void ThenTheMessageShouldBeDisplayedOnTheSearchPage(string p0)
        {
            StringAssert.Contains(_context.Driver.PageSource.ToLower(), p0.ToLower());
        }
    }
}
